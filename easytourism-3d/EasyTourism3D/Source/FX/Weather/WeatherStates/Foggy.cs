using System;
using Tao.OpenGl;
using System.Collections;

namespace EasyTourism3D
{
    /// <summary>
    /// 
    /// </summary>
    class Foggy : WeatherState
    {
        /// <summary>
        /// 
        /// </summary>
        private float density;

        /// <summary>
        /// 
        /// </summary>
        public float Density
        {
            get { return density; }
            set { density = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private float maximumDensity;

        /// <summary>
        /// 
        /// </summary>
        public float MaximumDensity
        {
            get { return maximumDensity; }
            set { maximumDensity = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private float step = 0.001f;

        /// <summary>
        /// 
        /// </summary>
        private float[] fogColor;

        /// <summary>
        /// 
        /// </summary>
        public float[] FogColor
        {
            get { return fogColor; }
            set { fogColor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Foggy()
        {
            this.stateName = AppState.Instance.ResourceManager.GetString("WeatherStateFoggy");

            this.FogColor = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
            this.density = 0.0f;
            this.maximumDensity = (float)Utilities.RandomCache.NextDouble();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxDens"></param>
        /// <param name="color"></param>
        public Foggy(float maxDens, float[] color)
        {            
            this.density = 0.0f;

            this.FogColor = color;
            this.maximumDensity = maxDens;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void initialize()
        {
            Gl.glEnable(Gl.GL_FOG);
            Gl.glHint(Gl.GL_FOG_HINT, Gl.GL_NICEST);
            Gl.glFogi(Gl.GL_FOG_MODE, Gl.GL_EXP2);
            Gl.glFogfv(Gl.GL_FOG_COLOR, this.FogColor);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void end()
        {
            Gl.glDisable(Gl.GL_FOG);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void draw()
        {
            if (this.elapsed % 120 == 0)
            {
                switch (this.CurrentPhase)
                {
                    case Phase.One:
                        {
                            this.phaseOne();
                            break;
                        }

                    case Phase.Two:
                        {
                            this.phaseTwo();
                            break;
                        }

                    case Phase.Three:
                        {
                            this.phaseThree();
                            break;
                        }
                }

                Gl.glFogf(Gl.GL_FOG_DENSITY, this.density);
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        private void increaseFog()
        {
            this.Density = (this.Density + this.step > this.MaximumDensity) ? this.Density : this.Density + this.step;
        }

        /// <summary>
        /// 
        /// </summary>
        private void decreaseFog()
        {
            this.Density = (this.Density - this.step > 0.0) ? this.Density - this.step : 0.0f;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void phaseOne()
        {
            this.increaseFog();            
        }

        /// <summary>
        /// 
        /// </summary>
        public override void phaseTwo()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public override void phaseThree()
        {
            this.decreaseFog();
        }
    }
}
