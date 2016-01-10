using System;
using Tao.OpenGl;

namespace EasyTourism3D
{
    /// <summary>
    /// 
    /// </summary>
    class Skybox : ThreeDObject
    {
        /// <summary>
        /// 
        /// </summary>
        private int displayListIDNight;

        /// <summary>
        /// 
        /// </summary>
        private int displayListIDDay;

        /// <summary>
        /// A posição a partir do qual será desenhado o objecto (0.0, 0.0, 0.0 por exemplo)
        /// </summary>
        /// <remarks>Não funciona exactamento como anunciado :P</remarks>
        private Vector3D centerAt = new Vector3D(-150.0, 0.0, -150.0);

        /// <summary>
        /// As dimensões da Skybox
        /// </summary>
        private Vector3D dimensions = new Vector3D(300.0, 200.0, 300.0);

        /// <summary>
        /// Retorna e define um Vector3D que indica qual a dimensão da skybox
        /// </summary>
        protected Vector3D Dimensions
        {
            get { return dimensions; }
            set { dimensions = value; }
        }

        /// <summary>
        /// Retorna e define o local a partir do qual será desenhada a Skybox
        /// </summary>
        protected Vector3D CenterAt
        {
            get { return centerAt; }
            set { centerAt = value; }
        }

        /// <summary>
        /// Override da classe Objecto3D que desenha a Skybox
        /// Se existir uma DisplayList definida utilizá-la senão desenhar a Skybox como o normal.
        /// </summary>
        public override void draw()
        {
            if ((AppState.Instance.CurrentDate.Hour >= 18 || AppState.Instance.CurrentDate.Hour <= 5) && this.displayListIDNight > 0)
            {
                Gl.glCallList(this.displayListIDNight);
            }
            else if (this.displayListIDDay > 0)
            {
                Gl.glCallList(this.displayListIDDay);
            }
            else
            {
                //  TODO: Não instancies directamente com o New
                this.drawDisplayList("Day", new double[] { 0.0, 1.0, 0.0 });
            }
        }

        /// <summary>
        /// Desenha a Skybox tendo em conta a altura do dia (dia/noite)
        /// </summary>
        /// <param name="type">Uma string que indica apenas Day/Night</param>
        /// <param name="normals">Um array de normais para iluminação</param>
        public void drawDisplayList(String type, double[] normals)
        {
            Gl.glPushMatrix();
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                Gl.glTranslated(0.0, -85.0, 0.0);

                Gl.glColor3d(1.0, 1.0, 1.0);                

                #region Norte

                if (Assets.Instance.Textures.ContainsKey("SkyboxNorte" + type))
                {
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, Assets.Instance.Textures["SkyboxNorte" + type]);
                }

                Gl.glBegin(Gl.GL_QUADS);

                    Gl.glNormal3dv(normals);

                    Gl.glTexCoord2d(1.0f, 0.0f);
                    Gl.glVertex3d(this.CenterAt.Px + this.Dimensions.Px, this.CenterAt.Py, this.CenterAt.Pz);

                    Gl.glTexCoord2d(1.0f, 1.0f);
                    Gl.glVertex3d(this.CenterAt.Px + this.Dimensions.Px, this.CenterAt.Py + this.Dimensions.Py, this.CenterAt.Pz);

                    Gl.glTexCoord2d(0.0f, 1.0f);
                    Gl.glVertex3d(this.CenterAt.Px, this.CenterAt.Py + this.Dimensions.Py, this.CenterAt.Pz);

                    Gl.glTexCoord2d(0.0f, 0.0f);
                    Gl.glVertex3d(this.CenterAt.Px, this.CenterAt.Py, this.CenterAt.Pz);
                Gl.glEnd();

                #endregion
                #region Sul
                if (Assets.Instance.Textures.ContainsKey("SkyboxSul" + type))
                {
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, Assets.Instance.Textures["SkyboxSul" + type]);
                }

                Gl.glBegin(Gl.GL_QUADS);

                    Gl.glNormal3dv(normals);

                    Gl.glTexCoord2d(1.0, 0.0);
                    Gl.glVertex3d(this.CenterAt.Px, this.CenterAt.Py, this.CenterAt.Pz + this.Dimensions.Pz);

                    Gl.glTexCoord2d(1.0, 1.0);
                    Gl.glVertex3d(this.CenterAt.Px, this.CenterAt.Py + this.Dimensions.Py, this.CenterAt.Pz + this.Dimensions.Pz);

                    Gl.glTexCoord2d(0.0, 1.0);
                    Gl.glVertex3d(this.CenterAt.Px + this.Dimensions.Px, this.CenterAt.Py + this.Dimensions.Py, this.CenterAt.Pz + this.Dimensions.Pz);

                    Gl.glTexCoord2d(0.0, 0.0);
                    Gl.glVertex3d(this.CenterAt.Px + this.Dimensions.Px, this.CenterAt.Py, this.CenterAt.Pz + this.Dimensions.Pz);
                Gl.glEnd();
                #endregion                
                #region Oeste

