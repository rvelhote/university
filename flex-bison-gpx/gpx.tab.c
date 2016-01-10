/* A Bison parser, made by GNU Bison 2.1.  */

/* Skeleton parser for Yacc-like parsing with Bison,
   Copyright (C) 1984, 1989, 1990, 2000, 2001, 2002, 2003, 2004, 2005 Free Software Foundation, Inc.

   This program is free software; you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation; either version 2, or (at your option)
   any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program; if not, write to the Free Software
   Foundation, Inc., 51 Franklin Street, Fifth Floor,
   Boston, MA 02110-1301, USA.  */

/* As a special exception, when this file is copied by Bison into a
   Bison output file, you may use that output file without restriction.
   This special exception was added by the Free Software Foundation
   in version 1.24 of Bison.  */

/* Written by Richard Stallman by simplifying the original so called
   ``semantic'' parser.  */

/* All symbols defined below should begin with yy or YY, to avoid
   infringing on user name space.  This should be done even for local
   variables, as they might otherwise be expanded by user macros.
   There are some unavoidable exceptions within include files to
   define necessary library symbols; they are noted "INFRINGES ON
   USER NAME SPACE" below.  */

/* Identify Bison output.  */
#define YYBISON 1

/* Bison version.  */
#define YYBISON_VERSION "2.1"

/* Skeleton name.  */
#define YYSKELETON_NAME "yacc.c"

/* Pure parsers.  */
#define YYPURE 0

/* Using locations.  */
#define YYLSP_NEEDED 0



/* Tokens.  */
#ifndef YYTOKENTYPE
# define YYTOKENTYPE
   /* Put the tokens into the symbol table, so that GDB and other debuggers
      know about them.  */
   enum yytokentype {
     VERSION = 258,
     CREATOR = 259,
     HREF = 260,
     LAT = 261,
     LON = 262,
     URL = 263,
     INTEGER = 264,
     DECIMAL = 265,
     STRING = 266,
     ID_EMAIL = 267,
     DOMAIN_EMAIL = 268,
     DATA_HORA = 269,
     AUTHOR_ABRE_TAG = 270,
     AUTHOR_FECHA_TAG = 271,
     EMAIL_ABRE_TAG = 272,
     NAME_ABRE_TAG = 273,
     NAME_FECHA_TAG = 274,
     LINK_ABRE_TAG = 275,
     LINK_FECHA_TAG = 276,
     DESC_ABRE_TAG = 277,
     DESC_FECHA_TAG = 278,
     TEXT_ABRE_TAG = 279,
     TEXT_FECHA_TAG = 280,
     COPYRIGHT_ABRE_TAG = 281,
     COPYRIGHT_FECHA_TAG = 282,
     TIME_ABRE_TAG = 283,
     TIME_FECHA_TAG = 284,
     KEYWORDS_ABRE_TAG = 285,
     KEYWORDS_FECHA_TAG = 286,
     EXTENSIONS_ABRE_TAG = 287,
     EXTENSIONS_FECHA_TAG = 288,
     BOUNDS_ABRE_TAG = 289,
     YEAR_ABRE_TAG = 290,
     YEAR_FECHA_TAG = 291,
     LICENSE_ABRE_TAG = 292,
     LICENSE_FECHA_TAG = 293,
     TYPE_ABRE_TAG = 294,
     TYPE_FECHA_TAG = 295,
     METADATA_ABRE_TAG = 296,
     METADATA_FECHA_TAG = 297,
     WPT_ABRE_TAG = 298,
     WPT_FECHA_TAG = 299,
     RTE_ABRE_TAG = 300,
     RTE_FECHA_TAG = 301,
     TRK_ABRE_TAG = 302,
     TRK_FECHA_TAG = 303,
     ABRE_TAG_GPX = 304,
     FECHA_TAG_GPX = 305,
     ELE_ABRE_TAG = 306,
     ELE_FECHA_TAG = 307,
     MAGVAR_ABRE_TAG = 308,
     MAGVAR_FECHA_TAG = 309,
     GEOIDHEIGHT_ABRE_TAG = 310,
     GEOIDHEIGHT_FECHA_TAG = 311,
     CMT_ABRE_TAG = 312,
     CMT_FECHA_TAG = 313,
     SRC_ABRE_TAG = 314,
     SRC_FECHA_TAG = 315,
     SYM_ABRE_TAG = 316,
     SYM_FECHA_TAG = 317,
     FIX_ABRE_TAG = 318,
     FIX_FECHA_TAG = 319,
     SAT_ABRE_TAG = 320,
     SAT_FECHA_TAG = 321,
     HDOP_ABRE_TAG = 322,
     HDOP_FECHA_TAG = 323,
     VDOP_ABRE_TAG = 324,
     VDOP_FECHA_TAG = 325,
     PDOP_ABRE_TAG = 326,
     PDOP_FECHA_TAG = 327,
     AGEOFDGPSDATA_ABRE_TAG = 328,
     AGEOFDGPSDATA_FECHA_TAG = 329,
     DGPSID_ABRE_TAG = 330,
     DGPSID_FECHA_TAG = 331,
     RTEPT_ABRE_TAG = 332,
     RTEPT_FECHA_TAG = 333,
     NUMBER_ABRE_TAG = 334,
     NUMBER_FECHA_TAG = 335,
     TRKSEG_ABRE_TAG = 336,
     TRKSEG_FECHA_TAG = 337,
     TRKPT_ABRE_TAG = 338,
     TRKPT_FECHA_TAG = 339,
     COPYRIGHT_AUTHOR = 340,
     MIN_LAT = 341,
     MIN_LON = 342,
     MAX_LAT = 343,
     MAX_LON = 344
   };
#endif
/* Tokens.  */
#define VERSION 258
#define CREATOR 259
#define HREF 260
#define LAT 261
#define LON 262
#define URL 263
#define INTEGER 264
#define DECIMAL 265
#define STRING 266
#define ID_EMAIL 267
#define DOMAIN_EMAIL 268
#define DATA_HORA 269
#define AUTHOR_ABRE_TAG 270
#define AUTHOR_FECHA_TAG 271
#define EMAIL_ABRE_TAG 272
#define NAME_ABRE_TAG 273
#define NAME_FECHA_TAG 274
#define LINK_ABRE_TAG 275
#define LINK_FECHA_TAG 276
#define DESC_ABRE_TAG 277
#define DESC_FECHA_TAG 278
#define TEXT_ABRE_TAG 279
#define TEXT_FECHA_TAG 280
#define COPYRIGHT_ABRE_TAG 281
#define COPYRIGHT_FECHA_TAG 282
#define TIME_ABRE_TAG 283
#define TIME_FECHA_TAG 284
#define KEYWORDS_ABRE_TAG 285
#define KEYWORDS_FECHA_TAG 286
#define EXTENSIONS_ABRE_TAG 287
#define EXTENSIONS_FECHA_TAG 288
#define BOUNDS_ABRE_TAG 289
#define YEAR_ABRE_TAG 290
#define YEAR_FECHA_TAG 291
#define LICENSE_ABRE_TAG 292
#define LICENSE_FECHA_TAG 293
#define TYPE_ABRE_TAG 294
#define TYPE_FECHA_TAG 295
#define METADATA_ABRE_TAG 296
#define METADATA_FECHA_TAG 297
#define WPT_ABRE_TAG 298
#define WPT_FECHA_TAG 299
#define RTE_ABRE_TAG 300
#define RTE_FECHA_TAG 301
#define TRK_ABRE_TAG 302
#define TRK_FECHA_TAG 303
#define ABRE_TAG_GPX 304
#define FECHA_TAG_GPX 305
#define ELE_ABRE_TAG 306
#define ELE_FECHA_TAG 307
#define MAGVAR_ABRE_TAG 308
#define MAGVAR_FECHA_TAG 309
#define GEOIDHEIGHT_ABRE_TAG 310
#define GEOIDHEIGHT_FECHA_TAG 311
#define CMT_ABRE_TAG 312
#define CMT_FECHA_TAG 313
#define SRC_ABRE_TAG 314
#define SRC_FECHA_TAG 315
#define SYM_ABRE_TAG 316
#define SYM_FECHA_TAG 317
#define FIX_ABRE_TAG 318
#define FIX_FECHA_TAG 319
#define SAT_ABRE_TAG 320
#define SAT_FECHA_TAG 321
#define HDOP_ABRE_TAG 322
#define HDOP_FECHA_TAG 323
#define VDOP_ABRE_TAG 324
#define VDOP_FECHA_TAG 325
#define PDOP_ABRE_TAG 326
#define PDOP_FECHA_TAG 327
#define AGEOFDGPSDATA_ABRE_TAG 328
#define AGEOFDGPSDATA_FECHA_TAG 329
#define DGPSID_ABRE_TAG 330
#define DGPSID_FECHA_TAG 331
#define RTEPT_ABRE_TAG 332
#define RTEPT_FECHA_TAG 333
#define NUMBER_ABRE_TAG 334
#define NUMBER_FECHA_TAG 335
#define TRKSEG_ABRE_TAG 336
#define TRKSEG_FECHA_TAG 337
#define TRKPT_ABRE_TAG 338
#define TRKPT_FECHA_TAG 339
#define COPYRIGHT_AUTHOR 340
#define MIN_LAT 341
#define MIN_LON 342
#define MAX_LAT 343
#define MAX_LON 344




/* Copy the first part of user declarations.  */
#line 1 "gpx.y"

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



/* Enabling traces.  */
#ifndef YYDEBUG
# define YYDEBUG 0
#endif

/* Enabling verbose error messages.  */
#ifdef YYERROR_VERBOSE
# undef YYERROR_VERBOSE
# define YYERROR_VERBOSE 1
#else
# define YYERROR_VERBOSE 0
#endif

/* Enabling the token table.  */
#ifndef YYTOKEN_TABLE
# define YYTOKEN_TABLE 0
#endif

#if ! defined (YYSTYPE) && ! defined (YYSTYPE_IS_DECLARED)
#line 73 "gpx.y"
typedef union YYSTYPE {
	char *paramStr;
	int paramInt;
	double paramFloat;
} YYSTYPE;
/* Line 196 of yacc.c.  */
#line 341 "gpx.tab.c"
# define yystype YYSTYPE /* obsolescent; will be withdrawn */
# define YYSTYPE_IS_DECLARED 1
# define YYSTYPE_IS_TRIVIAL 1
#endif



/* Copy the second part of user declarations.  */


/* Line 219 of yacc.c.  */
#line 353 "gpx.tab.c"

#if ! defined (YYSIZE_T) && defined (__SIZE_TYPE__)
# define YYSIZE_T __SIZE_TYPE__
#endif
#if ! defined (YYSIZE_T) && defined (size_t)
# define YYSIZE_T size_t
#endif
#if ! defined (YYSIZE_T) && (defined (__STDC__) || defined (__cplusplus))
# include <stddef.h> /* INFRINGES ON USER NAME SPACE */
# define YYSIZE_T size_t
#endif
#if ! defined (YYSIZE_T)
# define YYSIZE_T unsigned int
#endif

#ifndef YY_
# if YYENABLE_NLS
#  if ENABLE_NLS
#   include <libintl.h> /* INFRINGES ON USER NAME SPACE */
#   define YY_(msgid) dgettext ("bison-runtime", msgid)
#  endif
# endif
# ifndef YY_
#  define YY_(msgid) msgid
# endif
#endif

#if ! defined (yyoverflow) || YYERROR_VERBOSE

/* The parser invokes alloca or malloc; define the necessary symbols.  */

# ifdef YYSTACK_USE_ALLOCA
#  if YYSTACK_USE_ALLOCA
#   ifdef __GNUC__
#    define YYSTACK_ALLOC __builtin_alloca
#   else
#    define YYSTACK_ALLOC alloca
#    if defined (__STDC__) || defined (__cplusplus)
#     include <stdlib.h> /* INFRINGES ON USER NAME SPACE */
#     define YYINCLUDED_STDLIB_H
#    endif
#   endif
#  endif
# endif

# ifdef YYSTACK_ALLOC
   /* Pacify GCC's `empty if-body' warning. */
#  define YYSTACK_FREE(Ptr) do { /* empty */; } while (0)
#  ifndef YYSTACK_ALLOC_MAXIMUM
    /* The OS might guarantee only one guard page at the bottom of the stack,
       and a page size can be as small as 4096 bytes.  So we cannot safely
       invoke alloca (N) if N exceeds 4096.  Use a slightly smaller number
       to allow for a few compiler-allocated temporary stack slots.  */
