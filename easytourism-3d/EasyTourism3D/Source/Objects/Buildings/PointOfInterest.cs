using System;
using System.Collections.Generic;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.OpenAl;

namespace EasyTourism3D
{
    class PointOfInterest : ThreeDObject, IAudible
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private String nome;

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private RoadSegment associatedSegment;

        public RoadSegment AssociatedSegment
        {
            get { return associatedSegment; }
            set { associatedSegment = value; }
        }

        private String description;

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        private String facing;

        public String Facing
        {
            get { return facing; }
            set { facing = value; }
        }


        private List<String> features = new List<string>(1);

        public List<String> Features
        {
            get { return features; }
            set { features = value; }
        }

        private bool visited = false;

        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }

        private bool toVisit = false;

        public bool ToVisit
        {
            get { return toVisit; }
            set { toVisit = value; }
        }

        public PointOfInterest(Vector3D initialPosition)
        {
            this.Position.Px = initialPosition.Px;
            this.Position.Py = initialPosition.Py;
            this.Position.Pz = initialPosition.Pz;
        }

        public PointOfInterest(Vector3D initialPosition, bool autoPlay)
        {
            this.Position.Px = initialPosition.Px;
            this.Position.Py = initialPosition.Py;
            this.Position.Pz = initialPosition.Pz;

            if (autoPlay)
            {
                this.setSoundPosition();
                this.playSound();
            }
        }

        public override void draw()
        {
            if (this.Visible && Assets.Instance.Models.ContainsKey(this.ModelName))
            {
                ModelData modelo = Assets.Instance.Models[this.ModelName];

                if (this.ColisionArea.Visible)
                {
                    this.ColisionArea.drawArea(this.Position);
                }

                if (this.ToVisit && !this.Visited)
                {
                    Camera cam = Camera.getCurrentActiveCamera();

                    Gl.glEnable(Gl.GL_TEXTURE_2D);

                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, Assets.Instance.Textures["Seta"]);

                        Gl.glPushMatrix();
                            Gl.glTranslated(this.Position.Px, this.Position.Py + 0.5, this.Position.Pz);                            
                            Gl.glRotated(Utilities.toDegrees(cam.Following.Angle) + 90.0, 0.0, 1.0, 0.0);

                            Gl.glBegin(Gl.GL_TRIANGLES);

                            Gl.glTexCoord2d(1, 1);
                            Gl.glVertex3d(0.5, 10.0, 0.0);

                            Gl.glTexCoord2d(0, 0);
                            Gl.glVertex3d(0.0, 9.0, 0.0);

                            Gl.glTexCoord2d(1, 0);                            
                            Gl.glVertex3d(-0.5, 10.0, 0.0);
                            Gl.glEnd();
                        Gl.glPopMatrix();

                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, 0);
                }
 
                Gl.glDisable(Gl.GL_TEXTURE_2D);
                    Gl.glPushMatrix();
                        Gl.glTranslated(modelo.Translacao.Px, modelo.Translacao.Py, modelo.Translacao.Pz);                        
                        Gl.glTranslated(this.Position.Px, this.Position.Py, this.Position.Pz);

                        Gl.glRotated(modelo.Graus, modelo.Rotacao.Px, modelo.Rotacao.Py, modelo.Rotacao.Pz);
                        Gl.glScaled(modelo.Escala.Px, modelo.Escala.Py, modelo.Escala.Pz);

                        modelo.Model.Render();
                    Gl.glPopMatrix();
                Gl.glEnable(Gl.GL_TEXTURE_2D);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// TODO: Implementar completamente
        private void rotateToFacing()
        {            
            /// TODO: Mudar Facing para uma enum
            switch (this.Facing)
            {
                case "N": { Gl.glRotated(180.0, 0.0, 1.0, 0.0); break; }
                case "S": { Gl.glRotated(0.0, 0.0, 1.0, 0.0); break; }
                case "E": { Gl.glRotated(90.0, 0.0, 1.0, 0.0); break; }
                case "W": { Gl.glRotated(270.0, 0.0, 1.0, 0.0); break; }
            }            
        }

        #region IAudible Members

        private String soundName;

        public String SoundName
        {
            get { return soundName;  }
            set { soundName = value; }
        }

        public void setSoundPosition()
        {
            if (Assets.Instance.Sounds.ContainsKey(this.SoundName))
            {
                Al.alSource3f(Assets.Instance.Sounds[this.SoundName].SoundID, Al.AL_POSITION, (float)this.Position.Px, (float)this.Position.Py, (float)this.Position.Pz);
                Al.alSourcef(Assets.Instance.Sounds[this.SoundName].SoundID, Al.AL_ROLLOFF_FACTOR, 20.0f);                
            }
        }

        public void setSoundPosition(Vector3D p)
        {
            if (Assets.Instance.Sounds.ContainsKey(this.SoundName))
            {
                Al.alSource3f(Assets.Instance.Sounds[this.SoundName].SoundID, Al.AL_POSITION, (float)p.Px, (float)p.Py, (float)p.Pz);
            }
        }

        public void playSound()
        {
            if (Assets.Instance.Sounds.ContainsKey(this.SoundName))
            {
                Al.alSourcePlay(Assets.Instance.Sounds[this.SoundName].SoundID);
            }
        }

        public void stopSound()
        {
            if (Assets.Instance.Sounds.ContainsKey(this.SoundName))
            {
                Al.alSourceStop(Assets.Instance.Sounds[this.SoundName].SoundID);
            }
        }

        #endregion
    }
}