                if (Assets.Instance.Textures.ContainsKey("SkyboxOeste" + type))
                {
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, Assets.Instance.Textures["SkyboxOeste" + type]);
                }

                Gl.glBegin(Gl.GL_QUADS);

                    Gl.glNormal3dv(normals);

                    Gl.glTexCoord2d(1.0f, 1.0f);
                    Gl.glVertex3d(this.CenterAt.Px, this.CenterAt.Py + this.Dimensions.Py, this.CenterAt.Pz);

                    Gl.glTexCoord2d(0.0f, 1.0f);
                    Gl.glVertex3d(this.CenterAt.Px, this.CenterAt.Py + this.Dimensions.Py, this.CenterAt.Pz + this.Dimensions.Pz);

                    Gl.glTexCoord2d(0.0f, 0.0f);
                    Gl.glVertex3d(this.CenterAt.Px, this.CenterAt.Py, this.CenterAt.Pz + this.Dimensions.Pz);

                    Gl.glTexCoord2d(1.0f, 0.0f);
                    Gl.glVertex3d(this.CenterAt.Px, this.CenterAt.Py, this.CenterAt.Pz);
                Gl.glEnd();

                #endregion
                #region Este

                if (Assets.Instance.Textures.ContainsKey("SkyboxEste" + type))
                {
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, Assets.Instance.Textures["SkyboxEste" + type]);
                }

                Gl.glBegin(Gl.GL_QUADS);

                    Gl.glNormal3dv(normals);

                    Gl.glTexCoord2d(0.0f, 0.0f);
                    Gl.glVertex3d(this.CenterAt.Px + this.Dimensions.Px, this.CenterAt.Py, this.CenterAt.Pz);

                    Gl.glTexCoord2d(1.0f, 0.0f);
                    Gl.glVertex3d(this.CenterAt.Px + this.Dimensions.Px, this.CenterAt.Py, this.CenterAt.Pz + this.Dimensions.Pz);

                    Gl.glTexCoord2d(1.0f, 1.0f);
                    Gl.glVertex3d(this.CenterAt.Px + this.Dimensions.Px, this.CenterAt.Py + this.Dimensions.Py, this.CenterAt.Pz + this.Dimensions.Pz);

                    Gl.glTexCoord2d(0.0f, 1.0f);
                    Gl.glVertex3d(this.CenterAt.Px + this.Dimensions.Px, this.CenterAt.Py + this.Dimensions.Py, this.CenterAt.Pz);

                Gl.glEnd();

                #endregion
                #region Céu

                if (Assets.Instance.Textures.ContainsKey("SkyboxCeu" + type))
                {
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, Assets.Instance.Textures["SkyboxCeu" + type]);
                }

                Gl.glBegin(Gl.GL_QUADS);

                    Gl.glNormal3dv(normals);

                    Gl.glTexCoord2d(0.0f, 0.0f);
                    Gl.glVertex3d(this.CenterAt.Px + this.Dimensions.Px, this.CenterAt.Py + this.Dimensions.Py, this.CenterAt.Pz);

                    Gl.glTexCoord2d(1.0f, 0.0f);
                    Gl.glVertex3d(this.CenterAt.Px + this.Dimensions.Px, this.CenterAt.Py + this.Dimensions.Py, this.CenterAt.Pz + this.Dimensions.Pz);

                    Gl.glTexCoord2d(1.0f, 1.0f);
                    Gl.glVertex3d(this.CenterAt.Px, this.CenterAt.Py + this.Dimensions.Py, this.CenterAt.Pz + this.Dimensions.Pz);

                    Gl.glTexCoord2d(0.0f, 1.0f);
                    Gl.glVertex3d(this.CenterAt.Px, this.CenterAt.Py + this.Dimensions.Py, this.CenterAt.Pz);
                Gl.glEnd();

                #endregion
                #region Chão
                if (Assets.Instance.Textures.ContainsKey("SkyboxChao" + type))
                {
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, Assets.Instance.Textures["SkyboxChao" + type]);
                }

                Gl.glBegin(Gl.GL_QUADS);

                    Gl.glNormal3dv(normals);
      
                    Gl.glTexCoord2d(0.0f, 0.0f);
                    Gl.glVertex3d(this.CenterAt.Px, this.CenterAt.Py, this.CenterAt.Pz);

                    Gl.glTexCoord2d(1.0f, 0.0f);
                    Gl.glVertex3d(this.CenterAt.Px, this.CenterAt.Py, this.CenterAt.Pz + this.Dimensions.Pz);

                    Gl.glTexCoord2d(1.0f, 1.0f);
                    Gl.glVertex3d(this.CenterAt.Px + this.Dimensions.Px, this.CenterAt.Py, this.CenterAt.Pz + this.Dimensions.Pz);

                    Gl.glTexCoord2d(0.0f, 1.0f);
                    Gl.glVertex3d(this.CenterAt.Px + this.Dimensions.Px, this.CenterAt.Py, this.CenterAt.Pz);
                Gl.glEnd();
                #endregion

                Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glPopMatrix();
        }
        
        /// <summary>
        /// Cria as Display Lists para as Skyboxes de dia e de noite
        /// </summary>
        public void createDisplayList()
        {
            //  TODO: Não instancies directamente com o New
            this.displayListIDDay = Gl.glGenLists(1);
            Gl.glNewList(this.displayListIDDay, Gl.GL_COMPILE);
                this.drawDisplayList("Day", new double[] {0.0, 1.0, 0.0});
            Gl.glEndList();

            //  TODO: Não instancies directamente com o New
            this.displayListIDNight = Gl.glGenLists(1);
            Gl.glNewList(this.displayListIDNight, Gl.GL_COMPILE);                
                this.drawDisplayList("Night", new double[] { 0.0, 0.0, 0.0 });
            Gl.glEndList();
        }
    }
}