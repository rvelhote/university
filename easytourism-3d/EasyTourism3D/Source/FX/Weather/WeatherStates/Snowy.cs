using System;
using Tao.OpenGl;
using Tao.OpenAl;

namespace EasyTourism3D
{
    class Snowy : WeatherState
    {
        public enum SnowType
        {
            Light,
            Strong,
            Normal,
        }

        private SnowType type;
        public SnowType Type
        {
            get { return type; }
            set { type = value; }
        }

        private Foggy snowyFog = new Foggy();
        public Foggy SnowyFog
        {            
            get { return snowyFog; }
            set { snowyFog = value; }
        }

        private ParticleEngine engine;
        public ParticleEngine Engine
        {
            get { return engine; }            
        }

        public Snowy()
        {
            this.stateName = AppState.Instance.ResourceManager.GetString("WeatherStateSnowy");            

            int maxParticles = 0;

            this.Type = (SnowType)Utilities.RandomCache.Next(0, 3);

            switch (this.Type)
            {
                case SnowType.Light:
                    {
                        maxParticles = 200;
                        this.snowyFog.MaximumDensity = 0.01f;
                        break;
                    }

                case SnowType.Normal:
                    {
                        maxParticles = 400;
                        this.snowyFog.MaximumDensity = 0.015f;
                        break;
                    }

                case SnowType.Strong:
                    {
                        maxParticles = 600;
                        this.snowyFog.MaximumDensity = 0.02f;
                        break;
                    }
            }
            
            this.snowyFog.FogColor = new float[] { 0.6f, 0.6f, 0.6f, 1.0f };
            this.snowyFog.initialize();            

            this.engine = new ParticleEngine(maxParticles);
            this.engine.ParticleBaseVelocity = -1.0f;

            this.Engine.TypeOfParticle = ParticleEngine.ParticleType.Snow;
        }

        public override void initialize()
        {
            if (this.Type == SnowType.Normal)
            {
                if (Assets.Instance.Sounds.ContainsKey("Vento"))
                {
                    Al.alSourcePlay(Assets.Instance.Sounds["Vento"].SoundID);
                }
            }
            else if (this.Type == SnowType.Light)
            {
                if (Assets.Instance.Sounds.ContainsKey("Vento"))
                {
                    Al.alSourcePlay(Assets.Instance.Sounds["Vento"].SoundID);
                }
            }
            else if (this.Type == SnowType.Strong)
            {
                if (Assets.Instance.Sounds.ContainsKey("Vento"))
                {
                    Al.alSourcePlay(Assets.Instance.Sounds["Vento"].SoundID);
                }
            }
        }

        public override void end()
        {
            if (this.Type == SnowType.Normal)
            {
                if (Assets.Instance.Sounds.ContainsKey("Vento"))
                {
                    Al.alSourceStop(Assets.Instance.Sounds["Vento"].SoundID);
                }
            }
            else if (this.Type == SnowType.Light)
            {
                if (Assets.Instance.Sounds.ContainsKey("Vento"))
                {
                    Al.alSourceStop(Assets.Instance.Sounds["Vento"].SoundID);
                }
            }
            else if (this.Type == SnowType.Strong)
            {
                if (Assets.Instance.Sounds.ContainsKey("Vento"))
                {
                    Al.alSourceStop(Assets.Instance.Sounds["Vento"].SoundID);
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

            this.snowyFog.draw();
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
            this.Engine.CurrentMaxActiveParticles -= 2;
        }
    }
}
