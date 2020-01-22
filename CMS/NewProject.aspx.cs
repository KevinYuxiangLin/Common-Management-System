using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace CMS
{
    //create new project for the passing user id
    public partial class NewProject : System.Web.UI.Page
    {
        int user_id;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            user_id = (int)Session["UserId"];
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        //create new project
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int projectId = 0;
            string constr = ConfigurationManager.ConnectionStrings["WebFormConnectionString"].ConnectionString;
            
            //if the field not filled up, not proceeding
            if (ProjectNameTxtBox.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "All fields have to be filled up." + "');", true);
            }
            //call stored procedure to create project
            else
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Insert_Project"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ProjectName", ProjectNameTxtBox.Text.Trim());
 
                            cmd.Parameters.AddWithValue("@UserId", user_id);
                            cmd.Connection = con;
                            con.Open();
                            projectId = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();
                        }
                    }

                    //dispaly message if successful or not
                    string message = string.Empty;
                    switch (projectId)
                    {
                        case -1:
                            message = "Project Name already exists.\\nPlease choose a different project Name.";
                            break;
                        default:
                            message = "Save successful";
                            break;
                    }
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                }
            }
        }
    }
}