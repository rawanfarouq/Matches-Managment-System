using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace db_M3
{
    public partial class AssociationManager : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Theusername"] == null)
            {
                Response.Redirect("Login.aspx");//to login page
            }

            using (SqlConnection sqlCon =new SqlConnection(connStr))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select * from dbo.upcomingMatches()", sqlCon);
                DataTable table = new DataTable();
                sqlDa.Fill(table);

                UpcomingMatches1.DataSource = table;
                UpcomingMatches1.DataBind();

            }

            using (SqlConnection sqlCon = new SqlConnection(connStr))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select * from dbo.playedMatches()", sqlCon);
                DataTable table = new DataTable();
                sqlDa.Fill(table);

                playedmatches.DataSource = table;
                playedmatches.DataBind();

            }

            using (SqlConnection sqlCon = new SqlConnection(connStr))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select * from clubsNeverMatched", sqlCon);
                DataTable table = new DataTable();
                sqlDa.Fill(table);

                clubsnever.DataSource = table;
                clubsnever.DataBind();

            }
        }

        protected void addmatch(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            string host_name = hostname.Text;
            string guest_name = guestname.Text;
            string start = startime.Text;
            string end = endtime.Text;

            if (host_name.Equals("") || guest_name.Equals("") || start.Equals("") || end.Equals(""))
            {
                Response.Write("missing data!!!,please complete filling in ...");
            }

            else
            {
                SqlCommand checkfanfunc = new SqlCommand("checkMatch", conn);
                checkfanfunc.CommandType = System.Data.CommandType.StoredProcedure; //check
                checkfanfunc.Parameters.Add(new SqlParameter("@host_club", host_name));
                checkfanfunc.Parameters.Add(new SqlParameter("@guest_club", guest_name));
                checkfanfunc.Parameters.Add(new SqlParameter("@start_time", Convert.ToDateTime(start)));
                checkfanfunc.Parameters.Add(new SqlParameter("@end_time", Convert.ToDateTime(end)));

                SqlParameter usertype1 = checkfanfunc.Parameters.Add("@myout", SqlDbType.VarChar, 30);
                usertype1.Direction = ParameterDirection.Output;

                conn.Open();
                checkfanfunc.ExecuteNonQuery();
                conn.Close();

                if(usertype1.Value.Equals("already exists"))
                {
                    Response.Write("Match already exists");
                }

                else if(usertype1.Value.Equals("add the match"))
                {
                    SqlCommand checkUserfunction4 = new SqlCommand("checkdate", conn);
                    checkUserfunction4.CommandType = System.Data.CommandType.StoredProcedure; //check
                    checkUserfunction4.Parameters.Add(new SqlParameter("@date", Convert.ToDateTime(start)));
                    SqlParameter usertype4 = checkUserfunction4.Parameters.Add("@myout", SqlDbType.VarChar, 80);
                    usertype4.Direction = ParameterDirection.Output;

                    conn.Open();
                    checkUserfunction4.ExecuteNonQuery();
                    conn.Close();
                    if (usertype4.Value.Equals("invalid"))
                    {
                        Response.Write("You cannot add match by this date");
                    }
                    else
                    {
                        SqlCommand checkUserfunction1 = new SqlCommand("addNewMatch", conn);
                        checkUserfunction1.CommandType = System.Data.CommandType.StoredProcedure; //check
                        checkUserfunction1.Parameters.Add(new SqlParameter("@host_club", host_name));
                        checkUserfunction1.Parameters.Add(new SqlParameter("@guest_club", guest_name));
                        checkUserfunction1.Parameters.Add(new SqlParameter("@start_time", Convert.ToDateTime(start)));
                        checkUserfunction1.Parameters.Add(new SqlParameter("@end_time", Convert.ToDateTime(end)));
                        conn.Open();
                        checkUserfunction1.ExecuteNonQuery();
                        conn.Close();

                        Response.Write("the match is added successfully, Please reload the page");

                    }
                }
            }

        }

        protected void deletematch(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            string host_name = host1.Text;
            string guest_name = guest1.Text;
            string start = start1.Text;
            string end = end1.Text;

            if (host_name.Equals("") || guest_name.Equals("") || start.Equals("") || end.Equals(""))
            {
                Response.Write("missing data!!!,please complete filling in ...");
            }

            else
            {
                SqlCommand checkfanfunc = new SqlCommand("checkDeleteMatch", conn);
                checkfanfunc.CommandType = System.Data.CommandType.StoredProcedure; //check
                checkfanfunc.Parameters.Add(new SqlParameter("@host_club", host_name));
                checkfanfunc.Parameters.Add(new SqlParameter("@guest_club", guest_name));
                checkfanfunc.Parameters.Add(new SqlParameter("@start_time", Convert.ToDateTime(start)));
                checkfanfunc.Parameters.Add(new SqlParameter("@end_time", Convert.ToDateTime(end)));

                SqlParameter usertype1 = checkfanfunc.Parameters.Add("@myout", SqlDbType.VarChar, 30);
                usertype1.Direction = ParameterDirection.Output;

                conn.Open();
                checkfanfunc.ExecuteNonQuery();
                conn.Close();

                if(usertype1.Value.Equals("not found"))
                {
                    Response.Write("Match is not found");
                }

                else if(usertype1.Value.Equals("delete the match"))
                {
                    SqlCommand checkUserfunction4 = new SqlCommand("checkdate", conn);
                    checkUserfunction4.CommandType = System.Data.CommandType.StoredProcedure; //check
                    checkUserfunction4.Parameters.Add(new SqlParameter("@date", Convert.ToDateTime(start)));
                    SqlParameter usertype4 = checkUserfunction4.Parameters.Add("@myout", SqlDbType.VarChar, 80);
                    usertype4.Direction = ParameterDirection.Output;

                    conn.Open();
                    checkUserfunction4.ExecuteNonQuery();
                    conn.Close();
                    if (usertype4.Value.Equals("invalid"))
                    {
                        Response.Write("You cannot delete match by this date");
                    }

                    else
                    {
                        SqlCommand checkUserfunction1 = new SqlCommand("deleteMatch", conn);
                        checkUserfunction1.CommandType = System.Data.CommandType.StoredProcedure; //check
                        checkUserfunction1.Parameters.Add(new SqlParameter("@host_club", host_name));
                        checkUserfunction1.Parameters.Add(new SqlParameter("@guest_club", guest_name));
                        checkUserfunction1.Parameters.Add(new SqlParameter("@start_time", Convert.ToDateTime(start)));
                        checkUserfunction1.Parameters.Add(new SqlParameter("@end_time", Convert.ToDateTime(end)));

                        conn.Open();
                        checkUserfunction1.ExecuteNonQuery();
                        conn.Close();
                        Response.Write("the match is deleted, , Please reload the page");
                    }
                }
            }

        }


       /* protected void UpcomingMatch(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();
            string query = "Select * from upcomingMatches()";
            SqlCommand cmd = new SqlCommand(query, conn);
            var reader= cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);

            UpcomingMatches1.DataSource = table;
            conn.Close();


        }*/


    }
}