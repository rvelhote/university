using System;
using System.Collections.Generic;

namespace EasyTourism3D
{
    class Tour
    {
        public int cityID;
        public DateTime begin = DateTime.Now;
        public DateTime end = DateTime.Now.AddDays(1.0);
        public List<ToVisit> toVisit = new List<ToVisit>();
    }
}
