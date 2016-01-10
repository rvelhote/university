using System;

namespace EasyTourism3D
{
    class RGBA
    {
        private float r;

        public float Red
        {
            get { return r; }
            set { r = value; }
        }
        private float g;

        public float Green
        {
            get { return g; }
            set { g = value; }
        }
        private float b;

        public float Blue
        {
            get { return b; }
            set { b = value; }
        }
        private float a;

        public float Alpha
        {
            get { return a; }
            set { a = value; }
        }

        public RGBA()
        {
        }

        public RGBA(float r, float g, float b, float a)
        {
            this.Red = r;
            this.Green = g;
            this.Blue = b;
            this.Alpha = a;
        }

        public void Set(float r, float g, float b, float a)
        {
            this.Red = r;
            this.Green = g;
            this.Blue = b;
            this.Alpha = a;
        }

        public float[] toArray()
        {
            return new float[] { this.Red, this.Green, this.Blue, this.Alpha };
        }
    }
}
