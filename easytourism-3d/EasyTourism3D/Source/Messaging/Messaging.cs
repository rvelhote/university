using System;
using System.Collections;
using System.Collections.Generic;

namespace EasyTourism3D
{
    /// <summary>
    /// 
    /// </summary>
    class Messaging
    {
        #region Singleton
        /// <summary>
        /// 
        /// </summary>
        private static readonly Messaging instance = new Messaging();

        /// <summary>
        /// 
        /// </summary>
        private Messaging() { }

        /// <summary>
        /// 
        /// </summary>
        public static Messaging Instance
        {
            get { return instance; }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        private Queue information = new Queue();

        /// <summary>
        /// 
        /// </summary>
        public Queue Information
        {
            get { return information; }
            set { information = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private List<String> permanent = new List<String>();

        /// <summary>
        /// 
        /// </summary>
        public List<String> Permanent
        {
            get { return permanent; }
            set { permanent = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private List<String> poiInfo = new List<string>(1);

        /// <summary>
        /// 
        /// </summary>
        public List<String> PoiInfo
        {
            get { return poiInfo; }
            set { poiInfo = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int elapsed = 0;

        /// <summary>
        /// 
        /// </summary>
        public int Elapsed
        {
            get { return elapsed; }
            set { elapsed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private int timeout = 2000;

        /// <summary>
        /// 
        /// </summary>
        public int Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void stateCheck()
        {
            if (this.information.Count > 0)
            {
                this.elapsed += 50;

                if (this.elapsed % this.timeout == 0)
                {
                    this.information.Dequeue();
                    this.elapsed = 0;
                }

                if (this.information.Count > 5)
                {
                    for (int i = 0; i < this.information.Count - 5; i++)
                    {
                        this.Information.Dequeue();
                        this.Information.TrimToSize();
                    }
                }
            }
            else
            {
                this.elapsed = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public void addCharacteristics(PointOfInterest p)
        {
            Messaging.Instance.PoiInfo.Add(AppState.Instance.ResourceManager.GetString("AttractionFeatures") + ":");

            foreach (String c in p.Features)
            {
                Messaging.Instance.PoiInfo.Add(c);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void removeCharacteristics()
        {
            this.PoiInfo.Clear();
        }
    }
}
