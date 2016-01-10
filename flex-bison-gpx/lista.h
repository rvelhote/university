#include <stdio.h>
#include <stdlib.h>
#include <math.h>

/*
 *	Estrutura que guarda o atributo time
 */
typedef struct {
	int hora;
	int minuto;
	int segundo;
} TEMPO;

/*
 *	Elemento da lista ligada que vai armazenar os pontos
 */
struct el_lista {
	double latitude;
	double longitude;	
	double ele;
	TEMPO t;
	
	struct el_lista *seg;
};

typedef struct el_lista PONTO;

short INFO_PONTO;
short INFO_DOIS_PONTOS;
short CALCULAR;
short SUPRIMIR_ERROS;
