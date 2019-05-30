using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
        public static class Packages_products_suppliersDB
    {

            public static List<Packages_products_suppliers> GetPackages_products_suppliers()
            {
                SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
                List<Packages_products_suppliers> results = new List<Packages_products_suppliers>();

                try
                {

                    string sql = "SELECT * FROM [dbo].[Packages_Products_Suppliers] ";
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Packages_Products_Suppliers s = new Packages_Products_Suppliers();
                        s.ProductSupplierId = Convert.ToInt32(reader["ProductSupplierId"].ToString());
                        s.PackageId = Convert.ToInt32(reader["PackageId"].ToString());
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



            public static Packages_Products_Suppliers GetPackages_Products_Suppliers(int ID)
            {
                SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
                Packages_Products_Suppliers s = new Packages_Products_Suppliers();
                try
                {
                    string sql = "SELECT * FROM [dbo].[Packages_Products_Suppliers] ";
                    SqlCommand command = new SqlCommand(sql, connection);

                    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {

                        s.ProductSupplierId = Convert.ToInt32(reader["ProductSupplierId"].ToString());
                        s.PackageId = Convert.ToInt32(reader["PackageId"].ToString());
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





            //public static List<Product_Suppliers> orderby(string coluName)
            //{
            //    SqlConnection connection = TRAExpertsDB.GetConnection();
            //    List<Product_Suppliers> results = new List<Product_Suppliers>();
            //    try
            //    {
            //        string sql = "SELECT * FROM [dbo].[Products_Suppliers] order by" + "'" + coluName + "'";

            //        SqlCommand command = new SqlCommand(sql, connection);
            //        SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            //        while (reader.Read())
            //        {
            //            Product_Suppliers s = new Product_Suppliers();
            //            s.ProductSupplierId = Convert.ToInt32(reader["ProductSupplierId"].ToString());
            //            s.ProductId = Convert.ToInt32(reader["ProductId"].ToString());
            //            s.SupplierId = Convert.ToInt32(reader["SupplierId"].ToString());
            //            results.Add(s);
            //        }
            //    }
            //    catch { }

            //    finally
            //    {
            //        connection.Close();
            //    }
            //    return results;

            //}




        
    }
}
