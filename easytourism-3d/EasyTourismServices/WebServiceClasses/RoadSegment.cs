using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyTourismServices
{
    public class RoadSegment
    {
        public int id;
        public String name;

        public int idIntersectionBegin;
        public int idIntersectionEnd;

        public double avgByCar;
        public double avgByFoot;

        public int way;
    }
}
