/*
 *
 */
typedef struct {
	short gpx;
	short metadata;
	short extensions;
} GPX_TYPE;
	
/*
 *
 */
typedef struct {
	short name;
	short desc;
	short author;
	short copyright;
	short time;
	short keywords;
	short bounds;
	short extensions;
} METADATA_TYPE;

/*
 *
 */
typedef struct {
	short ele;
	short time;
	short magvar;
	short geoidheight;
	short name;
	short cmt;
	short desc;
	short src;
	short sym;
	short type;
	short fix;
	short sat;
	short hdop;
	short vdop;
	short pdop;
	short ageofdgpsdata;
	short dgpsid;
	short extensions;
} WPT_TYPE;

/*
 *
 */
typedef struct {
	short name;
	short cmt;
	short desc;
	short src;
	short number;
	short type;
	short extensions;
} RTE_TYPE;

/*
 *
 */
typedef struct {
	short name;
	short cmt;
	short desc;
	short src;	
	short number;
	short type;
	short extensions;
} TRK_TYPE;

/*
 *
 */
typedef struct {
	short extensions;
} TRKSEG_TYPE;

/*
 *
 */
typedef struct {
	short name;
	short email;
	short link;
} PERSON_TYPE;

/*
 *
 */
typedef struct {
	short text;
	short type;
} LINK_TYPE;

/*
 *
 */
typedef struct {
	short year;
	short license;
} COPYRIGHT_TYPE;

/*
 *
 */
typedef struct {
	GPX_TYPE el_gpx;
	METADATA_TYPE el_metadata_type;
	WPT_TYPE el_wpt_type;
	RTE_TYPE el_rte_type;
	TRK_TYPE el_trk_type;
	TRKSEG_TYPE el_trkseg_type;
	PERSON_TYPE el_person_type;
	LINK_TYPE el_link_type;
	COPYRIGHT_TYPE el_copyright_type;
} CONTROLO_ELEMENTOS;


/*
 *	Quantidade de waypoints, rotes e tracks existentes no ficheiro gpx
 *
 */
typedef struct {
	int waypoints;
	int routes;
	int tracks;
} QUANTIDADE_PONTOS;

/*
 *	Guarda valores 1 e 0 para indicar se cada Waypoint tem os pontos
 *	necessários para efectuar os cálculos
 */
typedef struct {
	short lat;
	short lon;
	short ele;
	short time;
} OK_PONTOS;

/*
 *	Estrutura que guarda os valores da tag Bounds
 *	para se comparar com os valores dos atributos
 *
 */
typedef struct {
	double minlat;
	double minlon;
	double maxlat;
	double maxlon;
	short temBounds;
} BOUNDS;
