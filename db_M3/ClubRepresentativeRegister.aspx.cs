using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace db_M3
{
    public partial class ClubRepresentativeRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register(object sender, EventArgs e)
        {
            /*
             * @club_representative varchar(20),
@club_name varchar(20),
@username varchar(20),
@password varchar(20)*/

            string connStr = WebConfigurationManager.ConnectionStrings["myconnection"].ToString();
            //create a new connection
            SqlConnection conn = new SqlConnection(connStr);

            string user = username1.Text;
            String pass = password1.Text;
            string name = name1.Text;
            string clubname = club.Text;

            if (user.Equals("") || pass.Equals("") || name.Equals("") || clubname.Equals(""))
            {
                Response.Write("missing data!!!,please complete filling in ...");
            }

            else
                {
                SqlCommand checkfanfunc = new SqlCommand("checkclub", conn);
                checkfanfunc.CommandType = System.Data.CommandType.StoredProcedure; //check
                checkfanfunc.Parameters.Add(new SqlParameter("@name", clubname));

                SqlParameter usertype1 = checkfanfunc.Parameters.Add("@myout", SqlDbType.VarChar, 80);
                usertype1.Direction = ParameterDirection.Output;

                SqlCommand checkfanfunc5 = new SqlCommand("checkRepresentative", conn);
                checkfanfunc5.CommandType = System.Data.CommandType.StoredProcedure; //check
                checkfanfunc5.Parameters.Add(new SqlParameter("@username", user));

                SqlParameter usertype2 = checkfanfunc5.Parameters.Add("@myout", SqlDbType.VarChar, 80);
                usertype2.Direction = ParameterDirection.Output;


                conn.Open();
                checkfanfunc.ExecuteNonQuery();
                checkfanfunc5.ExecuteNonQuery();
                conn.Close();
                if (usertype1.Value.Equals("not found"))
                {
                    Response.Write("invalid Club name :( ");
                }
                else if (usertype1.Value.Equals("already has a representative"))
                    {
                        Response.Write("already has a representative");
                    }

                    else
                    {

                    if (usertype2.Value.Equals("found"))
                    {
                        Response.Write("Username already exists, choose another username");
                    }

                    
                    else
                    {
                        SqlCommand checkfanfunc1 = new SqlCommand("addRepresentative", conn);
                        checkfanfunc1.CommandType = System.Data.CommandType.StoredProcedure; //check
                        checkfanfunc1.Parameters.Add(new SqlParameter("@club_representative", name));
                        checkfanfunc1.Parameters.Add(new SqlParameter("@club_name", clubname));
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