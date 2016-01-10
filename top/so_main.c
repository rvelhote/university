/*//////////////////////////////////////////
   Gest�o de Mem�ria >> Alpha 0.7
*///////////////////////////////////////////




#include <ncurses.h>
#include <stdlib.h>


#define RAM 128



/*/////////////////////
   Prot�tipos
*//////////////////////

int ReservarMemoria(int iTamanho);
void LibertarMemoria(int ID);
//void CompactarMemoria();



int nMemoriaOcupada = 0; // total de mem�ria ocupada
int nProcesso = 0; // Numero de Processos existentes


//
// Tabela de aloca��o de mem�ria
//
typedef struct tabela_memoria
{
   int ID, base, tamanho_alocado;
   struct tabela_memoria *pSeguinte;
}MEMORIA;

MEMORIA *pApontador; // pApontador vai apontar sempre para o primeiro elemento da lista





/*///////////////////////////////////////////

   Libertar mem�ria

   Retorna >> Void

*////////////////////////////////////////////

void LibertarMemoria(int ID)
{

   MEMORIA *pAux1, *pAux2;

   pAux1 = pApontador;
   

   while(pAux1 != NULL)
   {
      
      if (pAux1->ID == ID)
      {
         if (pAux1 == pApontador)
         {
            if (pApontador->pSeguinte != NULL)
            {
               pApontador = pApontador->pSeguinte;
            }
            else
            {
               pApontador = NULL;
            }
         }
         else
         {
            if (pAux1->pSeguinte == NULL)
            {
               pAux2->pSeguinte = NULL;            
            }
            else
            {
               pAux2->pSeguinte = pAux1->pSeguinte; 
            }
         }
 
         nMemoriaOcupada-=pAux1->tamanho_alocado;

         free(pAux1);

         
          
         return;
      }

      pAux2 = pAux1;      

      pAux1 = pAux1->pSeguinte;

   }

   attron(A_UNDERLINE); attron(A_BOLD); mvprintw(5, 35, "N�o existe nenhum processo com a ID %d", ID); 
   attron(A_BOLD); attroff(A_UNDERLINE);   
   refresh();
   getch();

}




/*///////////////////////////////////////////

   Reservar Mem�ria

   Retorna >> ID do processo

*////////////////////////////////////////////

int ReservarMemoria(int iTamanho)
{
   MEMORIA *pAux1, *pAux2, *pAux3; // pAux1 vai apontar para o elemento actual e pAux2 vai apontar para o anterior
                                   // para permitir verificar se existe algum bloco de memoria livre.
                                   // pAux3 vai ser utilizado para criar um novo elemento na lista

   int iAux_calc_ant = 0, iAux_calc_actual = 0;

 
   if (iTamanho + nMemoriaOcupada > RAM)
   {
      attron(A_UNDERLINE); attron(A_BOLD); mvprintw(4, 35, "N�o existe Mem�ria suficiente para correr esse processo!");  
      attron(A_BOLD); attroff(A_UNDERLINE); 
      refresh();
      getch();
      return;
   }


   pAux1 = pApontador;
   

   // a memoria est� vazia. alocar primeiro elemento
   if ( pAux1 == NULL )
   {
      pAux1 = malloc(sizeof(MEMORIA));
   
      pAux1->ID = nProcesso;
      pAux1->base = 1;
      pAux1->tamanho_alocado = iTamanho;
      pAux1->pSeguinte = NULL;

      pApontador = pAux1;

      nProcesso++;

      nMemoriaOcupada+=iTamanho; 

      return nProcesso;
   }


   // percorrer a lista em busca de um bloco vazio
   while( pAux1 != NULL )
   {
      
      // verificar se existe hipotese de colocar no inicio
      if (pAux1->base > 1 && abs(pAux1->base - iTamanho) > 0 && pAux1 == pApontador)
      {           
         pAux3 = malloc(sizeof(MEMORIA));
         
         pAux3->ID = nProcesso;
         pAux3->base = 1;
         pAux3->tamanho_alocado = iTamanho;
         pAux3->pSeguinte = pAux1;
         pApontador = pAux3;

         nProcesso++;
      
         nMemoriaOcupada+=iTamanho;
     
         return nProcesso;

      }
      

      iAux_calc_ant = pAux1->base + (pAux1->tamanho_alocado -1); // calcula as posicoes de memoria ocupadas

      // no fim
      if (pAux1->pSeguinte == NULL)
      {
         pAux3 = malloc(sizeof(MEMORIA));
         
         pAux3->ID = nProcesso;
         pAux3->base = iAux_calc_ant + 1;
         pAux3->tamanho_alocado = iTamanho;
         pAux3->pSeguinte = NULL;

         pAux1->pSeguinte = pAux3;
         
         nProcesso++;
         
         nMemoriaOcupada+=iTamanho;

         return nProcesso;
      }        

      // l� para o meio     
      else
      {
         pAux2 = pAux1;
         pAux1 = pAux1->pSeguinte;
         iAux_calc_actual = abs(pAux1->base - iAux_calc_ant);

         if ( iAux_calc_actual >= iTamanho )
         {
            pAux3 = malloc(sizeof(MEMORIA));

            pAux3->ID = nProcesso;
            pAux3->base = iAux_calc_ant + 1;
            pAux3->tamanho_alocado = iTamanho;
            pAux3->pSeguinte = pAux1;
            pAux2->pSeguinte = pAux3;           

            nProcesso++;

            nMemoriaOcupada+=iTamanho;
        
            return nProcesso;
         }

      }

   }

}






main()
{
   int ID, x=0, k;   
   MEMORIA *pPercorrer;

   initscr();
   noecho();

   

   pApontador = NULL;

   do
   {
      pPercorrer = pApontador;
      erase();      

      attron(A_BOLD);  printw("RAM Livre");  attroff(A_BOLD);  printw(" >> %dMB\n", RAM - nMemoriaOcupada);      

      attron(A_UNDERLINE); attron(A_BOLD);  printw("\nOp��es\n\n");  attroff(A_BOLD); attroff(A_UNDERLINE);
      attron(A_BOLD);  printw("[L]");  attroff(A_BOLD);  printw(" >>> Lan�ar novo processo\n");
      attron(A_BOLD);  printw("[T]");  attroff(A_BOLD);  printw(" >>> Terminar Processo\n");
      attron(A_BOLD);  printw("[F]");  attroff(A_BOLD);  printw(" >>> Sair\n\n");

      refresh();

      
         
         
      attron(A_UNDERLINE); attron(A_BOLD);  printw("\n\n\nProcess Control Block\n\n");  
      attroff(A_BOLD); attroff(A_UNDERLINE);

      if (pPercorrer == NULL)
      {
         printw("N�o existem processos a correr!");
      }

      while(pPercorrer != NULL)
      {         
         printw("Endere�o >> %d    Memoria Alocada >> %dMB    ID >> %d \n", pPercorrer->base, pPercorrer->tamanho_alocado, pPercorrer->ID);
         pPercorrer = pPercorrer->pSeguinte;
      }

      refresh();    

      
      mvprintw(43, 0, " ");
      k = getch();

      if(k == 108) // l
      {            
         ReservarMemoria(random() % 49);         
      }

      if (k==102) // f
      {
         break;
      }

      if (k == 116) // t
      {
         echo();
         attron(A_BOLD); mvprintw(5, 35, "ID >> ");  attroff(A_BOLD);
         refresh();
         scanw("%d",&ID);

         LibertarMemoria(ID);
         noecho();
      }
     
      x++;

   }while(1);

   endwin();
   return 0;
}




