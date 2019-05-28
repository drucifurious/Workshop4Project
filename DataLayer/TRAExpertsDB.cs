using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataLayer
{
    public class TRAExpertsDB
    {
        public static SqlConnection GetConnection()
        {
            //LOCAL DB

            //SqlConnection connection = new SqlConnection();
            //string ConnectionString = "Data Source=SoftDev;" + "Initial Catalog=TravelExperts;" + "Integrated Security=true;";
            //connection.ConnectionString = ConnectionString;

            //Remote DB

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "workshop4.database.windows.net";
            builder.UserID = "Ye";
            builder.Password = "Liu123456";
            builder.InitialCatalog = "TravelExperts";
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();
            return connection;

        }

    }
}
