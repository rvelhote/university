using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace EasyTourismServices
{
    /// <summary>
    /// 
    /// </summary>
    public class Query
    {
        /// <summary>
        /// 
        /// </summary>
        private SqlConnection connection;

        /// <summary>
        /// 
        /// </summary>
        public SqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private SqlDataReader reader;

        /// <summary>
        /// 
        /// </summary>
        public SqlDataReader Reader
        {
            get { return reader; }
            set { reader = value; }
        }

        public bool SaveTour(Guid touristID, int tourID, List<ToVisit> list)
        {
            bool saved = true;

            StringBuilder sb = new StringBuilder();
            SqlCommand command;
            SqlParameter param;

            command = new SqlCommand("GravarPercurso", this.connection);
            command.CommandType = CommandType.StoredProcedure;

            //param = new SqlParameter("@IDUtilizador", SqlDbType.UniqueIdentifier);
            //param.Value = touristID;
            //command.Parameters.Add(param);

            param = new SqlParameter("@IDPercurso", SqlDbType.Int);
            param.Value = tourID;
            command.Parameters.Add(param);

            //  TODO: Tenta fazer só uma query com ORs em vez de uma para cada atracção
            foreach (ToVisit t in list)
            {
                param = new SqlParameter("@IDAtracao", SqlDbType.Int);
                param.Value = t.id;

                command.Parameters.Add(param);
                command.ExecuteNonQuery();
                command.Parameters.Remove(param);
            }

            return saved;
        }

        public City CityInfo(int cityID)
        {
            SqlCommand command;
            SqlParameter p1 = new SqlParameter("@IDCidade", SqlDbType.Int);
            City c;

            p1.Value = cityID;

            command = new SqlCommand("DadosCidade", this.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(p1);

            this.reader = command.ExecuteReader();

            if (this.reader.HasRows)
            {
                this.reader.Read();

                c = new City();

                c.cityID = Int32.Parse(reader["ID"].ToString());
                c.cityName = reader["NOME"].ToString();
                c.country = reader["PAIS"].ToString();                
            }
            else
            {
                throw new Exception("Cidade não existe");
            }

            this.reader.Close();

            return c;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public SVGCartography SVGMap(int cityID)
        {
            SqlCommand command;

            SVGCartography cartography = new SVGCartography();

            List<SVGRoadSegment> l = new List<SVGRoadSegment>();
            SVGRoadSegment s;

            SqlParameter p1 = new SqlParameter("@IDCidade", SqlDbType.Int);
            p1.Value = cityID;

            command = new SqlCommand("SegmentosComInterseccoes", this.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(p1);

            this.reader = command.ExecuteReader();

            while (this.reader.Read())
            {
                s = new SVGRoadSegment();

                s.id = Int32.Parse(reader["ID"].ToString());
                s.name = reader["NOME"].ToString();

                //  TODO: Faz um translate no XML em vez de adicionar 50.0 para retirar as posições negativas
                s.begin = new Vector3D(Double.Parse(reader["XInicio"].ToString()), Double.Parse(reader["YInicio"].ToString()), Double.Parse(reader["ZInicio"].ToString()));
                s.end = new Vector3D(Double.Parse(reader["XFim"].ToString()), Double.Parse(reader["YFim"].ToString()), Double.Parse(reader["ZFim"].ToString()));

                l.Add(s);
            }

            this.reader.Close();

            List<PointOfInterest> p = new List<PointOfInterest>();
            p = this.PointsOfInterest(cityID, true);

            cartography.segments = l;
            cartography.pointsOfInterest = p;
            cartography.cityName = "Nao Implementado";

            return cartography;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public List<Intersection> Intersections(int cityID)
        {
            SqlCommand command;

            List<Intersection> l = new List<Intersection>();
            Intersection i;

            SqlParameter p1 = new SqlParameter("@IDCidade", SqlDbType.Int);
            p1.Value = cityID;

            command = new SqlCommand("InterseccoesCidade", this.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(p1);

            this.reader = command.ExecuteReader();

            while (this.reader.Read())
            {
                i = new Intersection();
                i.id = Int32.Parse(reader["ID_INTERSECCAO"].ToString());
                i.position = new Vector3D(Double.Parse(reader["X"].ToString()), Double.Parse(reader["Y"].ToString()), Double.Parse(reader["Z"].ToString()));
                l.Add(i);
            }

            this.reader.Close();

            return l;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public List<RoadSegment> Segments(int cityID)
        {
            SqlCommand command;

            List<RoadSegment> l = new List<RoadSegment>();
            RoadSegment r;

            SqlParameter p1 = new SqlParameter("@IDCidade", SqlDbType.Int);
            p1.Value = cityID;

            command = new SqlCommand("SegmentosCidade", this.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(p1);

            this.reader = command.ExecuteReader();

            while (this.reader.Read())
            {
                r = new RoadSegment();
                r.id = Int32.Parse(reader["ID"].ToString());
                r.idIntersectionBegin = Int32.Parse(reader["INTERSECCAO_INICIO"].ToString());
                r.idIntersectionEnd = Int32.Parse(reader["INTERSECCAO_FIM"].ToString());
                r.name = reader["NOME"].ToString();

                l.Add(r);
            }

            this.reader.Close();

            return l;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public List<PointOfInterest> PointsOfInterest(int cityID, bool minified)
        {
            SqlCommand command;
            SqlParameter paramCityID = new SqlParameter("@IDCidade", SqlDbType.Int);

            List<PointOfInterest> l = new List<PointOfInterest>();
            PointOfInterest p;

            //  
            command = new SqlCommand("AtraccoesCidade", this.connection);
            command.CommandType = CommandType.StoredProcedure;

            paramCityID.Value = cityID;
            command.Parameters.Add(paramCityID);
                       
            this.reader = command.ExecuteReader();

            while (this.reader.Read())
            {
                p = new PointOfInterest();

                //  Informação Base do Ponto de Interesse
                p.id = Int32.Parse(reader["ID"].ToString());
                p.segmentID = Int32.Parse(reader["ID_TROCO"].ToString());
                p.position = new Vector3D(Double.Parse(reader["X"].ToString()), Double.Parse(reader["Y"].ToString()), Double.Parse(reader["Z"].ToString()));
                p.facing = reader["DIRECCAO"].ToString();

                if (!minified)
                {
                    p.description = reader["NOME"].ToString();
                    p.model = reader["MODELO"].ToString();
                    p.type = reader["Tipo"].ToString();
                    p.classification = reader["Class"].ToString();
                }

                l.Add(p);
            }
            
            this.reader.Close();

            return l;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poiID"></param>
        /// <returns></returns>
        public List<String> PointOfInterestFeatures(int poiID)
        {
            List<String> features = new List<String>();
            SqlCommand command;
            SqlParameter paramPoiID = new SqlParameter("@IDAtraccao", SqlDbType.Int);

            command = new SqlCommand("CaracteristicasAtraccao", this.connection);
            command.CommandType = CommandType.StoredProcedure;

            paramPoiID.Value = poiID;
            command.Parameters.Add(paramPoiID);

            this.reader = command.ExecuteReader();

            while (this.reader.Read())
            {
                features.Add(this.reader["CARACTERISTICA"].ToString());
            }

            this.reader.Close();

            return features;
        }

        public List<GenericObject> GenericObjects(int cityID)
        {
            SqlCommand command;

            List<GenericObject> l = new List<GenericObject>();
            GenericObject i;

            SqlParameter p1 = new SqlParameter("@IDCidade", SqlDbType.Int);
            p1.Value = cityID;

            command = new SqlCommand("ObjectosCidade", this.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(p1);

            this.reader = command.ExecuteReader();

            while (this.reader.Read())
            {
                i = new GenericObject();

                i.id = Int32.Parse(reader["IDObjecto"].ToString());
                i.position = new Vector3D(Double.Parse(reader["X"].ToString()), Double.Parse(reader["Y"].ToString()), Double.Parse(reader["Z"].ToString()));
                i.type = reader["ShortCode"].ToString();

                l.Add(i);
            }

            this.reader.Close();

            return l;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="touristID"></param>
        /// <returns></returns>
        public TourList TourListByTourist(Guid touristID)
        {
            TourList tlist = new TourList();
            Tour t;

            SqlCommand command;
            SqlParameter paramTouristID = new SqlParameter("@IDUtilizador", SqlDbType.UniqueIdentifier);

            command = new SqlCommand("PercursosUtilizador", this.connection);
            command.CommandType = CommandType.StoredProcedure;

            paramTouristID.Value = touristID;
            command.Parameters.Add(paramTouristID);

            this.reader = command.ExecuteReader();

            while (this.reader.Read())
            {                
                t = new Tour();

                t.tourID = Int32.Parse(reader["ID"].ToString());
                t.cityID = Int32.Parse(reader["IDCidade"].ToString());
                t.cityName = reader["NOME"].ToString();
                t.begin = DateTime.Parse(reader["DATA_HORA_INICIO"].ToString());                

                tlist.tours.Add(t);
            }

            this.reader.Close();

            return tlist;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ///
        /// TODO: Practicamente igual à TourListByTourist.
        public Tour TourByTourist(Guid touristID, int tourID)
        {
            Tour t = new Tour();

            SqlCommand command;
            SqlParameter paramTouristID = new SqlParameter("@IDUtilizador", SqlDbType.UniqueIdentifier);
            SqlParameter paramTourID = new SqlParameter("@IDPercurso", SqlDbType.Int);

            command = new SqlCommand("InfoPercurso", this.connection);
            command.CommandType = CommandType.StoredProcedure;

            paramTourID.Value = tourID;
            paramTouristID.Value = touristID;

            command.Parameters.Add(paramTouristID);
            command.Parameters.Add(paramTourID);
            
            this.reader = command.ExecuteReader();

            while (this.reader.Read())
            {
                t.tourID = Int32.Parse(reader["ID"].ToString());
                t.cityID = Int32.Parse(reader["IDCidade"].ToString());
                t.cityName = reader["NOME"].ToString();
                t.begin = DateTime.Parse(reader["DATA_HORA_INICIO"].ToString());                
            }

            this.reader.Close();

            return t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tourID"></param>
        /// <returns></returns>
        public List<ToVisit> PointsOfInterestToVisit(int tourID)
        {
            List<ToVisit> pois = new List<ToVisit>();
            ToVisit t;

            SqlCommand command;
            SqlParameter paramTourID = new SqlParameter("@IDPercurso", SqlDbType.Int);

            command = new SqlCommand("AtraccoesPercurso", this.connection);
            command.CommandType = CommandType.StoredProcedure;

            paramTourID.Value = tourID;
            command.Parameters.Add(paramTourID);

            this.reader = command.ExecuteReader();

            while (this.reader.Read())
            {
                t = new ToVisit();

                t.id = Int32.Parse(reader["ID_ATRACAO"].ToString());
                t.visited = Boolean.Parse(reader["VISITADO"].ToString());
                t.ordering = Int32.Parse(reader["ORDEM"].ToString());
                t.beginVisit = DateTime.Parse(reader["DATA_HORA_I"].ToString());
                t.endVisit = DateTime.Parse(reader["DATA_HORA_F"].ToString());

                pois.Add(t);
            }

            this.reader.Close();

            return pois;
        }
    }
}
