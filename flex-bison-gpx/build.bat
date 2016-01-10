@echo off

cls

echo bison...
bison -d gpx.y
echo flex...
flex gpx.l

cd..
cd..
echo executavel...
gcc -o C:\Dev-Cpp\bin\lprog\bin\parser lprog\bin\gpx.tab.c lprog\bin\lex.yy.c lprog\bin\lista.c

cd lprog\bin

echo para correr o programa: parser [parametros] "<" NOME_DO_FICHEIRO
echo .
echo .
echo .
echo .
