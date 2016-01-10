using System;
using Tao.OpenGl;

namespace EasyTourism3D
{
    class CollisionBox
    {
        private Vector3D adjustment = new Vector3D();

        public Vector3D Adjustment
        {
            get { return adjustment; }
            set { adjustment = value; }
        }

        private Vector3D dimensions = new Vector3D();

        public Vector3D Dimensions
        {
            get { return dimensions; }
            set { dimensions = value; }
        }

        private bool visible;

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        public void drawArea(Vector3D pos)
        {
            Gl.glBegin(Gl.GL_QUADS);
                Gl.glVertex3d(pos.Px + this.Adjustment.Px + this.Dimensions.Px, pos.Py + this.Adjustment.Py + 2.0, pos.Pz + this.Adjustment.Pz + this.Dimensions.Pz);
                Gl.glVertex3d(pos.Px + this.Adjustment.Px - this.Dimensions.Px, pos.Py + this.Adjustment.Py + 2.0, pos.Pz + this.Adjustment.Pz + this.Dimensions.Pz);
                Gl.glVertex3d(pos.Px + this.Adjustment.Px - this.Dimensions.Px, pos.Py + this.Adjustment.Py + 2.0, pos.Pz + this.Adjustment.Pz - this.Dimensions.Pz);
                Gl.glVertex3d(pos.Px + this.Adjustment.Px + this.Dimensions.Px, pos.Py + this.Adjustment.Py + 2.0, pos.Pz + this.Adjustment.Pz - this.Dimensions.Pz);
            Gl.glEnd();

            //Gl.glBegin(Gl.GL_QUADS);
            //Gl.glVertex3d(pos.Px + this.Adjustment.Px + this.Dimensions.Px * 2, pos.Py + this.Adjustment.Py + 1.0, pos.Pz + this.Adjustment.Pz + this.Dimensions.Pz * 2);
            //Gl.glVertex3d(pos.Px + this.Adjustment.Px - this.Dimensions.Px * 2, pos.Py + this.Adjustment.Py + 1.0, pos.Pz + this.Adjustment.Pz + this.Dimensions.Pz * 2);
            //Gl.glVertex3d(pos.Px + this.Adjustment.Px - this.Dimensions.Px * 2, pos.Py + this.Adjustment.Py + 1.0, pos.Pz + this.Adjustment.Pz - this.Dimensions.Pz * 2);
            //Gl.glVertex3d(pos.Px + this.Adjustment.Px + this.Dimensions.Px * 2, pos.Py + this.Adjustment.Py + 1.0, pos.Pz + this.Adjustment.Pz - this.Dimensions.Pz * 2);
            //Gl.glEnd();
        }
    }
}
