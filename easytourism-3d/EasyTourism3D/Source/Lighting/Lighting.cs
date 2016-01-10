using System;
using Tao.OpenGl;

namespace EasyTourism3D
{
    abstract class Lighting
    {        
        private double lightAngle = 0.0;

        private int lightID;

        public int LightID
        {
            get { return lightID; }
            set { lightID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// TODO: Não devia ser RGBA. Criar um Vector4D para estes casos
        private RGBA position = new RGBA();

        public RGBA Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private RGBA ambient = new RGBA();

        public RGBA Ambient
        {
            get { return ambient; }
            set { ambient = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private RGBA diffuse = new RGBA();

        public RGBA Diffuse
        {
            get { return diffuse; }
            set { diffuse = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private RGBA specular = new RGBA();

        public RGBA Specular
        {
            get { return specular; }
            set { specular = value; }
        }

        private RGBA emission = new RGBA();

        public RGBA Emission
        {
            get { return emission; }
            set { emission = value; }
        }

        public void on()
        {
            Gl.glEnable(this.LightID);
        }

        public void off()
        {
            Gl.glDisable(this.LightID);
        }

        //private float[] luzPosicao = new float[4] { 0.0f, 50.0f, 0.0f, 0.0f };
        //private float[] luzAmbiente = new float[4] { .0f, 0.0f, 0.0f, 1.0f };
        //private float[] luzDifusa = new float[4] { 1.0f, 1.0f, 1.0f, 1.0f };
        //private float[] luzEspecular = new float[4] { 1.0f, 1.0f, 1.0f, 1.0f };

        //#region Posição da Luz
        //public float PosicaoX
        //{
        //    get
        //    {
        //        return this.luzPosicao[0];
        //    }

        //    set
        //    {
        //        this.luzPosicao[0] = value;
        //    }
        //}

        //public float PosicaoY
        //{
        //    get
        //    {
        //        return this.luzPosicao[1];
        //    }

        //    set
        //    {
        //        this.luzPosicao[1] = value;
        //    }
        //}

        //public float PosicaoZ
        //{
        //    get
        //    {
        //        return this.luzPosicao[2];
        //    }

        //    set
        //    {
        //        this.luzPosicao[2] = value;
        //    }
        //}

        //public float PosicaoW
        //{
        //    get
        //    {
        //        return this.luzPosicao[3];
        //    }

        //    set
        //    {
        //        this.luzPosicao[3] = value;
        //    }
        //}

        //public float[] PosicaoLuz
        //{
        //    get
        //    {
        //        return this.luzPosicao;
        //    }
        //}
        //#endregion

        //#region Cor da Luz Ambiente
        //public float AmbienteR
        //{
        //    get
        //    {
        //        return this.luzAmbiente[0];
        //    }

        //    set
        //    {
        //        this.luzAmbiente[0] = value;
        //    }
        //}

        //public float AmbienteG
        //{
        //    get
        //    {
        //        return this.luzAmbiente[1];
        //    }

        //    set
        //    {
        //        this.luzAmbiente[1] = value;
        //    }
        //}

        //public float AmbienteB
        //{
        //    get
        //    {
        //        return this.luzAmbiente[2];
        //    }

        //    set
        //    {
        //        this.luzAmbiente[2] = value;
        //    }
        //}

        //public float AmbienteAlpha
        //{
        //    get
        //    {
        //        return this.luzAmbiente[3];
        //    }

        //    set
        //    {
        //        this.luzAmbiente[3] = value;
        //    }
        //}

        //public float[] LuzAmbiente
        //{
        //    get
        //    {
        //        return this.luzAmbiente;
        //    }
        //}
        //#endregion

        //#region Cor da Luz Difusa
        //public float DifusaR
        //{
        //    get
        //    {
        //        return this.luzDifusa[0];
        //    }

        //    set
        //    {
        //        this.luzDifusa[0] = value;
        //    }
        //}

        //public float DifusaG
        //{
        //    get
        //    {
        //        return this.luzDifusa[1];
        //    }

        //    set
        //    {
        //        this.luzDifusa[1] = value;
        //    }
        //}

        //public float DifusaB
        //{
        //    get
        //    {
        //        return this.luzDifusa[2];
        //    }

        //    set
        //    {
        //        this.luzDifusa[2] = value;
        //    }
        //}

        //public float DifusaAlpha
        //{
        //    get
        //    {
        //        return this.luzDifusa[3];
        //    }

        //    set
        //    {
        //        this.luzDifusa[3] = value;
        //    }
        //}

        //public float[] LuzDifusa
        //{
        //    get
        //    {
        //        return this.luzDifusa;
        //    }
        //}
        //#endregion

        //#region Cor da Luz Especular
        //public float EspecularR
        //{
        //    get
        //    {
        //        return this.luzEspecular[0];
        //    }

        //    set
        //    {
        //        this.luzEspecular[0] = value;
        //    }
        //}

        //public float EspecularG
        //{
        //    get
        //    {
        //        return this.luzEspecular[1];
        //    }

        //    set
        //    {
        //        this.luzEspecular[1] = value;
        //    }
        //}

        //public float EspecularB
        //{
        //    get
        //    {
        //        return this.luzEspecular[2];
        //    }

        //    set
        //    {
        //        this.luzEspecular[2] = value;
        //    }
        //}

        //public float EspecularAlpha
        //{
        //    get
        //    {
        //        return this.luzEspecular[3];
        //    }

        //    set
        //    {
        //        this.luzEspecular[3] = value;
        //    }
        //}

        //public float[] LuzEspecular
        //{
        //    get
        //    {
        //        return this.luzEspecular;
        //    }
        //}
        //#endregion

        #region Propriedades
        //public int Luz
        //{
        //    get
        //    {
        //        return this.light;
        //    }

        //    set
        //    {
        //        this.light = value;
        //    }
        //}

        public double Angulo
        {
            get
            {
                return this.lightAngle;
            }

            set
            {
                this.lightAngle = value;
            }
        }
        #endregion
                
        public abstract void draw();

        //public void definirPosicao(float x, float y, float z, float w)
        //{
        //    this.PosicaoX = x;
        //    this.PosicaoY = y;
        //    this.PosicaoZ = z;
        //    this.PosicaoW = w;
        //}

        //public void definirLuzAmbiente(float r, float g, float b, float a)
        //{
        //    this.AmbienteR = r;
        //    this.AmbienteG = g;
        //    this.AmbienteB = b;
        //    this.AmbienteAlpha = a;
        //}

        //public void definirLuzDifusa(float r, float g, float b, float a)
        //{
        //    this.DifusaR = r;
        //    this.DifusaG = g;
        //    this.DifusaB = b;
        //    this.DifusaAlpha = a;
        //}

        //public void definirLuzEspecular(float r, float g, float b, float a)
        //{
        //    this.EspecularR = r;
        //    this.EspecularG = g;
        //    this.EspecularB = b;
        //    this.EspecularAlpha = a;
        //}

        //public void activar()
        //{
            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, this.LuzAmbiente);
            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, this.LuzDifusa);
            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, this.LuzEspecular);
            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_EMISSION, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
        //}
    }
}
