using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace EasyTourism3D
{
    class RandomBuilding : GenericObject
    {
        public int numAndares;
        private double area;

        public RandomBuilding()
        {            
            this.Area = 7;
            this.numAndares = Utilities.RandomCache.Next(7,30);
        }

        public double Area
        {
            get { return area; }
            set { area = value; this.ColisionArea.Dimensions.set((this.area / 2) + 0.2, 1.0, (this.area / 2) + 0.2); }
        }

        public override void draw()
        {
            Gl.glPushMatrix();
                Gl.glTranslated(this.Position.Px, 0.0, this.Position.Pz);
                Gl.glScaled(this.area, this.numAndares, this.area);
                Gl.glTranslated(0.0, 0.45, 0.0);
                this.desenhaCubo();
            Gl.glPopMatrix();
        }

        private void desenhaCubo()
        {
            //  TODO: Tira daqui estes new todos...
            desenhaPoligono(new double[] { 0.5, -0.5, -0.5 }, new double[] { -0.5, -0.5, -0.5 }, new double[] { -0.5, 0.5, -0.5 }, new double[] { 0.5, 0.5, -0.5 }, new double[] { 0.0, 0.0, -1.0 });
            desenhaPoligono(new double[] { 0.5, 0.5, -0.5 }, new double[] { -0.5, 0.5, -0.5 }, new double[] { -0.5, 0.5, 0.5 }, new double[] { 0.5, 0.5, 0.5 }, new double[] { 0.0, 1.0, 0.0 });
            desenhaPoligono(new double[] { -0.5, 0.5, -0.5 }, new double[] { -0.5, -0.5, -0.5 }, new double[] { -0.5, -0.5, 0.5 }, new double[] { -0.5, 0.5, 0.5 }, new double[] { -1.0, 0, 0.0 });
            desenhaPoligono(new double[] { 0.5, 0.5, 0.5 }, new double[] { 0.5, -0.5, 0.5 }, new double[] { 0.5, -0.5, -0.5 }, new double[] { 0.5, 0.5, -0.5 }, new double[] { 1.0, 0.0, 0.0 });
            desenhaPoligono(new double[] { -0.5, -0.5, 0.5 }, new double[] { 0.5, -0.5, 0.5 }, new double[] { 0.5, 0.5, 0.5 }, new double[] { -0.5, 0.5, 0.5 }, new double[] { 0.0, 0.0, 1.0 });
            desenhaPoligono(new double[] { 0.5, -0.5, 0.5 }, new double[] { -0.5, -0.5, 0.5 }, new double[] { -0.5, -0.5, -0.5 }, new double[] { 0.5, -0.5, -0.5 }, new double[] { 0.0, -1.0, 0.0 });
        }

        private void desenhaPoligono(double[] a, double[] b, double[] c, double[] d, double[] normais)
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);

                Gl.glBindTexture(Gl.GL_TEXTURE_2D, Assets.Instance.Textures["EdificioGenerico1"]);

                Gl.glBegin(Gl.GL_POLYGON);

                    Gl.glNormal3dv(normais);

                    Gl.glTexCoord2f(0, 0);
                    Gl.glVertex3dv(a);
                    Gl.glTexCoord2f(1,0);
                    Gl.glVertex3dv(b);
                    Gl.glTexCoord2f(1, 1);
                    Gl.glVertex3dv(c);
                    Gl.glTexCoord2f(0,1);
                    Gl.glVertex3dv(d);
                Gl.glEnd();

                Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }
    }
}
