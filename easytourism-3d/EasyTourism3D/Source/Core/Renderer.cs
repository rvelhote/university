using System;
using System.Collections.Generic;
using EasyTourism3D.Properties;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace EasyTourism3D
{
    /// <summary>
    /// 
    /// </summary>
    class Renderer
    {
        /// <summary>
        /// 
        /// </summary>
        private List<ThreeDObject> objects = new List<ThreeDObject>();

        /// <summary>
        /// 
        /// </summary>
        private List<Lighting> lighting = new List<Lighting>();

        /// <summary>
        /// 
        /// </summary>
        private Cartography map;

        /// <summary>
        /// 
        /// </summary>
        public Cartography Map
        {
            get { return map; }
            set { map = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private Atmosphere atmosphere;

        /// <summary>
        /// 
        /// </summary>
        public Atmosphere Atmosphere
        {
            get { return atmosphere; }
            set { atmosphere = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<ThreeDObject> ObjectosCena
        {
            get { return this.objects; }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Lighting> IluminacaoCena
        {
            get { return this.lighting; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void render()
        {
            this.clear();

            Camera.getCurrentActiveCamera().set();

            this.renderLighting();
            this.renderAtmosphere();
            this.renderMap();            
            this.renderSceneObjects();

            this.displayMessageQueue();

            Glut.glutSwapBuffers();
        }

        /// <summary>
        /// 
        /// </summary>
        private void displayMessageQueue()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0, AppState.Instance.Width, 0, AppState.Instance.Height);
            Gl.glScalef(1, -1, 1);
            Gl.glTranslatef(0, -AppState.Instance.Height, 0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            Gl.glPushMatrix();
            Gl.glLoadIdentity();

            Gl.glDisable(Gl.GL_LIGHTING);
            Gl.glDisable(Gl.GL_DEPTH_TEST);
            Gl.glColor3d(1.0, 1.0, 1.0);

            float i = 10.0f;
            if (Messaging.Instance.Information.Count > 0)
            {
                Object[] s = Messaging.Instance.Information.ToArray();

                for (int j = 0, k = (s.Length - 1); j < 5 && k >= 0; j++, k--)
                {
                    renderBitmapString(0.0f, i, (String)s[k], 10);
                    i += 10.0f;
                }
            }

            i = 10.0f;
            foreach (String message in Messaging.Instance.Permanent)
            {
                renderBitmapString(800.0f, i, message, 10);
                i += 10.0f;
            }


            i = 700.0f;
            foreach (String message in Messaging.Instance.PoiInfo)
            {
                renderBitmapString(0.0f, i, message, 10);
                i += 10.0f;
            }

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glPopMatrix();

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glPopMatrix();
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

        }

        /// <summary>
        /// 
        /// </summary>
        private void renderAtmosphere()
        {
            this.Atmosphere.Estado.draw();
        }

        /// <summary>
        /// 
        /// </summary>
        private void clear()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();            
        }

        /// <summary>
        /// 
        /// </summary>
        private void renderSceneObjects()
        {
            if (this.objects.Count > 0)
            {                
                foreach (ThreeDObject obj in this.objects)
                {
                    obj.draw();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void renderLighting()
        {
            if (this.lighting.Count > 0)
            {
                foreach (Lighting luz in this.lighting)
                {
                    luz.draw();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        /// <param name="h"></param>
        public void redimensionar(int w, int h)
        {            
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(Camera.getCurrentActiveCamera().FOV, Convert.ToDouble(AppState.Instance.Width) / Convert.ToDouble(AppState.Instance.Height), 1.0, 9999.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="str"></param>
        private void renderBitmapString(float x, float y, String str, int size)
        {
            IntPtr sz = Glut.GLUT_BITMAP_HELVETICA_10;

            if(size == 12) {
                sz = Glut.GLUT_BITMAP_HELVETICA_12;
            } else if(size == 18) {                            
                sz = Glut.GLUT_BITMAP_HELVETICA_18;
            }

            Gl.glRasterPos2f(x, y);

            for (int i = 0; i < str.Length; i++)
            {
                Glut.glutBitmapCharacter(sz, str[i]);                
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        public void renderMap()
        {
            Gl.glPushMatrix();
                Gl.glEnable(Gl.GL_TEXTURE_2D);

                    Gl.glTranslated(0.0, -0.95, 0.0);
                    Gl.glColor3d(1.0, 1.0, 1.0);

                    this.drawIntersections();

                    if (this.Map.displayListID == 0)
                    {
                        this.Map.displayListID = Gl.glGenLists(1);
                        Gl.glNewList(this.Map.displayListID, Gl.GL_COMPILE_AND_EXECUTE);
                            this.drawRoads();
                        Gl.glEndList();
                    }
                    else
                    {
                        Gl.glCallList(this.Map.displayListID);
                    }

                Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glPopMatrix();

            this.drawPointsOfInterest();
            this.drawGenerics();
        }

        /// <summary>
        /// 
        /// </summary>
        private void drawPointsOfInterest()
        {
            if (this.Map.pointsOfInterest.Count > 0)
            {
                foreach (PointOfInterest p in this.Map.pointsOfInterest)
                {
                    p.draw();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void drawGenerics()
        {
            if (this.Map.genericObjects.Count > 0)
            {
                foreach (GenericObject g in this.Map.genericObjects)
                {
                    g.draw();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void drawIntersections()
        {
            if (this.Map.intersections.Count > 0)
            {
                foreach (Intersection i in this.Map.intersections)
                {
                    i.draw();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void drawRoads()
        {
            if (this.Map.segments.Count > 0)
            {
                foreach (RoadSegment t in this.Map.segments)
                {
                    t.draw();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void disableLights()
        {
            if (this.lighting.Count > 0)
            {
                foreach (Lighting luz in this.lighting)
                {
                    luz.off();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void enableLights()
        {
            if (this.lighting.Count > 0)
            {
                foreach (Lighting luz in this.lighting)
                {
                    luz.on();
                }
            }
        }
    }
}
