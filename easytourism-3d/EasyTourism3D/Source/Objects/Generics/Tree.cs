using System;
using Tao.OpenGl;

namespace EasyTourism3D
{
    class Tree : GenericObject
    {
        public override void draw()
        {
            Camera cam = Camera.getCurrentActiveCamera();

            Gl.glPushMatrix();

                Gl.glTranslated(this.Position.Px, this.Position.Py - 1.0, this.Position.Pz);
                Gl.glRotated(Utilities.toDegrees(cam.Following.Angle) - 90.0, 0.0, 1.0, 0.0);

                Gl.glEnable(Gl.GL_TEXTURE_2D);
                    Gl.glEnable(Gl.GL_BLEND);
                    Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
                    Gl.glEnable(Gl.GL_ALPHA_TEST);                
                    Gl.glAlphaFunc(Gl.GL_GREATER, 0);
                    
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, Assets.Instance.Textures["Arvore1"]);

                        Gl.glBegin(Gl.GL_QUADS);

                            Gl.glNormal3d(0.0, 0.0, -1.0);

                            Gl.glTexCoord2f(0, 0);
                            Gl.glVertex3f(-3.0f, 0.0f, 0.0f);

                            Gl.glTexCoord2f(1, 0);
                            Gl.glVertex3f(3.0f, 0.0f, 0.0f);

                            Gl.glTexCoord2f(1, 1);
                            Gl.glVertex3f(3.0f, 6.0f, 0.0f);

                            Gl.glTexCoord2f(0, 1);
                            Gl.glVertex3f(-3.0f, 6.0f, 0.0f);
                        Gl.glEnd();

                    Gl.glDisable(Gl.GL_BLEND);
                    Gl.glDisable(Gl.GL_ALPHA_TEST);

                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
                Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glPopMatrix();
        }
    }
}
