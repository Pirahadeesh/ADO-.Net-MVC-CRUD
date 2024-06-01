using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Animal.Models
{
    public class CRUDModel
    {
        public DataTable GetAllCountry()
        {
            DataTable dt = new DataTable();
            string strConString = @"Data source=DESKTOP-0H6RN5Q\SQLEXPRESS; initial catalog=MyDB;integrated security=True;MultipleActiveResultSets=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from country", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }


        public int InsertCountry(string country_name, bool isActive)
        {
            string strConString = @"Data source=DESKTOP-0H6RN5Q\SQLEXPRESS; initial catalog=MyDB;integrated security=True;MultipleActiveResultSets=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into country (country_name, isActive) values(@country_name, @isActive)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@country_name", country_name);
                cmd.Parameters.AddWithValue("@isActive", isActive);

                return cmd.ExecuteNonQuery();
            }
        }
  //Get Country by ID
        public DataTable GetCountryByID(int country_id)
        {
            DataTable dt = new DataTable();

            string strConString = @"Data source=DESKTOP-0H6RN5Q\SQLEXPRESS; initial catalog=MyDB;integrated security=True;MultipleActiveResultSets=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from country where country_id=" + country_id, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        //Delete Country by ID

        public int DeleteCountry(int country_id)
        {

            string strConString = @"Data source=DESKTOP-0H6RN5Q\SQLEXPRESS; initial catalog=MyDB;integrated security=True;MultipleActiveResultSets=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Delete from country where country_id=@country_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@country_id", country_id);
                return cmd.ExecuteNonQuery();
            }
        }
        //Update Country by ID

        public int UpdateCountry(string country_name, bool isActive, int country_id)
        {
            string strConString = @"Data source=DESKTOP-0H6RN5Q\SQLEXPRESS; initial catalog=MyDB;integrated security=True;MultipleActiveResultSets=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "update country SET country_name=@country_name,isActive= @isActive where country_id=@country_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@country_name", country_name);
                cmd.Parameters.AddWithValue("@isActive", isActive);
                cmd.Parameters.AddWithValue("@country_id", country_id);
                return cmd.ExecuteNonQuery();
            }


        }
    }
}