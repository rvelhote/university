using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace EncodingModulation
{
    class Encoding
    {        
        public static void aplicarNRZL(String s, Graficos g)
        {
            g.x = -g.tamanhoLinha;
            g.y = 50;

            if (s[0] == '0')
            {
                g.y -= g.tamanhoLinha;
            }

            for (int i = 0; i < s.Length; i++)
            {
                g.desenharBinario(s[i], (i * g.tamanhoLinha) + (g.tamanhoLinha / 3), 0);

                if (s[i] == '0')
                {
                    g.desenharLinhaHorizontal();
                }
                else
                {
                    g.desenharLinhaHorizontal();
                }

                if (((i + 1) != s.Length) && (s[i + 1] != s[i]))
                {
                    g.desenharLinhaVertical((s[i + 1] == '1') ? g.DESENHAR_BAIXO : g.DESENHAR_CIMA);
                }
            }
        }

        public static void aplicarNRZI(String s, Graficos g)
        {
            g.x = -g.tamanhoLinha;
            g.y = 125;

            if (s[0] == '1')
            {
                g.y = 105;
            }

            int posActual = g.DESENHAR_CIMA;

            if (s[0] == '0')
            {
                posActual = g.DESENHAR_BAIXO;
            }

            for (int i = 0; i < s.Length; i++)
            {
                g.desenharBinario(s[i], (i * g.tamanhoLinha) + (g.tamanhoLinha / 3), 78);

                if (s[i] == '0')
                {
                    g.desenharLinhaHorizontal();
                }
                else
                {
                    g.desenharLinhaHorizontal();
                }

                if ( (i + 1 < s.Length) && (s[i + 1] == '1') )
                {
                    posActual = (posActual > 0) ? g.DESENHAR_CIMA : g.DESENHAR_BAIXO;
                    g.desenharLinhaVertical(posActual);
                }
            }
        }

        public static void aplicarDiferencialManchester(String s, Graficos g)
        {
            g.x = -g.tamanhoLinha / 2;
            g.y = 400;

            int posActual = g.DESENHAR_CIMA;

            if (s[0] == '0')
            {
                posActual = g.DESENHAR_BAIXO;
                g.desenharLinhaVertical(posActual, g.tamanhoLinha / 2, g.tamanhoLinha);
            }

            for (int i = 0; i < s.Length; i++)
            {
                g.desenharBinario(s[i], (i * g.tamanhoLinha) + (g.tamanhoLinha / 3), 375);

                if (s[i] == '0')
                {
                    posActual = (posActual > 0) ? g.DESENHAR_CIMA : g.DESENHAR_BAIXO;

                    g.desenharLinhaHorizontal(g.tamanhoLinha / 2);
                    g.desenharLinhaVertical(posActual, g.tamanhoLinha / 2, g.tamanhoLinha);
                    g.desenharLinhaHorizontal(g.tamanhoLinha / 2);
                }
                else
                {
                    posActual = (posActual > 0) ? g.DESENHAR_CIMA : g.DESENHAR_BAIXO;

                    g.desenharLinhaHorizontal(g.tamanhoLinha / 2);
                    g.desenharLinhaVertical(posActual, g.tamanhoLinha / 2, g.tamanhoLinha);
                    g.desenharLinhaHorizontal(g.tamanhoLinha / 2);
                }

                if (((i + 1) != s.Length) && (s[i + 1] != '1'))
                {
                    posActual = (posActual > 0) ? g.DESENHAR_CIMA : g.DESENHAR_BAIXO;
                    g.desenharLinhaVertical(posActual, g.tamanhoLinha / 2, g.tamanhoLinha);
                }
            }
        }

        public static void aplicarManchester(String s, Graficos g)
        {
            g.x = -g.tamanhoLinha / 2;
            g.y = 325;

            if (s[0] == '1')
            {
                g.y = 350;
            }

            int posActual = 0;

            for (int i = 0; i < s.Length; i++)
            {
                g.desenharBinario(s[i], (i * g.tamanhoLinha) + (g.tamanhoLinha / 3), 300);

                if (s[i] == '0')
                {                    
                    g.desenharLinhaHorizontal(g.tamanhoLinha / 2);
                    g.desenharLinhaVertical(g.DESENHAR_BAIXO, g.tamanhoLinha / 2, g.tamanhoLinha);
                    g.desenharLinhaHorizontal(g.tamanhoLinha / 2);
                    posActual = g.DESENHAR_BAIXO;
                }
                else
                {
                    g.desenharLinhaHorizontal(g.tamanhoLinha / 2);
                    g.desenharLinhaVertical(g.DESENHAR_CIMA, g.tamanhoLinha / 2, g.tamanhoLinha);
                    g.desenharLinhaHorizontal(g.tamanhoLinha / 2);
                    posActual = g.DESENHAR_CIMA;
                }

                if (((i + 1) != s.Length) && (s[i + 1] == s[i]))
                {
                    posActual = (posActual > 0) ? g.DESENHAR_CIMA : g.DESENHAR_BAIXO;
                    g.desenharLinhaVertical(posActual, g.tamanhoLinha / 2, g.tamanhoLinha);
                }
            }
        }

        public static void aplicarPseudoternary(String s, Graficos g)
        {
            g.x = -g.tamanhoLinha;
            g.y = 245;

            if (s[0] == '1')
            {
                g.y = 265;
            }

            int polaridade = g.DESENHAR_CIMA;

            for (int i = 0; i < s.Length; i++)
            {
                g.desenharBinario(s[i], (i * g.tamanhoLinha) + (g.tamanhoLinha / 3), 226);

                if (s[i] == '0')
                {
                    if (i != 0)
                    {
                        polaridade = (polaridade > 0) ? g.DESENHAR_CIMA : g.DESENHAR_BAIXO;
                        g.desenharLinhaVertical(polaridade, g.tamanhoLinha, g.tamanhoLinha / 2);
                    }

                    g.desenharLinhaHorizontal();
                    polaridade = (polaridade > 0) ? g.DESENHAR_CIMA : g.DESENHAR_BAIXO;

                    if (i + 1 < s.Length)
                    {
                        g.desenharLinhaVertical(polaridade, g.tamanhoLinha, g.tamanhoLinha / 2);
                        polaridade = (polaridade > 0) ? g.DESENHAR_CIMA : g.DESENHAR_BAIXO;
                    }
                }
                else
                {
                    g.desenharLinhaHorizontal();
                }
            }
        }

        public static void aplicarBipolarAMI(String s, Graficos g)
        {
            g.x = -g.tamanhoLinha;
            g.y = 190;

            int polaridade = g.DESENHAR_BAIXO;

            if (s[0] == '1')
            {
                polaridade = g.DESENHAR_CIMA;
                g.desenharLinhaVertical(polaridade, g.tamanhoLinha, g.tamanhoLinha / 2);
            }

            for (int i = 0; i < s.Length; i++)
            {
                g.desenharBinario(s[i], (i * g.tamanhoLinha) + (g.tamanhoLinha / 3), 156);

                if (s[i] == '0')
                {
                    g.desenharLinhaHorizontal();
                }
                else
                {
                    if (i != 0)
                    {
                        polaridade = (polaridade > 0) ? g.DESENHAR_CIMA : g.DESENHAR_BAIXO;
                        g.desenharLinhaVertical(polaridade, g.tamanhoLinha, g.tamanhoLinha / 2);
                    }

                    g.desenharLinhaHorizontal();
                    polaridade = (polaridade > 0) ? g.DESENHAR_CIMA : g.DESENHAR_BAIXO;

                    if (i + 1 < s.Length)
                    {
                        g.desenharLinhaVertical(polaridade, g.tamanhoLinha, g.tamanhoLinha / 2);
                        polaridade = (polaridade > 0) ? g.DESENHAR_CIMA : g.DESENHAR_BAIXO;
                    }
                }
            }
        }        
    }
}
