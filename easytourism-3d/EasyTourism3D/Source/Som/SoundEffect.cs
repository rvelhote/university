using System;
using Tao.OpenAl;

namespace EasyTourism3D
{
    class SoundEffect
    {
        private String soundName = "";

        public String SoundName
        {
            get { return soundName; }
            set { soundName = value; }
        }


        private IntPtr buffer = IntPtr.Zero;

        protected IntPtr Buffer
        {
            get { return buffer; }
            set { buffer = value; }
        }
        private Vector3D position = new Vector3D();

        protected Vector3D Position
        {
            get { return position; }
            set { position = value; }
        }
        private Vector3D velocity = new Vector3D();

        protected Vector3D Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }
        private int looping = Al.AL_FALSE;

        protected int Looping
        {
            get { return looping; }
            set { looping = value; }
        }
        private float pitch = 1.0f;

        protected float Pitch
        {
            get { return pitch; }
            set { pitch = value; }
        }
        private float gain = 1.0f;

        public float Gain
        {
            get { return gain; }
            set 
            {                
                gain = value;
                Al.alSourcef(this.SoundID, Al.AL_GAIN, gain);
            }
        }

        private int soundID = 0;

        public int SoundID
        {
            get { return soundID; }
            set { soundID = value; }
        }

        private int bufferID = 0;

        protected int BufferID
        {
            get { return bufferID; }
            set { bufferID = value; }
        }

        public SoundEffect(int id)
        {
            this.SoundID = id;
        }

        public SoundEffect(int id, int bid, IntPtr b, Vector3D pos, Vector3D v, bool l, float p, float g)
        {
            this.SoundID = id;
            this.BufferID = bid;

            this.Buffer = b;            
            this.Position = pos;
            this.Velocity = v;

            this.Looping = l ? Al.AL_TRUE : Al.AL_FALSE;
            this.Pitch = p;
            this.Gain = g;
        }

        public void setup()
        {            
            Al.alSourcei(this.SoundID, Al.AL_BUFFER, this.BufferID);

            Al.alSourcef(this.SoundID, Al.AL_PITCH, this.Pitch);
            Al.alSourcef(this.SoundID, Al.AL_GAIN, this.Gain);            
            Al.alSource3f(this.SoundID, Al.AL_VELOCITY, (float)this.Velocity.Px, (float)this.Velocity.Py, (float)this.Velocity.Pz);

            Al.alSourcei(this.SoundID, Al.AL_LOOPING, this.Looping);
        }        

        public void playSound()
        {
            Al.alSourceRewind(this.SoundID);
            Al.alSourcePlay(this.SoundID);
        }

        public void stopSound()
        {
            Al.alSourceStop(this.SoundID);
        }

        public void setPosition(Vector3D v)
        {
            Al.alSource3f(Assets.Instance.Sounds[this.SoundName].SoundID, Al.AL_POSITION, (float)v.Px, (float)v.Py, (float)v.Pz);
        }
    }
}
