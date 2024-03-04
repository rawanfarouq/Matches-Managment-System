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
    public partial class fan : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Theusername"] == null)
            {
                Response.Redirect("Login.aspx");//to login page
            }

            using (SqlConnection sqlCon = new SqlConnection(connStr))
            {
                sqlCon.Open();

                string date = matchdate.Text;
                SqlCommand cmd = new SqlCommand("availableMatchesToAttend", sqlCon);
                cmd.CommandText = "Select * from dbo.availableMatchesToAttend(@date)";
                cmd.Parameters.Add(new SqlParameter("@date", Convert.ToDateTime(date)));



                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                sqlDa.Fill(table);

                matches1Info.DataSource = table;
                matches1Info.DataBind();


            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string username = Session["Theusername"].ToString();


            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);




            SqlCommand checkUserfunction = new SqlCommand("checkfan123", conn);
            checkUserfunction.CommandType = System.Data.CommandType.StoredProcedure; //check
            checkUserfunction.Parameters.Add(new SqlParameter("@username", username));

            SqlParameter usertype = checkUserfunction.Parameters.Add("@myout", SqlDbType.VarChar, 80);
            usertype.Direction = ParameterDirection.Output;

            conn.Open();
            checkUserfunction.ExecuteNonQuery();
            conn.Close();

            if (usertype.Value.Equals("already blocked"))
            {
                Response.Write("Can't purchase a ticket");
            }
            else
            {
                MyButtonClick(sender, e);
            }

        }

        protected void MyButtonClick(object sender, EventArgs e)
        {
            string username = Session["Theusername"].ToString();


            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            Button btn = (Button)sender;
            GridViewRow grid = (GridViewRow)btn.NamingContainer;
            string hostClubName = grid.Cells[0].Text;
            string guestClubName = grid.Cells[1].Text;
            string start = grid.Cells[2].Text;
            string stadiumName = grid.Cells[3].Text;
            string location = grid.Cells[4].Text;





            SqlCommand checkUserfunction1 = new SqlCommand("purchaseTicket", conn);
            checkUserfunction1.CommandType = System.Data.CommandType.StoredProcedure; //check
            checkUserfunction1.Parameters.Add(new SqlParameter("@username", username));
            checkUserfunction1.Parameters.Add(new SqlParameter("@clubhost_name", hostClubName));
            checkUserfunction1.Parameters.Add(new SqlParameter("@clubguest_name", guestClubName));
            checkUserfunction1.Parameters.Add(new SqlParameter("@date", start));



            conn.Open();
            checkUserfunction1.ExecuteNonQuery();
            conn.Close();
        }


    }


    }
