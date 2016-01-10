using System;
using Tao.OpenGl;
using System.Collections.Generic;

namespace EasyTourism3D
{
    class Intersection : ThreeDObject
    {
        //public static int numberOfIntersections;
        //public static List<Intersection> intersectionList = new List<Intersection>();
        //public static Intersection getIntersectionWithID(int id)
        //{
        //    Intersection intr = null;

        //    foreach (Intersection i in Intersection.intersectionList)
        //    {
        //        if (i.id == id)
        //        {
        //            intr = i;
        //            break;
        //        }
        //    }

        //    return intr;
        //}

        public int id;
        public double Area = 1.0;

        public List<Directions> possibleDirections = new List<Directions>(4);

        public enum Directions
        {
            North,
            South,
            East,
            West,
        }

        public Intersection(int id)
        {
            this.id = id;
            //Intersection.intersectionList.Add(this);
            //this.id = Intersection.intersectionList.Count;
        }

        public override void draw()
        {
            Gl.glPushMatrix();

                Gl.glTranslated(this.Position.Px, this.Position.Py, this.Position.Pz);

                Gl.glBindTexture(Gl.GL_TEXTURE_2D, Assets.Instance.Textures["Interseccao"]);
                    Gl.glBegin(Gl.GL_QUADS);

                        Gl.glNormal3d(0.0, 1.0, 0.0);

                        Gl.glTexCoord2d(1.0, 0.0);
                        Gl.glVertex3d(this.Area, this.Position.Py, this.Area);

                        Gl.glTexCoord2d(0.0, 0.0);
                        Gl.glVertex3d(this.Area, this.Position.Py, - this.Area);

                        Gl.glTexCoord2d(0.0, 1.0);
                        Gl.glVertex3d(- this.Area, this.Position.Py, - this.Area);

                        Gl.glTexCoord2d(1.0, 1.0);
                        Gl.glVertex3d(- this.Area, this.Position.Py, + this.Area);
                    Gl.glEnd();

                Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);

            Gl.glPopMatrix();
        }
    }
}
