using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace db_M3
{
    public partial class SystemAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Theusername"] == null)
            {
                Response.Redirect("Login.aspx");//to login page
            }
        }

        protected void addclub(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            string clubname = name1.Text;
            String location = location1.Text;
            if (clubname.Equals("")|| location.Equals(""))
            {
                Response.Write("missing data!!!,please complete filling in ...");
            }
            else
            {
                SqlCommand checkfanfunc = new SqlCommand("checkclub", conn);
                checkfanfunc.CommandType = System.Data.CommandType.StoredProcedure; //check
                checkfanfunc.Parameters.Add(new SqlParameter("@name", clubname));

                SqlParameter usertype1 = checkfanfunc.Parameters.Add("@myout", SqlDbType.VarChar, 100);
                usertype1.Direction = ParameterDirection.Output;

                conn.Open();
                checkfanfunc.ExecuteNonQuery();
                conn.Close();

                if (usertype1.Value.Equals("found") || usertype1.Value.Equals("already has a representative")){
                    Response.Write("this club already exists...");
                }
                else if (usertype1.Value.Equals("not found"))
                {
                    SqlCommand checkUserfunction1 = new SqlCommand("addClub", conn);
                    checkUserfunction1.CommandType = System.Data.CommandType.StoredProcedure; //check
                    checkUserfunction1.Parameters.Add(new SqlParameter("@clubName",clubname));
                    checkUserfunction1.Parameters.Add(new SqlParameter("@location", location));
                    conn.Open();
                    checkUserfunction1.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("the club is added successfully :)");
                }
            }
        }

        protected void deleteclub(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            string name = name2.Text;

            if (name.Equals(""))
            {
                Response.Write("missing data!!!,please complete filling in ...");
            }
            else
            {
                SqlCommand checkUserfunction2 = new SqlCommand("deleteClub", conn);
                checkUserfunction2.CommandType = System.Data.CommandType.StoredProcedure;
                checkUserfunction2.Parameters.Add(new SqlParameter("@clubName", name));

                SqlParameter usertype1 = checkUserfunction2.Parameters.Add("@myout", SqlDbType.VarChar, 30);
                usertype1.Direction = ParameterDirection.Output;

                conn.Open();
                checkUserfunction2.ExecuteNonQuery();
                conn.Close();

                if (usertype1.Value.Equals("success"))
                {

        

                    Response.Write("this club has been deleted successfully :)");
                }
                else if(usertype1.Value.Equals("not found"))
                {
                    Response.Write("this club is not found");
                }
            }
        }

        protected void addstadium(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            string stadiumname = name3.Text;
            String location= location2.Text;
            string capacity = capacity1.Text;

            if (stadiumname.Equals("") || location.Equals("")|| capacity.Equals(""))
            {
                Response.Write("missing data!!!,please complete filling in ...");
            }

            else
            {
                SqlCommand checkfanfunc3 = new SqlCommand("checkstadium", conn);
                checkfanfunc3.CommandType = System.Data.CommandType.StoredProcedure; //check
                checkfanfunc3.Parameters.Add(new SqlParameter("@name", stadiumname));
                

                SqlParameter usertype1 = checkfanfunc3.Parameters.Add("@myout", SqlDbType.VarChar, 80);////
                usertype1.Direction = ParameterDirection.Output;

                conn.Open();
                checkfanfunc3.ExecuteNonQuery();
                conn.Close();

                if (usertype1.Value.Equals("found"))
                {
                    Response.Write("this stadium already exists...");
                }
                else if(usertype1.Value.Equals("not found"))
                {
                    SqlCommand checkUserfunction1 = new SqlCommand("addStadium", conn);
                    checkUserfunction1.CommandType = System.Data.CommandType.StoredProcedure; //check
                    checkUserfunction1.Parameters.Add(new SqlParameter("@stadiumName", stadiumname));
                    checkUserfunction1.Parameters.Add(new SqlParameter("@location", location));
                    checkUserfunction1.Parameters.Add(new SqlParameter("@capacity", capacity));
                    conn.Open();
                    checkUserfunction1.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("the stadium is added successfully");
                }
            }
        }

        protected void deletestadium(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            string name = name4.Text;

            if (name.Equals(""))
            {
                Response.Write("missing data!!!,please complete filling in ...");
            }
            else
            {
                SqlCommand checkUserfunction2 = new SqlCommand("deleteStadium", conn);
                checkUserfunction2.CommandType = System.Data.CommandType.StoredProcedure;
                checkUserfunction2.Parameters.Add(new SqlParameter("@stadiumName", name));

                SqlParameter usertype1 = checkUserfunction2.Parameters.Add("@myout", SqlDbType.VarChar, 20);
                usertype1.Direction = ParameterDirection.Output;

                conn.Open();
                checkUserfunction2.ExecuteNonQuery();
                conn.Close();

                if (usertype1.Value.Equals("success"))
                {
                    Response.Write("this club has been deleted successfully :)");
                }
                else if (usertype1.Value.Equals("not found"))
                {
                    Response.Write("this stadium is not found");
                }
            }
        }

        protected void blockfan(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            string nationalid = national2.Text;

            if (nationalid.Equals(""))
            {
                Response.Write("missing data!!!,please complete filling in ...");
            }

            else
            {
                SqlCommand checkfanfunc4 = new SqlCommand("checkfanblock", conn);
                checkfanfunc4.CommandType = System.Data.CommandType.StoredProcedure; //check
                checkfanfunc4.Parameters.Add(new SqlParameter("@national_id", nationalid));

                SqlParameter usertype1 = checkfanfunc4.Parameters.Add("@myout", SqlDbType.VarChar, 30);
                usertype1.Direction = ParameterDirection.Output;

                conn.Open();
                checkfanfunc4.ExecuteNonQuery();
                conn.Close();

                if(usertype1.Value.Equals("already blocked"))
                {
                    Response.Write("The fan is already blocked");
                }
                
                else if(usertype1.Value.Equals("not blocked"))
                {
                    SqlCommand checkUserfunction1 = new SqlCommand("blockFan", conn);
                    checkUserfunction1.CommandType = System.Data.CommandType.StoredProcedure; //check
                    checkUserfunction1.Parameters.Add(new SqlParameter("@national_id", nationalid));
                    conn.Open();
                    checkUserfunction1.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("the fan is blocked");
                }
            }

        }
    }
}