#   define YYSTACK_ALLOC_MAXIMUM 4032 /* reasonable circa 2005 */
#  endif
# else
#  define YYSTACK_ALLOC YYMALLOC
#  define YYSTACK_FREE YYFREE
#  ifndef YYSTACK_ALLOC_MAXIMUM
#   define YYSTACK_ALLOC_MAXIMUM ((YYSIZE_T) -1)
#  endif
#  ifdef __cplusplus
extern "C" {
#  endif
#  ifndef YYMALLOC
#   define YYMALLOC malloc
#   if (! defined (malloc) && ! defined (YYINCLUDED_STDLIB_H) \
	&& (defined (__STDC__) || defined (__cplusplus)))
void *malloc (YYSIZE_T); /* INFRINGES ON USER NAME SPACE */
#   endif
#  endif
#  ifndef YYFREE
#   define YYFREE free
#   if (! defined (free) && ! defined (YYINCLUDED_STDLIB_H) \
	&& (defined (__STDC__) || defined (__cplusplus)))
void free (void *); /* INFRINGES ON USER NAME SPACE */
#   endif
#  endif
#  ifdef __cplusplus
}
#  endif
# endif
#endif /* ! defined (yyoverflow) || YYERROR_VERBOSE */


#if (! defined (yyoverflow) \
     && (! defined (__cplusplus) \
	 || (defined (YYSTYPE_IS_TRIVIAL) && YYSTYPE_IS_TRIVIAL)))

/* A type that is properly aligned for any stack member.  */
union yyalloc
{
  short int yyss;
  YYSTYPE yyvs;
  };

/* The size of the maximum gap between one aligned stack and the next.  */
# define YYSTACK_GAP_MAXIMUM (sizeof (union yyalloc) - 1)

/* The size of an array large to enough to hold all stacks, each with
   N elements.  */
# define YYSTACK_BYTES(N) \
     ((N) * (sizeof (short int) + sizeof (YYSTYPE))			\
      + YYSTACK_GAP_MAXIMUM)

/* Copy COUNT objects from FROM to TO.  The source and destination do
   not overlap.  */
# ifndef YYCOPY
#  if defined (__GNUC__) && 1 < __GNUC__
#   define YYCOPY(To, From, Count) \
      __builtin_memcpy (To, From, (Count) * sizeof (*(From)))
#  else
#   define YYCOPY(To, From, Count)		\
      do					\
	{					\
	  YYSIZE_T yyi;				\
	  for (yyi = 0; yyi < (Count); yyi++)	\
	    (To)[yyi] = (From)[yyi];		\
	}					\
      while (0)
#  endif
# endif

/* Relocate STACK from its old location to the new one.  The
   local variables YYSIZE and YYSTACKSIZE give the old and new number of
   elements in the stack, and YYPTR gives the new location of the
   stack.  Advance YYPTR to a properly aligned location for the next
   stack.  */
# define YYSTACK_RELOCATE(Stack)					\
    do									\
      {									\
	YYSIZE_T yynewbytes;						\
	YYCOPY (&yyptr->Stack, Stack, yysize);				\
	Stack = &yyptr->Stack;						\
	yynewbytes = yystacksize * sizeof (*Stack) + YYSTACK_GAP_MAXIMUM; \
	yyptr += yynewbytes / sizeof (*yyptr);				\
      }									\
    while (0)

#endif

#if defined (__STDC__) || defined (__cplusplus)
   typedef signed char yysigned_char;
#else
   typedef short int yysigned_char;
#endif

/* YYFINAL -- State number of the termination state. */
#define YYFINAL  2
/* YYLAST -- Last index in YYTABLE.  */
#define YYLAST   481

/* YYNTOKENS -- Number of terminals. */
#define YYNTOKENS  95
/* YYNNTS -- Number of nonterminals. */
#define YYNNTS  96
/* YYNRULES -- Number of rules. */
#define YYNRULES  182
/* YYNRULES -- Number of states. */
#define YYNSTATES  354

/* YYTRANSLATE(YYLEX) -- Bison symbol number corresponding to YYLEX.  */
#define YYUNDEFTOK  2
#define YYMAXUTOK   344

#define YYTRANSLATE(YYX)						\
  ((unsigned int) (YYX) <= YYMAXUTOK ? yytranslate[YYX] : YYUNDEFTOK)

/* YYTRANSLATE[YYLEX] -- Bison symbol number corresponding to YYLEX.  */
static const unsigned char yytranslate[] =
{
       0,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,    91,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,    93,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
      94,    92,    90,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     1,     2,     3,     4,
       5,     6,     7,     8,     9,    10,    11,    12,    13,    14,
      15,    16,    17,    18,    19,    20,    21,    22,    23,    24,
      25,    26,    27,    28,    29,    30,    31,    32,    33,    34,
      35,    36,    37,    38,    39,    40,    41,    42,    43,    44,
      45,    46,    47,    48,    49,    50,    51,    52,    53,    54,
      55,    56,    57,    58,    59,    60,    61,    62,    63,    64,
      65,    66,    67,    68,    69,    70,    71,    72,    73,    74,
      75,    76,    77,    78,    79,    80,    81,    82,    83,    84,
      85,    86,    87,    88,    89
};

#if YYDEBUG
/* YYPRHS[YYN] -- Index of the first RHS symbol of rule number YYN in
   YYRHS.  */
static const unsigned short int yyprhs[] =
{
       0,     0,     3,     4,     5,     6,    15,    18,    20,    22,
      24,    26,    28,    30,    33,    35,    36,    39,    40,    43,
      45,    47,    48,    51,    52,    55,    56,    59,    60,    63,
      65,    68,    70,    72,    74,    76,    78,    80,    82,    84,
      86,    88,    90,    92,    94,    96,    98,   100,   102,   104,
     106,   108,   111,   113,   115,   117,   119,   121,   123,   125,
     127,   129,   131,   134,   136,   138,   140,   142,   144,   146,
     148,   150,   152,   154,   156,   158,   161,   163,   165,   167,
     170,   172,   173,   176,   177,   180,   181,   184,   193,   196,
     198,   200,   202,   205,   208,   210,   212,   213,   214,   221,
     222,   229,   232,   234,   236,   238,   240,   242,   253,   264,
     265,   270,   276,   293,   310,   314,   318,   322,   326,   330,
     334,   335,   340,   344,   348,   352,   356,   360,   364,   368,
     374,   378,   382,   385,   387,   393,   397,   401,   402,   403,
     409,   410,   414,   415,   416,   424,   429,   430,   437,   438,
     444,   448,   452,   457,   462,   463,   464,   470,   473,   479,
     484,   488,   491,   495,   498,   502,   505,   509,   510,   515,
     516,   521,   522,   527,   530,   532,   541,   550,   558,   561,
     563,   565,   567
};

/* YYRHS -- A `-1'-separated list of the rules' RHS. */
static const short int yyrhs[] =
{
      96,     0,    -1,    -1,    -1,    -1,    96,    49,    97,   126,
      98,    90,    99,    50,    -1,    99,   100,    -1,   100,    -1,
     174,    -1,   177,    -1,   178,    -1,   179,    -1,   180,    -1,
     101,   102,    -1,   102,    -1,    -1,   103,   158,    -1,    -1,
     104,   159,    -1,   160,    -1,   164,    -1,    -1,   105,   167,
      -1,    -1,   106,   170,    -1,    -1,   107,   171,    -1,    -1,
     108,   172,    -1,   180,    -1,   109,   110,    -1,   110,    -1,
     138,    -1,   170,    -1,   139,    -1,   140,    -1,   158,    -1,
     141,    -1,   159,    -1,   142,    -1,   167,    -1,   143,    -1,
     144,    -1,   146,    -1,   147,    -1,   148,    -1,   149,    -1,
     150,    -1,   151,    -1,   152,    -1,   180,    -1,   111,   112,
      -1,   112,    -1,   158,    -1,   141,    -1,   159,    -1,   142,
      -1,   167,    -1,   154,    -1,   144,    -1,   180,    -1,   153,
      -1,   113,   114,    -1,   114,    -1,   158,    -1,   141,    -1,
     159,    -1,   142,    -1,   167,    -1,   154,    -1,   144,    -1,
     180,    -1,   155,    -1,   156,    -1,   180,    -1,   116,   117,
      -1,   117,    -1,   181,    -1,   144,    -1,   118,   119,    -1,
     119,    -1,    -1,   120,   158,    -1,    -1,   121,   173,    -1,
      -1,   122,   167,    -1,    12,    91,    11,    91,    13,    91,
      11,    91,    -1,   124,   125,    -1,   125,    -1,   183,    -1,
     185,    -1,   129,   127,    -1,   127,   129,    -1,   127,    -1,
     129,    -1,    -1,    -1,     3,   128,    92,    91,   133,    91,
      -1,    -1,     4,   130,    92,    91,   131,    91,    -1,   131,
     132,    -1,   132,    -1,    10,    -1,    11,    -1,     9,    -1,
      10,    -1,     6,    92,    91,    10,    91,     7,    92,    91,
      10,    91,    -1,     7,    92,    91,    10,    91,     6,    92,
      91,    10,    91,    -1,    -1,    85,    91,    11,    91,    -1,
       5,    92,    91,     8,    91,    -1,    86,    91,    10,    91,
      87,    91,    10,    91,    88,    91,    10,    91,    89,    91,
      10,    91,    -1,    88,    91,    10,    91,    89,    91,    10,
      91,    86,    91,    10,    91,    87,    91,    10,    91,    -1,
      51,    10,    52,    -1,    53,    10,    54,    -1,    55,    10,
      56,    -1,    57,   189,    58,    -1,    59,   189,    60,    -1,
      61,   189,    62,    -1,    -1,   145,    39,   189,    40,    -1,
      63,   189,    64,    -1,    65,     9,    66,    -1,    67,    10,
      68,    -1,    69,    10,    70,    -1,    71,    10,    72,    -1,
      73,    10,    74,    -1,    75,     9,    76,    -1,    77,   134,
      90,   109,    78,    -1,    79,     9,    80,    -1,    81,   115,
      82,    -1,   156,   157,    -1,   157,    -1,    83,   134,    90,
     109,    84,    -1,    18,   189,    19,    -1,    22,   189,    23,
      -1,    -1,    -1,    15,   161,   118,   162,    16,    -1,    -1,
      15,   163,    16,    -1,    -1,    -1,    26,   135,    90,   165,
     124,   166,    27,    -1,    26,   135,    90,    27,    -1,    -1,
      20,   168,   136,    90,   116,    21,    -1,    -1,    20,   169,
      90,   116,    21,    -1,    28,    14,    29,    -1,    30,   189,
      31,    -1,    34,   137,    93,    90,    -1,    17,   123,    93,
      90,    -1,    -1,    -1,    41,   175,   101,   176,    42,    -1,
      41,    42,    -1,    43,   134,    90,   109,    44,    -1,    43,
     134,    90,    44,    -1,    45,   111,    46,    -1,    45,    46,
      -1,    47,   113,    48,    -1,    47,    48,    -1,    32,   187,
      33,    -1,    32,    33,    -1,    32,   189,    33,    -1,    -1,
     182,    24,   189,    25,    -1,    -1,    35,     9,   184,    36,
      -1,    -1,    37,     8,   186,    38,    -1,   187,   188,    -1,
     188,    -1,    94,    11,    90,   189,    94,    93,    11,    90,
      -1,    94,    11,    90,   187,    94,    93,    11,    90,    -1,
      94,    11,    90,    94,    93,    11,    90,    -1,   189,   190,
      -1,   190,    -1,     9,    -1,    10,    -1,    11,    -1
};

/* YYRLINE[YYN] -- source line where rule number YYN was defined.  */
static const unsigned short int yyrline[] =
{
       0,   148,   148,   150,   157,   150,   167,   167,   169,   176,
     179,   183,   187,   201,   201,   204,   204,   212,   212,   219,
     225,   232,   232,   236,   236,   244,   244,   252,   252,   259,
     273,   273,   275,   281,   287,   293,   299,   305,   311,   317,
     323,   325,   331,   337,   343,   349,   355,   361,   367,   373,
     379,   393,   393,   395,   401,   407,   413,   419,   421,   427,
     433,   439,   449,   449,   451,   457,   463,   469,   475,   477,
     483,   489,   495,   506,   508,   522,   522,   524,   530,   544,
     544,   547,   547,   555,   555,   563,   563,   581,   590,   590,
     591,   597,   617,   618,   619,   620,   621,   631,   631,   640,
     640,   649,   649,   650,   650,   650,   659,   669,   671,   673,
     683,   692,   704,   718,   748,   761,   775,   784,   793,   802,
     811,   811,   820,   830,   843,   852,   861,   870,   879,   892,
     902,   916,   925,   925,   926,   935,   944,   954,   956,   953,
     959,   959,   970,   972,   968,   975,   985,   985,   987,   987,
     997,  1014,  1023,  1032,  1042,  1044,  1041,  1049,  1059,  1065,
    1075,  1080,  1094,  1099,  1112,  1114,  1116,  1126,  1126,  1135,
    1135,  1144,  1144,  1153,  1153,  1155,  1159,  1163,  1191,  1191,
    1192,  1192,  1192
};
#endif

