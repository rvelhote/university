using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyTourismServices
{
    public class PointOfInterest
    {
        public int id;
        public int segmentID;

        public String name;
        public String model;

        public Vector3D position;        
        public String description;

        public List<String> features;
        public List<String> restrictions;

        public String type;
        public String classification;

        public String facing;
    }
}
