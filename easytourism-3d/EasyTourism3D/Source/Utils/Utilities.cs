using System;

namespace EasyTourism3D
{
    class Utilities
    {
        public static double toRadians(double graus)
        {
            return (Math.PI * (graus) / 180.0);
        }

        public static double toDegrees(double radianos)
        {
            return (180.0 * (radianos) / Math.PI);
        }

        private static Random randomCache = new Random((int)DateTime.Now.Ticks);

        public static Random RandomCache
        {
            get { return Utilities.randomCache; }
            set { Utilities.randomCache = value; }
        }
    }
}
