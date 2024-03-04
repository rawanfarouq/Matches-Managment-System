using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Data;

namespace db_M3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
                //create a new connection
                SqlConnection conn = new SqlConnection(connStr);
     
            string user = Username1.Text;
            String pass = Password1.Text;
            if (user.Equals("") || pass.Equals(""))
            {
                Response.Write("fill in the missing parts...");
            }
            else { 
            SqlCommand checkUserfunction = new SqlCommand("CheckUser", conn);
            checkUserfunction.CommandType = System.Data.CommandType.StoredProcedure; //check
            checkUserfunction.Parameters.Add(new SqlParameter("@username", user));
            checkUserfunction.Parameters.Add(new SqlParameter("@password", pass));

            SqlParameter usertype = checkUserfunction.Parameters.Add("@myout",SqlDbType.VarChar,80);
            usertype.Direction = ParameterDirection.Output;

            conn.Open();
            checkUserfunction.ExecuteNonQuery();
            conn.Close();


                if (usertype.Value.Equals("incorrect"))
                {

                    Response.Write("username or password is inncorrect or if it is your first time please register");
                }
                else
                {
                    Session["Theusername"] = user;
                    Session["Thepassward"] = pass;

                    if (usertype.Value.Equals("Fan"))
                    {
                        Response.Redirect("fan.aspx");
                    }
                    if (usertype.Value.Equals("Stadium_Manager"))
                    {
                        Response.Redirect("StadiumManager.aspx");
                    }
                    if (usertype.Value.Equals("Club_Representative"))
                    {
                        Response.Redirect("ClubRepresentative.aspx?Theusername=" + user);
                    }
                    if (usertype.Value.Equals("SportsAssociationManager"))
                    {
                        Response.Redirect("AssociationManager.aspx");
                    }
                    if (usertype.Value.Equals("System_Admin"))
                    {
                        Response.Redirect("SystemAdmin.aspx");
                    }
                }
            }
        }

        protected void Fan(object sender, EventArgs e)
        {
            Response.Redirect("FanRegister.aspx");
        }

        protected void AssociationManager(object sender, EventArgs e)
        {
            Response.Redirect("AssociationManagerRegister.aspx");
        }

        protected void ClubRepresentative(object sender, EventArgs e)
        {
            Response.Redirect("ClubRepresentativeRegister.aspx");
        }

        protected void StadiumManager(object sender, EventArgs e)
        {
            Response.Redirect("StadiumManagerRegister.aspx");
        }
    }
}