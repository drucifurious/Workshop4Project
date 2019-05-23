using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessLayer;

namespace DataLayer
{
 
    public static class SupplierDB
    {

        public static List<Supplier> GetSuppliers()
        {
            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            List<Supplier> results = new List<Supplier>();

            try
            {

                string sql = "SELECT SupplierId, SupName   FROM Suppliers ";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Supplier s = new Supplier();
                    s.SupName = reader["SupName"].ToString();
                    s.SupplierId = Convert.ToInt32(reader["SupplierId"].ToString());
                    results.Add(s);

                }
            }
            catch { }
            finally
            {
                connection.Close();
            }

            return results;

        }



        public static Supplier GetSuppliers(int ID)
        {
            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            Supplier s = new Supplier();
            try
            {
                string sql = "SELECT SupplierId, SupName " + 
                    " FROM Suppliers " +" WHERE SupplierId =" + ID;
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    s.SupName = reader["SupName"].ToString();
                    s.SupplierId = Convert.ToInt32(reader["SupplierId"].ToString());
                    //results.ADD(s);
                    //test
                }
            }
            catch { }
            finally
            {
                connection.Close();
            }


            return s;

        }


        public static int AddSupplier(int SupplierID, string SupName)
        {
            string sql = "INSERT INTO Suppliers" + " (SupplierID,SupName)" +
                 " VALUES" +
                 " (@SupplierID,@SupName)";
            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SupplierID", SupplierID);
            command.Parameters.AddWithValue("@SupName", SupName);
       


            int qq = command.ExecuteNonQuery();
        
            return qq;

        }
        public static int DeleSupplier(int SupId)
        {
            string sql = "Delete Suppliers where SupplierId=" + SupId;

            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);
            int qq = command.ExecuteNonQuery();
       
            return qq;

        }

        public static int UpdaSupplier(int SupId, string SupName)
        {

            string sql = "UPDATE  Suppliers  SET SupName=@SupName WHERE SupplierId=" + SupId;
            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SupName",SupName);
      

            int qq = command.ExecuteNonQuery();
            return qq;

        }

        public static List<Supplier> orderby(string coluName)
        {
            SqlConnection connection = TRAExpertsDB.GetConnection();
            List<Supplier> results = new List<Supplier>();
            try
            {
                string sql = "SELECT * FROM suppliers order by" + "'" + coluName + "'";
               // string sql = "SELECT * FROM suppliers order by  SupplierId";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Supplier s = new Supplier();
                    s.SupplierId = Convert.ToInt32(reader["SupplierId"].ToString());
                    s.SupName = reader["SupName"].ToString();
                    results.Add(s);
                }
            }
            catch { }

            finally
            {
                connection.Close();
            }
            return results;

        }






    }




}
