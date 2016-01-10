using System;
using System.Collections.Generic;

namespace EasyTourism3D
{
    /// <summary>
    /// 
    /// </summary>
    abstract class ThreeDObject : IReal
    {
        /// <summary>
        /// 
        /// </summary>
        private List<String> textureList = new List<string>(1);

        /// <summary>
        /// 
        /// </summary>
        public List<String> TextureList
        {
            get { return textureList; }
            set { textureList = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public String SingleTexture
        {
            get
            {
                String texture = "";

                if (this.TextureList.Count > 0)
                {
                    texture = this.TextureList[0];
                }

                return texture;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string defaultTexture = "";

        /// <summary>
        /// 
        /// </summary>
        public string DefaultTexture
        {
            get { return defaultTexture; }
            set { defaultTexture = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        private double angle = 0.0;

        /// <summary>
        /// 
        /// </summary>
        private String modelName = "";
        
        /// <summary>
        /// 
        /// </summary>
        private bool visible = true;

        /// <summary>
        /// 
        /// </summary>
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
    
        /// <summary>
        /// 
        /// </summary>
        public String ModelName
        {
            get { return modelName; }
            set { modelName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Angle
        {
            get { return this.angle; }
            set { this.angle = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoX"></param>
        /// <param name="novoY"></param>
        /// <param name="novoZ"></param>
        public void setPosicao(double novoX, double novoY, double novoZ)
        {
            this.Position.Px = novoX;
            this.Position.Py = novoY;
            this.Position.Pz = novoZ;            
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract void draw();
        
        #region IReal Members

            /// <summary>
            /// 
            /// </summary>
            private Vector3D position = new Vector3D();

            /// <summary>
            /// 
            /// </summary>
            public Vector3D Position
            {
                get { return position; }
            }

            /// <summary>
            /// 
            /// </summary>
            private CollisionBox collisionArea = new CollisionBox();

            /// <summary>
            /// 
            /// </summary>
            public CollisionBox ColisionArea
            {
                get { return collisionArea; }
            }

        #endregion
    }
}
