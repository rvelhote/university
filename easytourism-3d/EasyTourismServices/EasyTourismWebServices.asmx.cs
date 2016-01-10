using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Text;
using System.Web.Security;

namespace EasyTourismServices
{
    /// <summary>
    /// Webservices disponibilizados pelo EasyTourism3D
    /// </summary>
    [WebService(Namespace = "http://dot.dei.isep.ipp.pt/jarasoft/Dir2/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]   
    public class EasyTourismServices : System.Web.Services.WebService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        [WebMethod(Description = "Grava um percurso na Base de Dados [Requer Autenticação]")]
        public bool SaveTour(String username, String password, int tourID, List<ToVisit> list)
        {
            bool saved = false;

            //if (Membership.ValidateUser(username, password))
            //{
            //Guid guid = (Guid)Membership.GetUser(username).ProviderUserKey;
            Guid guid = new Guid("12345678-9012-3456-7890-123456789013");

                Database database = new Database();
                database.connect();
                    saved = database.Query.SaveTour(guid, tourID, list);
                database.disconnect();

                saved = true;
            //}
            
            return saved;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID">A ID da cidade da qual queremos ver o mapa em SVG</param>
        /// <returns>XML em formato SVG</returns>
        [WebMethod(Description="Retorna o Mapa da cidade escolhida em formato SVG")]
        public XmlDocument SVGMap(int cityID)
        {
            Database database = new Database();
            XmlDocument xmldoc = new XmlDocument();

            #region Doctype
            //  TODO: Não está a inserir o doctype correctamente
            XmlDocumentType doctype = xmldoc.CreateDocumentType("svg", "-//W3C//DTD SVG 1.1//EN", "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd", "");
            xmldoc.AppendChild(doctype);
            #endregion

            #region Elemento Raiz
            XmlElement root = xmldoc.CreateElement("svg");
            root.SetAttribute("width", "100%");
            root.SetAttribute("height", "100%");
            root.SetAttribute("version", "1.1");
            root.SetAttribute("xmlns", "http://www.w3.org/2000/svg");
            #endregion
            
            database.connect();
                SVGCartography c = database.Query.SVGMap(cityID);
            database.disconnect();

            #region Criação do Mapa em SVG
            XmlElement g;
            g = xmldoc.CreateElement("g");
            g.SetAttribute("transform", "scale(5) translate(60,38) rotate(-90)");

            XmlElement line;

            foreach (SVGRoadSegment s in c.segments)
            {
                line = xmldoc.CreateElement("line");
                line.SetAttribute("x1", s.begin.x.ToString());
                line.SetAttribute("y1", s.begin.z.ToString());

                line.SetAttribute("x2", s.end.x.ToString());
                line.SetAttribute("y2", s.end.z.ToString());

                line.SetAttribute("style", "stroke:rgb(99,99,99);stroke-width:1");

                g.AppendChild(line);
            }

            XmlElement circle;

            foreach (PointOfInterest p in c.pointsOfInterest)
            {
                circle = xmldoc.CreateElement("circle");

                //  TODO: Aqui também deves fazer o translate
                circle.SetAttribute("cx", p.position.x.ToString());
                circle.SetAttribute("cy", p.position.z.ToString());
                circle.SetAttribute("r", "1");
                circle.SetAttribute("stroke", "black");
                circle.SetAttribute("stroke-width", "0.2");
                circle.SetAttribute("fill", "red");

                g.AppendChild(circle);
            }

            root.AppendChild(g);
            xmldoc.AppendChild(root);
            #endregion

            return xmldoc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID">A ID da cidade da qual queremos ver o mapa em SVG</param>
        /// <returns>XML em formato SVG</returns>
        [WebMethod(Description = "Retorna a cartografia da cidade escolhida em formato CSV")]
        public void CSVMap(int cityID)
        {
            Database database = new Database();
            StringBuilder csv = new StringBuilder();            
                        
            database.connect();
                // TODO: Usar uma classe diferente, pode ser melhor
                SVGCartography c = database.Query.SVGMap(cityID);
                City cityInfo = database.Query.CityInfo(cityID);
            database.disconnect();

            csv.Append("Nome Rua;X Início;Y Início;Z Início;X Fim;Y Fim;Z Fim");

            foreach (SVGRoadSegment r in c.segments)
            {                
                csv.AppendFormat("{0};{1};{2};{3};{4};{5};{6}", r.name, r.begin.x, r.begin.y,r.begin.z, r.end.x, r.end.y,r.end.z);
                csv.AppendLine();
            }

            HttpContext.Current.Response.ContentType = "text/csv";
            HttpContext.Current.Response.AddHeader("Content-disposition", "attachment;filename=" + cityInfo.cityName + ".csv");
            HttpContext.Current.Response.HeaderEncoding = Encoding.UTF8;
            HttpContext.Current.Response.Write(csv.ToString());
            HttpContext.Current.Response.Flush();
        } 
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>        
        public Cartography CityCartography(int cityID, bool minified)
        {
            Database database = new Database();
            Cartography cartography = new Cartography();

            database.connect();
            
                cartography.pointsOfInterest = database.Query.PointsOfInterest(cityID, minified);
                cartography.roadSegments = database.Query.Segments(cityID);
                cartography.intersections = database.Query.Intersections(cityID);

                if (!minified)
                {
                    cartography.genericObjects = database.Query.GenericObjects(cityID);
                }
                else
                {
                    cartography.genericObjects = null;
                }

            database.disconnect();

            return cartography;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        [WebMethod(Description = "Retorna a cartografia mínima da cidade. Inclui: Intersecções, Segmentos de Estrada e Pontos de Interesse")]
        public Cartography CityCartographyMinified(int cityID)
        {
            return this.CityCartography(cityID, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        [WebMethod(Description = "Retorna a cartografia completa da cidade. Para além da informação incluída na cartografia mínima inclui também detalhes sobre cada atracção")]
        public Cartography CityCartographyFull(int cityID)
        {
            Cartography c = this.CityCartography(cityID, false);
            Database database = new Database();

            database.connect();

                foreach (PointOfInterest p in c.pointsOfInterest)
                {
                    p.features = database.Query.PointOfInterestFeatures(p.id);
                }

            database.disconnect();

            return c;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="touristID"></param>
        /// <returns></returns>
        [WebMethod(Description = "Retorna a lista de Percursos que um determinado utilizador criou. [Requer Autenticação]")]
        public TourList TourListForTourist(String username, String password)
        {
            TourList tlist = new TourList();

            //if (Membership.ValidateUser(username, password))
            //{
                //Guid guid = (Guid)Membership.GetUser(username).ProviderUserKey;
            Guid guid = new Guid("12345678-9012-3456-7890-123456789013");
                Database database = new Database();
                database.connect();
                    tlist = database.Query.TourListByTourist(guid);
                database.disconnect();

                tlist.authenticated = true;
            //}

            return tlist;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="touristID"></param>
        /// <param name="tourID"></param>
        /// <returns></returns>
        [WebMethod(Description = "Retorna um percurso escolhido por um utilizador. Inclui dados sobre as Atracções. [Requer Autenticação]")]
        public Tour TourForTourist(String username, String password, int tourID)
        {
            Tour tour = new Tour();            

            //if (Membership.ValidateUser(username, password))
            //{
                //Guid guid = (Guid)Membership.GetUser(username).ProviderUserKey;
            Guid guid = new Guid("12345678-9012-3456-7890-123456789013");
                Database database = new Database();
                database.connect();
                    tour = database.Query.TourByTourist(guid, tourID);
                    tour.toVisit = database.Query.PointsOfInterestToVisit(tourID);
                database.disconnect();

                tour.authenticated = true;
            //}

            return tour;
        }
    }
}
