using System;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace EasyTourism3D
{
    /// <summary>
    /// 
    /// </summary>
    class Sun : Lighting
    {
        /// <summary>
        /// 
        /// </summary>
        public Sun()
        {
            this.LightID = Gl.GL_LIGHT0;

            this.Position.Set(0.0f, 85.0f, 0.0f, 0.0f);
            this.Ambient.Set(0.2f, 0.2f, 0.2f, 1.0f);
            this.Diffuse.Set(0.8f, 0.8f, 0.8f, 1.0f);
            this.Specular.Set(0.5f, 0.5f, 0.5f, 1.0f);
            this.Emission.Set(1.0f, 1.0f, 1.0f, 1.0f);

            this.on();

            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, this.Position.toArray());
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, this.Ambient.toArray());
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, this.Diffuse.toArray());            
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, this.Specular.toArray());
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_EMISSION, this.Emission.toArray());

            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, this.Ambient.toArray());
        }

        /// <summary>
        /// 
        /// </summary>
        public override void draw()
        {
            Gl.glPushMatrix();

                this.Angulo = ((AppState.Instance.CurrentDate.Hour * 60) + AppState.Instance.CurrentDate.Minute - 720) * 0.25;

                Gl.glRotated(this.Angulo, 1.0, 0.0, 0.0);

                //  TODO: :P
                Gl.glTranslated(this.Position.Red, this.Position.Green, this.Position.Blue);
                Gl.glLightfv(this.LightID, Gl.GL_POSITION, this.Position.toArray());
            Gl.glPopMatrix();
        }
    }
}
