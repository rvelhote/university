using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyTourismServices
{
    /// <summary>
    /// 
    /// </summary>
    public class SVGCartography
    {
        /// <summary>
        /// 
        /// </summary>
        public String cityName;

        /// <summary>
        /// 
        /// </summary>
        public List<SVGRoadSegment> segments;

        /// <summary>
        /// 
        /// </summary>
        public List<PointOfInterest> pointsOfInterest;
    }

    /// <summary>
    /// 
    /// </summary>
    public class SVGRoadSegment
    {
        /// <summary>
        /// 
        /// </summary>
        public int id;

        /// <summary>
        /// 
        /// </summary>
        public String name;

        /// <summary>
        /// 
        /// </summary>
        public Vector3D begin;

        /// <summary>
        /// 
        /// </summary>
        public Vector3D end;
    }
}
