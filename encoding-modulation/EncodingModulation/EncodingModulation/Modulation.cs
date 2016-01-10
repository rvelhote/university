using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace EncodingModulation
{
    class Modulation
    {
        public static void aplicarAmplitudeShiftKeying(String s, Graficos gx, double frequencia, double amplitude, int tempo)
        {
            Graphics g = gx.getGraphics();
            PointF[] pontos = new PointF[tempo];

            int dy = 200;            
            float x = 1.0F;
            double calc;            

            for (int j = 0; j < s.Length; j++)
            {
                g.DrawString(Convert.ToString(s[j]), new Font("Verdana", 8), Brushes.Black, x + (tempo / 3), dy - ((float)amplitude + 25));

                if (s[j] == '0')
                {                    
                    g.DrawLine(new Pen(Brushes.Black, 1), x, dy, x + tempo, dy);
                    x += tempo;
                }
                else
                {
                    int comecaEm = 0;
                    if (j != 0 && s[j - 1] == '0')
                    {
                        pontos[0] = new PointF(x, 200);
                        comecaEm = 1;
                    }

                    for (int i = comecaEm; i < tempo; i++)
                    {
                        calc = amplitude * Math.Cos(2 * 3.14 * frequencia * i);
                        pontos[i] = new PointF(x, (float)calc + dy);
                        x += 1.0F;
                    }

                    if (j + 1 != s.Length && s[j + 1] == '0')
                    {
                        pontos[tempo - 1] = new PointF(x, 200);
                    }

                    g.DrawCurve(new Pen(Brushes.Black, 1), pontos);
                }
            }
        }

        public static void aplicarFrequencyShiftKeying(String s, Graficos gx, double frequencia, double amplitude, int tempo, double frequenciaAlt)
        {
            Graphics g = gx.getGraphics();
            PointF[] pontos = new PointF[tempo];

            int dy = 200;

            double calc;                                    

            float x = 1.0F;

            for (int j = 0; j < s.Length; j++)
            {
                g.DrawString(Convert.ToString(s[j]), new Font("Verdana", 8), Brushes.Black, x + (tempo / 3), dy - ((float)amplitude + 25));

                if (s[j] == '0')
                {
                    for (int i = 0; i < tempo; i++)
                    {
                        calc = amplitude * Math.Cos(2 * 3.14 * frequenciaAlt * i);
                        pontos[i] = new PointF(x, (float)calc + dy);
                        x += 1.0F;
                    }

                    g.DrawCurve(new Pen(Brushes.Black, 1), pontos);
                }
                else
                {
                    for (int i = 0; i < tempo; i++)
                    {
                        calc = amplitude * Math.Cos(2 * 3.14 * frequencia * i);
                        pontos[i] = new PointF(x, (float)calc + dy);
                        x += 1.0F;
                    }

                    g.DrawCurve(new Pen(Brushes.Black, 1), pontos);
                }
            }
        }

        public static void aplicarPhaseShiftKeying(String s, Graficos gx, double frequencia, double amplitude, int tempo)
        {
            Graphics g = gx.getGraphics();
            PointF[] pontos = new PointF[tempo];

            int dy = 200;
            float x = 1.0F;            
            double calc;
            int sig = 1;
            
            for (int j = 0; j < s.Length; j++)
            {                
                g.DrawString(Convert.ToString(s[j]), new Font("Verdana", 8), Brushes.Black, x + (tempo / 3), dy - ((float)amplitude + 25));

                if (s[j] == '0')
                {
                    for (int i = 0; i < tempo; i++)
                    {
                        calc = (amplitude * Math.Sin(2 * 3.14 * frequencia * i)) * sig;
                        pontos[i] = new PointF(x, (float)calc+ dy);
                        x += 1.0F;
                    }

                    x -= 1.0F;
                    g.DrawCurve(new Pen(Brushes.Black, 1), pontos);
                }
                else
                {
                    for (int i = 0; i < tempo; i++)
                    {
                        calc = (amplitude * Math.Sin(2 * 3.14 * frequencia * i)) * sig;
                        pontos[i] = new PointF(x, (float)calc + dy);
                        x += 1.0F;
                    }

                    x -= 1.0F;
                    g.DrawCurve(new Pen(Brushes.Black, 1), pontos);
                }

                if (j + 1 != s.Length && s[j + 1] == '1')
                {
                    sig *= -1;
                }
            }
        }
    }
}