#if YYDEBUG || YYERROR_VERBOSE || YYTOKEN_TABLE
/* YYTNAME[SYMBOL-NUM] -- String name of the symbol SYMBOL-NUM.
   First, the terminals, then, starting at YYNTOKENS, nonterminals. */
static const char *const yytname[] =
{
  "$end", "error", "$undefined", "VERSION", "CREATOR", "HREF", "LAT",
  "LON", "URL", "INTEGER", "DECIMAL", "STRING", "ID_EMAIL", "DOMAIN_EMAIL",
  "DATA_HORA", "AUTHOR_ABRE_TAG", "AUTHOR_FECHA_TAG", "EMAIL_ABRE_TAG",
  "NAME_ABRE_TAG", "NAME_FECHA_TAG", "LINK_ABRE_TAG", "LINK_FECHA_TAG",
  "DESC_ABRE_TAG", "DESC_FECHA_TAG", "TEXT_ABRE_TAG", "TEXT_FECHA_TAG",
  "COPYRIGHT_ABRE_TAG", "COPYRIGHT_FECHA_TAG", "TIME_ABRE_TAG",
  "TIME_FECHA_TAG", "KEYWORDS_ABRE_TAG", "KEYWORDS_FECHA_TAG",
  "EXTENSIONS_ABRE_TAG", "EXTENSIONS_FECHA_TAG", "BOUNDS_ABRE_TAG",
  "YEAR_ABRE_TAG", "YEAR_FECHA_TAG", "LICENSE_ABRE_TAG",
  "LICENSE_FECHA_TAG", "TYPE_ABRE_TAG", "TYPE_FECHA_TAG",
  "METADATA_ABRE_TAG", "METADATA_FECHA_TAG", "WPT_ABRE_TAG",
  "WPT_FECHA_TAG", "RTE_ABRE_TAG", "RTE_FECHA_TAG", "TRK_ABRE_TAG",
  "TRK_FECHA_TAG", "ABRE_TAG_GPX", "FECHA_TAG_GPX", "ELE_ABRE_TAG",
  "ELE_FECHA_TAG", "MAGVAR_ABRE_TAG", "MAGVAR_FECHA_TAG",
  "GEOIDHEIGHT_ABRE_TAG", "GEOIDHEIGHT_FECHA_TAG", "CMT_ABRE_TAG",
  "CMT_FECHA_TAG", "SRC_ABRE_TAG", "SRC_FECHA_TAG", "SYM_ABRE_TAG",
  "SYM_FECHA_TAG", "FIX_ABRE_TAG", "FIX_FECHA_TAG", "SAT_ABRE_TAG",
  "SAT_FECHA_TAG", "HDOP_ABRE_TAG", "HDOP_FECHA_TAG", "VDOP_ABRE_TAG",
  "VDOP_FECHA_TAG", "PDOP_ABRE_TAG", "PDOP_FECHA_TAG",
  "AGEOFDGPSDATA_ABRE_TAG", "AGEOFDGPSDATA_FECHA_TAG", "DGPSID_ABRE_TAG",
  "DGPSID_FECHA_TAG", "RTEPT_ABRE_TAG", "RTEPT_FECHA_TAG",
  "NUMBER_ABRE_TAG", "NUMBER_FECHA_TAG", "TRKSEG_ABRE_TAG",
  "TRKSEG_FECHA_TAG", "TRKPT_ABRE_TAG", "TRKPT_FECHA_TAG",
  "COPYRIGHT_AUTHOR", "MIN_LAT", "MIN_LON", "MAX_LAT", "MAX_LON", "'>'",
  "'\"'", "'='", "'/'", "'<'", "$accept", "gpx", "@1", "@2", "gpxType",
  "gpxTypeTag", "metadataType", "metadataTypeTag", "@3", "@4", "@5", "@6",
  "@7", "@8", "wptType", "wptTypeTag", "rteType", "rteTypeTag", "trkType",
  "trkTypeTag", "trksegType", "linkType", "linkTypeTag", "personType",
  "personTypeTag", "@9", "@10", "@11", "emailType", "copyrightType",
  "copyrightTypeTag", "atributosGPX", "atributoGPXVersao", "@12",
  "atributoGPXCreator", "@13", "valCreator", "val", "valVersion",
  "atributosWpt", "atributosCopyright", "linkTypeHref", "atributosBounds",
  "tagEle", "tagMagvar", "tagGeoidheight", "tagCmt", "tagSrc", "tagSym",
  "tagType", "@14", "tagFix", "tagSat", "tagHdop", "tagVdop", "tagPdop",
  "tagAgeofdgpsdata", "tagDgpsid", "tagRtept", "tagNumber", "tagsTrkseg",
  "tagsTrkpt", "tagTrkpt", "tagName", "tagDesc", "tagAuthor", "@15", "@16",
  "@17", "tagCopyright", "@18", "@19", "tagLink", "@20", "@21", "tagTime",
  "tagKeywords", "tagBounds", "tagEmail", "tagMetadata", "@22", "@23",
  "tagWpt", "tagRte", "tagTrk", "tagExtensions", "tagText", "@24",
  "tagYear", "@25", "tagLicense", "@26", "tagsAleatorias", "tagAleatoria",
  "valores", "valor", 0
};
#endif

# ifdef YYPRINT
/* YYTOKNUM[YYLEX-NUM] -- Internal token number corresponding to
   token YYLEX-NUM.  */
static const unsigned short int yytoknum[] =
{
       0,   256,   257,   258,   259,   260,   261,   262,   263,   264,
     265,   266,   267,   268,   269,   270,   271,   272,   273,   274,
     275,   276,   277,   278,   279,   280,   281,   282,   283,   284,
     285,   286,   287,   288,   289,   290,   291,   292,   293,   294,
     295,   296,   297,   298,   299,   300,   301,   302,   303,   304,
     305,   306,   307,   308,   309,   310,   311,   312,   313,   314,
     315,   316,   317,   318,   319,   320,   321,   322,   323,   324,
     325,   326,   327,   328,   329,   330,   331,   332,   333,   334,
     335,   336,   337,   338,   339,   340,   341,   342,   343,   344,
      62,    34,    61,    47,    60
};
# endif

/* YYR1[YYN] -- Symbol number of symbol that rule YYN derives.  */
static const unsigned char yyr1[] =
{
       0,    95,    96,    97,    98,    96,    99,    99,   100,   100,
     100,   100,   100,   101,   101,   103,   102,   104,   102,   102,
     102,   105,   102,   106,   102,   107,   102,   108,   102,   102,
     109,   109,   110,   110,   110,   110,   110,   110,   110,   110,
     110,   110,   110,   110,   110,   110,   110,   110,   110,   110,
     110,   111,   111,   112,   112,   112,   112,   112,   112,   112,
     112,   112,   113,   113,   114,   114,   114,   114,   114,   114,
     114,   114,   114,   115,   115,   116,   116,   117,   117,   118,
     118,   120,   119,   121,   119,   122,   119,   123,   124,   124,
     125,   125,   126,   126,   126,   126,   126,   128,   127,   130,
     129,   131,   131,   132,   132,   132,   133,   134,   134,   134,
     135,   136,   137,   137,   138,   139,   140,   141,   142,   143,
     145,   144,   146,   147,   148,   149,   150,   151,   152,   153,
     154,   155,   156,   156,   157,   158,   159,   161,   162,   160,
     163,   160,   165,   166,   164,   164,   168,   167,   169,   167,
     170,   171,   172,   173,   175,   176,   174,   174,   177,   177,
     178,   178,   179,   179,   180,   180,   180,   182,   181,   184,
     183,   186,   185,   187,   187,   188,   188,   188,   189,   189,
     190,   190,   190
};

/* YYR2[YYN] -- Number of symbols composing right hand side of rule YYN.  */
static const unsigned char yyr2[] =
{
       0,     2,     0,     0,     0,     8,     2,     1,     1,     1,
       1,     1,     1,     2,     1,     0,     2,     0,     2,     1,
       1,     0,     2,     0,     2,     0,     2,     0,     2,     1,
       2,     1,     1,     1,     1,     1,     1,     1,     1,     1,
       1,     1,     1,     1,     1,     1,     1,     1,     1,     1,
       1,     2,     1,     1,     1,     1,     1,     1,     1,     1,
       1,     1,     2,     1,     1,     1,     1,     1,     1,     1,
       1,     1,     1,     1,     1,     2,     1,     1,     1,     2,
       1,     0,     2,     0,     2,     0,     2,     8,     2,     1,
       1,     1,     2,     2,     1,     1,     0,     0,     6,     0,
       6,     2,     1,     1,     1,     1,     1,    10,    10,     0,
       4,     5,    16,    16,     3,     3,     3,     3,     3,     3,
       0,     4,     3,     3,     3,     3,     3,     3,     3,     5,
       3,     3,     2,     1,     5,     3,     3,     0,     0,     5,
       0,     3,     0,     0,     7,     4,     0,     6,     0,     5,
       3,     3,     4,     4,     0,     0,     5,     2,     5,     4,
       3,     2,     3,     2,     3,     2,     3,     0,     4,     0,
       4,     0,     4,     2,     1,     8,     8,     7,     2,     1,
       1,     1,     1
};

/* YYDEFACT[STATE-NAME] -- Default rule to reduce with in state
   STATE-NUM when YYTABLE doesn't specify something else to do.  Zero
   means the default is an error.  */
static const unsigned char yydefact[] =
{
       2,     0,     1,     3,    96,    97,    99,     4,    94,    95,
       0,     0,     0,    93,    92,     0,     0,     0,     0,     0,
       0,   154,   109,   120,   120,     0,     7,     8,     9,    10,
      11,    12,   106,     0,   105,   103,   104,     0,   102,   180,
     181,   182,   165,     0,     0,   174,     0,   179,   157,    15,
       0,     0,     0,     0,   146,     0,   161,     0,     0,   109,
       0,   120,    52,    54,    56,    59,     0,    61,    58,    53,
      55,    57,    60,   163,     0,   120,    63,    65,    67,    70,
      69,    72,    64,    66,    68,    71,     5,     6,    98,   100,
     101,     0,   164,   173,   166,   178,   137,     0,    15,    14,
       0,     0,     0,     0,     0,     0,    19,    20,    29,     0,
       0,   120,     0,     0,     0,     0,     0,     0,     0,     0,
     160,    51,     0,   109,     0,    73,   133,    74,   162,    62,
       0,    81,     0,     0,     0,    13,     0,    16,    18,    22,
       0,    24,     0,    26,     0,    28,     0,     0,   159,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
     120,    31,    32,    34,    35,    37,    39,    41,    42,    43,
      44,    45,    46,    47,    48,    49,    36,    38,    40,    33,
      50,   135,     0,     0,   120,   136,   117,   118,   120,   130,
       0,     0,   131,   132,     0,     0,     0,    81,    80,     0,
       0,     0,   141,     0,   142,   156,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,   158,    30,     0,   120,   120,    76,
      78,    77,     0,   120,   121,   120,     0,     0,     0,    79,
       0,    82,     0,    84,    86,     0,   145,     0,   150,   151,
       0,     0,     0,     0,     0,   114,   115,   116,   119,   122,
     123,   124,   125,   126,   127,   128,     0,   120,   149,    75,
       0,   129,   120,     0,     0,     0,   139,     0,     0,   110,
       0,     0,   143,    89,    90,    91,     0,     0,   152,     0,
       0,     0,   147,     0,   134,   177,     0,     0,     0,     0,
     169,   171,    88,     0,     0,     0,     0,     0,   111,   168,
     176,   175,     0,   153,     0,     0,   144,     0,     0,     0,
       0,     0,   170,   172,     0,     0,     0,     0,     0,     0,
       0,   107,   108,     0,     0,     0,     0,     0,     0,    87,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,   112,   113
};

/* YYDEFGOTO[NTERM-NUM]. */
static const short int yydefgoto[] =
{
      -1,     1,     4,    12,    25,    26,    98,    99,   100,   101,
     102,   103,   104,   105,   160,   161,    61,    62,    75,    76,
     124,   228,   229,   197,   198,   199,   200,   201,   278,   282,
     283,     7,     8,    10,     9,    11,    37,    38,    33,    52,
     134,   183,   210,   162,   163,   164,   165,   166,   167,   168,
      66,   169,   170,   171,   172,   173,   174,   175,    67,    68,
      81,   125,   126,   176,   177,   106,   131,   240,   132,   107,
     247,   303,   178,   113,   114,   179,   143,   145,   243,    27,
      49,   136,    28,    29,    30,   180,   231,   232,   284,   314,
     285,   315,    44,    45,    46,    47
};

