package tetris;

import java.io.IOException;
import javax.microedition.lcdui.Canvas;
import javax.microedition.lcdui.Font;
import javax.microedition.lcdui.Graphics;
import javax.microedition.lcdui.Image;

public class Menu extends Canvas {
    //  referencias ao GameCanvas onde vai correr o jogo e à midlet para o caso
    //  de ser necessário retornar ou ir para alguma das duas
    private TetrisCanvasN jogo = null;
    private TetrisMidlet midlet = null;
    
    //  as strings das opcoes que vão aparecer no menu principal
    private String[] opcoesMenu = { "Jogar", "Ajuda" ,"Acerca", "Sair" };
    
    //  a opção actual do menu que está actualmente seleccionada
    //  0 - jogar
    //  1- ajuda etc...
    private int opcaoActual = 0;
    
    //  o ecra actual
    //  0 - splash
    //  1 - ecra de ajuda etc...
    private int ecraActual = 0;    
    
    //  a imagem do splash e também do fundo dos menus
    private Image splash = null;
    
    public Menu(TetrisMidlet m) {
        //  guardar a referencia à midlet
        midlet = m;
        
        //  carregar a imagem
        try {
            splash = Image.createImage("/tetris/imagens/background_splash_menu.png");
        } catch(IOException e) {
            return;
        }
    }
    
    //  o método paint é o método que desenha as coisas no ecrã
    public void paint(Graphics g) {        
        //  limpar o ecra para actualizar as coisas
        g.setColor(230, 211, 187);
        g.fillRect(0, 0, getWidth(), getHeight());
        
        //  mostrar o ecrã com base na variável
        if (ecraActual == 0) {
            mostrarSplash(g);
        } else if (ecraActual == 1) {
            mostrarAjuda(g);
        } else if (ecraActual == 2) {
            mostrarAcerca(g);
        } else if (ecraActual == 4){
            mostrarMenuPrincipal(g);
        }
    }
    
    private void mostrarSplash(Graphics g) {
        g.drawImage(splash, 0, 0, 0);
        g.setColor(0, 0, 0);
        g.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_MEDIUM));
        g.drawString("Carrega num botão para continuar", 25, 200, 0);
    }
    
    //  substituir o xxxxxxxxxx por qualquer coisa
    private void mostrarAcerca(Graphics g) {
        g.drawImage(splash, 0, 0, 0);
        g.setColor(0, 0, 0);
        g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_BOLD, Font.SIZE_MEDIUM));
        g.drawString("xxxxxxxxxxxxxx", 5, 160, 0);
        g.drawString("xxxxxxxxxxxxxxx", 5, 180, 0);
        g.drawString("xxxxxxxxxxxxxxxx", 5, 200, 0);
        g.drawString("xxxxxxxxxxxxxxxxxxxxxxxx", 5, 240, 0);
    }
    
    //  substituir o xxxxxxxxxx por qualquer coisa
    private void mostrarAjuda(Graphics g) {
        g.drawImage(splash, 0, 0, 0);
        g.setColor(0, 0, 0);
        g.setFont(Font.getFont(Font.FACE_PROPORTIONAL, Font.STYLE_BOLD, Font.SIZE_MEDIUM));
        g.drawString("xxxxxxxxxxxxxxxx", 1, 130, 0);
        g.drawString("xxxxxxxxxxxxxxxxx", 1, 140, 0);
        g.drawString("xxxxxxxxxxxxxxxx", 1, 160, 0);
        g.drawString("xxxxxxxxxxxx", 1, 170, 0);
        g.drawString("xxxxxxxxxxxxxxxx", 1, 180, 0);
        g.drawString("xxxxxxxxxxxxxxxxxxe", 1, 200, 0);
        g.drawString("xxxxxxxxxxxxxxxxxx", 1, 210, 0);
        g.drawString("xxxxxxxxxxxxxxxxxxx", 1, 220, 0);
        g.drawString("xxxxxxxxxxxxxxxxxxxxxx", 1, 240, 0);
        g.drawString("xxxxxxxxxxxxxxxxxxxxxxxxxx", 1, 250, 0);
        g.drawString("xxxxxxxxxxxxxxxxxxxxx ", 1, 260, 0);
        g.drawString("xxxxxxxxxxxxxxxxxxxx", 1, 270, 0);
    }
    
    //  desenhar o menu principal
    private void mostrarMenuPrincipal(Graphics g) {
        g.drawImage(splash, 0, 0, 0);
        
        //  ciclar por todas as opções possiveis (jogar, ajuda, etc..)
        for(int i = 0; i < opcoesMenu.length; i++) {
            
            //  iluminar a opção que está actualmente seleccionada
            if (i == opcaoActual) {
                g.setColor(0, 0, 0);
                g.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_LARGE));
                g.drawString(opcoesMenu[i], 100, 140 + (i * 25), 0);
                
                //  mostrar as outras
            } else {
                g.setFont(Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_MEDIUM));
                g.setColor(120, 120, 120);
                g.drawString(opcoesMenu[i], 100, 140 + (i * 25), 0);
            }
        }
    }
    
    //  verificar qual foi a tecla pressionada pelo utilizador
    protected void keyPressed(int k) {
        
        //  se foi a seta para cima
        if (getGameAction(k) == Canvas.UP) {
            
            //  se estivermos no menu inicial e se estiver a primeira opção seleccionada
            //  passar para o fim do menu
            if (ecraActual == 4 && --opcaoActual < 0) {
                opcaoActual = (opcoesMenu.length - 1);
            }
            
            //  pintar tudo
            repaint();
            
            
            //  se foi a seta para cima
        } else if (getGameAction(k) == Canvas.DOWN) {
            
            //  se estivermos no menu inicial e se estiver a ultima opção seleccionada
            //  passar para o inicio do menu
            if (ecraActual == 4 && ++opcaoActual == opcoesMenu.length) {
                opcaoActual = 0;                
            }
            
            //  pintar tudo
            repaint();
            
            //  se carregamos no ENTER (a tecla ENTAR corresponde ao FIRE)
        } else if (getGameAction(k) == Canvas.FIRE) {
            
            //  se estivermos no ecra de splash, ajuda ou acerca e carregarmos no enter
            //  passar para o menu principal (que tem o nº 4)
            if(ecraActual == 0 || ecraActual == 1 || ecraActual == 2) {
                ecraActual = 4;
                repaint();
                
                //  se carregamos no ENTER e a opção seleccionada é a 1ª (equivalente a 0)
                //  iniciar o jogo
            } else if (opcaoActual == 0) {
                jogo = new TetrisCanvasN(midlet);                
                midlet.display.setCurrent(jogo); 
                
                //  se carregamos no ENTER e a opção seleccionada é a 2ª (equivalente a 1)
                //  mostrar o ecrã ajuda
            } else if (opcaoActual == 1) {
                ecraActual = opcaoActual;
                repaint();
                
                //  se carregamos no ENTER e a opção seleccionada é a 3ª (equivalente a 2)
                //  mostrar o ecrã acerca
            } else if (opcaoActual == 2) {
                ecraActual = opcaoActual;
                repaint();
                
                //  se carregamos no ENTER e a opção seleccionada é a 4ª (equivalente a 3)
                //  sair do jogo
            } else if (opcaoActual == 3) {
                midlet.notifyDestroyed();                
            }
        }
    }
}