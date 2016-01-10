using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace EncodingModulation
{
    public class Graficos
    {
        private Pen corGrafico;
        private Graphics g;

        public int x;        
        public int y;

        public int tamanhoLinha;

        public int DESENHAR_CIMA = -1;
        public int DESENHAR_BAIXO = 1;

        public Graficos(Graphics g)
        {
            this.g = g;

            this.tamanhoLinha = 30;
            this.corGrafico = new Pen(Brushes.Black, 3);            
        }

        public Graphics getGraphics()
        {
            return g;
        }

        public void desenharLinhaHorizontal()
        {                       
            x += tamanhoLinha;
            g.DrawLine(corGrafico, x, y, x + tamanhoLinha, y);
        }

        public void desenharLinhaVertical(int pos)
        {
            y += (tamanhoLinha * pos);
            g.DrawLine(corGrafico, x + tamanhoLinha, y, x + tamanhoLinha, y + (tamanhoLinha * -(pos)));            
        }

        public void desenharLinhaHorizontal(int tamanho)
        {
            x += tamanho;
            g.DrawLine(corGrafico, x, y, x + tamanho, y);
        }

        public void desenharLinhaVertical(int pos, int tamanhoX, int tamanhoY)
        {
            y += (tamanhoY * pos);
            g.DrawLine(corGrafico, x + tamanhoX, y, x + tamanhoX, y + (tamanhoY * -(pos)));
        }
        
        public void desenharBinario(char codigo, int posX, int posY)
        {
            g.DrawString(codigo.ToString(), new Font("Tahoma", 8, FontStyle.Bold), new SolidBrush(Color.Black), posX, posY);
        }

        public void desenharQuadro()
        {
            Pen penVertical = new Pen(Brushes.Gray, 1);
            Pen penHorizontal = new Pen(Brushes.LightSteelBlue, 3);
            int qx = tamanhoLinha;
            int qy = 74;

            for (int i = 0; i < 27; i++)
            {
                g.DrawLine(penVertical, qx, 0, qx, 448);

                if (i < 5)
                {
                    g.DrawLine(penHorizontal, 0, qy, 819, qy);
                    qy += 74;
                }

                qx += tamanhoLinha;                
            }
        }
    }
}
