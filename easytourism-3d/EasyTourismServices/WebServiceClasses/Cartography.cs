using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyTourismServices
{
    public class Cartography
    {
        public List<PointOfInterest> pointsOfInterest = new List<PointOfInterest>();
        public List<Intersection> intersections = new List<Intersection>();
        public List<RoadSegment> roadSegments = new List<RoadSegment>();
        public List<GenericObject> genericObjects = new List<GenericObject>();
    }
}
