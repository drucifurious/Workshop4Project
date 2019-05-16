using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessLayer;
namespace DataLayer
{
    public class Product_SuppliersDB
    {
        public static List<Product_SuppliersDB> GetProduct_SupplierDB()
        {
            SqlConnection connection = DataLayer.Product_SuppliersDB.GetConnection();
            List<Product_SuppliersDB> results = new List<Product_SuppliersDB>();

            try
            {

                string sql = "SELECT ProductId, SupplierId   FROM dbo.Products_Suppliers ";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Product_SuppliersDB s = new Product_SuppliersDB ();
                    s.ProductId = reader["ProductId"].ToString();
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

        public static DataLayer GetProducts_Suppliers(int ProductId, int SuppliersId)
        {
            SqlConnection connection = DataLayer.Product_suppliersId.GetConnection();
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
