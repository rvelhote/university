using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace EasyTourismServices
{
    /// <summary>
    /// 
    /// </summary>
    public class Database
    {
        /// <summary>
        /// 
        /// </summary>
        private SqlConnection connection;

        /// <summary>
        /// 
        /// </summary>
        private Query query = new Query();

        /// <summary>
        /// 
        /// </summary>
        public Query Query
        {
            get { return query; }
        }

        /// <summary>
        /// 
        /// </summary>
        private String connectionString = @"Password=------------;Persist Security Info=True;User ID=sa;Initial Catalog=jarasoft;Data Source=WIN-SV5FTEH2P7C;";

        public Database()
        {
            this.connection = new SqlConnection(this.connectionString);
        }

        /// <summary>
        /// 
        /// </summary>
        public void connect()
        {
            if (this.connection.State == ConnectionState.Closed)
            {                
                this.connection.Open();

                this.Query.Connection = this.connection;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void disconnect()
        {
            if (this.connection.State == ConnectionState.Open)
            {
                this.connection.Close();
            }
        }        
    }
}
