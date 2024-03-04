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
    public partial class FanRegister : System.Web.UI.Page
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
            string name1 = name.Text;
            string nationalID = nationalid.Text;
            string phnumber = phonenumber.Text;
            string bd = birthdate.Text;
            string address = address1.Text;

            if (user.Equals("")||pass.Equals("")||name1.Equals("")
                ||nationalID.Equals("")||phnumber.Equals("")||bd.Equals("")||address.Equals(""))
            {
                Response.Write("missing data!!!,please complete filling in ...");
            }
            else {
                SqlCommand checkfanfunc = new SqlCommand("checkfan", conn);
                checkfanfunc.CommandType = System.Data.CommandType.StoredProcedure; //check
                checkfanfunc.Parameters.Add(new SqlParameter("@username", user));
                checkfanfunc.Parameters.Add(new SqlParameter("@nationalID", nationalID));

                SqlParameter usertype1 = checkfanfunc.Parameters.Add("@myout", SqlDbType.VarChar, 80);
                usertype1.Direction = ParameterDirection.Output;

                conn.Open();
                checkfanfunc.ExecuteNonQuery();
                conn.Close();

         

                if (usertype1.Value.Equals("can_register"))
                {

                    SqlCommand checkUserfunction1 = new SqlCommand("addFan", conn);
                    checkUserfunction1.CommandType = System.Data.CommandType.StoredProcedure; //check
                    checkUserfunction1.Parameters.Add(new SqlParameter("@name", name1));
                    checkUserfunction1.Parameters.Add(new SqlParameter("@username", user));
                    checkUserfunction1.Parameters.Add(new SqlParameter("@password", pass));
                    checkUserfunction1.Parameters.Add(new SqlParameter("@national_id_nom", nationalID));
                    checkUserfunction1.Parameters.Add(new SqlParameter("@birthdate", Convert.ToDateTime(bd)));
                    checkUserfunction1.Parameters.Add(new SqlParameter("@address", address));
                    checkUserfunction1.Parameters.Add(new SqlParameter("@phone_number", phnumber));

                    conn.Open();
                    checkUserfunction1.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("Login.aspx");
                }
                if(usertype1.Value.Equals("username_already_exists"))
                {
                    Response.Write("this username is already taken please change your username");
                }
                if(usertype1.Value.Equals("fan_already_exists"))
                {
                    Response.Write("this fan already exist ");
                }
            }

        }
    }
}