/* YYPACT[STATE-NUM] -- Index in YYTABLE of the portion describing
   STATE-NUM.  */
#define YYPACT_NINF -167
static const short int yypact[] =
{
    -167,    29,  -167,  -167,    30,  -167,  -167,  -167,    33,    51,
     -15,   -10,    34,  -167,  -167,    -1,    41,   167,   101,   185,
       5,    83,    42,   212,    94,   209,  -167,  -167,  -167,  -167,
    -167,  -167,  -167,    55,  -167,  -167,  -167,    17,  -167,  -167,
    -167,  -167,  -167,   137,    -8,  -167,   174,  -167,  -167,   374,
      60,    62,    74,   251,    76,   251,  -167,   251,   251,    42,
     165,   217,  -167,  -167,  -167,  -167,   140,  -167,  -167,  -167,
    -167,  -167,  -167,  -167,     8,   145,  -167,  -167,  -167,  -167,
    -167,  -167,  -167,  -167,  -167,  -167,  -167,  -167,  -167,  -167,
    -167,    91,  -167,  -167,  -167,  -167,   166,   106,   115,  -167,
     179,   176,   180,   173,   186,   169,  -167,  -167,  -167,   127,
     131,   280,   274,   223,   146,   256,    65,    46,   148,   160,
    -167,  -167,   251,    42,   161,   163,  -167,  -167,  -167,  -167,
      10,   114,   232,   162,   183,  -167,   213,  -167,  -167,  -167,
     237,  -167,   251,  -167,   -23,  -167,   247,   254,  -167,   265,
     267,   270,   251,   251,   272,   276,   277,   278,   282,   281,
     312,  -167,  -167,  -167,  -167,  -167,  -167,  -167,  -167,  -167,
    -167,  -167,  -167,  -167,  -167,  -167,  -167,  -167,  -167,  -167,
    -167,  -167,   203,   207,   275,  -167,  -167,  -167,   340,  -167,
     118,   214,  -167,  -167,     0,   216,    13,   152,  -167,   179,
     289,   180,  -167,   303,   291,  -167,   287,   129,   229,   231,
     233,   236,   238,   284,   288,   290,    32,    21,   286,   293,
     268,   285,   292,   283,  -167,  -167,   257,   275,   135,  -167,
    -167,  -167,   326,   250,  -167,   340,   343,     7,   271,  -167,
     354,  -167,   362,  -167,  -167,   295,  -167,    80,  -167,  -167,
     366,   368,   294,   373,   376,  -167,  -167,  -167,  -167,  -167,
    -167,  -167,  -167,  -167,  -167,  -167,   380,   168,  -167,  -167,
     251,  -167,   158,   300,   381,   387,  -167,   319,   321,  -167,
     403,   408,    80,  -167,  -167,  -167,   327,   328,  -167,   325,
     329,   331,  -167,   111,  -167,  -167,   330,   333,   413,   335,
    -167,  -167,  -167,   399,   341,   338,   339,   342,  -167,  -167,
    -167,  -167,   344,  -167,   393,   394,  -167,   345,   346,   421,
     424,   425,  -167,  -167,   429,   430,   350,   351,   352,   353,
     355,  -167,  -167,   434,   359,   363,   357,   360,   361,  -167,
     440,   443,   364,   365,   369,   367,   370,   371,   447,   449,
     372,   375,  -167,  -167
};

/* YYPGOTO[NTERM-NUM].  */
static const short int yypgoto[] =
{
    -167,  -167,  -167,  -167,  -167,   435,  -167,   377,  -167,  -167,
    -167,  -167,  -167,  -167,  -137,  -154,  -167,   404,  -167,   389,
    -167,   240,  -166,  -167,   273,  -167,  -167,  -167,  -167,  -167,
     187,  -167,   459,  -167,   463,  -167,  -167,   436,  -167,   -42,
    -167,  -167,  -167,  -167,  -167,  -167,    22,    44,  -167,   -22,
    -167,  -167,  -167,  -167,  -167,  -167,  -167,  -167,  -167,    20,
    -167,  -167,   347,   -11,    12,  -167,  -167,  -167,  -167,  -167,
    -167,  -167,   -14,  -167,  -167,   378,  -167,  -167,  -167,  -167,
    -167,  -167,  -167,  -167,  -167,    35,  -167,  -167,  -167,  -167,
    -167,  -167,   348,   -40,   -50,   -46
};

/* YYTABLE[YYPACT[STATE-NUM]].  What to do in state STATE-NUM.  If
   positive, shift that token.  If negative, reduce the rule which
   number is the opposite.  If zero, do what YYDEFACT says.
   If YYTABLE_NINF, syntax error.  */
#define YYTABLE_NINF -168
static const short int yytable[] =
{
      95,    65,    79,   112,    93,   115,   225,   116,   117,    71,
      84,    91,    69,    82,    39,    40,    41,   118,    91,    39,
      40,    41,    39,    40,    41,    92,    34,    35,    36,     2,
      39,    40,    41,     5,     6,    70,    83,     6,    42,    65,
      20,    39,    40,    41,    80,    63,    77,    71,    50,    51,
      69,   233,    31,    79,     5,    39,    40,    41,    72,    85,
      31,    84,   269,   208,    82,   209,    95,    64,    78,    95,
      95,    95,   190,    70,    39,    40,    41,    15,     3,   225,
     196,   191,    16,    63,   108,   259,    43,    83,   139,   137,
      18,   123,   207,   236,   258,    80,    72,    77,   272,    43,
     274,   269,   216,   217,   194,    64,   187,   238,    89,   127,
      85,    32,    53,   138,    54,   280,    55,   281,   225,    78,
      39,    40,    41,   186,    17,    48,    20,    39,    40,    41,
      96,   -83,    19,   108,   -85,   -21,   309,   -17,    39,    40,
      41,    97,    73,   -23,    95,   -25,    88,    20,    91,   -27,
      95,    57,   109,    58,   110,    93,   268,  -155,   234,  -167,
     249,    95,   230,    53,   111,    54,  -148,    55,  -138,   -83,
      95,    95,   -85,    60,   119,    74,    53,    20,    54,   122,
      55,   130,  -140,    39,    40,    41,   140,   244,   241,   292,
      20,   133,  -167,   128,    34,    35,    36,    53,    55,    20,
      54,   140,    57,   144,    58,   230,   230,    94,    21,   149,
      22,   150,    23,   151,    24,    57,   142,    58,   146,   152,
     293,   153,   147,   154,    60,   155,    74,   156,   182,   157,
      53,   158,    54,   159,    55,    53,   184,    54,   188,    55,
     189,    20,   294,   192,    20,   230,   123,    95,   202,    20,
      21,   206,    22,   203,    23,   205,    24,   211,    56,    86,
      39,    40,    41,   120,   212,    39,    40,    41,    53,    57,
      54,    58,    55,   204,    57,   213,    58,   214,   140,   185,
     215,   218,    20,    39,    40,    41,   219,   220,   221,    59,
     223,    60,   222,   181,    59,   226,    60,   227,    53,  -167,
      54,   149,    55,   150,   235,   151,   242,    57,   140,    58,
     237,   152,    20,   153,   245,   154,   248,   155,   246,   156,
     250,   157,   251,   158,   148,   159,   252,   253,   271,   254,
      53,   149,    54,   150,    55,   151,   255,    57,   262,    58,
     140,   152,   256,   153,    20,   154,   257,   155,   266,   156,
     270,   157,   260,   158,   273,   159,   224,   263,    53,   265,
      54,   261,    55,   149,   275,   150,   264,   151,   140,    57,
     276,    58,    20,   152,   277,   153,   286,   154,   287,   155,
     289,   156,   290,   157,   288,   158,   279,   159,   291,    96,
     295,   149,   296,   150,   -21,   151,   -17,    57,   297,    58,
      97,   152,   -23,   153,   -25,   154,    20,   155,   -27,   156,
     298,   157,   300,   158,   299,   159,   301,   306,   304,   305,
     310,   307,   308,   311,   312,   313,   316,   318,   317,   322,
     319,   326,   323,   320,   327,   321,   324,   325,   328,   329,
     330,   331,   332,   333,   334,   336,   335,   337,   339,   338,
     342,   340,   341,   343,   347,   344,   345,   350,   346,   351,
      87,   348,   349,   352,   129,   121,   353,   267,    14,   302,
     239,    13,   193,    90,     0,   135,     0,     0,   195,     0,
       0,   141
};

static const short int yycheck[] =
{
      46,    23,    24,    53,    44,    55,   160,    57,    58,    23,
      24,    11,    23,    24,     9,    10,    11,    59,    11,     9,
      10,    11,     9,    10,    11,    33,     9,    10,    11,     0,
       9,    10,    11,     3,     4,    23,    24,     4,    33,    61,
      32,     9,    10,    11,    24,    23,    24,    61,     6,     7,
      61,   188,    17,    75,     3,     9,    10,    11,    23,    24,
      25,    75,   228,    86,    75,    88,   112,    23,    24,   115,
     116,   117,   122,    61,     9,    10,    11,    92,    49,   233,
     130,   123,    92,    61,    49,    64,    94,    75,   102,   100,
      91,    83,   142,    93,    62,    75,    61,    75,   235,    94,
      93,   267,   152,   153,    94,    61,    60,    94,    91,    74,
      75,    10,    18,   101,    20,    35,    22,    37,   272,    75,
       9,    10,    11,    58,    90,    42,    32,     9,    10,    11,
      15,    17,    91,    98,    20,    20,    25,    22,     9,    10,
      11,    26,    48,    28,   190,    30,    91,    32,    11,    34,
     196,    57,    92,    59,    92,   195,    21,    42,    40,    24,
      31,   207,   184,    18,    90,    20,    90,    22,    16,    17,
     216,   217,    20,    79,     9,    81,    18,    32,    20,    39,
      22,    90,    16,     9,    10,    11,    28,   201,   199,    21,
      32,    85,    24,    48,     9,    10,    11,    18,    22,    32,
      20,    28,    57,    34,    59,   227,   228,    33,    41,    51,
      43,    53,    45,    55,    47,    57,    30,    59,    91,    61,
     270,    63,    91,    65,    79,    67,    81,    69,     5,    71,
      18,    73,    20,    75,    22,    18,    90,    20,    90,    22,
      80,    32,    84,    82,    32,   267,    83,   293,    16,    32,
      41,    14,    43,    91,    45,    42,    47,    10,    46,    50,
       9,    10,    11,    46,    10,     9,    10,    11,    18,    57,
      20,    59,    22,    90,    57,    10,    59,    10,    28,    23,
      10,     9,    32,     9,    10,    11,    10,    10,    10,    77,
       9,    79,    10,    19,    77,    92,    79,    90,    18,    24,
      20,    51,    22,    53,    90,    55,    17,    57,    28,    59,
      94,    61,    32,    63,    11,    65,    29,    67,    27,    69,
      91,    71,    91,    73,    44,    75,    93,    91,    78,    91,
      18,    51,    20,    53,    22,    55,    52,    57,    70,    59,
      28,    61,    54,    63,    32,    65,    56,    67,    91,    69,
      24,    71,    66,    73,    11,    75,    44,    72,    18,    76,
      20,    68,    22,    51,    93,    53,    74,    55,    28,    57,
      16,    59,    32,    61,    12,    63,    10,    65,    10,    67,
       7,    69,     6,    71,    90,    73,    91,    75,     8,    15,
      90,    51,    11,    53,    20,    55,    22,    57,    11,    59,
      26,    61,    28,    63,    30,    65,    32,    67,    34,    69,
      91,    71,     9,    73,    93,    75,     8,    92,    91,    91,
      90,    92,    91,    90,    11,    90,    27,    89,    87,    36,
      91,    10,    38,    91,    10,    91,    91,    91,    13,    10,
      10,    91,    91,    91,    91,    11,    91,    88,    91,    86,
      10,    91,    91,    10,    87,    91,    91,    10,    89,    10,
      25,    91,    91,    91,    75,    61,    91,   227,     9,   282,
     197,     8,   125,    37,    -1,    98,    -1,    -1,   130,    -1,
      -1,   103
};

/* YYSTOS[STATE-NUM] -- The (internal number of the) accessing
   symbol of state STATE-NUM.  */
