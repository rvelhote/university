using System;
using System.Collections.Generic;

namespace EasyTourismServices
{
    /// <summary>
    /// 
    /// </summary>
    public class TourList
    {
        /// <summary>
        /// 
        /// </summary>
        public bool authenticated;

        /// <summary>
        /// 
        /// </summary>
        public int touristID;
        
        /// <summary>
        /// 
        /// </summary>
        public List<Tour> tours = new List<Tour>(1);
    }
}
