using System;
using System.Collections.Generic;
using EasyTourism3D.WebService;
using EasyTourism3D.Properties;

namespace EasyTourism3D
{
    class WebServiceData : EasyTourismServices
    {
        private EasyTourismServices ws = new EasyTourismServices();

        private EasyTourismServices Ws
        {
            get { return ws; }            
        }

        public bool loadTour(ref Tour tour)
        {
            bool loaded = false;
            WebService.Tour wsTour = this.Ws.TourForTourist(AppState.Instance.Username, AppState.Instance.Password, AppState.Instance.TourID);

            if (wsTour.authenticated)
            {
                loaded = true;

                tour.cityID = wsTour.cityID;
                tour.begin = wsTour.begin;

                foreach (WebService.ToVisit t in wsTour.toVisit)
                {
                    tour.toVisit.Add(new ToVisit(t.id, t.visited, t.ordering, t.beginVisit, t.endVisit));
                }
            }
            else
            {
                throw new Exception(AppState.Instance.ResourceManager.GetString("AuthenticationFailedException"));
            }

            return loaded;
        }

        public void loadCartography(ref Cartography cartography, int cityID)
        {

            WebService.Cartography c = this.Ws.CityCartographyFull(cityID);

            Intersection itr;
            foreach (WebService.Intersection i in c.intersections)
            {
                itr = new Intersection(i.id);
                itr.Position.set(i.position.x, i.position.y, i.position.z);
                cartography.intersections.Add(itr);
            }

            RoadSegment rs;
            foreach (WebService.RoadSegment r in c.roadSegments)
            {
                rs = new RoadSegment(cartography.getIntersectionWithID(r.idIntersectionBegin), cartography.getIntersectionWithID(r.idIntersectionEnd));
                rs.SegmentName = r.name;
                cartography.segments.Add(rs);
            }

            PointOfInterest poi;
            foreach (WebService.PointOfInterest p in c.pointsOfInterest)
            {
                poi = new PointOfInterest(new Vector3D(p.position.x, p.position.y, p.position.z));
                poi.ID = p.id;
                poi.ModelName = p.model;

                /// TODO: Alterar para "Nome"
                poi.Nome = p.description;
                poi.Description = p.description;

                poi.Facing = p.facing;

                for (int i = 0; i < p.features.Length; i++)
                {
                    poi.Features.Add(p.features[i]);
                }

                //adjustment = new String[0];
                //dimensions = new String[0];


                //NameValueConfigurationCollection nvc = ModelSettings.Default.Properties;
                //Console.WriteLine(ConfigurationSettings.AppSettings.AllKeys.);

                //if (poi.ModelName == "Castelo")
                //{

                //    //if (ModelSettings.Default.PropertyValues..Contains(poi.ModelName + "Adjustment"))
                //    //{
                //    adjustment = ModelSettings.Default[poi.ModelName + "Adjustment"].ToString().Split('|');
                //    //}

                //    //if (ModelSettings.Default.SettingsKey.Contains(poi.ModelName + "Dimensions"))
                //    //{
                //    dimensions = ModelSettings.Default[poi.ModelName + "Dimensions"].ToString().Split('|');
                //    //}

                //    //if (ModelSettings.Default.SettingsKey.Contains(poi.ModelName + "SoundName"))
                //    //{
                //    poi.SoundName = ModelSettings.Default[poi.ModelName + "SoundName"].ToString();
                //    //}

                //    if (adjustment.Length > 0)
                //    {
                //        poi.ColisionArea.Adjustment.set(Double.Parse(adjustment[0]), Double.Parse(adjustment[1]), Double.Parse(adjustment[2]));
                //    }

                //    if (dimensions.Length > 0)
                //    {
                //        poi.ColisionArea.Dimensions.set(Double.Parse(dimensions[0]), Double.Parse(dimensions[1]), Double.Parse(dimensions[2]));
                //    }

                //    poi.ColisionArea.Visible = true;
                //}

                poi.ColisionArea.Visible = true;

                poi.ColisionArea.Adjustment.set(0, 0, -1.5);
                poi.ColisionArea.Dimensions.set(3, 1, 2);

                cartography.pointsOfInterest.Add(poi);
            }

            GenericObject go;
            foreach (WebService.GenericObject g in c.genericObjects)
            {
                go = GenericObjectFactory.getGenericObject(g.type);
                go.Position.set(g.position.x, g.position.y, g.position.z);
                cartography.genericObjects.Add(go);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tour"></param>
        /// <param name="cartography"></param>
        public void save(ref Tour tour, ref Cartography cartography)
        {
            if (tour.toVisit.Count > 0)
            {
                bool saved = false;

                PointOfInterest poi;
                EasyTourismServices webService = new EasyTourismServices();

                List<WebService.ToVisit> tv = new List<WebService.ToVisit>();
                WebService.ToVisit[] tvArray;

                WebService.ToVisit t;
                
                /// TODO: Chuta logo para o Array[]!
                foreach (ToVisit toVisit in tour.toVisit)
                {
                    poi = cartography.getPointOfInterestWithID(toVisit.attractionID);
                    
                    if (poi.ToVisit && poi.Visited)
                    {
                        t = new WebService.ToVisit();

                        t.id = poi.ID;
                        t.visited = poi.Visited;

                        tv.Add(t);
                    }
                }

                tvArray = new WebService.ToVisit[tv.Count];
                tv.CopyTo(tvArray);

                saved = webService.SaveTour(AppState.Instance.Username, AppState.Instance.Password, AppState.Instance.TourID, tvArray);

                if (!saved)
                {
                    throw new Exception(AppState.Instance.ResourceManager.GetString("TourNotSavedException"));
                }
            }
        }
    }
}
