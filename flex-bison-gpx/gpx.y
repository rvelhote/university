%{
#include "lista.h"
#include "token_struct.h"

#define YYERROR_VERBOSE 1

/*
 *	Protótipos
 */
void erro(char *msg);
double rad(double graus);
double graus(double radianos);
void temPontos();
void converterData(char *data);
void resetWpt();
void resetRte();
void resetLink();
void resetTrk();
void resetCopyright();
void resetPersonType();
void resetMetadata();
int comparaTags(char *abre, char *fecha);
void validarPosicao(double lat, double lon, short salvar);
void validarBounds(double lat, double lon);

/*
 *	Variavel que indica se estamos dentro da tag metadata ou nao
 */
short mostraAtributo = 0;

/*
 *	Variáveis
 *
 */
extern int numLinha;
int numErros = 0;


/*
 *	Estrutura que controla o numero de Waypoints, Routes e Tracks
 *
 */
QUANTIDADE_PONTOS pontos;

/*
 *	Estrutura que indica se os pontos necessários para fazer os cálculos
 *	estão presentes 
 *
 */
OK_PONTOS ok;

/*
 *	Guarda temporariamente os valores de lat, lon, ele e hora
 *	de cada ponto
 *
 */
PONTO *buffer;

/*
 *	Guarda os valores dos atributos da tag Bounds
 *
 */
BOUNDS bounds;

/*
 *	Controla o número de tags existentes de cada elemento
 *	Há algumas tags que só podem aparecer uma vez.
 */
CONTROLO_ELEMENTOS controlo;

%}

%union {
	char *paramStr;
	int paramInt;
	double paramFloat;
}

/*****************************
 *		TOKENS DE ATRIBUTOS
 *
 *
 *
 *****************************
 */
%token		VERSION					CREATOR					HREF;
%token		LAT						LON						<paramStr>URL;
%token		<paramInt>INTEGER		<paramFloat>DECIMAL		<paramStr>STRING;
%token		ID_EMAIL				DOMAIN_EMAIL			<paramStr>DATA_HORA;

/*****************************
 *		TOKENS DE TAGS
 *
 *
 *
 *****************************
 */
%token		AUTHOR_ABRE_TAG			AUTHOR_FECHA_TAG			EMAIL_ABRE_TAG;

%token		NAME_ABRE_TAG			NAME_FECHA_TAG				LINK_ABRE_TAG				LINK_FECHA_TAG;

%token		DESC_ABRE_TAG			DESC_FECHA_TAG				TEXT_ABRE_TAG				TEXT_FECHA_TAG;

%token		COPYRIGHT_ABRE_TAG		COPYRIGHT_FECHA_TAG			TIME_ABRE_TAG				TIME_FECHA_TAG;

%token		KEYWORDS_ABRE_TAG 		KEYWORDS_FECHA_TAG			EXTENSIONS_ABRE_TAG			EXTENSIONS_FECHA_TAG;

%token		BOUNDS_ABRE_TAG			YEAR_ABRE_TAG				YEAR_FECHA_TAG;

%token		LICENSE_ABRE_TAG		LICENSE_FECHA_TAG			TYPE_ABRE_TAG				TYPE_FECHA_TAG;

%token		METADATA_ABRE_TAG		METADATA_FECHA_TAG			WPT_ABRE_TAG				WPT_FECHA_TAG;

%token		RTE_ABRE_TAG			RTE_FECHA_TAG				TRK_ABRE_TAG				TRK_FECHA_TAG;

%token		ABRE_TAG_GPX			FECHA_TAG_GPX				ELE_ABRE_TAG				ELE_FECHA_TAG;

%token		MAGVAR_ABRE_TAG			MAGVAR_FECHA_TAG			GEOIDHEIGHT_ABRE_TAG		GEOIDHEIGHT_FECHA_TAG;

%token		CMT_ABRE_TAG			CMT_FECHA_TAG				SRC_ABRE_TAG				SRC_FECHA_TAG;

%token		SYM_ABRE_TAG			SYM_FECHA_TAG				TYPE_ABRE_TAG				TYPE_FECHA_TAG;
			
%token 		FIX_ABRE_TAG			FIX_FECHA_TAG				SAT_ABRE_TAG				SAT_FECHA_TAG;
			
%token		HDOP_ABRE_TAG			HDOP_FECHA_TAG				VDOP_ABRE_TAG				VDOP_FECHA_TAG;
			
%token		PDOP_ABRE_TAG			PDOP_FECHA_TAG				AGEOFDGPSDATA_ABRE_TAG		AGEOFDGPSDATA_FECHA_TAG;
			
%token		DGPSID_ABRE_TAG			DGPSID_FECHA_TAG			RTEPT_ABRE_TAG				RTEPT_FECHA_TAG;

%token		NUMBER_ABRE_TAG			NUMBER_FECHA_TAG			TRKSEG_ABRE_TAG				TRKSEG_FECHA_TAG;

%token		TRKPT_ABRE_TAG			TRKPT_FECHA_TAG				COPYRIGHT_AUTHOR;

%token		MIN_LAT					MIN_LON						MAX_LAT						MAX_LON;

%start gpx;
%%

/*****************************
 *		1 - GPX
 *
 *		<gpx version="DECIMAL" creator="STRING"> gpxType </gpx> [1]
 *
 *****************************
 */
