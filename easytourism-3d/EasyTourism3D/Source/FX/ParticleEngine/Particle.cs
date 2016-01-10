using System;
using Tao.OpenGl;

namespace EasyTourism3D
{
    class Particle : ThreeDObject
    {
        private double velocity;

        public double Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public bool Alive
        {
            get { return this.Position.Py <= -0.1 ? false : true; }
        }

        public override void draw()
        {
        }

        public void revive(int particleRadius, int particleStart, double ParticleBaseVelocity)
        {
            this.setParticleProperties(particleRadius, particleRadius, ParticleBaseVelocity);
        }

        public void setParticleProperties(int particleRadius, int particleStart, double ParticleBaseVelocity)
        {
            this.Position.Px = Utilities.RandomCache.Next(0, particleRadius) * (Utilities.RandomCache.Next(0, 1) == 0 ? -1 : 1);
            this.Position.Py = Utilities.RandomCache.Next(particleStart, particleStart * 2);
            this.Position.Pz = Utilities.RandomCache.Next(0, particleRadius) * (Utilities.RandomCache.Next(0, 1) == 1 ? -1 : 1);

            this.Velocity = Utilities.RandomCache.NextDouble() + ParticleBaseVelocity;

            if (this.Velocity <= 0.0)
            {
                this.Velocity = 0.1;
            }
        }
    }
}
