using System;

namespace EasyTourismServices
{
    /// <summary>
    /// 
    /// </summary>
    public class Vector3D
    {
        /// <summary>
        /// 
        /// </summary>
        public double x;

        /// <summary>
        /// 
        /// </summary>
        public double y;

        /// <summary>
        /// 
        /// </summary>
        public double z;

        /// <summary>
        /// 
        /// </summary>
        public Vector3D()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
