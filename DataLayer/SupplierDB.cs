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
            SqlConnection connection = TRAExpertsDB.GetConnection();
            List<Supplier> results = new List<Supplier>();
            try
            {
                string sql = "SELECT SupplierId, SupName FROM Suppliers";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Supplier s = new Supplier();
                    s.SupplierId = reader["SupplierId"].ToString();
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
        
        public static Supplier GetSupplier(int ID)
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
                    s.SupplierId = reader["SupplierId"].ToString();
                    //results.ADD(s);

                }
            }
            catch { }
            finally
            {
                connection.Close();
            }


            return s;

        }


        public static int AddSupplier(string SupName)
        {
            string sql = "INSERT INTO Suppliers" + " (SupName)" +
                 " VALUES" +
                 " (@SupName)";
            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);

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

        public static int UpdaSupplier(int ID, string SupName)
        {
            //string sql = "UPDATE  Suppliers" + "SET (SupName)=" +

            //  "(@SupName)"+ "where SupplierId ="+ID;

            string sql = "UPDATE  Suppliers  SET SupName=@SupName" + ID;

            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@SupName",SupName);
      

            int qq = command.ExecuteNonQuery();
            return qq;

        }








    }




}
