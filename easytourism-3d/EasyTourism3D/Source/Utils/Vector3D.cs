using System;

namespace EasyTourism3D
{
    class Vector3D
    {
        public Vector3D()
        {
            this.Px = this.Py = this.Pz = 0.0;
        }

        public Vector3D(double x, double y, double z)
        {
            this.Px = x;
            this.Py = y;
            this.Pz = z;
        }

        private double px;
        public double Px
        {
            get { return px; }
            set { px = value; }
        }

        private double py;
        public double Py
        {
            get { return py; }
            set { py = value; }
        }

        private double pz;
        public double Pz
        {
            get { return pz; }
            set { pz = value; }
        }

        public double Length
        {
            get { return Math.Abs(Math.Sqrt(Math.Pow(this.Px, 2.0) + Math.Pow(this.Py, 2.0) + Math.Pow(this.Pz, 2.0))); }
        }

        public Vector3D sum(Vector3D ov)
        {
            return new Vector3D(this.Px + ov.px, this.Py + ov.Py, this.Pz + ov.Pz);
        }

        public Vector3D subtract(Vector3D ov)
        {
            return new Vector3D(this.Px - ov.px, this.Py - ov.Py, this.Pz - ov.Pz);
        }

        public Vector3D scalarMultiplication(double scalar)
        {
            return new Vector3D(this.Px * scalar, this.Py * scalar, this.Pz * scalar);
        }

        public Vector3D normalize()
        {
            double len = this.Length;
            return new Vector3D(this.Px / len, this.Py / len, this.Pz / len);
        }

        public double dotProduct(Vector3D ov)
        {
            return (this.Px * ov.Px) + (this.Py * ov.Py) + (this.Pz * ov.Pz);
        }

        public Vector3D crossProduct(Vector3D ov)
        {
            return new Vector3D((this.Py * ov.Pz) - (ov.Py * this.Pz),
                                (this.Pz * ov.Px) - (ov.Pz * this.Px),
                                (this.Px * ov.Py) - (ov.Px * this.Py));
        }

        public double angle(Vector3D ov)
        {
            //Vector3D v1 = this.normalize();
            //Vector3D v2 = ov.normalize();

            //return Utilities.toDegrees(Math.Acos(v1.dotProduct(v2)));
            //return Utilities.toDegrees(Math.Atan2(v1.crossProduct(v2).Length, v1.dotProduct(v2)));

            //return Utilities.toDegrees(Math.Atan2(this.Px - ov.Px, this.Pz - ov.Pz));
            return Utilities.toDegrees(Math.Atan2(this.Px - ov.Px, this.Pz - ov.Pz));

            //double d = Math.Atan2(this.Px - ov.Px, this.Pz - ov.Pz);

            //d = d < 0.0 ? d + 2 * Math.PI : d;

            //return Utilities.toDegrees(d);
        }

        public double distance(Vector3D ov)
        {
            return Math.Sqrt(Math.Pow(this.Px - ov.Px, 2.0) + Math.Pow(this.Py - ov.Py, 2.0) + Math.Pow(this.Pz - ov.Pz, 2.0));
        }

        public void escreve()
        {
            Console.WriteLine("X: {0} | Y: {1} | Z: {2}", this.Px, this.Py, this.Pz);
        }

        public void set(double x, double y, double z)
        {
            this.Px = x;
            this.Py = y;
            this.Pz = z;
        }
    }
}
