using System;

namespace EasyTourism3D
{
    abstract class WeatherState
    {
        public String stateName;

        public int duration = 0;
        public int elapsed = 0;

        private Phase currentPhase = Phase.One;

        internal Phase CurrentPhase
        {
            get { return currentPhase; }
            set { currentPhase = value; }
        }

        public enum Phase
        {
            One,
            Two,
            Three,
            Over
        }

        public Phase checkPhase()
        {
            Phase current = this.CurrentPhase;

            if (this.elapsed <= this.duration / 3)
            {
                this.CurrentPhase = Phase.One;
            }
            else if (this.elapsed <= this.duration / 2)
            {
                this.CurrentPhase = Phase.Two;
            }
            else if (this.elapsed <= this.duration)
            {
                this.CurrentPhase = Phase.Three;
            }
            else
            {
                current = Phase.Over;
            }

            return current;
        }

        public abstract void initialize();
        public abstract void end();

        public abstract void phaseOne();
        public abstract void phaseTwo();
        public abstract void phaseThree();

        public abstract void draw();
    }
}
