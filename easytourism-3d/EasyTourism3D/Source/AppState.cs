using System;
using System.Resources;
using System.Globalization;
using System.Threading;

namespace EasyTourism3D
{
    /// <summary>
    /// 
    /// </summary>
    class AppState
    {
        #region Definição do Singleton

        /// <summary>
        /// 
        /// </summary>
        private static readonly AppState instance = new AppState();

        /// <summary>
        /// 
        /// </summary>
        private AppState() { }

        /// <summary>
        /// 
        /// </summary>
        public static AppState Instance
        {
            get { return instance; }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        private ResourceManager resourceManager;

        /// <summary>
        /// 
        /// </summary>
        public ResourceManager ResourceManager
        {
            get { return resourceManager; }
            set { resourceManager = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isoCode"></param>
        public void setLanguage(String isoCode)
        {            
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(isoCode);            
            resourceManager = new ResourceManager("EasyTourism3D.Language.Resources", System.Reflection.Assembly.GetExecutingAssembly());
        }

        private int tourID;

        public int TourID
        {
            get { return tourID; }
            set { tourID = value; }
        }

        private int width = 1024;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        private int height = 768;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        private bool fullscreen;

        public bool Fullscreen
        {
            get { return fullscreen; }
            set { fullscreen = value; }
        }

        private bool saveTour = true;

        public bool SaveTour
        {
            get { return saveTour; }
            set { saveTour = value; }
        }

        private String language = "pt-PT";


        public String Language
        {
            get { return language; }
            set { language = value; }
        }

        private String username;

        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        private String password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        private bool saveTourOnExit;

        public bool SaveTourOnExit
        {
            get { return saveTourOnExit; }
            set { saveTourOnExit = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        private string weatherState = "Clear";

        public string WeatherState
        {
            get { return weatherState; }
            set { weatherState = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private DateTime currentDate = new DateTime(2008, 1, 5, 12, 0, 0);

        /// <summary>
        /// 
        /// </summary>
        public DateTime CurrentDate
        {
            get { return currentDate; }
            set { currentDate = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int globalTick = 0;

        /// <summary>
        /// 
        /// </summary>
        public void clockForward()
        {
            switch (AppState.Instance.CurrentSimulationSpeed)
            {
                case AppState.SimulationSpeed.Normal:
                    {
                        this.currentDate = this.currentDate.AddSeconds(2.0);
                        break;
                    }

                case AppState.SimulationSpeed.Fast:
                    {
                        this.currentDate = this.currentDate.AddSeconds(20.0);
                        break;
                    }

                case AppState.SimulationSpeed.Faster:
                    {
                        this.currentDate = this.currentDate.AddSeconds(60.0);
                        break;
                    }

                case AppState.SimulationSpeed.SuperFast:
                    {
                        this.currentDate = this.currentDate.AddSeconds(120.0);
                        break;
                    }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public enum SimulationSpeed
        {
            Normal = 1,
            Fast = 30,
            Faster = 60,
            SuperFast = 240
        }

        /// <summary>
        /// 
        /// </summary>
        private SimulationSpeed currentSimulationSpeed = SimulationSpeed.Normal;

        /// <summary>
        /// 
        /// </summary>
        public SimulationSpeed CurrentSimulationSpeed
        {
            get { return currentSimulationSpeed; }
            set { currentSimulationSpeed = value; }
        }
    }
}