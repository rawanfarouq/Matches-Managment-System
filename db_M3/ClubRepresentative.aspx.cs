using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace db_M3
{
    public partial class ClubRepresentative : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Theusername"] == null)
            {
                Response.Redirect("Login.aspx");//to login page
            }
            string username = Session["Theusername"].ToString();
            using (SqlConnection sqlCon = new SqlConnection(connStr))
            {

                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("checkinfo", sqlCon);
                cmd.CommandText = "Select * from dbo.checkinfo(@username)";
                cmd.Parameters.Add(new SqlParameter("@username", username));


                
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                sqlDa.Fill(table);

                clubinfo.DataSource = table;
                clubinfo.DataBind();

            }

            using (SqlConnection sqlCon = new SqlConnection(connStr))
            {

                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("checkupcomingmatchRepresentative", sqlCon);
                cmd.CommandText = "Select * from dbo.checkupcomingmatchRepresentative(@username)";
                cmd.Parameters.Add(new SqlParameter("@username", username));



                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                sqlDa.Fill(table);

                matchesInfo.DataSource = table;
                matchesInfo.DataBind();

            }

        }

        protected void stadium(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            string date = available.Text;
            conn.Open();
            SqlCommand checkUserfunction = new SqlCommand("viewAvailableStadiumsOn", conn);
            checkUserfunction.CommandText = "Select * from dbo.viewAvailableStadiumsOn(@date)";
            checkUserfunction.Parameters.Add(new SqlParameter("@date", date));

            SqlDataAdapter sqlDa = new SqlDataAdapter(checkUserfunction);
            DataTable table = new DataTable();
            sqlDa.Fill(table);

            GridView1.DataSource = table;
            GridView1.DataBind();

            conn.Close();

        }

        protected void request(object sender, EventArgs e)
        {
            string username = Session["Theusername"].ToString();

            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            string stadium_name = stadiumname.Text;
            string start = start_time.Text;

            if (stadium_name.Equals("") || start.Equals(""))
            {
                Response.Write("Missing info");
            }
            else
            {


                SqlCommand checkUserfunction = new SqlCommand("checkRequests", conn);
                checkUserfunction.CommandType = System.Data.CommandType.StoredProcedure; //check
                checkUserfunction.Parameters.Add(new SqlParameter("@username_rep", username));
                checkUserfunction.Parameters.Add(new SqlParameter("@stadium_name", stadium_name));
                checkUserfunction.Parameters.Add(new SqlParameter("@start", Convert.ToDateTime(start)));

                SqlParameter usertype = checkUserfunction.Parameters.Add("@myout", SqlDbType.VarChar, 80);
                usertype.Direction = ParameterDirection.Output;

                conn.Open();
                checkUserfunction.ExecuteNonQuery();
                conn.Close();



                if (usertype.Value.Equals("already exists"))
                {
                    Response.Write("This request is already exists");
                }

                if(usertype.Value.Equals("no match"))
                {
                    Response.Write("Couldn't find match");
                }
                else
                {
                    SqlCommand checkUserfunction2 = new SqlCommand("addHostRequest", conn);
                    checkUserfunction2.CommandType = System.Data.CommandType.StoredProcedure;
                    checkUserfunction2.Parameters.Add(new SqlParameter("@representative_username", username));
                    checkUserfunction2.Parameters.Add(new SqlParameter("@stadium_name", stadium_name));
                    checkUserfunction2.Parameters.Add(new SqlParameter("@start_time", Convert.ToDateTime(start)));


                    SqlParameter usertype1= checkUserfunction2.Parameters.Add("@myout", SqlDbType.VarChar, 80);
                    usertype1.Direction = ParameterDirection.Output;

                    conn.Open();
                    checkUserfunction2.ExecuteNonQuery();
                    conn.Close();

                    if (usertype1.Value.Equals("no match"))
                    {
                        Response.Write("There is no match with this start time or no stadium manager ");
                    }
                    else
                    {
                        Response.Write("Added successfully");
                    }
                   
                }

            }
        }
    }
}