static const unsigned char yystos[] =
{
       0,    96,     0,    49,    97,     3,     4,   126,   127,   129,
     128,   130,    98,   129,   127,    92,    92,    90,    91,    91,
      32,    41,    43,    45,    47,    99,   100,   174,   177,   178,
     179,   180,    10,   133,     9,    10,    11,   131,   132,     9,
      10,    11,    33,    94,   187,   188,   189,   190,    42,   175,
       6,     7,   134,    18,    20,    22,    46,    57,    59,    77,
      79,   111,   112,   141,   142,   144,   145,   153,   154,   158,
     159,   167,   180,    48,    81,   113,   114,   141,   142,   144,
     154,   155,   158,   159,   167,   180,    50,   100,    91,    91,
     132,    11,    33,   188,    33,   190,    15,    26,   101,   102,
     103,   104,   105,   106,   107,   108,   160,   164,   180,    92,
      92,    90,   189,   168,   169,   189,   189,   189,   134,     9,
      46,   112,    39,    83,   115,   156,   157,   180,    48,   114,
      90,   161,   163,    85,   135,   102,   176,   158,   159,   167,
      28,   170,    30,   171,    34,   172,    91,    91,    44,    51,
      53,    55,    61,    63,    65,    67,    69,    71,    73,    75,
     109,   110,   138,   139,   140,   141,   142,   143,   144,   146,
     147,   148,   149,   150,   151,   152,   158,   159,   167,   170,
     180,    19,     5,   136,    90,    23,    58,    60,    90,    80,
     189,   134,    82,   157,    94,   187,   189,   118,   119,   120,
     121,   122,    16,    91,    90,    42,    14,   189,    86,    88,
     137,    10,    10,    10,    10,    10,   189,   189,     9,    10,
      10,    10,    10,     9,    44,   110,    92,    90,   116,   117,
     144,   181,   182,   109,    40,    90,    93,    94,    94,   119,
     162,   158,    17,   173,   167,    11,    27,   165,    29,    31,
      91,    91,    93,    91,    91,    52,    54,    56,    62,    64,
      66,    68,    70,    72,    74,    76,    91,   116,    21,   117,
      24,    78,   109,    11,    93,    93,    16,    12,   123,    91,
      35,    37,   124,   125,   183,   185,    10,    10,    90,     7,
       6,     8,    21,   189,    84,    90,    11,    11,    91,    93,
       9,     8,   125,   166,    91,    91,    92,    92,    91,    25,
      90,    90,    11,    90,   184,   186,    27,    87,    89,    91,
      91,    91,    36,    38,    91,    91,    10,    10,    13,    10,
      10,    91,    91,    91,    91,    91,    11,    88,    86,    91,
      91,    91,    10,    10,    91,    91,    89,    87,    91,    91,
      10,    10,    91,    91
};

#define yyerrok		(yyerrstatus = 0)
#define yyclearin	(yychar = YYEMPTY)
#define YYEMPTY		(-2)
#define YYEOF		0

#define YYACCEPT	goto yyacceptlab
#define YYABORT		goto yyabortlab
#define YYERROR		goto yyerrorlab


/* Like YYERROR except do call yyerror.  This remains here temporarily
   to ease the transition to the new meaning of YYERROR, for GCC.
   Once GCC version 2 has supplanted version 1, this can go.  */

#define YYFAIL		goto yyerrlab

#define YYRECOVERING()  (!!yyerrstatus)

#define YYBACKUP(Token, Value)					\
do								\
  if (yychar == YYEMPTY && yylen == 1)				\
    {								\
      yychar = (Token);						\
      yylval = (Value);						\
      yytoken = YYTRANSLATE (yychar);				\
      YYPOPSTACK;						\
      goto yybackup;						\
    }								\
  else								\
    {								\
      yyerror (YY_("syntax error: cannot back up")); \
      YYERROR;							\
    }								\
while (0)


#define YYTERROR	1
#define YYERRCODE	256


/* YYLLOC_DEFAULT -- Set CURRENT to span from RHS[1] to RHS[N].
   If N is 0, then set CURRENT to the empty location which ends
   the previous symbol: RHS[0] (always defined).  */

#define YYRHSLOC(Rhs, K) ((Rhs)[K])
#ifndef YYLLOC_DEFAULT
# define YYLLOC_DEFAULT(Current, Rhs, N)				\
    do									\
      if (N)								\
	{								\
	  (Current).first_line   = YYRHSLOC (Rhs, 1).first_line;	\
	  (Current).first_column = YYRHSLOC (Rhs, 1).first_column;	\
	  (Current).last_line    = YYRHSLOC (Rhs, N).last_line;		\
	  (Current).last_column  = YYRHSLOC (Rhs, N).last_column;	\
	}								\
      else								\
	{								\
	  (Current).first_line   = (Current).last_line   =		\
	    YYRHSLOC (Rhs, 0).last_line;				\
	  (Current).first_column = (Current).last_column =		\
	    YYRHSLOC (Rhs, 0).last_column;				\
	}								\
    while (0)
#endif


/* YY_LOCATION_PRINT -- Print the location on the stream.
   This macro was not mandated originally: define only if we know
   we won't break user code: when these are the locations we know.  */

#ifndef YY_LOCATION_PRINT
# if YYLTYPE_IS_TRIVIAL
#  define YY_LOCATION_PRINT(File, Loc)			\
     fprintf (File, "%d.%d-%d.%d",			\
              (Loc).first_line, (Loc).first_column,	\
              (Loc).last_line,  (Loc).last_column)
# else
#  define YY_LOCATION_PRINT(File, Loc) ((void) 0)
# endif
#endif


/* YYLEX -- calling `yylex' with the right arguments.  */

#ifdef YYLEX_PARAM
# define YYLEX yylex (YYLEX_PARAM)
#else
# define YYLEX yylex ()
#endif

/* Enable debugging if requested.  */
#if YYDEBUG

# ifndef YYFPRINTF
#  include <stdio.h> /* INFRINGES ON USER NAME SPACE */
#  define YYFPRINTF fprintf
# endif

# define YYDPRINTF(Args)			\
do {						\
  if (yydebug)					\
    YYFPRINTF Args;				\
} while (0)

# define YY_SYMBOL_PRINT(Title, Type, Value, Location)		\
do {								\
  if (yydebug)							\
    {								\
      YYFPRINTF (stderr, "%s ", Title);				\
      yysymprint (stderr,					\
                  Type, Value);	\
      YYFPRINTF (stderr, "\n");					\
    }								\
} while (0)

/*------------------------------------------------------------------.
| yy_stack_print -- Print the state stack from its BOTTOM up to its |
| TOP (included).                                                   |
`------------------------------------------------------------------*/

#if defined (__STDC__) || defined (__cplusplus)
static void
yy_stack_print (short int *bottom, short int *top)
#else
static void
yy_stack_print (bottom, top)
    short int *bottom;
    short int *top;
#endif
{
  YYFPRINTF (stderr, "Stack now");
  for (/* Nothing. */; bottom <= top; ++bottom)
    YYFPRINTF (stderr, " %d", *bottom);
  YYFPRINTF (stderr, "\n");
}

# define YY_STACK_PRINT(Bottom, Top)				\
do {								\
  if (yydebug)							\
    yy_stack_print ((Bottom), (Top));				\
} while (0)


/*------------------------------------------------.
| Report that the YYRULE is going to be reduced.  |
`------------------------------------------------*/

#if defined (__STDC__) || defined (__cplusplus)
static void
yy_reduce_print (int yyrule)
#else
static void
yy_reduce_print (yyrule)
    int yyrule;
#endif
{
  int yyi;
  unsigned long int yylno = yyrline[yyrule];
  YYFPRINTF (stderr, "Reducing stack by rule %d (line %lu), ",
             yyrule - 1, yylno);
  /* Print the symbols being reduced, and their result.  */
  for (yyi = yyprhs[yyrule]; 0 <= yyrhs[yyi]; yyi++)
    YYFPRINTF (stderr, "%s ", yytname[yyrhs[yyi]]);
  YYFPRINTF (stderr, "-> %s\n", yytname[yyr1[yyrule]]);
}

# define YY_REDUCE_PRINT(Rule)		\
do {					\
  if (yydebug)				\
    yy_reduce_print (Rule);		\
} while (0)

/* Nonzero means print parse trace.  It is left uninitialized so that
   multiple parsers can coexist.  */
int yydebug;
#else /* !YYDEBUG */
# define YYDPRINTF(Args)
# define YY_SYMBOL_PRINT(Title, Type, Value, Location)
# define YY_STACK_PRINT(Bottom, Top)
# define YY_REDUCE_PRINT(Rule)
#endif /* !YYDEBUG */


/* YYINITDEPTH -- initial size of the parser's stacks.  */
#ifndef	YYINITDEPTH
# define YYINITDEPTH 200
#endif

/* YYMAXDEPTH -- maximum size the stacks can grow to (effective only
   if the built-in stack extension method is used).

   Do not make this value too large; the results are undefined if
   YYSTACK_ALLOC_MAXIMUM < YYSTACK_BYTES (YYMAXDEPTH)
   evaluated with infinite-precision integer arithmetic.  */

#ifndef YYMAXDEPTH
# define YYMAXDEPTH 10000
#endif



#if YYERROR_VERBOSE

# ifndef yystrlen
#  if defined (__GLIBC__) && defined (_STRING_H)
#   define yystrlen strlen
#  else
/* Return the length of YYSTR.  */
static YYSIZE_T
#   if defined (__STDC__) || defined (__cplusplus)
yystrlen (const char *yystr)
#   else
yystrlen (yystr)
     const char *yystr;
#   endif
{
  const char *yys = yystr;

  while (*yys++ != '\0')
    continue;

  return yys - yystr - 1;
}
#  endif
# endif

# ifndef yystpcpy
#  if defined (__GLIBC__) && defined (_STRING_H) && defined (_GNU_SOURCE)
#   define yystpcpy stpcpy
#  else
/* Copy YYSRC to YYDEST, returning the address of the terminating '\0' in
   YYDEST.  */
static char *
#   if defined (__STDC__) || defined (__cplusplus)
yystpcpy (char *yydest, const char *yysrc)
#   else
yystpcpy (yydest, yysrc)
     char *yydest;
     const char *yysrc;
#   endif
{
  char *yyd = yydest;
  const char *yys = yysrc;

  while ((*yyd++ = *yys++) != '\0')
    continue;

  return yyd - 1;
}
#  endif
# endif

# ifndef yytnamerr
/* Copy to YYRES the contents of YYSTR after stripping away unnecessary
   quotes and backslashes, so that it's suitable for yyerror.  The
   heuristic is that double-quoting is unnecessary unless the string
   contains an apostrophe, a comma, or backslash (other than
   backslash-backslash).  YYSTR is taken from yytname.  If YYRES is
   null, do not copy; instead, return the length of what the result
   would have been.  */
static YYSIZE_T
yytnamerr (char *yyres, const char *yystr)
{
  if (*yystr == '"')
    {
      size_t yyn = 0;
      char const *yyp = yystr;

      for (;;)
	switch (*++yyp)
	  {
	  case '\'':
	  case ',':
	    goto do_not_strip_quotes;

	  case '\\':
	    if (*++yyp != '\\')
	      goto do_not_strip_quotes;
	    /* Fall through.  */
	  default:
	    if (yyres)
	      yyres[yyn] = *yyp;
	    yyn++;
	    break;

	  case '"':
	    if (yyres)
	      yyres[yyn] = '\0';
	    return yyn;
	  }
    do_not_strip_quotes: ;
    }

  if (! yyres)
    return yystrlen (yystr);

  return yystpcpy (yyres, yystr) - yyres;
}
# endif

#endif /* YYERROR_VERBOSE */



#if YYDEBUG
/*--------------------------------.
| Print this symbol on YYOUTPUT.  |
`--------------------------------*/

#if defined (__STDC__) || defined (__cplusplus)
static void
yysymprint (FILE *yyoutput, int yytype, YYSTYPE *yyvaluep)
#else
static void
yysymprint (yyoutput, yytype, yyvaluep)
    FILE *yyoutput;
    int yytype;
    YYSTYPE *yyvaluep;
#endif
{
  /* Pacify ``unused variable'' warnings.  */
  (void) yyvaluep;

  if (yytype < YYNTOKENS)
    YYFPRINTF (yyoutput, "token %s (", yytname[yytype]);
  else
    YYFPRINTF (yyoutput, "nterm %s (", yytname[yytype]);


# ifdef YYPRINT
  if (yytype < YYNTOKENS)
    YYPRINT (yyoutput, yytoknum[yytype], *yyvaluep);
# endif
  switch (yytype)
    {
      default:
        break;
    }
  YYFPRINTF (yyoutput, ")");
}

#endif /* ! YYDEBUG */
/*-----------------------------------------------.
| Release the memory associated to this symbol.  |
`-----------------------------------------------*/

