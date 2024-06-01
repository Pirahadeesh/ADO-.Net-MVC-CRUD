using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;
using System.Runtime.CompilerServices;

namespace Animal.Models
{
    public class CityModel
    {
 
        public DataTable GetAllCity()
        {
            DataTable dt = new DataTable();
            string strConString = @"Data source=DESKTOP-0H6RN5Q\SQLEXPRESS; initial catalog=MyDB;integrated security=True;MultipleActiveResultSets=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select a.city_id,b.country_name,a.isactive,a.city_name from city as a left join country as b on a.country_id =b.country_id order by city_id", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    public int InsertCity(string city_name, bool isActive, int country_id)
        {
            string strConString = @"Data source=DESKTOP-0H6RN5Q\SQLEXPRESS; initial catalog=MyDB;integrated security=True;MultipleActiveResultSets=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into city(city_name, isActive,country_id) values(@city_name, @isActive,@country_id)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@city_name", city_name);
                cmd.Parameters.AddWithValue("@isActive", isActive);
                cmd.Parameters.AddWithValue("@country_id", country_id);
                return cmd.ExecuteNonQuery();
            }
        }

        //Get Country by ID
        public DataTable GetCityByID(int city_id)
        {
            DataTable dt = new DataTable();

            string strConString = @"Data source=DESKTOP-0H6RN5Q\SQLEXPRESS; initial catalog=MyDB;integrated security=True;MultipleActiveResultSets=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from city where city_id=" + city_id, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        //Delete Country by ID
      public int DeleteCity(int city_id)
        {
      string strConString = @"Data source=DESKTOP-0H6RN5Q\SQLEXPRESS; initial catalog=MyDB;integrated security=True;MultipleActiveResultSets=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Delete from city where city_id=@city_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@city_id", city_id);
                return cmd.ExecuteNonQuery();
            }


        }

        public List<cty> country()
        {
            string strConString = @"Data source=DESKTOP-0H6RN5Q\SQLEXPRESS; initial catalog=MyDB;integrated security=True;MultipleActiveResultSets=True";

            using(SqlConnection con = new SqlConnection(strConString))
            {
                DataTable dtbl = new DataTable();
                SqlCommand cmd = new SqlCommand("Select * from country", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtbl);
              List<cty> docTypes = new List<cty>();
                docTypes = (from DataRow dr in dtbl.Rows
                            select new cty
                            {
                                country_id = Convert.ToInt32(dr["country_id"]),
                                country_name = dr["country_name"].ToString(),
                            }).ToList();

                return docTypes;
            }


        }



        //Update City by ID

        public int UpdateCity(int city_id, int country_id, string city_name, bool isActive)
        {
            string strConString = @"Data source=DESKTOP-0H6RN5Q\SQLEXPRESS; initial catalog=MyDB;integrated security=True;MultipleActiveResultSets=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "update city SET country_id=@country_id,city_name=@city_name,isActive= @isActive where city_id=@city_id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@city_id", city_id);
                cmd.Parameters.AddWithValue("@country_id", country_id);
                cmd.Parameters.AddWithValue("@city_name", city_name);
                cmd.Parameters.AddWithValue("@isActive", isActive);
                return cmd.ExecuteNonQuery();
            }


        }
      public class cty
        {
            public int country_id { get; set; }
            public string country_name { get; set; }
        }

        public class DocViews
        {

            public cty cty { get; set; }

            public List<cty> country { get; set; }
   }

}
}