%{
	#include "gpx.tab.h"
	int numLinha = 1;
%}

letra						[a-zA-Z]
digito						[0-9]

caracteres					\.|\_|\-|\:

inteiro						\-?{digito}+
real						\-?{inteiro}+(\.{inteiro}*)?
palavra						{letra}({letra}|{inteiro}|{caracteres})*

dataHora					({digito}){4}-({digito}){2}-({digito}){2}T({digito}){2}:({digito}){2}:({digito}){2}Z
tld							com|pt|org|edu|us|net
url							http:\/\/(www\.)?{palavra}\.{tld}

a							\<
f							\>
af							\<\/

%%

{dataHora}   				yylval.paramStr = strdup(yytext); return DATA_HORA;
href						return HREF;
lat							return LAT;
lon 						return LON;
author=						return COPYRIGHT_AUTHOR;
id=							return ID_EMAIL;
domain=						return DOMAIN_EMAIL;
minlat=						return MIN_LAT;
minlon=						return MIN_LON;
maxlat=						return MAX_LAT;
maxlon=						return MAX_LON;
version						return VERSION;
creator						return CREATOR;

{a}author{f}				return AUTHOR_ABRE_TAG;
{af}author{f}				return AUTHOR_FECHA_TAG;

{a}email					return EMAIL_ABRE_TAG;

{a}name{f}					return NAME_ABRE_TAG;
{af}name{f}					return NAME_FECHA_TAG;

{a}link						return LINK_ABRE_TAG;
{af}link{f}					return LINK_FECHA_TAG;

{a}type{f}					return TYPE_ABRE_TAG;
{af}type{f}					return TYPE_FECHA_TAG;

{a}desc{f}					return DESC_ABRE_TAG;
{af}desc{f}					return DESC_FECHA_TAG;

{a}text{f}					return TEXT_ABRE_TAG;
{af}text{f}					return TEXT_FECHA_TAG;

{a}copyright				return COPYRIGHT_ABRE_TAG;
{af}copyright{f}			return COPYRIGHT_FECHA_TAG;

{a}time{f}					return TIME_ABRE_TAG;
{af}time{f}					return TIME_FECHA_TAG;

{a}keywords{f}				return KEYWORDS_ABRE_TAG;
{af}keywords{f}				return KEYWORDS_FECHA_TAG;

{a}extensions{f}			return EXTENSIONS_ABRE_TAG;
{af}extensions{f}			return EXTENSIONS_FECHA_TAG;

{a}bounds					return BOUNDS_ABRE_TAG;

{a}year{f}					return YEAR_ABRE_TAG;
{af}year{f}					return YEAR_FECHA_TAG;

{a}license{f}				return LICENSE_ABRE_TAG;
{af}license{f}				return LICENSE_FECHA_TAG;

{a}metadata{f} 				return METADATA_ABRE_TAG;
{af}metadata{f}				return METADATA_FECHA_TAG;

{a}wpt 						return WPT_ABRE_TAG;
{af}wpt{f}					return WPT_FECHA_TAG;

{a}rte{f} 					return RTE_ABRE_TAG;
{af}rte{f}					return RTE_FECHA_TAG;

{a}trk{f} 					return TRK_ABRE_TAG;
{af}trk{f}					return TRK_FECHA_TAG;

{a}ele{f} 					return ELE_ABRE_TAG;
{af}ele{f}					return ELE_FECHA_TAG;

{a}magvar{f} 				return MAGVAR_ABRE_TAG;
{af}magvar{f}				return MAGVAR_FECHA_TAG;

{a}geoidheight{f} 			return GEOIDHEIGHT_ABRE_TAG;
{af}geoidheight{f}			return GEOIDHEIGHT_FECHA_TAG;

{a}cmt{f} 					return CMT_ABRE_TAG;
{af}cmt{f}					return CMT_FECHA_TAG;

{a}sym{f} 					return SYM_ABRE_TAG;
{af}sym{f}					return SYM_FECHA_TAG;

{a}src{f}					return SRC_ABRE_TAG;
{af}src{f}	 				return SRC_FECHA_TAG;

{a}trkseg{f}				return TRKSEG_ABRE_TAG;
{af}trkseg{f}	 			return TRKSEG_FECHA_TAG;

{a}fix{f}					return FIX_ABRE_TAG; 
{af}fix{f}	 				return FIX_FECHA_TAG;

{a}sat{f}					return SAT_ABRE_TAG; 
{af}sat{f}	 				return SAT_FECHA_TAG;

{a}hdop{f}					return HDOP_ABRE_TAG; 
{af}hdop{f}	 				return HDOP_FECHA_TAG;

{a}vdop{f}					return VDOP_ABRE_TAG; 
{af}vdop{f}	 				return VDOP_FECHA_TAG;

{a}pdop{f}					return PDOP_ABRE_TAG; 
{af}pdop{f}	 				return PDOP_FECHA_TAG;

{a}ageofdgpsdata{f}			return AGEOFDGPSDATA_ABRE_TAG; 
{af}ageofdgpsdata{f}	 	return AGEOFDGPSDATA_FECHA_TAG;

{a}dgpsid{f}				return DGPSID_ABRE_TAG; 
{af}dgpsid{f}	 			return DGPSID_FECHA_TAG;

{a}rtept					return RTEPT_ABRE_TAG; 
{af}rtept{f}	 			return RTEPT_FECHA_TAG;

{a}number{f}				return NUMBER_ABRE_TAG; 
{af}number{f}	 			return NUMBER_FECHA_TAG;

{a}trkpt					return TRKPT_ABRE_TAG; 
{af}trkpt{f}	 			return TRKPT_FECHA_TAG;

{a}gpx						return ABRE_TAG_GPX;
{af}gpx{f} 					return FECHA_TAG_GPX;

">"							return yytext[0];
"="							return yytext[0];
"\""						return yytext[0];
"<"							return yytext[0];
"/"							return yytext[0];

{url}						yylval.paramStr = strdup(yytext); return URL;	
{palavra}					yylval.paramStr = strdup(yytext); return STRING;
{inteiro}					yylval.paramInt = atoi(yytext); return INTEGER;
{real}						yylval.paramFloat = atof(yytext); return DECIMAL;

[ \t]+
\n							numLinha++;
<<EOF>>						return 0;

%%