#if defined (__STDC__) || defined (__cplusplus)
static void
yydestruct (const char *yymsg, int yytype, YYSTYPE *yyvaluep)
#else
static void
yydestruct (yymsg, yytype, yyvaluep)
    const char *yymsg;
    int yytype;
    YYSTYPE *yyvaluep;
#endif
{
  /* Pacify ``unused variable'' warnings.  */
  (void) yyvaluep;

  if (!yymsg)
    yymsg = "Deleting";
  YY_SYMBOL_PRINT (yymsg, yytype, yyvaluep, yylocationp);

  switch (yytype)
    {

      default:
        break;
    }
}


/* Prevent warnings from -Wmissing-prototypes.  */

#ifdef YYPARSE_PARAM
# if defined (__STDC__) || defined (__cplusplus)
int yyparse (void *YYPARSE_PARAM);
# else
int yyparse ();
# endif
#else /* ! YYPARSE_PARAM */
#if defined (__STDC__) || defined (__cplusplus)
int yyparse (void);
#else
int yyparse ();
#endif
#endif /* ! YYPARSE_PARAM */



/* The look-ahead symbol.  */
int yychar;

/* The semantic value of the look-ahead symbol.  */
YYSTYPE yylval;

/* Number of syntax errors so far.  */
int yynerrs;



/*----------.
| yyparse.  |
`----------*/

#ifdef YYPARSE_PARAM
# if defined (__STDC__) || defined (__cplusplus)
int yyparse (void *YYPARSE_PARAM)
# else
int yyparse (YYPARSE_PARAM)
  void *YYPARSE_PARAM;
# endif
#else /* ! YYPARSE_PARAM */
#if defined (__STDC__) || defined (__cplusplus)
int
yyparse (void)
#else
int
yyparse ()
    ;
