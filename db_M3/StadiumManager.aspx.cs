using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Messaging;
using System.Xml.Linq;

namespace db_M3
{
    public partial class StadiumManager : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("checkinfoStadium", sqlCon);
                cmd.CommandText = "Select * from dbo.checkinfoStadium(@username)";
                cmd.Parameters.Add(new SqlParameter("@username", username));



                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                sqlDa.Fill(table);

                matchesInfo.DataSource = table;
                matchesInfo.DataBind();

            }

            using (SqlConnection sqlCon = new SqlConnection(connStr))
            {

                sqlCon.Open();

                SqlCommand cmd = new SqlCommand("viewRequests", sqlCon);
                cmd.CommandText = "Select * from dbo.viewRequests(@username)";
                cmd.Parameters.Add(new SqlParameter("@username", username));



                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();



                sqlDa.Fill(table);

                


                requestinfo.DataSource = table;
                requestinfo.DataBind();

            }

        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            Button btn = (Button)sender;
            GridViewRow grid = (GridViewRow)btn.NamingContainer;
            string username = Session["Theusername"].ToString();
            string clubRepresentative = grid.Cells[0].Text;
            string hostClubName = grid.Cells[1].Text;
            string guestClubName = grid.Cells[2].Text;
            string start = grid.Cells[3].Text;
            string status = grid.Cells[5].Text;


           /* SqlCommand checkUserfunction = new SqlCommand("checkRequest", conn);
            checkUserfunction.CommandType = System.Data.CommandType.StoredProcedure; 
            checkUserfunction.Parameters.Add(new SqlParameter("@status", status));

            SqlParameter usertype = checkUserfunction.Parameters.Add("@myout", SqlDbType.VarChar, 80);
            usertype.Direction = ParameterDirection.Output;

            conn.Open();
            checkUserfunction.ExecuteNonQuery();
            conn.Close();

            if(usertype.Value.Equals("already handled"))
            {
                Response.Write("Already handled");
            }

            else
            {*/
                if (btn.Text.Equals("Accept"))
                {


                    accept(sender, e);



                }
                else
                {

                    decline(sender, e);
                }
            


          



        }
        
        protected void accept(object sender, EventArgs e)
        {
            string username = Session["Theusername"].ToString();


            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            Button btn = (Button)sender;

            GridViewRow grid = (GridViewRow)btn.NamingContainer;
            string clubRepresentative = grid.Cells[0].Text;
            string hostClubName = grid.Cells[1].Text;
            string guestClubName = grid.Cells[2].Text;
            string start = grid.Cells[3].Text;
            string status = grid.Cells[5].Text;

            if (status.Equals("accepted") || status.Equals("rejected"))
            {
                Response.Write("Already handled");
            }

            else
            {
                SqlCommand checkUserfunction1 = new SqlCommand("acceptRequest11", conn);
                checkUserfunction1.CommandType = System.Data.CommandType.StoredProcedure; //check
                checkUserfunction1.Parameters.Add(new SqlParameter("@stadium_manager_name", username));
                checkUserfunction1.Parameters.Add(new SqlParameter("@host_club_name", hostClubName));
                checkUserfunction1.Parameters.Add(new SqlParameter("@guest_club_name", guestClubName));
                checkUserfunction1.Parameters.Add(new SqlParameter("@time", start));

                Response.Write("Changed successfully, please reload the page");




                conn.Open();
                checkUserfunction1.ExecuteNonQuery();
                conn.Close();
            }
        }

        protected void decline(object sender, EventArgs e)
        {
            string username = Session["Theusername"].ToString();

            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            Button btn = (Button)sender;
            GridViewRow grid = (GridViewRow)btn.NamingContainer;
            string clubRepresentative = grid.Cells[0].Text;
            string hostClubName = grid.Cells[1].Text;
            string guestClubName = grid.Cells[2].Text;
            string start = grid.Cells[3].Text;
            string status = grid.Cells[5].Text;

            if (status.Equals("accepted") || status.Equals("rejected"))
            {
                Response.Write("Already handled");
            }

            else
            {
                SqlCommand checkUserfunction2 = new SqlCommand("rejectRequest", conn);
                checkUserfunction2.CommandType = System.Data.CommandType.StoredProcedure; //check
                checkUserfunction2.Parameters.Add(new SqlParameter("@managerusername", username));
                checkUserfunction2.Parameters.Add(new SqlParameter("@hostClub", hostClubName));
                checkUserfunction2.Parameters.Add(new SqlParameter("@guestClub", guestClubName));
                checkUserfunction2.Parameters.Add(new SqlParameter("@StartTime", start));


                Response.Write("Changed successfully, please reload the page");


                conn.Open();
                checkUserfunction2.ExecuteNonQuery();
                conn.Close();
            }
        
        }


    }
}