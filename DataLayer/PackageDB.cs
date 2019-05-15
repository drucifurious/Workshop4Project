
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
   

        public static Packages GetPackage(int PkgId)
        {
            SqlConnection connection = DataLayer.TRAExpertsDB.GetConnection();
            Packages s = new Packages();
            try
            {
                string sql = "SELECT * " + "FROM Packages " +
                    "WHERE PackageID =" + PkgId;
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    s.PkgName = reader["PkgName"].ToString();
                    s.PackageId = Convert.ToInt32(reader["PackageId"].ToString());
                    s.PkgStartDate = Convert.ToDateTime(reader["PkgStartDate"].ToString());
                    s.PkgEndDate = Convert.ToDateTime(reader["PkgEndDate"].ToString());
                    s.PkgDesc = reader["PkgDesc"].ToString();
                    s.PkgBasePrice = Convert.ToInt32(reader["PkgBasePrice"].ToString());
                    s.PkgAgencyCommission = Convert.ToInt32(reader["PkgAgencyCommission"].ToString());

                }
            }
            catch { }
            finally
            {
                connection.Close();
            }


            return s;

        }


        public static int AddPackage(string PkgName, string PkgStartDate, string PkgEndDate, string PkgDesc, string PkgBasePrice, string PkgAgencyCommission)
        {
            string sql = "INSERT INTO Packages (PkgName,PkgStartDate,PkgEndDate,PkgDesc,PkgBasePrice,PkgAgencyCommission)  VALUE (@PkgName,@PkgStartDate,@PkgEndDate,@PkgDesc,@PkgBasePrice,@PkgAgencyCommission)";
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

        public static int UpdaPackage(int PkgId, string PkgName, string PkgStartDate, string PkgEndDate, string PkgDesc, string PkgBasePrice, string PkgAgencyCommission)
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








    }




}