gpx:	/* vazio */

		| gpx ABRE_TAG_GPX {
			if(++controlo.el_gpx.gpx > 1) {
				erro("Só pode existir uma definição da tag GPX");
			}
			
			printf("\n\t[ Dados do Ficheiro GPX ]\n\t|");
			
		} atributosGPX { printf("\n\n\n"); } '>' gpxType FECHA_TAG_GPX	
		;

		/*****************************
		 *		1.1 - GPX TYPE
		 *
		 *		metadata | wpt | rte |trk | extensions
		 *
		 *****************************
		 */
		gpxType:	gpxType gpxTypeTag | gpxTypeTag;
		gpxTypeTag:	
			tagMetadata {
				if(++controlo.el_gpx.metadata > 1) {
					erro("Só pode existir uma definição da tag METADATA dentro da tag GPX");
				}				
			}
			
			|
			tagWpt
			
			|
			tagRte
			
			|
		
			tagTrk
			
			|
		
			tagExtensions {
				if(++controlo.el_gpx.extensions > 1) {
					erro("Só pode existir uma definição da tag EXTENSIONS dentro da tag GPX");
				}
			}
			;										
	
		/**************************************************************************************************
		 *		1.2 - METADATA TYPE
		 *
		 *		name | desc | author | copyright | link | time | keywords | bounds | extensions
		 *
		 **************************************************************************************************
		 */	
		metadataType: metadataType metadataTypeTag | metadataTypeTag;
		metadataTypeTag:
			
			{if(mostraAtributo == 1) printf("\n\t|\tNome:"); }
			tagName {	
				if(++controlo.el_metadata_type.name > 1) {
					erro("Só pode existir uma definição da tag NAME dentro de uma tag METADATA");
				}
			}
			|

			{if(mostraAtributo == 1) printf("\n\t|\tDescricao:"); }
			tagDesc {
				if(++controlo.el_metadata_type.desc > 1) {
					erro("Só pode existir uma definição da tag DESC dentro de uma tag METADATA");
				}
			}
			|	
			tagAuthor {
				if(++controlo.el_metadata_type.author > 1) {
					erro("Só pode existir uma definição da tag AUTHOR dentro de uma tag METADATA");
				}
			}
			|
			tagCopyright {
				if(++controlo.el_metadata_type.copyright > 1) {
					erro("Só pode existir uma definição da tag COPYRIGHT dentro de uma tag METADATA");
				}
			}
			|
			
			{if(mostraAtributo == 1) printf("\n\t|\tLink: "); }
			tagLink
			|

			{if(mostraAtributo == 1) printf("\n\t|\tData/Hora: "); }	
			tagTime {
				if(++controlo.el_metadata_type.time > 1) {
					erro("Só pode existir uma definição da tag TIME dentro de uma tag METADATA");
				}
			}
			|	
			
			{if(mostraAtributo == 1) printf("\n\t|\tKeywords: "); }
			tagKeywords {
				if(++controlo.el_metadata_type.keywords > 1) {
					erro("Só pode existir uma definição da tag KEYWORDS dentro de uma tag METADATA");
				}
			}
			|

			{if(mostraAtributo == 1) printf("\n\t|\tBounds: "); }	
			tagBounds {
				if(++controlo.el_metadata_type.bounds > 1) {
					erro("Só pode existir uma definição da tag BOUNDS dentro de uma tag METADATA");
				}
			}
			|
			tagExtensions {
				if(++controlo.el_metadata_type.extensions > 1) {
					erro("Só pode existir uma definição da tag EXTENSIONS dentro de uma tag METADATA");
				}
			}
			;

		/*****************************************************************************************************************************************************************
		 *		1.3 - WPT TYPE
		 *
		 *		ele | time | magvar | geoidheight | name | cmt | desc | src | link | sym | type | fix | sat | hdop | vdop | ageofdgpsdata | dgpsid | extensions
		 *
		 *****************************************************************************************************************************************************************
		 */
		wptType: wptType wptTypeTag | wptTypeTag;
		wptTypeTag:
					tagEle {
						if(++controlo.el_wpt_type.ele > 1) {
							erro("Só pode existir uma tag ELE dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagTime {
						if(++controlo.el_wpt_type.time > 1) {
							erro("Só pode existir uma tag TIME dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagMagvar {
						if(++controlo.el_wpt_type.magvar > 1) {
							erro("Só pode existir uma tag MAGVAR dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagGeoidheight {
						if(++controlo.el_wpt_type.geoidheight > 1) {
							erro("Só pode existir uma tag GEOIDHEIGHT dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagName {
						if(++controlo.el_wpt_type.name > 1) {
							erro("Só pode existir uma tag NAME dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagCmt {
						if(++controlo.el_wpt_type.cmt > 1) {
							erro("Só pode existir uma tag CMT dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagDesc {
						if(++controlo.el_wpt_type.desc > 1) {
							erro("Só pode existir uma tag DESC dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagSrc {
						if(++controlo.el_wpt_type.src > 1) {
							erro("Só pode existir uma tag SRC dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagLink
					|
					tagSym {
						if(++controlo.el_wpt_type.sym > 1) {
							erro("Só pode existir uma tag SYM dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagType {
						if(++controlo.el_wpt_type.type > 1) {
							erro("Só pode existir uma tag TYPE dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagFix {
						if(++controlo.el_wpt_type.fix > 1) {
							erro("Só pode existir uma tag FIX dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagSat {
						if(++controlo.el_wpt_type.sat > 1) {
							erro("Só pode existir uma tag SAT dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagHdop {
						if(++controlo.el_wpt_type.hdop > 1) {
							erro("Só pode existir uma tag HDOP dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagVdop {
						if(++controlo.el_wpt_type.vdop > 1) {
							erro("Só pode existir uma tag VDOP dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagPdop {
						if(++controlo.el_wpt_type.pdop > 1) {
							erro("Só pode existir uma tag PDOP dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagAgeofdgpsdata {
						if(++controlo.el_wpt_type.ageofdgpsdata > 1) {
							erro("Só pode existir uma tag AGEOFDGPSDATA dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagDgpsid {
						if(++controlo.el_wpt_type.dgpsid > 1) {
							erro("Só pode existir uma tag DGPSID dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}
					|
					tagExtensions {
						if(++controlo.el_wpt_type.extensions > 1) {
							erro("Só pode existir uma tag EXTENSIONS dentro de uma tag WPT || RTEPT || TRKPT");
						}
					}					
					;
			
		/*****************************************************************************************
		 *		1.4 - RTE TYPE
		 *
		 *		name | cmt | desc | src | link | number | type | extensions | rtept
		 *
		 *****************************************************************************************
		 */
		rteType: rteType rteTypeTag | rteTypeTag;
		rteTypeTag:
					tagName {
						if(++controlo.el_rte_type.name > 1) {
							erro("Só pode existir uma tag NAME dentro de uma tag RTE");
						}
					}
					|
					tagCmt {
						if(++controlo.el_rte_type.cmt > 1) {
							erro("Só pode existir uma tag CMT dentro de uma tag RTE");
						}
					}
					|
					tagDesc {
						if(++controlo.el_rte_type.desc > 1) {
							erro("Só pode existir uma tag DESC dentro de uma tag RTE");
						}
					}
					|
					tagSrc {
						if(++controlo.el_rte_type.src > 1) {
							erro("Só pode existir uma tag SRC dentro de uma tag RTE");
						}
					}
					|
					tagLink
					|
					tagNumber {
						if(++controlo.el_rte_type.number > 1) {
							erro("Só pode existir uma tag NUMBER dentro de uma tag RTE");
						}
					}
					|
					tagType {
						if(++controlo.el_rte_type.type > 1) {
							erro("Só pode existir uma tag TYPE dentro de uma tag RTE");
						}
					}
					|
					tagExtensions {
						if(++controlo.el_rte_type.extensions > 1) {
							erro("Só pode existir uma tag EXTENSIONS dentro de uma tag RTE");
						}
					}
					|
					tagRtept
					;

		/***********************************************************************************
		 *		1.5 - TRK TYPE
		 *
		 *		name | cmt | desc | src | link | number | type | extensions | trkseg
		 *
		 ***********************************************************************************
		 */
		trkType: trkType trkTypeTag | trkTypeTag;
		trkTypeTag:
					tagName {
						if(++controlo.el_trk_type.name > 1) {
							erro("Só pode existir uma tag NAME dentro de uma tag TRK");
						}
					}
					|
					tagCmt {
						if(++controlo.el_trk_type.cmt > 1) {
							erro("Só pode existir uma tag CMT dentro de uma tag TRK");
						}
					}
					|
					tagDesc {
						if(++controlo.el_trk_type.desc > 1) {
							erro("Só pode existir uma tag DESC dentro de uma tag TRK");
						}
					}
					|
					tagSrc {
						if(++controlo.el_trk_type.src > 1) {
							erro("Só pode existir uma tag SRC dentro de uma tag TRK");
						}
					}
					|
					tagLink
					|
					tagNumber {
						if(++controlo.el_rte_type.number > 1) {
							erro("Só pode existir uma tag NUMBER dentro de uma tag TRK");
						}
					}
					|
					tagType {
						if(++controlo.el_trk_type.type > 1) {
							erro("Só pode existir uma tag TYPE dentro de uma tag TRK");
						}
					}
					|
					tagExtensions {
						if(++controlo.el_trk_type.extensions > 1) {
							erro("Só pode existir uma tag EXTENSIONS dentro de uma tag TRK");
						}
					}
					|
					tagsTrkseg
					;

		/********************************
		 *		1.6 - TRKSEG TYPE
		 *
		 *		trkpt | extensions
		 *
		 ********************************
		 */
		trksegType:
						tagsTrkpt
						|
						tagExtensions {
							if(++controlo.el_trkseg_type.extensions > 1) {
								erro("Só pode existir uma definição de EXTENSIONS dentro de uma tag TRKSEG");
							}
						}
						;
				
		/*****************************
		 *		1.7 - LINK TYPE
		 *
		 *		text | type
		 *
		 *****************************
		 */
		linkType: linkType linkTypeTag | linkTypeTag;
		linkTypeTag:
					tagText {
						if(++controlo.el_link_type.text > 1) {
							erro("Só pode existir uma tag TEXT dentro de uma tag LINK");
						}
					}
					|
					tagType{		
						if(++controlo.el_link_type.type > 1) {
							erro("Só pode existir uma tag TYPE dentro de uma tag LINK");
						}						
					}
					;						
						
		/***********************************
		 *		1.8 - PERSON TYPE
		 *
		 *		name | email | link
		 *
		 ***********************************
		 */
		personType: personType personTypeTag | personTypeTag;
		personTypeTag:
		
			{if(mostraAtributo == 1) printf("\n\t|\tNome: "); }
			tagName {
				if(++controlo.el_person_type.name > 1) {
					erro("Só pode existir uma definição de NAME dentro da tag AUTHOR");
				}
			}
			|	
			
			{if(mostraAtributo == 1) printf("\n\t|\tEmail: "); }
			tagEmail {
				if(++controlo.el_person_type.email > 1) {
					erro("Só pode existir uma definição de EMAIL dentro da tag AUTHOR");
				}
			}
			|
			
			{if(mostraAtributo == 1) printf("\n\t|\tLink: "); }
			tagLink	{
				if(++controlo.el_person_type.link > 1) {
					erro("Só pode existir uma definição de LINK dentro da tag AUTHOR");
				}
			}
			;
			
		/************************************************************
		 *		1.9 - EMAIL TYPE
		 *
		 *		id = "STRING"
		 *		domain = "STRING"
		 *
		 *		nota: esta tag não "abre e fecha" como as outras		 
		 *
		 ************************************************************
		 */
		emailType: ID_EMAIL '"' STRING '"' DOMAIN_EMAIL '"' STRING '"' { if(mostraAtributo == 1) printf("%s@%s", $3, $7); };
					
		/***********************************
		 *		1.10 - COPYRIGHT TYPE
		 *
		 *		year | license
		 *
		 ***********************************
		 */
		copyrightType: copyrightType copyrightTypeTag | copyrightTypeTag;
		copyrightTypeTag:	tagYear {
								if(++controlo.el_copyright_type.year > 1) {
									erro("Só pode existir uma definição de YEAR dentro de uma tag COPYRIGHT");
								}
							}
							|
							tagLicense{
								if(++controlo.el_copyright_type.license > 1) {
									erro("Só pode existir uma definição de LICENSE dentro de uma tag COPYRIGHT");
								}
							}
							;
		
/*****************************
 *		2 - Atributos
 *****************************
 */

		 /*****************************
		  *		2.1 - Atributos da TAG GPX
		  *
		  *		version = "DECIMAL"
		  *		creator = "STRING"
		  *
		  *****************************
		  */
		atributosGPX: 		atributoGPXCreator atributoGPXVersao 		
						| 	atributoGPXVersao atributoGPXCreator 		
						| 	atributoGPXVersao { erro("Falta o abributo 'version'"); }	
						| 	atributoGPXCreator { erro("Falta o atributo 'creator'"); }	
						|	/* vazio */ { erro("A tag GPX deve conter o atributo 'creator' e a 'version'"); }
						;
		
				/*************************************
				 *		2.1.1 - Atributo 'Version'
				 *
				 *
				 *
				 ************************************
				 */
				atributoGPXVersao:		VERSION { printf("\n\t|\tVersao: ") } '=' '"' valVersion '"';
				
				/************************************
				 *		2.1.2 - Atributo 'Creator'
				 *
				 *
				 *
				 ************************************
				 */
				atributoGPXCreator:		CREATOR { printf("\n\t|\tCreator: ") } '=' '"' valCreator  '"';
				
						/***********************************************************
						 *
						 *	2.1.2.1 - Valores possíveis do atributo creator
						 *									 
						 *
						 ***********************************************************
						 */
						valCreator: valCreator val { printf(" "); } | val;
						val: DECIMAL { printf("%.1f", $1); } | STRING { printf("%s", $1); } | INTEGER { printf("%d", $1); } ;
						
						/*******************************************
						 *
						 *	2.1.2.2 - valor do atributo version
						 *									 
						 *
						 *******************************************
						 */
						valVersion: DECIMAL { printf("%.1f", $1); };
					
		/******************************************************
		 *		2.2 - Atributos da TAG WPT, RTEPT e TRKSEG
		 *
		 *		lat = "DECIMAL"
		 *		lon = "DECIMAL"
		 *
		 ******************************************************
		 */
		atributosWpt:	LAT '=' '"' DECIMAL '"' LON '=' '"' DECIMAL '"' { validarPosicao($4, $9, 1); validarBounds($4, $9); }
						|
						LON '=' '"' DECIMAL '"' LAT '=' '"' DECIMAL '"' { validarPosicao($9, $4, 1);  validarBounds($4, $9); }
						|	
						/* vazio */ { erro("Os parametros de latitude e longitude sao obrigatorios"); }
						;
			
		/********************************************
		 *		2.3 - Atributos da TAG COPYRIGHT
		 *
		 *		author="STRING"
		 *
		 ********************************************
		 */
		atributosCopyright: COPYRIGHT_AUTHOR '"' STRING '"';
		
		/********************************
		 *		2.4 - Atributo da TAG LINK
		 *
		 *		href="URL"
		 *
		 ********************************
		 */
		linkTypeHref: HREF '=' '"' URL '"' {if(mostraAtributo == 1) printf("%s", $4);};
		
		/****************************************
		 *		2.5 - Atributos da TAG BOUNDS
		 *
		 *		minlat = "DECIMAL"
		 *		minlon = "DECIMAL"
		 *		maxlat = "DECIMAL"
		 *		maxlon = "DECIMAL"
		 *
		 ****************************************
		 */
		atributosBounds: MIN_LAT '"' DECIMAL '"' MIN_LON '"' DECIMAL '"' MAX_LAT '"' DECIMAL '"' MAX_LON  '"' DECIMAL '"' { 
							validarPosicao($3, $7, 0); validarPosicao($11, $15, 0); 
							
							if(mostraAtributo == 1) {
								printf("Min Lat: %f\n\t\t\tMin Lon: %f\n\t\t\tMax Lat: %f\n\t\t\tMax Lon: %f", $3, $7, $11, $15);
							}
							
							bounds.minlat = $3;
							bounds.minlon = $7;
							bounds.maxlat = $11;
							bounds.maxlon = $15;
							bounds.temBounds = 1;
						}
						|
						MAX_LAT '"' DECIMAL '"' MAX_LON  '"' DECIMAL '"' MIN_LAT '"' DECIMAL '"' MIN_LON '"' DECIMAL '"'  { 
							validarPosicao($3, $7, 0); validarPosicao($11, $15, 0); 
							
							if(mostraAtributo == 1) {
								printf("Min Lat: %f\n\t\t\tMin Lon: %f\n\t\t\tMax Lat: %f\n\t\t\tMax Lon: %f", $11, $15, $3, $7);
							}
							
							bounds.minlat = $11;
							bounds.minlon = $15;
							bounds.maxlat = $3;
							bounds.maxlon = $7;
							bounds.temBounds = 1;
						};
	
	
/*****************************
 *		3 - Tags
 *
 *
 *
 *****************************
 */

		/*****************************
		 *		3.1 - TAG ELE
		 *
		 *
		 *
		 *****************************
		 */
		tagEle: ELE_ABRE_TAG DECIMAL ELE_FECHA_TAG {	
			ok.ele = 1;
			buffer->ele = $2;
		};
		
		/*****************************
		 *		3.2 - TAG MAGVAR
		 *
		 *
		 *
		 *****************************
		 */
		tagMagvar:
			MAGVAR_ABRE_TAG DECIMAL MAGVAR_FECHA_TAG {
				if($2 < 0.0 || $2 > 360.0) {
					erro("O atributo da tag MAGVAR deve estar ente 0.0 e 360.0");
				}
			}			
			;
		
		/****************************************
		 *		3.3 - TAG GEOIDHEIGHT
		 *
		 *
		 *
		 ****************************************
		 */
		tagGeoidheight: GEOIDHEIGHT_ABRE_TAG DECIMAL GEOIDHEIGHT_FECHA_TAG;
		
		/*****************************
		 *		3.4 - TAG CMT
		 *
		 *
		 *
		 *****************************
		 */
		tagCmt: CMT_ABRE_TAG valores CMT_FECHA_TAG;
		
		/*****************************
		 *		3.5 - TAG SRC
		 *
		 *
		 *
		 *****************************
		 */
		tagSrc: SRC_ABRE_TAG valores SRC_FECHA_TAG;
		
		/*****************************
		 *		3.6 - TAG SYM
		 *
		 *
		 *
		 *****************************
		 */
		tagSym: SYM_ABRE_TAG valores SYM_FECHA_TAG;
		
		/*****************************
		 *		3.7 - TAG TYPE
		 *
		 *
		 *
		 *****************************
		 */
		tagType: {mostraAtributo = 0;}TYPE_ABRE_TAG valores TYPE_FECHA_TAG{mostraAtributo = 1;};
		
		/*****************************
		 *		3.8 - TAG FIX
		 *
		 *
		 *
		 *****************************
		 */			
		tagFix: FIX_ABRE_TAG valores FIX_FECHA_TAG;
		
		/*****************************
		 *		3.9 - TAG SAT
		 *
		 *
		 *
		 *****************************
		 */
		tagSat:
			SAT_ABRE_TAG INTEGER SAT_FECHA_TAG {
				if($2 < 0) {
					erro("O atributo da tag SAT nao pode ser negativo");
				}
			};
		
		/*****************************
		 *		3.10 - TAG HDOP
		 *
		 *
		 *
		 *****************************
		 */
		tagHdop: HDOP_ABRE_TAG DECIMAL HDOP_FECHA_TAG;
		
		/*****************************
		 *		3.11 - TAG VDOP
		 *
		 *
		 *
		 *****************************
		 */
		tagVdop: VDOP_ABRE_TAG DECIMAL VDOP_FECHA_TAG;
		
		/*****************************
		 *		3.12 - TAG PDOP
		 *
		 *
		 *
		 *****************************
		 */
		tagPdop: PDOP_ABRE_TAG DECIMAL PDOP_FECHA_TAG;
		
		/***************************************
		 *		3.13 - TAG AGEOFDGPSDATA
		 *
		 *
		 *
		 ***************************************
		 */
		tagAgeofdgpsdata: AGEOFDGPSDATA_ABRE_TAG DECIMAL AGEOFDGPSDATA_FECHA_TAG;
		
		/*****************************
		 *		3.14 - TAG DGPSID
		 *
		 *
		 *
		 *****************************
		 */			
		tagDgpsid: DGPSID_ABRE_TAG INTEGER DGPSID_FECHA_TAG {
					if($2 < 0 || $2 > 1023) {
						erro("O valor da tag DGPSID deve ser >> 0 <= valor <= 1023");
					}
				};
							
		/*****************************
		 *		3.15 - TAG RTEPT
		 *
		 *
		 *
		 *****************************
		 */
		tagRtept: RTEPT_ABRE_TAG atributosWpt '>' wptType RTEPT_FECHA_TAG  { resetWpt(); temPontos(); pontos.waypoints++; };
		
		/*****************************
		 *		3.16 - TAG NUMBER
		 *
		 *
		 *
		 *****************************
		 */
		tagNumber:
			NUMBER_ABRE_TAG INTEGER NUMBER_FECHA_TAG {
				if($2 < 0) {
					erro("O atributo da tag NUMBER nao pode ser negativo");
				}
			}
			;
		
		/*****************************
		 *		3.17 - TAG TRKSEG
		 *
		 *
		 *
		 *****************************
		 */
		tagsTrkseg: TRKSEG_ABRE_TAG trksegType TRKSEG_FECHA_TAG;
		
		/*****************************
		 *		3.18 - TAG TRKPT
		 *
		 *
		 *
		 *****************************
		 */
		tagsTrkpt: tagsTrkpt tagTrkpt | tagTrkpt;
		tagTrkpt: TRKPT_ABRE_TAG atributosWpt '>' wptType TRKPT_FECHA_TAG { resetWpt(); temPontos(); pontos.waypoints++; };

		/*****************************
		 *		3.19 - TAG NAME
		 *
		 *
		 *
		 *****************************
		 */
		tagName: NAME_ABRE_TAG valores NAME_FECHA_TAG;
		
		/*****************************
		 *		3.20 - TAG DESC
		 *
		 *
		 *
		 *****************************
		 */
		tagDesc: DESC_ABRE_TAG valores DESC_FECHA_TAG;
		
		/*****************************
		 *		3.21 - TAG DESC
		 *
		 *
		 *
		 *****************************
		 */
		tagAuthor: 		AUTHOR_ABRE_TAG 
							{ printf("\n\n\n\t[ Dados do Autor ]\n\t|"); mostraAtributo = 1; } 
						personType 
							{ mostraAtributo=0; resetPersonType(); } 
						AUTHOR_FECHA_TAG
						
					|	AUTHOR_ABRE_TAG { resetPersonType(); } AUTHOR_FECHA_TAG;
		
		/***********************************
		 *		3.22 - TAG COPYRIGHT
		 *
		 *
		 *
		 ***********************************
		 */
		tagCopyright: 	COPYRIGHT_ABRE_TAG 							
						atributosCopyright '>' 
							{ printf("\n\n\n\t[ Dados do Copyright ]\n\t|"); mostraAtributo = 1; } 
						copyrightType 
							{ mostraAtributo=0; resetCopyright(); } 
						COPYRIGHT_FECHA_TAG
						|
						COPYRIGHT_ABRE_TAG atributosCopyright '>' COPYRIGHT_FECHA_TAG;
						;
		
		/*****************************
		 *		3.23 - TAG LINK
		 *
		 *
		 *
		 *****************************
		 */
		tagLink:	LINK_ABRE_TAG { resetLink(); } linkTypeHref '>' linkType LINK_FECHA_TAG	
					|
					LINK_ABRE_TAG { resetLink(); erro("O atributo HREF é obrigatório"); } '>' linkType LINK_FECHA_TAG
					;

		/*****************************
		 *		3.24 - TAG TIME
		 *
		 *
		 *
		 *****************************
		 */
		tagTime:	TIME_ABRE_TAG DATA_HORA TIME_FECHA_TAG {
						if(mostraAtributo == 1) {
							printf("%s", $2);
						}
						
						ok.time = 1;
						converterData($2);
					}
					;

		/*****************************
		 *		3.25 - TAG KEYWORDS
		 *
		 *
		 *
		 *****************************
		 */
		tagKeywords: KEYWORDS_ABRE_TAG valores KEYWORDS_FECHA_TAG;
		
		/*****************************
		 *		3.26 - TAG BOUNDS
		 *
		 *
		 *
		 *****************************
		 */
		tagBounds: BOUNDS_ABRE_TAG atributosBounds '/' '>';
		
		/*****************************
		 *		3.27 - TAG EMAIL
		 *
		 *		
		 *
		 *****************************
		 */
		tagEmail: EMAIL_ABRE_TAG emailType '/' '>';
		
		/***********************************************************
		 *		3.28 - TAG METADATA
		 *
		 *		<metadata> metadataType </metadata>
		 *
		 ***********************************************************
		 */
		tagMetadata: 	METADATA_ABRE_TAG 
							{ printf("\n\t[ Dados da Metadata ]\n\t|"); mostraAtributo = 1; } 
						metadataType
							{ mostraAtributo = 0; } 
						METADATA_FECHA_TAG {
							resetMetadata();
						}
						|
						METADATA_ABRE_TAG METADATA_FECHA_TAG
						;
		
		/***********************************************************************
		 *		3.29 - TAG WPT
		 *
		 *		<wpt lat="DECIMAL" lon="DECIMAL"> wptType </wpt>
		 *
		 ***********************************************************************
		 */
		tagWpt:	WPT_ABRE_TAG atributosWpt '>' wptType WPT_FECHA_TAG { 
					resetWpt();
					temPontos();
					pontos.waypoints++; 
				}
				|
				WPT_ABRE_TAG atributosWpt '>' WPT_FECHA_TAG
				;
		
		/*****************************************
		 *		3.30 - TAG RTE
		 *
		 *		<rte> rteType </rte>
		 *
		 *****************************************
		 */				
		tagRte:	RTE_ABRE_TAG rteType RTE_FECHA_TAG { 
					resetRte();
					pontos.routes++; 
				}
				|
				RTE_ABRE_TAG RTE_FECHA_TAG { 
					resetRte();
					pontos.routes++; 
				}
				;
		
		
		/*****************************************************
		 *		3.31 - TAG TRK
		 *
		 *		<trk> trkType </trk>
		 *
		 *****************************************************
		 */
		tagTrk:	TRK_ABRE_TAG trkType TRK_FECHA_TAG { 
					resetTrk();
					pontos.tracks++; 
				}
				|
				TRK_ABRE_TAG TRK_FECHA_TAG { 
					resetTrk();
					pontos.tracks++; 
				}
				;
		
		/*****************************************************************
		 *		3.32 - TAG Extensions
		 *
		 *		<extensions> extensionsType </extensions>
		 *
		 *****************************************************************
		 */				
		tagExtensions:	EXTENSIONS_ABRE_TAG tagsAleatorias EXTENSIONS_FECHA_TAG
						|
						EXTENSIONS_ABRE_TAG EXTENSIONS_FECHA_TAG
						|
						EXTENSIONS_ABRE_TAG valores EXTENSIONS_FECHA_TAG
						;
						
		/***************************
		 *	3.33 - TAG TEXT
		 *
		 *
		 *
		 ***************************
		 */
		tagText: {mostraAtributo = 0;} TEXT_ABRE_TAG valores TEXT_FECHA_TAG {mostraAtributo = 1;};
		
		/***************************
		 *
		 *	3.34 - TAG YEAR
		 *
		 *
		 ***************************
		 */
		 tagYear: YEAR_ABRE_TAG INTEGER { if(mostraAtributo == 1) printf("\n\t|\tAno: %d", $2); } YEAR_FECHA_TAG;
		 
		/***************************
		 *
		 *	3.35 - TAG LICENSE
		 *
		 *
		 ***************************
		 */
		 tagLicense: LICENSE_ABRE_TAG URL { if(mostraAtributo == 1) printf("\n\t|\tLicenca: %s", $2); }  LICENSE_FECHA_TAG;
		
		/**********************************************************************************
		 *	3.36 - Conjunto de tags aleatórias dentro da tag EXTENSIONS
		 *
		 *	A única condição para o conjunto de tags aleatórias é que a string que abre seja igual à string que fecha
		 *
		 **********************************************************************************
		 */
		 tagsAleatorias: tagsAleatorias tagAleatoria | tagAleatoria;		 
		tagAleatoria: 
						'<' STRING '>' valores '<' '/' STRING '>' {
							comparaTags($2, $7);							
						}
						|		
						'<' STRING '>' tagsAleatorias '<' '/' STRING '>' {
							comparaTags($2, $7);	
						}
						|		
						'<' STRING '>'  '<' '/' STRING '>' {
							comparaTags($2, $6);
						}						
						;

/*****************************
 *		4 - Outras
 *
 *
 *
 *****************************
 */
 
		/*********************************************************
		 *	4.1 - O atributo STRING pode ter uma ou mais palavras
		 *
		 *
		 *
		 *********************************************************
		 */
		//xsd_string: xsd_string STRING { if(mostraAtributo == 1) printf(" %s", $2); } | STRING { if(mostraAtributo == 1) printf("%s", $1); };
		
		/******************************************
		 *	4.2 - Um atributo pode ter vários valores
		 *	
		 *
		 ******************************************
		 */
		valores: valores valor | valor;
		valor: INTEGER { if(mostraAtributo == 1) printf(" %d", $1); } | DECIMAL { if(mostraAtributo == 1) printf(" %f", $1); } | STRING { if(mostraAtributo == 1) printf(" %s", $1); };
%%

/*
 *
 *
 */
void resetLink() {
	controlo.el_link_type.text = 0;
	controlo.el_link_type.type = 0;
}

/*
 *
 *
 */
void resetMetadata() {
	controlo.el_metadata_type.name = 0;
	controlo.el_metadata_type.desc = 0;
	controlo.el_metadata_type.author = 0;
	controlo.el_metadata_type.copyright = 0;
	controlo.el_metadata_type.keywords = 0;
	controlo.el_metadata_type.bounds = 0;
	controlo.el_metadata_type.extensions = 0;
	controlo.el_metadata_type.time = 0;
}

/*
 *
 *
 */
void resetWpt() {
	controlo.el_wpt_type.ele = 0;
	controlo.el_wpt_type.time = 0;
	controlo.el_wpt_type.magvar = 0;
	controlo.el_wpt_type.geoidheight = 0;
	controlo.el_wpt_type.name = 0;
	controlo.el_wpt_type.cmt = 0;
	controlo.el_wpt_type.desc = 0;
	controlo.el_wpt_type.src = 0;
	controlo.el_wpt_type.sym = 0;
	controlo.el_wpt_type.type = 0;
	controlo.el_wpt_type.fix = 0;
	controlo.el_wpt_type.sat = 0;
	controlo.el_wpt_type.hdop = 0;
	controlo.el_wpt_type.vdop = 0;
	controlo.el_wpt_type.pdop = 0;
	controlo.el_wpt_type.ageofdgpsdata = 0;
	controlo.el_wpt_type.dgpsid = 0;
	controlo.el_wpt_type.extensions = 0;
}

/*
 *
 *
 */
void resetRte() {
	controlo.el_rte_type.name = 0;
	controlo.el_rte_type.cmt = 0;
	controlo.el_rte_type.desc = 0;
	controlo.el_rte_type.src = 0;
	controlo.el_rte_type.number = 0;
	controlo.el_rte_type.type = 0;
	controlo.el_rte_type.extensions = 0;
}

/*
 *
 *
 */
void resetTrk() {
	controlo.el_trk_type.name = 0;
	controlo.el_trk_type.cmt = 0;
	controlo.el_trk_type.desc = 0;
	controlo.el_trk_type.src = 0;
	controlo.el_trk_type.number = 0;
	controlo.el_trk_type.type = 0;
	controlo.el_trk_type.extensions = 0;
}

/*
 *
 *
 */
void resetCopyright() {
	controlo.el_copyright_type.year = 0;
	controlo.el_copyright_type.license = 0;
}

/*
 *
 *
 */
void resetPersonType() {
	controlo.el_person_type.name = 0;
	controlo.el_person_type.email = 0;
	controlo.el_person_type.link = 0;
}

/*
 *
 *
 */
int comparaTags(char *abre, char *fecha) {
	if(strcmp(abre, fecha) != 0) {
		erro("A Tag de abertura deve set igual à tag de fecho");
	}
}

/*
 *
 *
 */
void validarBounds(double lat, double lon) {
	if(bounds.temBounds == 1) {
		if(lat < bounds.minlat || lat > bounds.maxlat) {			
			erro("O valor da latitude nao se encontra dentro dos limites");
			printf("\n\t\t\tLat: %f\n\t\t\tMin Lat: %f Max Lat: %f", lat, bounds.minlat, bounds.maxlat);
		}
		
		if(lon < bounds.minlon || lon > bounds.maxlon) {
			erro("O valor da longitude nao se encontra dentro dos limites");
			printf("\n\t\t\tLon: %f\n\t\t\tMin Lon: %f Max Lon: %f", lon, bounds.minlon, bounds.maxlon);
		}
	}
}

/*
 *		Verifica se a longitude e a latitude estão dentro dos parametros
 *		e se necessário armazena os valores no buffer
 *
 *		lat -> o valor da latitude
 *		lon -> o valor da longitude
 *		salvar -> guardar na estrutura de BUFFER
 *
 */
void validarPosicao(double lat, double lon, short salvar) {
	if(lat <= -90.0 || lat > 90.0) {
		erro("O parametro da LATITUDE deve ser >> -90.0 <= valor <= 90.0");
	} else if(salvar == 1) {
		ok.lat = 1;
		buffer->latitude = rad(lat);
	}
	
	if(lon <= -180.0 || lon > 180.0) {
		erro("O parametro da LONGITUDE deve ser >> -180.0 <= valor < 180.0");
	} else if(salvar == 1) {
		ok.lon = 1;
		buffer->longitude = rad(lon);
	}
}
/*
 *	Converte uma data do formato yyyy-mmddThh:mm:ssZ
 *	para o formato da estrutura que é h:m:s
 *
 *	data -> a data no formato yyyy-mmddThh:mm:ssZ
 *
 */
void converterData(char *data) {
	char valor[2];

	valor[0] = data[11];
	valor[1] = data[12];
	
	buffer->t.hora = atoi(valor);
	
	valor[0] = data[14];
	valor[1] = data[15];
	
	buffer->t.minuto = atoi(valor);
	
	valor[0] = data[17];
	valor[1] = data[18];
	
	buffer->t.segundo = atoi(valor);
}

/*
 *	Cada vez que um dos atributos necessários é encontrado, o elemento
 *	correspondente da estrutura passa a 1. No final da tag, se todos
 *	os elementos da estrutura forem 1, o ponto é adicionado à lista
 *	ligada para mais tade serem efectuados os parciais
 */
void temPontos() {
	if(ok.lat == 1 && ok.lon == 1 && ok.ele == 1 && ok.time == 1) {			
		adicionar(buffer);
	} else {
		erro("A tag WPT|RTEPT|TRKPT não tem dados suficientes para efectuar os cálculos. Deve conter pelo menos uma tag ELE e outra TIME");
	}

	ok.lat = 0;
	ok.lon = 0; 
	ok.ele = 0;
	ok.time = 0;
}

/*
 *	Converte um valor em GRAUS para RADIANOS
 *
 *	graus -> o valor em graus
 *
 *	retorna o valor convertido em radianos
 *
 */
double rad(double graus) {
	return graus * ((2 * M_PI) / 360);
}

/*
 *	Converte um valor em RADIANOS para GRAUS
 *
 *	graus -> o valor em radianos
 *	
 *	retorna o valor convertido em graus
 *
 */
double graus(double radianos) {
	return radianos * (360 / (2 * M_PI));
}


/*
 *
 *
 */
void ajuda() {
	printf("\n\n\t##### AJUDA #####\n\n");
	printf("\t-i\t- activa o modo de informacao de pontos");
	printf("\n\t-ip\t- mostra os dados dos dois pontos que estao a ser calculados NOTA: deve ser utilizado juntamente com -c");
	printf("\n\t-e\t- suprimir as mensagens de erro");	
	printf("\n\t-c\t- efetua os calculos");	
	printf("\n\t?\t- mostra a ajuda");
	printf("\n\t\n\tpara correr o programa: g [parametros] < NOME_DO_FICHEIRO\n\n\n\n");
}

/*
 *
 *
 */
int yyerror(char *s) {
	if(SUPRIMIR_ERROS == 0) {
		printf("\n\n\t[ ERRO ] linha %d: %s", numLinha, s);		
	}
	
	numErros++;
}

/*
 *	Mostra uma mensagem de erro. Já inclui o numero da linha em que se encontra
 *	e incremente a variável de erros.
 *
 *	msg -> a mensagem de erro a ser mostrada
 *
 */
void erro(char *msg) {
	if(SUPRIMIR_ERROS == 0) {
		printf("\n\n\t[ ERRO ] linha %d: %s...", numLinha, msg);		
	}
	
	numErros++;
}

/*
 *
 *
 */
int yywrap() {
	return 1;
}

/*
 *
 *
 */
int main(int argc, char *argv[]) {	
	int i = 0;	
	buffer = (PONTO *)malloc(sizeof(PONTO));

	for(i = 0; i < argc; i++) {
		if(strcmp(argv[i], "?") == 0) {
			ajuda();
			exit(0);
		} else {
			if(strcmp(argv[i], "-i") == 0) {
				INFO_PONTO = 1;		
			} else if(strcmp(argv[i], "-ip") == 0) {
				INFO_DOIS_PONTOS = 1;
			} else if(strcmp(argv[i], "-c") == 0) {
				CALCULAR = 1;
			} else if(strcmp(argv[i], "-e") == 0) {
				SUPRIMIR_ERROS = 1;
			}
		}		
	}

	yyparse(); 
	
	if(INFO_PONTO == 1) {
			printf("\n\n\n\t[ Dados dos Pontos ]\n");
			infoPonto();
		}
	
	if(CALCULAR == 1) {
		printf("\n\n\n\t[ Calculos ]\n");
		calcular();
	}
	
	if(numErros == 0) {									
		printf("\n\n\n\t[ Quantidade de Pontos ]\n\t|\n");
		printf("\t|\tWaypoints: %d\n", pontos.waypoints);
		printf("\t|\tRoutes: %d\n", pontos.routes);
		printf("\t|\tTracks: %d\n", pontos.tracks);
		
		printf("\n\n\n\t|\tNao existem erros. O ficheiro e valido.\n");
	} else if(numErros == 1) {
		printf("\n\n\n\n\t[ Existe %d erro ]", numErros);
	} else {
		printf("\n\n\n\n\t[ Existem %d erros ]", numErros);
	}

	printf("\n\n\n\t[ %d linhas validadas ]\n\n\n\n", numLinha);
	
	/*
	 *	...
	 */
	libertar();
	free(buffer);
}