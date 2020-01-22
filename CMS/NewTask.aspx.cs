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
    //populate project and task list drop down, call stored procedure to create new task with input values
    public partial class NewTask : System.Web.UI.Page
    {
        string user_id;

        static string strConnString = ConfigurationManager.ConnectionStrings["WebFormConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);

        SqlDataAdapter da, da1;
        DataTable dt, dt1;
        
        //retrieve user id and populate project drop down, and populate task list drop down by selected project id
        protected void Page_Load(object sender, EventArgs e)
        {
            user_id = Request.QueryString["id"];
            if (!IsPostBack)
            {
                da = new SqlDataAdapter("Select p.ProjectId, ProjectName from Projects p inner join UserProject up on p.projectId = up.projectId where UserId = " + user_id, con);
                dt = new DataTable();
                da.Fill(dt);
                ProjectDropDownList.DataSource = dt;
                ProjectDropDownList.DataTextField = "ProjectName";
                ProjectDropDownList.DataValueField = "ProjectId";
                ProjectDropDownList.DataBind();

                string projectId = ProjectDropDownList.SelectedValue;
                PopulateTaskList(projectId);
            }
        }

        //populate task list drop down by project id
        public void PopulateTaskList(string ProjectId)
        {
            da1 = new SqlDataAdapter("Select TaskListName from TaskList where ProjectId = " + ProjectId, con);
            dt1 = new DataTable();
            da1.Fill(dt1);
            DropDownList1.DataSource = dt1;
            DropDownList1.DataTextField = "TaskListName";
            DropDownList1.DataValueField = "TaskListName";
            DropDownList1.DataBind();
        }

        //populate task list drop down by the project id change
        public void Selected_Changed(object sender, EventArgs e)
        {
            string projectId = ProjectDropDownList.SelectedValue;
            PopulateTaskList(projectId);
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        
        //call store procedure to create new task
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int TaskId = 0;
            string constr = ConfigurationManager.ConnectionStrings["WebFormConnectionString"].ConnectionString;

            //if not all fields filled up, cannot proceed
            if (NewTaskNameTxtBox.Text == "" || DateTextBox.Text == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "All fields have to be filled up." + "');", true);
            }
            else
            {
                //call stored procedure to create new task
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Insert_Task"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TaskName", NewTaskNameTxtBox.Text.Trim());
                            cmd.Parameters.AddWithValue("@TaskListName", DropDownList1.SelectedValue);
                            cmd.Parameters.AddWithValue("@priority", PriorityDropDownList.SelectedValue);
                            cmd.Parameters.AddWithValue("@Date", Convert.ToDateTime(DateTextBox.Text));
                            cmd.Parameters.AddWithValue("@ProjectId", ProjectDropDownList.SelectedValue);
                            cmd.Connection = con;
                            con.Open();
                            TaskId = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();
                        }
                    }
                    
                    //display message if successful or not
                    string message = string.Empty;
                    switch (TaskId)
                    {
                        case -1:
                            message = "Task Name already exists.\\nPlease choose a different Task Name.";
                            break;
                        default:
                            message = "Save successful";
                            break;
                    }
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                }
            }
        }

        //date picker input
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTextBox.Text = Calendar1.SelectedDate.ToString();
        }
    }
}