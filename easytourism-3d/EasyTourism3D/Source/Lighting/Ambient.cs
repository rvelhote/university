using System;
using Tao.OpenGl;

namespace EasyTourism3D
{
    class Ambiente
    {
        //private float[] materialEspecular = new float[4] { 0.8f, 0.8f, 0.8f, 1.0f };
        //private float[] emission = new float[4] { 1.0f, 1.0f, 1.0f, 1.0f };
        //private float brilhoMaterial = 104;

        public void definirProperiedades()
        {
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE);

            //Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, this.materialEspecular);
            //Gl.glMaterialfv(Gl.GL_FRONT_AND_BACK, Gl.GL_EMISSION, emission);
            //Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, this.brilhoMaterial);
        }
    }
}
