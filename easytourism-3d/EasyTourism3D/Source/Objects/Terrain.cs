using System;
using Tao.OpenGl;
using System.Collections.Generic;

namespace EasyTourism3D
{
    /// <summary>
    /// 
    /// </summary>
    class Terrain : ThreeDObject
    {
        /// <summary>
        /// 
        /// </summary>
        private int Height = 53;

        /// <summary>
        /// 
        /// </summary>
        private int Width = 38;

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<String, int> displayLists = new Dictionary<string, int>(2);

        /// <summary>
        /// 
        /// </summary>
        public override void draw()
        {
            if (this.displayLists.ContainsKey(AppState.Instance.WeatherState))
            {
                Gl.glCallList(this.displayLists[AppState.Instance.WeatherState]);
            }
            else
            {
                this.drawDisplayList(AppState.Instance.WeatherState);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void createDisplayList()
        {
            String[] states = new String[] {"Clear", "Snowy", "Foggy", "Rainy"};
            int newID = 0;

            for (int i = 0; i < states.Length; i++)
            {
                newID = Gl.glGenLists(1);
                this.displayLists.Add(states[i], newID);

                if (states[i] != "Snowy")
                {
                    states[i] = "Clear";
                }

                Gl.glNewList(newID, Gl.GL_COMPILE);
                    this.drawDisplayList(states[i]);
                Gl.glEndList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture"></param>
        private void drawDisplayList(String texture)
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);

            if (Assets.Instance.Textures.ContainsKey(texture))
            {
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, Assets.Instance.Textures[texture]);
            }
            else
            {
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
            }

            Gl.glPushMatrix();

                Gl.glTranslated(0.0, -1.0, 0.0);

                for (int i = -this.Width; i <= this.Width; i++)
                {
                    Gl.glBegin(Gl.GL_QUAD_STRIP);

                        for (int j = -this.Height; j <= this.Height; j++)
                        {                        
                            Gl.glNormal3d(0.0, 1.0, 0.0);

                            //Gl.glTexCoord2f(1, 1);
                            if (j % 2.0 == 0.0) Gl.glTexCoord2d(1.0, 1.0); else Gl.glTexCoord2d(0.0, 1.0);
                            Gl.glVertex3f(i + 1, 0, j + 1);

                            if (j % 2.0 == 0.0) Gl.glTexCoord2d(1.0, 0.0); else Gl.glTexCoord2d(0.0, 0.0);
                            Gl.glVertex3f(i, 0, j + 1);
                        } 
                    
                    Gl.glEnd();
                }

            Gl.glPopMatrix();

            Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }
    }
}