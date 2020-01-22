using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using CMS.Models;


namespace ComManSys
{
    //validate user and transfer to other web forms
    public partial class LogInPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ValidateUser(object sender, EventArgs e)
        {
            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["WebFormConnectionString"].ConnectionString;
            //call stored procedure to validate user by input user name and password
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Validate_User"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", txtuser.Text);
                    cmd.Parameters.AddWithValue("@Password", txtpwd.Text);
                    cmd.Connection = con;
                    con.Open();
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                //if valid user, transfer to CMS default page (into system), if not, display error message
                switch (userId)
                {
                    case -1:
                        lblmsg.Text = "Invalid User/password!!";
                        break;
                    default:
                        Session["UserId"] = userId;
                        Response.Redirect("Default.aspx");
                        break;
                }
            }
        }
        //transfer to sign up page if the button click
        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUpPage.aspx");
        }
    }
}
