using System;
using System.Collections.Generic;
using Tao.OpenGl;

namespace EasyTourism3D
{
    class Camera : IControllable
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<Camera> CameraList = new List<Camera>(1);
        public static Camera getCurrentActiveCamera()
        {
            Camera current = null;

            foreach (Camera c in Camera.CameraList)
            {
                if (c.IsActive)
                {
                    current = c;
                }
            }

            return current;
        }

        private ThreeDObject following;

        public ThreeDObject Following
        {
            get { return following; }
            set { following = value; }
        }

        private bool active;

        public bool IsActive
        {
            get { return active; }
            set { active = value; }
        }


        private double fov = 60.0;
        private double angulo;
        private double alturaCameraTopo = 100.0;
        private double anguloRotacao = 5.0;

        public double RotationAngle
        {
            get { return anguloRotacao; }
        }

        public double AlturaCameraTopo
        {
            get { return alturaCameraTopo; }
            set { alturaCameraTopo = value; }
        }

        public double Angulo
        {
            get { return angulo; }
            set { angulo = value; }
        }

        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
        private double longitude;

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        public double velocidade = 0.1;

        private Vector3D eye = new Vector3D();

        internal Vector3D Eye
        {
            get { return eye; }
            set { eye = value; }
        }
        private Vector3D center = new Vector3D();

        internal Vector3D Center
        {
            get { return center; }
            set { center = value; }
        }
        private Vector3D up = new Vector3D();

        internal Vector3D Up
        {
            get { return up; }
            set { up = value; }
        }

        public enum TipoCamera
        {
            Topo,
            TerceiraPessoa,
            FPS
        }

        private TipoCamera camera = TipoCamera.Topo;

        #region Propriedades
        public TipoCamera CameraActual
        {
            get
            {
                return this.camera;
            }

            set
            {
                this.camera = value;
            }
        }
        public double FOV
        {
            get
            {
                return this.fov;
            }

            set
            {
                this.fov = value;
            }
        }

        //public double Angulo
        //{
        //    get
        //    {
        //        return this.angulo;
        //    }

        //    set
        //    {
        //        this.angulo = value;
        //    }
        //}
        #endregion

        //#region Singleton
        //private static readonly Camera instancia = new Camera();

        //private Camera() { }

        //public static Camera Instancia
        //{
        //    get
        //    {
        //        return instancia;
        //    }
        //}
        //#endregion

        public void set()
        {
            if (this.CameraActual == TipoCamera.TerceiraPessoa)
            {
                this.Center.Px = this.Following.Position.Px;
                this.Center.Py = this.Following.Position.Py + 0.6;
                this.Center.Pz = this.Following.Position.Pz;

                this.Eye.Px = this.Center.Px - Math.Cos(this.Longitude);
                this.Eye.Py = this.Center.Py + 0.4;
                this.Eye.Pz = this.Center.Pz - Math.Sin(-this.Longitude) ;

                this.Up.Px = 0.0;
                this.Up.Py = 1.0;
                this.Up.Pz = 0.0;

            }
            else if (this.CameraActual == TipoCamera.FPS)
            {
                this.Eye.Px = this.Following.Position.Px;
                this.Eye.Py = this.Following.Position.Py + 0.9;
                this.Eye.Pz = this.Following.Position.Pz;

                this.Center.Px = this.Following.Position.Px + Math.Cos(this.Longitude) * Math.Cos(this.Latitude);
                this.Center.Py = this.Eye.Py + Math.Sin(this.Latitude);
                this.Center.Pz = this.Following.Position.Pz + Math.Sin(-this.Longitude) * Math.Cos(this.Latitude);

                this.Up.Px = 0.0;
                this.Up.Py = 1.0;
                this.Up.Pz = 0.0;
            }
            else if (this.CameraActual == TipoCamera.Topo)
            {
                this.Eye.Px = this.Following.Position.Px;
                this.Eye.Py = this.AlturaCameraTopo;
                this.Eye.Pz = this.Following.Position.Pz;

                this.Center.Px = this.Following.Position.Px;
                this.Center.Py = this.Following.Position.Py;
                this.Center.Pz = this.Following.Position.Pz;

                this.Up.Px = 0.0;
                this.Up.Py = 0.0;
                this.Up.Pz = -1.0;
            }

            Glu.gluLookAt(this.Eye.Px, this.Eye.Py, this.Eye.Pz, this.Center.Px, this.Center.Py, this.Center.Pz, this.Up.Px, this.Up.Py, this.Up.Pz);
            //Console.WriteLine(this.Eye.Pz);
        }

        public void mudarCamera()
        {
            this.CameraActual = (this.CameraActual == TipoCamera.FPS) ? 0 : this.CameraActual + 1;            
        }

        #region IControlavel Members

        public double Velocity
        {
            get { return this.velocidade; }
            set { this.velocidade = value; }
        }

        public void moveForward()
        {
        }

        public void moveBackward()
        {
        }

        public void lookUp()
        {
            if (this.CameraActual == TipoCamera.Topo)
            {
                this.AlturaCameraTopo++;
            }
        }

        public void lookDown()
        {
            if (this.CameraActual == TipoCamera.Topo && this.AlturaCameraTopo > 1.0)
            {
                this.AlturaCameraTopo--;
            }
        }

        public void moveLeft()
        {
            this.Longitude += Utilities.toRadians(this.RotationAngle);
        }

        public void moveRight()
        {
            this.Longitude -= Utilities.toRadians(this.RotationAngle);
        }

        #endregion
    }
}
