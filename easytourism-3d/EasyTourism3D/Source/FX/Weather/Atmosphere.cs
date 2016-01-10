using System;

namespace EasyTourism3D
{
    class Atmosphere
    {
        private WeatherState estado = new Clear();

        private void setRandomWeatherState()
        {
            this.Estado.end();

            int valor = Utilities.RandomCache.Next(0, 4000);

            if (valor > 0 && valor <= 1000 && !(this.Estado is Snowy))
            {
                this.Estado = new Snowy();
            }
            else if (valor > 1000 && valor <= 2000 && !(this.Estado is Rainy))
            {
                this.Estado = new Rainy();
            }
            else if (valor > 2000 && valor <= 3000 && !(this.Estado is Foggy))
            {
                this.Estado = new Foggy();
            }
            else if (!(this.Estado is Clear))
            {
                this.Estado = new Clear();
            }

            this.Estado.initialize();
            this.Estado.duration = Utilities.RandomCache.Next(20000, 40000);
            this.Estado.elapsed = 0;

            AppState.Instance.WeatherState = this.Estado.GetType().Name;

            Messaging.Instance.Information.Enqueue(AppState.Instance.ResourceManager.GetString("WeatherStateLabel") + this.Estado.stateName);
        }

        public void weatherStateCheck()
        {
            if (this.Estado.checkPhase() == WeatherState.Phase.Over)
            {
                this.setRandomWeatherState();
            }
            else
            {
                this.Estado.elapsed += 40;                
            }            
        }

        public WeatherState Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}