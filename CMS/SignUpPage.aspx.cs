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
    //handle control events, create new account
    public partial class SignUpPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //call stored procedure to create a new account
        protected void RegisterUser(object sender, EventArgs e)
        {

            int userId = 0;
            string constr = ConfigurationManager.ConnectionStrings["WebFormConnectionString"].ConnectionString;

            //if all fields not filled up, cannot proceed
            if (SignUpUsertxt.Text == "" || SignUpPasstxt.Text == "" || SignUpEmailtxt.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "All fields have to be filled up." + "');", true);
            }
            else
            {

                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Insert_User"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Username", SignUpUsertxt.Text.Trim());//txtUsername.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", SignUpPasstxt.Text.Trim());//txtPassword.Text.Trim());
                            cmd.Parameters.AddWithValue("@Email", SignUpEmailtxt.Text.Trim());//txtEmail.Text.Trim());
                            cmd.Connection = con;
                            con.Open();
                            userId = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();
                        }
                    }

                    //display message if successful or not
                    string message = string.Empty;
                    switch (userId)
                    {
                        case -1:
                            message = "Username already exists.\\nPlease choose a different username.";
                            break;
                        case -2:
                            message = "Supplied email address has already been used.";
                            break;
                        default:
                            message = "Registration successful.\\nUser Id: " + userId.ToString();
                            break;
                    }
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                }
            }
        }

        //transfer to log in page if button clicked
        protected void SignInButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogInPage.aspx");
        }
    }
}
