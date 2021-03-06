﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessLayer;

namespace DataLayer
{
    public static class Product_SuppliersDB
    {

        public static List<Products_suppliers> GetProduct_Suppliers()
        {
            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            List<Products_suppliers> results = new List<Products_suppliers>();

            try
            {

                string sql = "SELECT * FROM [dbo].[Products_Suppliers] ";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Products_suppliers s = new Products_suppliers();
                    
                    s.ProductSupplierId = Convert.ToInt32(reader["ProductSupplierId"].ToString());

                    s.ProductId = Convert.ToInt32(reader["ProductId"].ToString());                   
                
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



        public static Products_suppliers GetProduct_Suppliers(int ID)
        {
            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            Products_suppliers s = new Products_suppliers();
            try
            {
                string sql = "SELECT * FROM [dbo].[Products_Suppliers] where ProductSupplierId="+ID;
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                   
                    s.ProductSupplierId = Convert.ToInt32(reader["ProductSupplierId"].ToString());
                    s.ProductId = Convert.ToInt32(reader["ProductId"].ToString());                   
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


       


        public static List<Products_suppliers> orderby(string coluName)
        {
            SqlConnection connection = TRAExpertsDB.GetConnection();
            List<Products_suppliers> results = new List<Products_suppliers>();
            try
            {
                string sql = "SELECT * FROM [dbo].[Products_Suppliers] order by" + "'" + coluName + "'";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read()) 
                {
                    Products_suppliers s = new Products_suppliers ();
                    s.ProductSupplierId = Convert.ToInt32(reader["ProductSupplierId"].ToString());
                    s.ProductId = Convert.ToInt32(reader["ProductId"].ToString());                   
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


       


    }
}
