using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyTourism3D
{
    class GenericObjectFactory
    {
        public static GenericObject getGenericObject(String type)
        {
            GenericObject go;

            switch (type)
            {
                case "EDF":
                    {
                        go = new RandomBuilding();
                        break;
                    }

                case "ARV":
                    {
                        go = new Tree();
                        break;
                    }

                default:
                    {
                        go = new RandomBuilding();
                        break;
                    }
            }

            return go;
        }
    }
}
