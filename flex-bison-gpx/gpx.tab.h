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




#if ! defined (YYSTYPE) && ! defined (YYSTYPE_IS_DECLARED)
#line 73 "gpx.y"
typedef union YYSTYPE {
	char *paramStr;
	int paramInt;
	double paramFloat;
} YYSTYPE;
/* Line 1447 of yacc.c.  */
#line 222 "gpx.tab.h"
# define yystype YYSTYPE /* obsolescent; will be withdrawn */
# define YYSTYPE_IS_DECLARED 1
# define YYSTYPE_IS_TRIVIAL 1
#endif

extern YYSTYPE yylval;



