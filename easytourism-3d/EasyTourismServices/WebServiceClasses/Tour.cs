using System;
using System.Collections.Generic;

namespace EasyTourismServices
{
    /// <summary>
    /// 
    /// </summary>
    public class Tour
    {
        /// <summary>
        /// 
        /// </summary>
        public bool authenticated;

        /// <summary>
        /// 
        /// </summary>
        public int tourID;

        /// <summary>
        /// 
        /// </summary>
        public int cityID;

        /// <summary>
        /// 
        /// </summary>
        public String cityName;

        /// <summary>
        /// 
        /// </summary>
        public DateTime begin = DateTime.Now;
        
        /// <summary>
        /// 
        /// </summary>
        //public List<PointOfInterest> toVisit;
        public List<ToVisit> toVisit;
    }
}
