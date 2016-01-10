using System;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.OpenAl;

namespace EasyTourism3D
{
    /// <summary>
    /// 
    /// </summary>
    class Input
    {
        /// <summary>
        /// 
        /// </summary>
        private bool wPressed = false;

        /// <summary>
        /// 
        /// </summary>
        public bool TeclaW
        {
            get { return wPressed; }
            set { wPressed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool aPressed = false;

        /// <summary>
        /// 
        /// </summary>
        public bool TeclaA
        {
            get { return aPressed; }
            set { aPressed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool sPressed = false;

        /// <summary>
        /// 
        /// </summary>
        public bool TeclaS
        {
            get { return sPressed; }
            set { sPressed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool dPressed = false;

        /// <summary>
        /// 
        /// </summary>
        public bool TeclaD
        {
            get { return dPressed; }
            set { dPressed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool tPressed = false;

        /// <summary>
        /// 
        /// </summary>
        public bool TeclaT
        {
            get { return tPressed; }
            set { tPressed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool gPressed = false;

        /// <summary>
        /// 
        /// </summary>
        public bool TeclaG
        {
            get { return gPressed; }
            set { gPressed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool tabPressed = false;

        /// <summary>
        /// 
        /// </summary>
        public bool Tab
        {
            get { return tabPressed; }
            set { tabPressed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool plusPressed = false;

        /// <summary>
        /// 
        /// </summary>
        public bool Plus
        {
            get { return plusPressed; }
            set { plusPressed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool minusPressed = false;

        /// <summary>
        /// 
        /// </summary>
        public bool Minus
        {
            get { return minusPressed; }
            set { minusPressed = value; }
        }

        private bool exit;

        public bool ExitingApplication
        {
            get { return exit; }
            set { exit = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        private byte lastNormalKeyPressed;

        /// <summary>
        /// 
        /// </summary>
        public byte LastNormalKeyPressed
        {
          get { return lastNormalKeyPressed; }
          set { lastNormalKeyPressed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int lastSpecialKeyPressed;

        /// <summary>
        /// 
        /// </summary>
        public int LastSpecialKeyPressed
        {
          get { return lastSpecialKeyPressed; }
          set { lastSpecialKeyPressed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int lastMouseButtonPressed;

        /// <summary>
        /// 
        /// </summary>
        public int LastMouseButtonPressed
        {
          get { return lastMouseButtonPressed; }
          set { lastMouseButtonPressed = value; }
        }

        private bool simulationSpeedChanged;

        public bool SimulationSpeedChanged
        {
            get { return simulationSpeedChanged; }
            set { simulationSpeedChanged = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private Vector3D lastMousePosition = new Vector3D();

        /// <summary>
        /// 
        /// </summary>
        public Vector3D LastMousePosition
        {
          get { return lastMousePosition; }
          set { lastMousePosition = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool keyPressed()
        {
            return (this.TeclaW || this.TeclaA || this.TeclaS || this.TeclaD || this.Tab || this.Minus || this.Plus || this.TeclaT || this.TeclaG) ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool isMoving()
        {
            return (this.TeclaW || this.TeclaA || this.TeclaS || this.TeclaD) ? true : false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void tecladoNormal(byte key, int x, int y)
        {
            this.LastNormalKeyPressed = key;

            switch (Convert.ToChar(key))
            {
                case (char)ConsoleKey.Escape: { this.ExitingApplication = true; break; }
                case (char)ConsoleKey.Tab: { this.Tab = true; break; }

                case 'w': { this.TeclaW = true; break; }
                case 'a': { this.TeclaA = true; break; }
                case 's': { this.TeclaS = true; break; }
                case 'd': { this.TeclaD = true; break; }
                case 't': { this.TeclaT = true; break; }
                case 'g': { this.TeclaG = true; break; }

                case 'p': { Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE); Gl.glDisable(Gl.GL_TEXTURE_2D); break; }
                case 'l': { Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL); Gl.glEnable(Gl.GL_TEXTURE_2D); break; }
                case 'i': { Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_POINT); break; }
                case 'o': { Gl.glDisable(Gl.GL_LIGHTING); break; }
                case 'k': { Gl.glEnable(Gl.GL_LIGHTING); break; }
                case 'm': { Gl.glEnable(Gl.GL_CULL_FACE); break; }
                case 'n': { Gl.glDisable(Gl.GL_CULL_FACE); break; }

                case '1': { AppState.Instance.CurrentSimulationSpeed = AppState.SimulationSpeed.Normal; this.SimulationSpeedChanged = true; break; }
                case '2': { AppState.Instance.CurrentSimulationSpeed = AppState.SimulationSpeed.Fast; this.SimulationSpeedChanged = true; break; }
                case '3': { AppState.Instance.CurrentSimulationSpeed = AppState.SimulationSpeed.Faster; this.SimulationSpeedChanged = true; break; }
                case '4': { AppState.Instance.CurrentSimulationSpeed = AppState.SimulationSpeed.SuperFast; this.SimulationSpeedChanged = true; break; }

                case '-': { this.Minus = true; break; }
                case '+': { this.Plus = true; break; }
            }                        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void tecladoNormalUp(byte key, int x, int y)
        {
            switch (Convert.ToChar(key))
            {
                case 'w': { this.TeclaW = false; break; }
                case 'a': { this.TeclaA = false; break; }
                case 's': { this.TeclaS = false; break; }
                case 'd': { this.TeclaD = false; break; }

                case 't': { this.TeclaT = false; break; }
                case 'g': { this.TeclaG = false; break; }
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void tecladoEspecial(int key, int x, int y)
        {
            this.LastSpecialKeyPressed = key;

            switch (key)
            {
                default: { break; }
            }
        }
    }
}
