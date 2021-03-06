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
    public static class PackageDB
    {
        public static List<Packages>GetPackages()
    {
        SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
        List<Packages> results = new List<Packages>();

        try
        {
            string sql = "SELECT * FROM Packages ";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Packages s = new Packages();
                s.PkgName = reader["PkgName"].ToString();
                s.PackageId = Convert.ToInt32(reader["PackageId"].ToString());
                s.PkgStartDate = Convert.ToDateTime(reader["PkgStartDate"].ToString());
                s.PkgEndDate = Convert.ToDateTime(reader["PkgEndDate"].ToString());
                s.PkgDesc = reader["PkgDesc"].ToString();
                s.PkgBasePrice = Convert.ToDouble(reader["PkgBasePrice"].ToString());
                s.PkgAgencyCommission = Convert.ToDouble(reader["PkgAgencyCommission"].ToString());
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


        public static Packages GetPackage(int PkgId)
        {
            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            Packages s = new Packages();
            try
            {
                string sql = "SELECT * FROM Packages WHERE PackageID =" + PkgId;
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    s.PkgName = reader["PakName"].ToString();
                    s.PackageId = Convert.ToInt32(reader["PackageId"].ToString());
                    s.PkgStartDate = Convert.ToDateTime(reader["PkgStartDate"].ToString());
                    s.PkgEndDate = Convert.ToDateTime(reader["PkgEndDate"].ToString());
                    s.PkgDesc = reader["PkgDesc"].ToString();
                    s.PkgBasePrice = Convert.ToDouble(reader["PkgBasePrice"].ToString());
                    s.PkgAgencyCommission = Convert.ToDouble(reader["PkgAgencyCommission"].ToString());

                }
            }
            catch { }
            finally
            {
                connection.Close();
            }


            return s;

        }


        public static int AddPackage(string PkgName, DateTime PkgStartDate, DateTime PkgEndDate, string PkgDesc, double PkgBasePrice, double PkgAgencyCommission)
        {
            string sql = "INSERT INTO Packages (PkgName,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission)  VALUES (@PkgName,@PkgStartDate,@PkgEndDate,@PkgDesc,@PkgBasePrice,@PkgAgencyCommission)";
           // string sql = "INSERT INTO Packages (PkgName,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission)  VALUES ('Ye','2019-06-06','2019-06-06','Ye',100,120)";
            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@PkgName", PkgName);
            command.Parameters.AddWithValue("@PkgStartDate", PkgStartDate);
            command.Parameters.AddWithValue("@PkgEndDate", PkgEndDate);
            command.Parameters.AddWithValue("@PkgDesc", PkgDesc);
            command.Parameters.AddWithValue("@PkgBasePrice", PkgBasePrice);
            command.Parameters.AddWithValue("@PkgAgencyCommission", PkgAgencyCommission);

            int qq = command.ExecuteNonQuery();

            return qq;

        }
        public static int DelePackage(int PkgId)
        {
            string sql = "Delete Packages where PackageID=" + PkgId;

            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);
            int qq = command.ExecuteNonQuery();

            return qq;
        }

        public static int UpdaPackage(int PkgId, string PkgName, DateTime PkgStartDate, DateTime PkgEndDate, string PkgDesc, Double PkgBasePrice, Double PkgAgencyCommission)
        {


            string sql = "UPDATE  Packages  SET PkgName=@PkgName, PkgStartDate=@PkgStartDate,PkgEndDate=@PkgEndDate,PkgDesc=@PkgDesc,PkgBasePrice=@PkgBasePrice,PkgAgencyCommission=@PkgAgencyCommission   where PackageId=" + PkgId;

            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@PkgName", PkgName);
            command.Parameters.AddWithValue("@PkgStartDate", PkgStartDate);
            command.Parameters.AddWithValue("@PkgEndDate", PkgEndDate);
            command.Parameters.AddWithValue("@PkgDesc", PkgDesc);
            command.Parameters.AddWithValue("@PkgBasePrice", PkgBasePrice);
            command.Parameters.AddWithValue("@PkgAgencyCommission", PkgAgencyCommission);

            int qq = command.ExecuteNonQuery();
            return qq;

        }
        public static List<Packages> orderby(string coluName)
        {
            SqlConnection connection = TRAExpertsDB.GetConnection();
            List<Packages> results = new List<Packages>();
            try
            {
                string sql = "SELECT * FROM Packages order by" + "'" + coluName + "'";

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Packages p = new Packages();
                    p.PackageId = Convert.ToInt32(reader["PackageId"].ToString());
                    p.PkgName = reader["PkgName"].ToString();
                    p.PkgStartDate = Convert.ToDateTime(reader["PkgStartDate"].ToString());
                    p.PkgEndDate = Convert.ToDateTime(reader["PkgEndDate"].ToString());
                    p.PkgDesc = reader["PkgDesc"].ToString();
                    p.PkgBasePrice = Convert.ToDouble(reader["PkgBasePrice"].ToString());
                    p.PkgAgencyCommission = Convert.ToDouble( reader["PkgAgencyCommission"].ToString());

                    results.Add(p);
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

