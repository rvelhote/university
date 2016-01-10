using System;
using Tao.OpenGl;

namespace EasyTourism3D
{
    class RoadSegment : ThreeDObject
    {
        private String segmentName = "";

        public String SegmentName
        {
            get { return segmentName; }
            set { segmentName = value; }
        }

        private double area = 1.0;

        public double Area
        {
            get { return area; }
            set { area = value; }
        }

        public Intersection begin;
        public Intersection end;

        public RoadSegment(Intersection b, Intersection e)
        {
            if (b == null)
            {
                Console.WriteLine("A Intersecção de Início no Segmento {0} está errada", this.SegmentName);
                b = new Intersection(0);
            }

            if (e == null)
            {
                Console.WriteLine("A Intersecção de Fim no Segmento {0} está errada", this.SegmentName);
                e = new Intersection(0);
            }

            this.begin = b;
            this.end = e;
        }

        public override void draw()
        {
            double angle = this.begin.Position.angle(this.end.Position) - 180.0;
            double distance = this.begin.Position.distance(this.end.Position);

            //    Console.WriteLine("Angulo (" + this.begin.Position.Px + ", " + this.begin.Position.Py + ", " + this.begin.Position.Pz + ") (" + this.end.Position.Px + ", " + this.end.Position.Py + ", " + this.end.Position.Pz + "): " + this.begin.Position.angle(this.end.Position));
            //    Console.WriteLine("Distancia: " + Math.Round(this.begin.Position.distance(this.end.Position)));
            //    Console.WriteLine("Angulo Corrigido: " + (this.begin.Position.angle(this.end.Position) - 180));

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, Assets.Instance.Textures["Estrada"]);

            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);

            Gl.glPushMatrix();

                if (angle == 0)
                {
                    Gl.glTranslated(this.begin.Position.Px, this.begin.Position.Py, this.begin.Position.Pz + this.Area * 2);
                }
                else if (angle == -90)
                {
                    Gl.glTranslated(this.begin.Position.Px - this.Area * 2, this.begin.Position.Py, this.begin.Position.Pz);
                }
            
                if (angle == 0 || angle == -90)
                {

                    Gl.glRotated(angle, 0.0, 1.0, 0.0);

                    Gl.glBegin(Gl.GL_QUAD_STRIP);

                    for (double i = 0; i < distance; i = i + this.Area * 2)
                    {
                        Gl.glNormal3d(0.0, 1.0, 0.0);

                        if (i % 4.0 == 0.0) Gl.glTexCoord2d(1.0, 0.0); else Gl.glTexCoord2d(0.0, 0.0);
                        Gl.glVertex3d(this.Area, this.begin.Position.Py, i - this.Area);

                        if (i % 4.0 == 0.0) Gl.glTexCoord2d(1.0, 1.0); else Gl.glTexCoord2d(0.0, 1.0);
                        Gl.glVertex3d(-this.Area, this.begin.Position.Py, i - this.Area);
                    }

                    Gl.glEnd();
                }
                else
                {
                    /// TODO: Melhorar as Diagonais
                    Gl.glTranslated(this.begin.Position.Px, this.begin.Position.Py, this.begin.Position.Pz);
                    Gl.glRotated(angle - 90.0, 0.0, 1.0, 0.0);

                    Gl.glBegin(Gl.GL_QUADS);

                        Gl.glNormal3d(0.0, 1.0, 0.0);

                        Gl.glTexCoord2d(1.0, 0.0);
                        Gl.glVertex3d(this.Area + distance, this.Position.Py - 0.01, this.Area);

                        Gl.glTexCoord2d(1.0, 1.0);
                        Gl.glVertex3d(this.Area + distance, this.Position.Py - 0.01, -this.Area);

                        Gl.glTexCoord2d(0.0, 1.0);
                        Gl.glVertex3d(-this.Area, this.Position.Py - 0.01, -this.Area);

                        Gl.glTexCoord2d(0.0, 0.0);
                        Gl.glVertex3d(-this.Area, this.Position.Py - 0.01, +this.Area);                     
                    Gl.glEnd();
                }

            Gl.glPopMatrix();
        }
    }
}
