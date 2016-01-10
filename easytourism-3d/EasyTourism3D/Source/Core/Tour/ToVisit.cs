using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyTourism3D
{
    class ToVisit
    {
        public int attractionID;
        public bool visited;
        public int ordering;
        public DateTime beginVisit;
        public DateTime endVisit;

        public ToVisit(int id, bool visited, int ordering, DateTime begin, DateTime end)
        {
            this.attractionID = id;
            this.visited = visited;
            this.ordering = ordering;
            this.beginVisit = begin;
            this.endVisit = end;
        }
    }
}