#endif
#endif
{
  
  int yystate;
  int yyn;
  int yyresult;
  /* Number of tokens to shift before error messages enabled.  */
  int yyerrstatus;
  /* Look-ahead token as an internal (translated) token number.  */
  int yytoken = 0;

  /* Three stacks and their tools:
     `yyss': related to states,
     `yyvs': related to semantic values,
     `yyls': related to locations.

     Refer to the stacks thru separate pointers, to allow yyoverflow
     to reallocate them elsewhere.  */

  /* The state stack.  */
  short int yyssa[YYINITDEPTH];
  short int *yyss = yyssa;
  short int *yyssp;

  /* The semantic value stack.  */
  YYSTYPE yyvsa[YYINITDEPTH];
  YYSTYPE *yyvs = yyvsa;
  YYSTYPE *yyvsp;



#define YYPOPSTACK   (yyvsp--, yyssp--)

  YYSIZE_T yystacksize = YYINITDEPTH;

  /* The variables used to return semantic value and location from the
     action routines.  */
  YYSTYPE yyval;


  /* When reducing, the number of symbols on the RHS of the reduced
     rule.  */
  int yylen;

  YYDPRINTF ((stderr, "Starting parse\n"));

  yystate = 0;
  yyerrstatus = 0;
  yynerrs = 0;
  yychar = YYEMPTY;		/* Cause a token to be read.  */

  /* Initialize stack pointers.
     Waste one element of value and location stack
     so that they stay on the same level as the state stack.
     The wasted elements are never initialized.  */

  yyssp = yyss;
  yyvsp = yyvs;

  goto yysetstate;

/*------------------------------------------------------------.
| yynewstate -- Push a new state, which is found in yystate.  |
`------------------------------------------------------------*/
 yynewstate:
  /* In all cases, when you get here, the value and location stacks
     have just been pushed. so pushing a state here evens the stacks.
     */
  yyssp++;

 yysetstate:
  *yyssp = yystate;

  if (yyss + yystacksize - 1 <= yyssp)
    {
      /* Get the current used size of the three stacks, in elements.  */
      YYSIZE_T yysize = yyssp - yyss + 1;

#ifdef yyoverflow
      {
	/* Give user a chance to reallocate the stack. Use copies of
	   these so that the &'s don't force the real ones into
	   memory.  */
	YYSTYPE *yyvs1 = yyvs;
	short int *yyss1 = yyss;


	/* Each stack pointer address is followed by the size of the
	   data in use in that stack, in bytes.  This used to be a
	   conditional around just the two extra args, but that might
	   be undefined if yyoverflow is a macro.  */
	yyoverflow (YY_("memory exhausted"),
		    &yyss1, yysize * sizeof (*yyssp),
		    &yyvs1, yysize * sizeof (*yyvsp),

		    &yystacksize);

	yyss = yyss1;
	yyvs = yyvs1;
      }
#else /* no yyoverflow */
# ifndef YYSTACK_RELOCATE
      goto yyexhaustedlab;
# else
      /* Extend the stack our own way.  */
      if (YYMAXDEPTH <= yystacksize)
	goto yyexhaustedlab;
      yystacksize *= 2;
      if (YYMAXDEPTH < yystacksize)
	yystacksize = YYMAXDEPTH;

      {
	short int *yyss1 = yyss;
	union yyalloc *yyptr =
	  (union yyalloc *) YYSTACK_ALLOC (YYSTACK_BYTES (yystacksize));
	if (! yyptr)
	  goto yyexhaustedlab;
	YYSTACK_RELOCATE (yyss);
	YYSTACK_RELOCATE (yyvs);

#  undef YYSTACK_RELOCATE
	if (yyss1 != yyssa)
	  YYSTACK_FREE (yyss1);
      }
# endif
#endif /* no yyoverflow */

      yyssp = yyss + yysize - 1;
      yyvsp = yyvs + yysize - 1;


      YYDPRINTF ((stderr, "Stack size increased to %lu\n",
		  (unsigned long int) yystacksize));

      if (yyss + yystacksize - 1 <= yyssp)
	YYABORT;
    }

  YYDPRINTF ((stderr, "Entering state %d\n", yystate));

  goto yybackup;

/*-----------.
| yybackup.  |
`-----------*/
yybackup:

/* Do appropriate processing given the current state.  */
/* Read a look-ahead token if we need one and don't already have one.  */
/* yyresume: */

  /* First try to decide what to do without reference to look-ahead token.  */

  yyn = yypact[yystate];
  if (yyn == YYPACT_NINF)
    goto yydefault;

  /* Not known => get a look-ahead token if don't already have one.  */

  /* YYCHAR is either YYEMPTY or YYEOF or a valid look-ahead symbol.  */
  if (yychar == YYEMPTY)
    {
      YYDPRINTF ((stderr, "Reading a token: "));
      yychar = YYLEX;
    }

  if (yychar <= YYEOF)
    {
      yychar = yytoken = YYEOF;
      YYDPRINTF ((stderr, "Now at end of input.\n"));
    }
  else
    {
      yytoken = YYTRANSLATE (yychar);
      YY_SYMBOL_PRINT ("Next token is", yytoken, &yylval, &yylloc);
    }

  /* If the proper action on seeing token YYTOKEN is to reduce or to
     detect an error, take that action.  */
  yyn += yytoken;
  if (yyn < 0 || YYLAST < yyn || yycheck[yyn] != yytoken)
    goto yydefault;
  yyn = yytable[yyn];
  if (yyn <= 0)
    {
      if (yyn == 0 || yyn == YYTABLE_NINF)
	goto yyerrlab;
      yyn = -yyn;
      goto yyreduce;
    }

  if (yyn == YYFINAL)
    YYACCEPT;

  /* Shift the look-ahead token.  */
  YY_SYMBOL_PRINT ("Shifting", yytoken, &yylval, &yylloc);

  /* Discard the token being shifted unless it is eof.  */
  if (yychar != YYEOF)
    yychar = YYEMPTY;

  *++yyvsp = yylval;


  /* Count tokens shifted since error; after three, turn off error
     status.  */
  if (yyerrstatus)
    yyerrstatus--;

  yystate = yyn;
  goto yynewstate;


/*-----------------------------------------------------------.
| yydefault -- do the default action for the current state.  |
`-----------------------------------------------------------*/
yydefault:
  yyn = yydefact[yystate];
  if (yyn == 0)
    goto yyerrlab;
  goto yyreduce;


/*-----------------------------.
| yyreduce -- Do a reduction.  |
`-----------------------------*/
yyreduce:
  /* yyn is the number of a rule to reduce with.  */
  yylen = yyr2[yyn];

  /* If YYLEN is nonzero, implement the default value of the action:
     `$$ = $1'.

     Otherwise, the following line sets YYVAL to garbage.
     This behavior is undocumented and Bison
     users should not rely upon it.  Assigning to YYVAL
     unconditionally makes the parser a bit smaller, and it avoids a
     GCC warning that YYVAL may be used uninitialized.  */
  yyval = yyvsp[1-yylen];


  YY_REDUCE_PRINT (yyn);
  switch (yyn)
    {
        case 3:
#line 150 "gpx.y"
    {
			if(++controlo.el_gpx.gpx > 1) {
				erro("Só pode existir uma definição da tag GPX");
			}
			
			printf("\n\t[ Dados do Ficheiro GPX ]\n\t|");
			
		;}
    break;

  case 4:
#line 157 "gpx.y"
    { printf("\n\n\n"); ;}
    break;

  case 8:
#line 169 "gpx.y"
    {
				if(++controlo.el_gpx.metadata > 1) {
					erro("Só pode existir uma definição da tag METADATA dentro da tag GPX");
				}				
			;}
    break;

  case 12:
#line 187 "gpx.y"
    {
				if(++controlo.el_gpx.extensions > 1) {
					erro("Só pode existir uma definição da tag EXTENSIONS dentro da tag GPX");
				}
			;}
    break;

  case 15:
#line 204 "gpx.y"
    {if(mostraAtributo == 1) printf("\n\t|\tNome:"); ;}
    break;

  case 16:
#line 205 "gpx.y"
    {	
				if(++controlo.el_metadata_type.name > 1) {
					erro("Só pode existir uma definição da tag NAME dentro de uma tag METADATA");
				}
			;}
    break;

  case 17:
#line 212 "gpx.y"
    {if(mostraAtributo == 1) printf("\n\t|\tDescricao:"); ;}
    break;

  case 18:
#line 213 "gpx.y"
    {
				if(++controlo.el_metadata_type.desc > 1) {
					erro("Só pode existir uma definição da tag DESC dentro de uma tag METADATA");
				}
			;}
    break;

  case 19:
#line 219 "gpx.y"
    {
				if(++controlo.el_metadata_type.author > 1) {
					erro("Só pode existir uma definição da tag AUTHOR dentro de uma tag METADATA");
				}
			;}
    break;

  case 20:
#line 225 "gpx.y"
    {
				if(++controlo.el_metadata_type.copyright > 1) {
					erro("Só pode existir uma definição da tag COPYRIGHT dentro de uma tag METADATA");
				}
			;}
    break;

  case 21:
#line 232 "gpx.y"
    {if(mostraAtributo == 1) printf("\n\t|\tLink: "); ;}
    break;

  case 23:
#line 236 "gpx.y"
    {if(mostraAtributo == 1) printf("\n\t|\tData/Hora: "); ;}
    break;

  case 24:
#line 237 "gpx.y"
    {
				if(++controlo.el_metadata_type.time > 1) {
					erro("Só pode existir uma definição da tag TIME dentro de uma tag METADATA");
				}
			;}
    break;

  case 25:
#line 244 "gpx.y"
    {if(mostraAtributo == 1) printf("\n\t|\tKeywords: "); ;}
    break;

  case 26:
#line 245 "gpx.y"
    {
				if(++controlo.el_metadata_type.keywords > 1) {
					erro("Só pode existir uma definição da tag KEYWORDS dentro de uma tag METADATA");
				}
			;}
    break;

  case 27:
#line 252 "gpx.y"
    {if(mostraAtributo == 1) printf("\n\t|\tBounds: "); ;}
    break;

  case 28:
#line 253 "gpx.y"
    {
				if(++controlo.el_metadata_type.bounds > 1) {
					erro("Só pode existir uma definição da tag BOUNDS dentro de uma tag METADATA");
				}
			;}
    break;

  case 29:
#line 259 "gpx.y"
    {
				if(++controlo.el_metadata_type.extensions > 1) {
					erro("Só pode existir uma definição da tag EXTENSIONS dentro de uma tag METADATA");
				}
			;}
    break;

  case 32:
#line 275 "gpx.y"
    {
						if(++controlo.el_wpt_type.ele > 1) {
							erro("Só pode existir uma tag ELE dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 33:
#line 281 "gpx.y"
    {
						if(++controlo.el_wpt_type.time > 1) {
							erro("Só pode existir uma tag TIME dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 34:
#line 287 "gpx.y"
    {
						if(++controlo.el_wpt_type.magvar > 1) {
							erro("Só pode existir uma tag MAGVAR dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 35:
#line 293 "gpx.y"
    {
						if(++controlo.el_wpt_type.geoidheight > 1) {
							erro("Só pode existir uma tag GEOIDHEIGHT dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 36:
#line 299 "gpx.y"
    {
						if(++controlo.el_wpt_type.name > 1) {
							erro("Só pode existir uma tag NAME dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 37:
#line 305 "gpx.y"
    {
						if(++controlo.el_wpt_type.cmt > 1) {
							erro("Só pode existir uma tag CMT dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 38:
#line 311 "gpx.y"
    {
						if(++controlo.el_wpt_type.desc > 1) {
							erro("Só pode existir uma tag DESC dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 39:
#line 317 "gpx.y"
    {
						if(++controlo.el_wpt_type.src > 1) {
							erro("Só pode existir uma tag SRC dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 41:
#line 325 "gpx.y"
    {
						if(++controlo.el_wpt_type.sym > 1) {
							erro("Só pode existir uma tag SYM dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 42:
#line 331 "gpx.y"
    {
						if(++controlo.el_wpt_type.type > 1) {
							erro("Só pode existir uma tag TYPE dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 43:
#line 337 "gpx.y"
    {
						if(++controlo.el_wpt_type.fix > 1) {
							erro("Só pode existir uma tag FIX dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 44:
#line 343 "gpx.y"
    {
						if(++controlo.el_wpt_type.sat > 1) {
							erro("Só pode existir uma tag SAT dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 45:
#line 349 "gpx.y"
    {
						if(++controlo.el_wpt_type.hdop > 1) {
							erro("Só pode existir uma tag HDOP dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 46:
#line 355 "gpx.y"
    {
						if(++controlo.el_wpt_type.vdop > 1) {
							erro("Só pode existir uma tag VDOP dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 47:
#line 361 "gpx.y"
    {
						if(++controlo.el_wpt_type.pdop > 1) {
							erro("Só pode existir uma tag PDOP dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 48:
#line 367 "gpx.y"
    {
						if(++controlo.el_wpt_type.ageofdgpsdata > 1) {
							erro("Só pode existir uma tag AGEOFDGPSDATA dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 49:
#line 373 "gpx.y"
    {
						if(++controlo.el_wpt_type.dgpsid > 1) {
							erro("Só pode existir uma tag DGPSID dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 50:
#line 379 "gpx.y"
    {
						if(++controlo.el_wpt_type.extensions > 1) {
							erro("Só pode existir uma tag EXTENSIONS dentro de uma tag WPT || RTEPT || TRKPT");
						}
					;}
    break;

  case 53:
#line 395 "gpx.y"
    {
						if(++controlo.el_rte_type.name > 1) {
							erro("Só pode existir uma tag NAME dentro de uma tag RTE");
						}
					;}
    break;

  case 54:
#line 401 "gpx.y"
    {
						if(++controlo.el_rte_type.cmt > 1) {
							erro("Só pode existir uma tag CMT dentro de uma tag RTE");
						}
					;}
    break;

  case 55:
#line 407 "gpx.y"
    {
						if(++controlo.el_rte_type.desc > 1) {
							erro("Só pode existir uma tag DESC dentro de uma tag RTE");
						}
					;}
    break;

  case 56:
#line 413 "gpx.y"
    {
						if(++controlo.el_rte_type.src > 1) {
							erro("Só pode existir uma tag SRC dentro de uma tag RTE");
						}
					;}
    break;

  case 58:
#line 421 "gpx.y"
    {
						if(++controlo.el_rte_type.number > 1) {
							erro("Só pode existir uma tag NUMBER dentro de uma tag RTE");
						}
					;}
    break;

  case 59:
#line 427 "gpx.y"
    {
						if(++controlo.el_rte_type.type > 1) {
							erro("Só pode existir uma tag TYPE dentro de uma tag RTE");
						}
					;}
    break;

  case 60:
#line 433 "gpx.y"
    {
						if(++controlo.el_rte_type.extensions > 1) {
							erro("Só pode existir uma tag EXTENSIONS dentro de uma tag RTE");
						}
					;}
    break;

  case 64:
#line 451 "gpx.y"
    {
						if(++controlo.el_trk_type.name > 1) {
							erro("Só pode existir uma tag NAME dentro de uma tag TRK");
						}
					;}
    break;

  case 65:
#line 457 "gpx.y"
    {
						if(++controlo.el_trk_type.cmt > 1) {
							erro("Só pode existir uma tag CMT dentro de uma tag TRK");
						}
					;}
    break;

  case 66:
#line 463 "gpx.y"
    {
						if(++controlo.el_trk_type.desc > 1) {
							erro("Só pode existir uma tag DESC dentro de uma tag TRK");
						}
					;}
    break;

  case 67:
#line 469 "gpx.y"
    {
						if(++controlo.el_trk_type.src > 1) {
							erro("Só pode existir uma tag SRC dentro de uma tag TRK");
						}
					;}
    break;

  case 69:
#line 477 "gpx.y"
    {
						if(++controlo.el_rte_type.number > 1) {
							erro("Só pode existir uma tag NUMBER dentro de uma tag TRK");
						}
					;}
    break;

  case 70:
#line 483 "gpx.y"
    {
						if(++controlo.el_trk_type.type > 1) {
							erro("Só pode existir uma tag TYPE dentro de uma tag TRK");
						}
					;}
    break;

  case 71:
#line 489 "gpx.y"
    {
						if(++controlo.el_trk_type.extensions > 1) {
							erro("Só pode existir uma tag EXTENSIONS dentro de uma tag TRK");
						}
					;}
    break;

  case 74:
#line 508 "gpx.y"
    {
							if(++controlo.el_trkseg_type.extensions > 1) {
								erro("Só pode existir uma definição de EXTENSIONS dentro de uma tag TRKSEG");
							}
						;}
    break;

  case 77:
#line 524 "gpx.y"
    {
						if(++controlo.el_link_type.text > 1) {
							erro("Só pode existir uma tag TEXT dentro de uma tag LINK");
						}
					;}
    break;

  case 78:
#line 530 "gpx.y"
    {		
						if(++controlo.el_link_type.type > 1) {
							erro("Só pode existir uma tag TYPE dentro de uma tag LINK");
						}						
					;}
    break;

  case 81:
#line 547 "gpx.y"
    {if(mostraAtributo == 1) printf("\n\t|\tNome: "); ;}
    break;

  case 82:
#line 548 "gpx.y"
    {
				if(++controlo.el_person_type.name > 1) {
					erro("Só pode existir uma definição de NAME dentro da tag AUTHOR");
				}
			;}
    break;

  case 83:
#line 555 "gpx.y"
    {if(mostraAtributo == 1) printf("\n\t|\tEmail: "); ;}
    break;

  case 84:
#line 556 "gpx.y"
    {
				if(++controlo.el_person_type.email > 1) {
					erro("Só pode existir uma definição de EMAIL dentro da tag AUTHOR");
				}
			;}
    break;

  case 85:
#line 563 "gpx.y"
    {if(mostraAtributo == 1) printf("\n\t|\tLink: "); ;}
    break;

  case 86:
#line 564 "gpx.y"
    {
				if(++controlo.el_person_type.link > 1) {
					erro("Só pode existir uma definição de LINK dentro da tag AUTHOR");
				}
			;}
    break;

  case 87:
#line 581 "gpx.y"
    { if(mostraAtributo == 1) printf("%s@%s", (yyvsp[-5].paramStr), (yyvsp[-1].paramStr)); ;}
    break;

  case 90:
#line 591 "gpx.y"
    {
								if(++controlo.el_copyright_type.year > 1) {
									erro("Só pode existir uma definição de YEAR dentro de uma tag COPYRIGHT");
								}
							;}
    break;

  case 91:
#line 597 "gpx.y"
    {
								if(++controlo.el_copyright_type.license > 1) {
									erro("Só pode existir uma definição de LICENSE dentro de uma tag COPYRIGHT");
								}
							;}
    break;

  case 94:
#line 619 "gpx.y"
    { erro("Falta o abributo 'version'"); ;}
    break;

  case 95:
#line 620 "gpx.y"
    { erro("Falta o atributo 'creator'"); ;}
    break;

  case 96:
#line 621 "gpx.y"
    { erro("A tag GPX deve conter o atributo 'creator' e a 'version'"); ;}
    break;

  case 97:
#line 631 "gpx.y"
    { printf("\n\t|\tVersao: ") ;}
    break;

  case 99:
#line 640 "gpx.y"
    { printf("\n\t|\tCreator: ") ;}
    break;

  case 101:
#line 649 "gpx.y"
    { printf(" "); ;}
    break;

  case 103:
#line 650 "gpx.y"
    { printf("%.1f", (yyvsp[0].paramFloat)); ;}
    break;

  case 104:
#line 650 "gpx.y"
    { printf("%s", (yyvsp[0].paramStr)); ;}
    break;

  case 105:
#line 650 "gpx.y"
    { printf("%d", (yyvsp[0].paramInt)); ;}
    break;

  case 106:
#line 659 "gpx.y"
    { printf("%.1f", (yyvsp[0].paramFloat)); ;}
    break;

  case 107:
#line 669 "gpx.y"
    { validarPosicao((yyvsp[-6].paramFloat), (yyvsp[-1].paramFloat), 1); validarBounds((yyvsp[-6].paramFloat), (yyvsp[-1].paramFloat)); ;}
    break;

  case 108:
#line 671 "gpx.y"
    { validarPosicao((yyvsp[-1].paramFloat), (yyvsp[-6].paramFloat), 1);  validarBounds((yyvsp[-6].paramFloat), (yyvsp[-1].paramFloat)); ;}
    break;

  case 109:
#line 673 "gpx.y"
    { erro("Os parametros de latitude e longitude sao obrigatorios"); ;}
    break;

  case 111:
#line 692 "gpx.y"
    {if(mostraAtributo == 1) printf("%s", (yyvsp[-1].paramStr));;}
    break;

  case 112:
#line 704 "gpx.y"
    { 
							validarPosicao((yyvsp[-13].paramFloat), (yyvsp[-9].paramFloat), 0); validarPosicao((yyvsp[-5].paramFloat), (yyvsp[-1].paramFloat), 0); 
							
							if(mostraAtributo == 1) {
								printf("Min Lat: %f\n\t\t\tMin Lon: %f\n\t\t\tMax Lat: %f\n\t\t\tMax Lon: %f", (yyvsp[-13].paramFloat), (yyvsp[-9].paramFloat), (yyvsp[-5].paramFloat), (yyvsp[-1].paramFloat));
							}
							
							bounds.minlat = (yyvsp[-13].paramFloat);
							bounds.minlon = (yyvsp[-9].paramFloat);
							bounds.maxlat = (yyvsp[-5].paramFloat);
							bounds.maxlon = (yyvsp[-1].paramFloat);
							bounds.temBounds = 1;
						;}
    break;

  case 113:
#line 718 "gpx.y"
    { 
							validarPosicao((yyvsp[-13].paramFloat), (yyvsp[-9].paramFloat), 0); validarPosicao((yyvsp[-5].paramFloat), (yyvsp[-1].paramFloat), 0); 
							
							if(mostraAtributo == 1) {
								printf("Min Lat: %f\n\t\t\tMin Lon: %f\n\t\t\tMax Lat: %f\n\t\t\tMax Lon: %f", (yyvsp[-5].paramFloat), (yyvsp[-1].paramFloat), (yyvsp[-13].paramFloat), (yyvsp[-9].paramFloat));
							}
							
							bounds.minlat = (yyvsp[-5].paramFloat);
							bounds.minlon = (yyvsp[-1].paramFloat);
							bounds.maxlat = (yyvsp[-13].paramFloat);
							bounds.maxlon = (yyvsp[-9].paramFloat);
							bounds.temBounds = 1;
						;}
    break;

  case 114:
#line 748 "gpx.y"
    {	
			ok.ele = 1;
			buffer->ele = (yyvsp[-1].paramFloat);
		;}
    break;

  case 115:
#line 761 "gpx.y"
    {
				if((yyvsp[-1].paramFloat) < 0.0 || (yyvsp[-1].paramFloat) > 360.0) {
					erro("O atributo da tag MAGVAR deve estar ente 0.0 e 360.0");
				}
			;}
    break;

  case 120:
#line 811 "gpx.y"
    {mostraAtributo = 0;;}
    break;

  case 121:
#line 811 "gpx.y"
    {mostraAtributo = 1;;}
    break;

  case 123:
#line 830 "gpx.y"
    {
				if((yyvsp[-1].paramInt) < 0) {
					erro("O atributo da tag SAT nao pode ser negativo");
				}
			;}
    break;

  case 128:
#line 879 "gpx.y"
    {
					if((yyvsp[-1].paramInt) < 0 || (yyvsp[-1].paramInt) > 1023) {
						erro("O valor da tag DGPSID deve ser >> 0 <= valor <= 1023");
					}
				;}
    break;

  case 129:
#line 892 "gpx.y"
    { resetWpt(); temPontos(); pontos.waypoints++; ;}
    break;

  case 130:
#line 902 "gpx.y"
    {
				if((yyvsp[-1].paramInt) < 0) {
					erro("O atributo da tag NUMBER nao pode ser negativo");
				}
			;}
    break;

  case 134:
#line 926 "gpx.y"
    { resetWpt(); temPontos(); pontos.waypoints++; ;}
    break;

  case 137:
#line 954 "gpx.y"
    { printf("\n\n\n\t[ Dados do Autor ]\n\t|"); mostraAtributo = 1; ;}
    break;

  case 138:
#line 956 "gpx.y"
    { mostraAtributo=0; resetPersonType(); ;}
    break;

  case 140:
#line 959 "gpx.y"
    { resetPersonType(); ;}
    break;

  case 142:
#line 970 "gpx.y"
    { printf("\n\n\n\t[ Dados do Copyright ]\n\t|"); mostraAtributo = 1; ;}
    break;

  case 143:
#line 972 "gpx.y"
    { mostraAtributo=0; resetCopyright(); ;}
    break;

  case 146:
#line 985 "gpx.y"
    { resetLink(); ;}
    break;

  case 148:
#line 987 "gpx.y"
    { resetLink(); erro("O atributo HREF é obrigatório"); ;}
    break;

  case 150:
#line 997 "gpx.y"
    {
						if(mostraAtributo == 1) {
							printf("%s", (yyvsp[-1].paramStr));
						}
						
						ok.time = 1;
						converterData((yyvsp[-1].paramStr));
					;}
    break;

  case 154:
#line 1042 "gpx.y"
    { printf("\n\t[ Dados da Metadata ]\n\t|"); mostraAtributo = 1; ;}
    break;

  case 155:
#line 1044 "gpx.y"
    { mostraAtributo = 0; ;}
    break;

  case 156:
#line 1045 "gpx.y"
    {
							resetMetadata();
						;}
    break;

  case 158:
#line 1059 "gpx.y"
    { 
					resetWpt();
					temPontos();
					pontos.waypoints++; 
				;}
    break;

  case 160:
#line 1075 "gpx.y"
    { 
					resetRte();
					pontos.routes++; 
				;}
    break;

  case 161:
#line 1080 "gpx.y"
    { 
					resetRte();
					pontos.routes++; 
				;}
    break;

  case 162:
#line 1094 "gpx.y"
    { 
					resetTrk();
					pontos.tracks++; 
				;}
    break;

  case 163:
#line 1099 "gpx.y"
    { 
					resetTrk();
					pontos.tracks++; 
				;}
    break;

  case 167:
#line 1126 "gpx.y"
    {mostraAtributo = 0;;}
    break;

  case 168:
#line 1126 "gpx.y"
    {mostraAtributo = 1;;}
    break;

  case 169:
#line 1135 "gpx.y"
    { if(mostraAtributo == 1) printf("\n\t|\tAno: %d", (yyvsp[0].paramInt)); ;}
    break;

  case 171:
#line 1144 "gpx.y"
    { if(mostraAtributo == 1) printf("\n\t|\tLicenca: %s", (yyvsp[0].paramStr)); ;}
    break;

  case 175:
#line 1155 "gpx.y"
    {
							comparaTags((yyvsp[-6].paramStr), (yyvsp[-1].paramStr));							
						;}
    break;

  case 176:
#line 1159 "gpx.y"
    {
							comparaTags((yyvsp[-6].paramStr), (yyvsp[-1].paramStr));	
						;}
    break;

  case 177:
#line 1163 "gpx.y"
    {
							comparaTags((yyvsp[-5].paramStr), (yyvsp[-1].paramStr));
						;}
    break;

  case 180:
#line 1192 "gpx.y"
    { if(mostraAtributo == 1) printf(" %d", (yyvsp[0].paramInt)); ;}
    break;

  case 181:
#line 1192 "gpx.y"
    { if(mostraAtributo == 1) printf(" %f", (yyvsp[0].paramFloat)); ;}
    break;

  case 182:
#line 1192 "gpx.y"
    { if(mostraAtributo == 1) printf(" %s", (yyvsp[0].paramStr)); ;}
    break;


      default: break;
    }

/* Line 1126 of yacc.c.  */
#line 2576 "gpx.tab.c"

  yyvsp -= yylen;
  yyssp -= yylen;


  YY_STACK_PRINT (yyss, yyssp);

  *++yyvsp = yyval;


  /* Now `shift' the result of the reduction.  Determine what state
     that goes to, based on the state we popped back to and the rule
     number reduced by.  */

  yyn = yyr1[yyn];

  yystate = yypgoto[yyn - YYNTOKENS] + *yyssp;
  if (0 <= yystate && yystate <= YYLAST && yycheck[yystate] == *yyssp)
    yystate = yytable[yystate];
  else
    yystate = yydefgoto[yyn - YYNTOKENS];

  goto yynewstate;


/*------------------------------------.
| yyerrlab -- here on detecting error |
`------------------------------------*/
yyerrlab:
  /* If not already recovering from an error, report this error.  */
  if (!yyerrstatus)
    {
      ++yynerrs;
#if YYERROR_VERBOSE
      yyn = yypact[yystate];

      if (YYPACT_NINF < yyn && yyn < YYLAST)
	{
	  int yytype = YYTRANSLATE (yychar);
	  YYSIZE_T yysize0 = yytnamerr (0, yytname[yytype]);
	  YYSIZE_T yysize = yysize0;
	  YYSIZE_T yysize1;
	  int yysize_overflow = 0;
	  char *yymsg = 0;
#	  define YYERROR_VERBOSE_ARGS_MAXIMUM 5
	  char const *yyarg[YYERROR_VERBOSE_ARGS_MAXIMUM];
	  int yyx;

#if 0
	  /* This is so xgettext sees the translatable formats that are
	     constructed on the fly.  */
	  YY_("syntax error, unexpected %s");
	  YY_("syntax error, unexpected %s, expecting %s");
	  YY_("syntax error, unexpected %s, expecting %s or %s");
	  YY_("syntax error, unexpected %s, expecting %s or %s or %s");
	  YY_("syntax error, unexpected %s, expecting %s or %s or %s or %s");
#endif
	  char *yyfmt;
	  char const *yyf;
	  static char const yyunexpected[] = "syntax error, unexpected %s";
	  static char const yyexpecting[] = ", expecting %s";
	  static char const yyor[] = " or %s";
	  char yyformat[sizeof yyunexpected
			+ sizeof yyexpecting - 1
			+ ((YYERROR_VERBOSE_ARGS_MAXIMUM - 2)
			   * (sizeof yyor - 1))];
	  char const *yyprefix = yyexpecting;

	  /* Start YYX at -YYN if negative to avoid negative indexes in
	     YYCHECK.  */
	  int yyxbegin = yyn < 0 ? -yyn : 0;

	  /* Stay within bounds of both yycheck and yytname.  */
	  int yychecklim = YYLAST - yyn;
	  int yyxend = yychecklim < YYNTOKENS ? yychecklim : YYNTOKENS;
	  int yycount = 1;

	  yyarg[0] = yytname[yytype];
	  yyfmt = yystpcpy (yyformat, yyunexpected);

	  for (yyx = yyxbegin; yyx < yyxend; ++yyx)
	    if (yycheck[yyx + yyn] == yyx && yyx != YYTERROR)
	      {
		if (yycount == YYERROR_VERBOSE_ARGS_MAXIMUM)
		  {
		    yycount = 1;
		    yysize = yysize0;
		    yyformat[sizeof yyunexpected - 1] = '\0';
		    break;
		  }
		yyarg[yycount++] = yytname[yyx];
		yysize1 = yysize + yytnamerr (0, yytname[yyx]);
		yysize_overflow |= yysize1 < yysize;
		yysize = yysize1;
		yyfmt = yystpcpy (yyfmt, yyprefix);
		yyprefix = yyor;
	      }

	  yyf = YY_(yyformat);
	  yysize1 = yysize + yystrlen (yyf);
	  yysize_overflow |= yysize1 < yysize;
	  yysize = yysize1;

	  if (!yysize_overflow && yysize <= YYSTACK_ALLOC_MAXIMUM)
	    yymsg = (char *) YYSTACK_ALLOC (yysize);
	  if (yymsg)
	    {
	      /* Avoid sprintf, as that infringes on the user's name space.
		 Don't have undefined behavior even if the translation
		 produced a string with the wrong number of "%s"s.  */
	      char *yyp = yymsg;
	      int yyi = 0;
	      while ((*yyp = *yyf))
		{
		  if (*yyp == '%' && yyf[1] == 's' && yyi < yycount)
		    {
		      yyp += yytnamerr (yyp, yyarg[yyi++]);
		      yyf += 2;
		    }
		  else
		    {
		      yyp++;
		      yyf++;
		    }
		}
	      yyerror (yymsg);
	      YYSTACK_FREE (yymsg);
	    }
	  else
	    {
	      yyerror (YY_("syntax error"));
	      goto yyexhaustedlab;
	    }
	}
      else
#endif /* YYERROR_VERBOSE */
	yyerror (YY_("syntax error"));
    }



  if (yyerrstatus == 3)
    {
      /* If just tried and failed to reuse look-ahead token after an
	 error, discard it.  */

      if (yychar <= YYEOF)
        {
	  /* Return failure if at end of input.  */
	  if (yychar == YYEOF)
	    YYABORT;
        }
      else
	{
	  yydestruct ("Error: discarding", yytoken, &yylval);
	  yychar = YYEMPTY;
	}
    }

  /* Else will try to reuse look-ahead token after shifting the error
     token.  */
  goto yyerrlab1;


/*---------------------------------------------------.
| yyerrorlab -- error raised explicitly by YYERROR.  |
`---------------------------------------------------*/
yyerrorlab:

  /* Pacify compilers like GCC when the user code never invokes
     YYERROR and the label yyerrorlab therefore never appears in user
     code.  */
  if (0)
     goto yyerrorlab;

yyvsp -= yylen;
  yyssp -= yylen;
  yystate = *yyssp;
  goto yyerrlab1;


/*-------------------------------------------------------------.
| yyerrlab1 -- common code for both syntax error and YYERROR.  |
`-------------------------------------------------------------*/
yyerrlab1:
  yyerrstatus = 3;	/* Each real token shifted decrements this.  */

  for (;;)
    {
      yyn = yypact[yystate];
      if (yyn != YYPACT_NINF)
	{
	  yyn += YYTERROR;
	  if (0 <= yyn && yyn <= YYLAST && yycheck[yyn] == YYTERROR)
	    {
	      yyn = yytable[yyn];
	      if (0 < yyn)
		break;
	    }
	}

      /* Pop the current state because it cannot handle the error token.  */
      if (yyssp == yyss)
	YYABORT;


      yydestruct ("Error: popping", yystos[yystate], yyvsp);
      YYPOPSTACK;
      yystate = *yyssp;
      YY_STACK_PRINT (yyss, yyssp);
    }

  if (yyn == YYFINAL)
    YYACCEPT;

  *++yyvsp = yylval;


  /* Shift the error token. */
  YY_SYMBOL_PRINT ("Shifting", yystos[yyn], yyvsp, yylsp);

  yystate = yyn;
  goto yynewstate;


/*-------------------------------------.
| yyacceptlab -- YYACCEPT comes here.  |
`-------------------------------------*/
yyacceptlab:
  yyresult = 0;
  goto yyreturn;

/*-----------------------------------.
| yyabortlab -- YYABORT comes here.  |
`-----------------------------------*/
yyabortlab:
  yyresult = 1;
  goto yyreturn;

#ifndef yyoverflow
/*-------------------------------------------------.
| yyexhaustedlab -- memory exhaustion comes here.  |
`-------------------------------------------------*/
yyexhaustedlab:
  yyerror (YY_("memory exhausted"));
  yyresult = 2;
  /* Fall through.  */
#endif

yyreturn:
  if (yychar != YYEOF && yychar != YYEMPTY)
     yydestruct ("Cleanup: discarding lookahead",
		 yytoken, &yylval);
  while (yyssp != yyss)
    {
      yydestruct ("Cleanup: popping",
		  yystos[*yyssp], yyvsp);
      YYPOPSTACK;
    }
#ifndef yyoverflow
  if (yyss != yyssa)
    YYSTACK_FREE (yyss);
#endif
  return yyresult;
}


#line 1193 "gpx.y"


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
