using System;
using System.Collections.Generic;
using Tao.OpenGl;

namespace EasyTourism3D
{
    class Cartography
    {
        public List<RoadSegment> segments = new List<RoadSegment>();
        public List<Intersection> intersections = new List<Intersection>();
        public List<PointOfInterest> pointsOfInterest = new List<PointOfInterest>();
        public List<GenericObject> genericObjects = new List<GenericObject>();

        private bool activa = false;        

        public bool Active
        {
            get { return activa; }
            set { activa = value; }
        }

        public int displayListID = 0;

        public Intersection getIntersectionWithID(int id)
        {
            Intersection intr = null;

            foreach (Intersection i in this.intersections)
            {
                if (i.id == id)
                {
                    intr = i;
                    break;
                }
            }

            return intr;
        }

        public PointOfInterest getPointOfInterestWithID(int id)
        {
            PointOfInterest point = null;

            foreach (PointOfInterest p in this.pointsOfInterest)
            {
                if (p.ID == id)
                {
                    point = p;
                    break;
                }
            }

            return point;
        }        
    }
}
