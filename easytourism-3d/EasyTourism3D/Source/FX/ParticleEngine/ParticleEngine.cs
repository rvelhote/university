using System;
using System.Collections.Generic;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace EasyTourism3D
{
    /// <summary>
    /// 
    /// </summary>
    class ParticleEngine
    {
        /// <summary>
        /// 
        /// </summary>
        private int maxParticles;

        /// <summary>
        /// 
        /// </summary>
        public int MaxParticles
        {
            get { return maxParticles; }
            set { maxParticles = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private List<Particle> particleList;

        /// <summary>
        /// 
        /// </summary>
        public List<Particle> ParticleList
        {
            get { return particleList; }
            set { particleList = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private double baseVelocity = 0.1;

        /// <summary>
        /// 
        /// </summary>
        public double ParticleBaseVelocity
        {
            get { return baseVelocity; }
            set { baseVelocity = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="max"></param>
        public ParticleEngine(int max)
        {
            this.MaxParticles = max;
            this.ParticleList = new List<Particle>(this.MaxParticles);
            this.createParticles(this.MaxParticles);
        }

        /// <summary>
        /// 
        /// </summary>
        private ParticleType typeOfParticle;

        /// <summary>
        /// 
        /// </summary>
        public ParticleType TypeOfParticle
        {
            get { return typeOfParticle; }
            set { typeOfParticle = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ParticleType
        {
            Snow,
            Rain
        }

        /// <summary>
        /// 
        /// </summary>
        private int particleRadius = 8;

        /// <summary>
        /// 
        /// </summary>
        private int particleStart = 50;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        public void createParticles(int number)
        {
            Particle p;

            int position = 0;

            for (int i = 0; i < number; i++)
            {
                p = new Particle();
                p.setParticleProperties(this.particleRadius, this.particleRadius, this.ParticleBaseVelocity);

                if (position == 1) { p.Position.Px *= -1; }
                if (position == 2) { p.Position.Pz *= -1; }
                if (position == 3) { p.Position.Pz *= -1; p.Position.Px *= -1; }

                position++;

                if (position == 4) { position = 0; }

                this.ParticleList.Add(p);
            }
        }

        private void randomizeAroundObject()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void addMoreParticles()
        {
            int numParticles = Utilities.RandomCache.Next(100, 200);
            numParticles = (this.ParticleList.Count + numParticles < this.MaxParticles) ? numParticles : this.MaxParticles - this.ParticleList.Count;            

            if (this.particleList.Count < this.maxParticles)
            {                
                this.createParticles(numParticles);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void reviveParticles()
        {
            int revived = 0;
            int position = 0;

            foreach (Particle p in this.ParticleList)
            {
                if (!p.Alive)
                {
                    revived++;
                    p.revive(this.particleRadius, this.particleStart, this.ParticleBaseVelocity);

                    if (position == 1) { p.Position.Px *= -1; }
                    if (position == 2) { p.Position.Pz *= -1; }
                    if (position == 3) { p.Position.Pz *= -1; p.Position.Px *= -1; }

                    position++;

                    if (position == 4) { position = 0; }

                    if (this.ActiveParticles + revived >= this.CurrentMaxActiveParticles)
                    {
                        break;
                    }                    
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private int activeParticles;

        /// <summary>
        /// 
        /// </summary>
        public int ActiveParticles
        {
            get { return activeParticles; }
            set { activeParticles = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int currentMaxActiveParticles;

        /// <summary>
        /// 
        /// </summary>
        public int CurrentMaxActiveParticles
        {
            get { return currentMaxActiveParticles; }
            set { currentMaxActiveParticles = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void drawParticles()
        {
            Camera cam = Camera.getCurrentActiveCamera();

            this.ActiveParticles = 0;
            bool maxParticlesReached = false;
            
            foreach (Particle p in this.particleList)
            {
                if (p.Alive)
                {
                    this.ActiveParticles++;

                    Gl.glPushMatrix();

                    Gl.glTranslated(cam.Following.Position.Px + p.Position.Px, p.Position.Py, cam.Following.Position.Pz + p.Position.Pz);
                    Gl.glRotated(Utilities.toDegrees(cam.Following.Angle) + 90.0, 0.0, 1.0, 0.0);

                    Gl.glColor3d(1.0, 1.0, 1.0);

                    /// TODO: Deveria estar no draw da classe Particle já que ela herda de ThreeDObject
                    if (this.TypeOfParticle == ParticleType.Rain)
                    {
                        Gl.glBegin(Gl.GL_QUADS);
                            Gl.glTexCoord2d(1.0, 1.0);
                            Gl.glVertex3d(0.001, -0.1, 0.0);

                            Gl.glTexCoord2d(1.0, 0.0);
                            Gl.glVertex3d(-0.001, -0.1, 0.0);

                            Gl.glTexCoord2d(0.0, 0.0);
                            Gl.glVertex3d(-0.001, 0.1, 0.0);

                            Gl.glTexCoord2d(0.0, 1.0);
                            Gl.glVertex3d(0.001, 0.1, 0.0);
                        Gl.glEnd();
                    }
                    else
                    {
                        Glut.glutSolidSphere(0.02, 10, 10);
                    }

                    p.Position.Py -= p.Velocity;

                    Gl.glPopMatrix();
                }
                
                if (this.ActiveParticles >= this.CurrentMaxActiveParticles || this.ActiveParticles >= this.MaxParticles)
                {
                    maxParticlesReached = true;
                    break;
                }
            }

            if (!maxParticlesReached)
            {
                this.reviveParticles();
            }
        }
    }
}
