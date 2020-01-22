using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CMS.Models;

namespace CMS
{
    //populate project drop down by user id, create new task list by selected project id
    public partial class NewList : System.Web.UI.Page
    {
        string user_id;
        static string strConnString = ConfigurationManager.ConnectionStrings["WebFormConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);

        SqlDataAdapter da;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            user_id = Request.QueryString["id"];

            //populate project drop down by user id
            if (!IsPostBack)
            {
                da = new SqlDataAdapter("Select p.ProjectId, ProjectName from Projects p inner join UserProject up on p.projectId = up.projectId where UserId = " + user_id, con);
                dt = new DataTable();
                da.Fill(dt);
                ProjectDropDownList.DataSource = dt;
                ProjectDropDownList.DataTextField = "ProjectName";
                ProjectDropDownList.DataValueField = "ProjectId";
                ProjectDropDownList.DataBind();
            }
         }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int ListId = 0;
            string constr = ConfigurationManager.ConnectionStrings["WebFormConnectionString"].ConnectionString;

            //if field not filled up, not proceeding
            if (NewListNameTxtBox.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "All fields have to be filled up." + "');", true);
            }

            //call stored procedure to create task list
            else
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Insert_TaskList"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TaskListname", NewListNameTxtBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@ProjectId", ProjectDropDownList.SelectedValue);
                            cmd.Connection = con;
                            con.Open();
                            ListId = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();
                        }
                    }

                    //display message if successful or not
                    string message = string.Empty;
                    switch (ListId)
                    {
                        case -1:
                            message = "List Name already exists.\\nPlease choose a different list Name.";
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