using System;
using Tao.OpenGl;
using Tao.OpenAl;

namespace EasyTourism3D
{
    class Rainy : WeatherState
    {
        public enum RainType
        {
            Shower,
            Storm,
            Normal,
        }

        private RainType type;
        public Foggy fog = new Foggy();

        public RainType Type
        {
            get { return type; }
            set { type = value; }
        }

        private ParticleEngine engine;

        public ParticleEngine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public Rainy()
        {
            this.stateName = AppState.Instance.ResourceManager.GetString("WeatherStateRainy");
            

            int maxParticles = 0;

            this.Type = (RainType)Utilities.RandomCache.Next(0, 3);
            this.fog.initialize();

            switch (this.Type)
            {
                case RainType.Shower:
                    {
                        maxParticles = 200;
                        this.fog.MaximumDensity = 0.01f;
                        break;
                    }

                case RainType.Normal:
                    {
                        maxParticles = 400;
                        this.fog.MaximumDensity = 0.015f;
                        break;
                    }

                case RainType.Storm:
                    {
                        maxParticles = 600;
                        this.fog.MaximumDensity = 0.02f;
                        break;
                    }
            }

            this.engine = new ParticleEngine(maxParticles);
            this.engine.ParticleBaseVelocity = 0.7f;

            this.Engine.TypeOfParticle = ParticleEngine.ParticleType.Rain;
        }

        public override void initialize()
        {
            if (this.Type == RainType.Normal)
            {
                if (Assets.Instance.Sounds.ContainsKey("Chuva"))
                {
                    Al.alSourcePlay(Assets.Instance.Sounds["Chuva"].SoundID);
                }
            }
            else if (this.Type == RainType.Shower)
            {
                if (Assets.Instance.Sounds.ContainsKey("Chuva"))
                {
                    Al.alSourcePlay(Assets.Instance.Sounds["Chuva"].SoundID);
                }
            }
            else if (this.Type == RainType.Storm)
            {
                if (Assets.Instance.Sounds.ContainsKey("Chuva"))
                {
                    Al.alSourcePlay(Assets.Instance.Sounds["Chuva"].SoundID);
                }
            }
            
            //Al.alSource3f(Assets.Instancia.Sounds["Chimes"].SoundID, Al.AL_POSITION, 0.0f, 0.0f, 0.0f);
            
            //Al.alListener3f(Al.AL_POSITION, (float)Turista.Instancia.Posicao.Px, (float)Turista.Instancia.Posicao.Py, (float)Turista.Instancia.Posicao.Pz);

            //Gl.glEnable(Gl.GL_FOG);
            //Gl.glFogi(Gl.GL_FOG_MODE, Gl.GL_EXP2);
            //Gl.glFogfv(Gl.GL_FOG_COLOR, this.fogColor);
            //Gl.glFogf(Gl.GL_FOG_DENSITY, this.density);
            //Gl.glHint(Gl.GL_FOG_HINT, Gl.GL_NICEST);
        }

        public override void end()
        {
            if (this.Type == RainType.Normal)
            {
                if (Assets.Instance.Sounds.ContainsKey("Chuva"))
                {
                    Al.alSourceStop(Assets.Instance.Sounds["Chuva"].SoundID);
                }
            }
            else if (this.Type == RainType.Shower)
            {
                if (Assets.Instance.Sounds.ContainsKey("Chuva"))
                {
                    Al.alSourceStop(Assets.Instance.Sounds["Chuva"].SoundID);
                }
            }
            else if (this.Type == RainType.Storm)
            {
                if (Assets.Instance.Sounds.ContainsKey("Chuva"))
                {
                    Al.alSourceStop(Assets.Instance.Sounds["Chuva"].SoundID);
                }
            }
            
            this.engine.ParticleList.Clear();
            Gl.glDisable(Gl.GL_FOG);
        }

        public override void draw()
        {
            if (this.elapsed % 400 == 0)
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
            }

            this.fog.draw();
            engine.drawParticles();            
        }

        public override void phaseOne()
        {
            this.Engine.CurrentMaxActiveParticles += 2;
        }

        public override void phaseTwo()
        {         
            this.Engine.reviveParticles();
        }

        public override void phaseThree()
        {
            this.Engine.CurrentMaxActiveParticles += 2;
        }
    }
}
