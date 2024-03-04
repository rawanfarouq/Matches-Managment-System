using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace db_M3
{
    public partial class StadiumManagerRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register(object sender, EventArgs e)
        {
            //add new user(fan)


            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            string user = username1.Text;
            String pass = password1.Text;
            string name = name1.Text;
            string stadiumName = stadiumname.Text;

            if (user.Equals("") || pass.Equals("") || name.Equals("") || stadiumName.Equals(""))
            {
                Response.Write("missing data!!!,please complete filling in ...");
            }

            else
            {
                SqlCommand checkfanfunc = new SqlCommand("checkstadium", conn);
                checkfanfunc.CommandType = System.Data.CommandType.StoredProcedure; 
                checkfanfunc.Parameters.Add(new SqlParameter("@name", stadiumName));

                SqlParameter usertype1 = checkfanfunc.Parameters.Add("@myout", SqlDbType.VarChar, 80);
                usertype1.Direction = ParameterDirection.Output;

                SqlCommand checkfanfunc4 = new SqlCommand("checkmanager", conn);
                checkfanfunc4.CommandType = System.Data.CommandType.StoredProcedure;
                checkfanfunc4.Parameters.Add(new SqlParameter("@username", user));

                SqlParameter usertype2 = checkfanfunc4.Parameters.Add("@myout", SqlDbType.VarChar, 80);
                usertype2.Direction = ParameterDirection.Output;

                conn.Open();
                checkfanfunc.ExecuteNonQuery();
                checkfanfunc4.ExecuteNonQuery();
                conn.Close();
                if (usertype1.Value.Equals("not found"))
                {
                    Response.Write("invalid stadium name :( ");
                }
                else if(usertype1.Value.Equals("already has a manager"))
                {
                    Response.Write("already has a manager");
                }
                else
                {
                    if (usertype2.Value.Equals("username_already_exists"))
                    {
                        Response.Write("Username already exists,please choose another username");
                    }
                    else
                    {
                        SqlCommand checkfanfunc1 = new SqlCommand("addStadiumManager", conn);
                        checkfanfunc1.CommandType = System.Data.CommandType.StoredProcedure; //check
                        checkfanfunc1.Parameters.Add(new SqlParameter("@name", name));
                        checkfanfunc1.Parameters.Add(new SqlParameter("@stadium_name", stadiumName));
                        checkfanfunc1.Parameters.Add(new SqlParameter("@username", user));
                        checkfanfunc1.Parameters.Add(new SqlParameter("@password", pass));

                        conn.Open();
                        checkfanfunc1.ExecuteNonQuery();
                        conn.Close();

                        Response.Redirect("Login.aspx");
                    }
                }
            }
        }
    }
}