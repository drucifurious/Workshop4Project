using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessLayer;

namespace DataLayer
{

    public static class ProductDB
    {

        public static List<Products> GetProduct()
        {
            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            List<Products> results = new List<Products>();

            try
            {
               
                string sql = "SELECT * ProductId, ProdName   FROM Products ";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Products s= new Products();
                    s.ProdName = reader["ProdName"].ToString();
                    s.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
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

        public static Products GetProducts(int ProdId)
        {
            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            Products s = new Products();

            try
            {
                string sql = "SELECT ProductId, ProdName " +
                    " FROM Products " +
                    " WHERE ProductID =" + ProdId;
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    s.ProdName = reader["ProdName"].ToString();
                    s.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
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

        public static int AddProduct(string ProdName)
        {
            string sql = "INSERT INTO Products  (ProdName)   VALUES (@ProdName)";
            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@ProdName", ProdName);



            int qq = command.ExecuteNonQuery();

            return qq;

        }
        public static int DeleProduct(int ProdId)
        {
            string sql = "Delete Products where ProductID=" + ProdId;

            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);
            int qq = command.ExecuteNonQuery();

            return qq;

        }

        public static int UpdaProduct(int ProdId, string ProdName)
        {
            //string sql = "UPDATE  Products" + "SET (ProdName)=" +

            //  "(@ProdName)"+ "where ProductID ="+ID;

            string sql = "UPDATE  Products  SET ProdName=@ProdName" + ProdId;

            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@ProdName", ProdName);


            int qq = command.ExecuteNonQuery();
            return qq;

        }








    }




}

