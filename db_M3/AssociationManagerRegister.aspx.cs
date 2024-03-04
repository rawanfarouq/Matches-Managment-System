using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Web.Configuration;

namespace db_M3
{
    public partial class AssociationManagerRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            string user = username1.Text;
            String pass = password1.Text;
            string name = name1.Text;

            if (user.Equals("") || pass.Equals("") || name.Equals(""))
            {
                Response.Write("missing data!!!,please complete filling in ...");
            }

            else
            {
                SqlCommand checkfanfunc = new SqlCommand("checkmanager", conn);
                checkfanfunc.CommandType = System.Data.CommandType.StoredProcedure; //check
                checkfanfunc.Parameters.Add(new SqlParameter("@username", user));
                
                SqlParameter usertype1 = checkfanfunc.Parameters.Add("@myout", SqlDbType.VarChar, 80);
                usertype1.Direction = ParameterDirection.Output;

                conn.Open();
                checkfanfunc.ExecuteNonQuery();
                conn.Close();

                Response.Write(usertype1.Value);

                if (usertype1.Value.Equals("username_already_exists"))
                {
                    Response.Write("this username is already taken please change your username");
                }

                else 
                {

                    SqlCommand checkUserfunction1 = new SqlCommand("addAssociationManager", conn);
                    checkUserfunction1.CommandType = System.Data.CommandType.StoredProcedure; //check
                    checkUserfunction1.Parameters.Add(new SqlParameter("@name", name));
                    checkUserfunction1.Parameters.Add(new SqlParameter("@username", user));
                    checkUserfunction1.Parameters.Add(new SqlParameter("@password", pass));
                    
                        conn.Open();
                        checkUserfunction1.ExecuteNonQuery();
                        conn.Close();
                   
                    Response.Redirect("Login.aspx");
                }
                
            }
           
        }
    }
}