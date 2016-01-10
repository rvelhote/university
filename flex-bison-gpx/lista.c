#include "lista.h"

/*
 *
 *
 */
PONTO *inicio = NULL;
PONTO *fim = NULL;
int parcial;

/*
 *	Estrutura que guarda os valores acumulados
 */
struct a {
	double altitudePositiva;
	double altitudeNegativa;
	double distancia;
	int duracao;
	double velocidadeMedia;
	double velocidadeMaxima;
}; 
struct a acumulado;

/*
 *	Converte a estrutura TEMPO do formato h:m:s para segundos
 *
 *	t -> a estrutura que contém os valores a converter	
 *
 */
int segundos(TEMPO t) {
	return (t.hora * 3600) + (t.minuto * 60) + t.segundo;
}

/*
 *	Converte segundos no formato h:m:s para poder ser
 *	armazenado na estrtura TEMPO
 *
 *	segundos -> o valor a converter
 *
 *	retorna uma estrutura TEMPO com os valores convertidos
 *
 */
TEMPO horas(int segundos) {
	TEMPO t;
	
	t.hora = segundos / 3600;
	t.minuto = (segundos / 60) % 60;
	t.segundo = segundos % 60;
	
	return t;
}

/*
 *	Acumula os valores do parcial na estrutura correspondente
 *
 *	dist -> a distância
 *	t -> tempo
 *	ele -> elevação
 *	vmed -> velocidade média
 *
 */
void acumular(double dist, double t, double ele, double vmed) {	
	if(ele > 0) {
		acumulado.altitudePositiva += ele;
	} else {
		acumulado.altitudeNegativa += ele;
	}

	acumulado.distancia += dist;
	acumulado.duracao += t;
	acumulado.velocidadeMedia += vmed;
	acumulado.velocidadeMaxima = (vmed > acumulado.velocidadeMaxima) ? vmed : acumulado.velocidadeMaxima;	
}

/*
 *	Imprime os valores acumulados na estrutura depois de terem sido
 *	efectuados os todos os cálculos referentes aos parciais
 *
 */
void imprimirAcumulado() {
	printf("\n\n\n\n\t[Resultados Acumulados]\n\t~~~~~~~~~~~~~~~~~~~~~~~\n\n");
	printf("\tAltitude Acumulada Positiva: %.5fm\n", acumulado.altitudePositiva);
	printf("\tAltitude Acumulada Negativa: %.5fm\n", acumulado.altitudeNegativa * -1);
	printf("\tDistancia: %.1fm\n", acumulado.distancia);
	
	TEMPO t = horas(acumulado.duracao);
	printf("\tDuracao: %dh %dm %ds\n", t.hora, t.minuto, t.segundo);
	printf("\tVelocidade Media: %.3fkm/h\n", acumulado.velocidadeMedia / parcial);
	printf("\tVelocidade Maxima: %.3fkm/h\n", acumulado.velocidadeMaxima);
}

/*
 *	Mostra os dados dos dois pontos com os quais está a ser
 *	efectuado o cálculo dos parciais
 *
 */
void infoPontos(PONTO *ponto1, PONTO *ponto2) {
	printf("\n\n\n\n\n\t******* DADOS DOS PONTOS *******\n\n");
	printf("\tP1 >> lat: %f | lon: %f | ele: %f | t: %dh %dm %ds", ponto1->latitude, ponto1->longitude, ponto1->ele, ponto1->t.hora, ponto1->t.minuto, ponto1->t.segundo);
	printf("\n\tP2 >> lat: %f | lon: %f | ele: %f | t: %dh %dm %ds", ponto2->latitude, ponto2->longitude, ponto2->ele, ponto2->t.hora, ponto2->t.minuto, ponto2->t.segundo);
	printf("\n\n\tda:\n");	
}

/*
 *	Mostra os dados de todos os pontos
 *
 *
 */
void infoPonto() {
	PONTO *p = inicio;
	int i = 1;
	
	while(p != NULL) {
		printf("\n\n\t\tPonto %d\n\t\t|\n", i);
		printf("\t\t|\tLatitude: %f\n\t\t|\tLongitude: %f\n\t\t|\tElevacao: %.3fm\n\t\t|\tHora: %dh %dm %ds\n", p->latitude, p->longitude, p->ele, p->t.hora, p->t.minuto, p->t.segundo);	
		p = p->seg;
		i++;
	}

	//printf("\n\n\t[ DADO DOS PONTO ]\n\t|\n");
	
}

/*
 *	Calcula os parciais entre dois pontos
 *
 */
void calcularParcial(PONTO *ponto1, PONTO *ponto2) {
	double alpha = cos(ponto1->latitude) * cos(ponto2->latitude) * cos(ponto2->longitude - ponto1->longitude) + sin(ponto1->latitude) * sin(ponto2->latitude);			
	double dist = acos(alpha) * 6371;			
	double deltaEle = (ponto2->ele - ponto1->ele);
	int deltaT = segundos(ponto2->t) - segundos(ponto1->t);	
	double vmed = dist * 360;
	
	char sinal = (deltaEle > 0) ? '+' : ' ';
	char zero = (deltaT < 10) ? '0' : ' ';
		
	acumular((dist * 1000), deltaT, deltaEle, vmed);
	
	if(INFO_DOIS_PONTOS == 1) {
		infoPontos(ponto1, ponto2);
	}
	
	printf("\n\tParcial %d:\t%.2fm\t\t dt: %c%ds\t dele: %c%.5fm\t Vmed: %.3fkm/h", parcial, (dist * 1000), zero, deltaT, sinal, deltaEle, vmed);
}

/*
 *	Percorre a lista ligada a partir do início e envia
 *	os pontos escolhidos para a função 'calcularParcial'
 *
 */
void calcular() {
	PONTO *ponto1 = inicio;
	PONTO *ponto2 = inicio->seg;
	
	parcial = 0;
	acumulado.velocidadeMaxima = 0.0;

	printf("\t* num *\t\t* Distancia *\t* Tempo *\t* Elevacao *\t\t* vMedia *\n");

	while(ponto2 != NULL) {
		parcial++;
		calcularParcial(ponto1, ponto2);
	
		ponto1 = ponto2;
		ponto2 = ponto2->seg;				
	}
	
	imprimirAcumulado();
}

/*
 *	Adiciona um novo elemento à lista
 *
 *	buffer -> estrutura que contém os dados que farão
 *			parte do novo elemento
 *
 */
void adicionar(PONTO *buffer) {
	PONTO *novo = NULL;
	
	novo = (PONTO *)malloc(sizeof(PONTO));	
		
	novo->latitude = buffer->latitude;
	novo->longitude = buffer->longitude;
	novo->ele = buffer->ele;
	
	novo->t.hora = buffer->t.hora;
	novo->t.minuto = buffer->t.minuto;
	novo->t.segundo = buffer->t.segundo;
	
	novo->seg = NULL;
	
	if(inicio == NULL) {
		inicio = novo;
		fim = novo;
	} else {	
		fim->seg = novo;
		fim = novo;
	}
}

/*
 *	Liberta a memória utilizada pela lista ligada
 *
 */
void libertar() {
	PONTO *tmp;

	while(inicio != NULL) {
		tmp = inicio;
		inicio = inicio->seg;			
		free(tmp);			
	}

	fim = NULL;
	inicio = NULL;
}
