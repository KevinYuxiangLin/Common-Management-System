using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS
{
    //display nested grid view for task list, task 
    //edit, delete function for task list and task records
    public partial class TaskList : System.Web.UI.Page
    {
        static string strConnString = ConfigurationManager.ConnectionStrings["WebFormConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);

        SqlDataAdapter da;
        DataTable dt, dt1;

        static string projectId;
        int user_id;

        public int User_Id
        {
            get
            {
                return user_id;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //user id and project id 
            projectId = Request.QueryString["projectid"];
            user_id = Convert.ToInt16(Request.QueryString["userid"]);

            //populate task list grid view
            if (!IsPostBack)
            {
                LoadgvTaskList();
            }
        }

        //within task list row, populate task grid view and button operation
        protected void gvTaskList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.ToString() != "Edit" && e.CommandName.ToString() != "Delete" && e.CommandName.ToString() != "Cancel" && e.CommandName.ToString() != "Update")
            {
                int ListId = int.Parse(e.CommandName.ToString());
                int rowindex = int.Parse(e.CommandArgument.ToString());
                GridView gvTask = (GridView)gvTaskList.Rows[rowindex].FindControl("gvTasks");
                Button btn = ((Button)gvTaskList.Rows[rowindex].FindControl("Button1"));
                if (btn.Text == "Open Task")
                {
                    btn.Text = "Cancel";
                    gvTask.DataSource = LoadgvTask(ListId);
                    gvTask.DataBind();
                    gvTask.Visible = true;
                }
                else
                {
                    btn.Text = "Open Task";
                    gvTask.Visible = false;
                }
            }
        }

        //populate task list grid view by project id
        public void LoadgvTaskList()
        {
            SqlConnection con = new SqlConnection(strConnString);
            da = new SqlDataAdapter("Select * from TaskList where ProjectId = " + projectId, con);
            dt = new DataTable();
            da.Fill(dt);
            gvTaskList.DataSource = dt;
            gvTaskList.DataBind();
        }

        //populate task grid view by tasklist id
        protected DataTable LoadgvTask(int TaskListId)
        {
            SqlConnection con = new SqlConnection(strConnString);
            da = new SqlDataAdapter("select * from view_all where TaskListId=" + TaskListId + " and UserId = " + user_id, con);
            dt1 = new DataTable();
            da.Fill(dt1);
            return dt1;
        }

        //task grid view operation when click "edit"
        protected void gvTasks_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView Gv = (GridView)sender;
            GridViewRow gvrow = (GridViewRow)Gv.Parent.Parent;
            int ListId = int.Parse(gvTaskList.DataKeys[gvrow.RowIndex].Value.ToString());
            Gv.EditIndex = e.NewEditIndex;

            //refresh task grid view
            Gv.DataSource = LoadgvTask(ListId);
            Gv.DataBind();
        }

        //task grid view operation when click "cancel"
        protected void gvTasks_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView Gv = (GridView)sender;
            GridViewRow gvrow = (GridViewRow)Gv.Parent.Parent;
            int ListId = int.Parse(gvTaskList.DataKeys[gvrow.RowIndex].Value.ToString());
            Gv.EditIndex = -1;

            //refresh task grid view
            Gv.DataSource = LoadgvTask(ListId);
            Gv.DataBind();
        }

        //update task
        protected void gvTasks_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridView Gv = (GridView)sender;
            GridViewRow gvrow = (GridViewRow)Gv.Parent.Parent;
            int ListId = int.Parse(gvTaskList.DataKeys[gvrow.RowIndex].Value.ToString());
            int TaskId = int.Parse(Gv.DataKeys[e.RowIndex].Value.ToString());
            string Name = ((TextBox)(Gv.Rows[e.RowIndex].FindControl("TextBox4"))).Text.Trim();
            string Priority = ((TextBox)(Gv.Rows[e.RowIndex].FindControl("TextBox5"))).Text.Trim();
            string DueDate = ((TextBox)(Gv.Rows[e.RowIndex].FindControl("TextBox6"))).Text.Trim();

            //call stored procedure to update task
            SqlCommand cmd = new SqlCommand("Update_Task");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@TaskName", Name);
            cmd.Parameters.AddWithValue("@DueDate", DueDate);
            cmd.Parameters.AddWithValue("@Priority", Priority);
            cmd.Parameters.AddWithValue("@TaskId", TaskId);
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }

            //refresh task grid view
            Gv.EditIndex = -1;
            Gv.DataSource = LoadgvTask(ListId);
            Gv.DataBind();
        }

        //delete task
        protected void gvTasks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView Gv = (GridView)sender;
            GridViewRow gvrow = (GridViewRow)Gv.Parent.Parent;
            int ListId = int.Parse(gvTaskList.DataKeys[gvrow.RowIndex].Value.ToString());
            int TaskId = int.Parse(Gv.DataKeys[e.RowIndex].Value.ToString());

            //call stored procedure to delete task
            SqlCommand cmd = new SqlCommand("Delete_Task");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@TaskId", TaskId);
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
 
            //refresh task grid view
            Gv.EditIndex = -1;
            Gv.DataSource = LoadgvTask(ListId);
            Gv.DataBind();
        }

        //task lise grid view operation when click "edit"
        protected void gvTaskList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTaskList.EditIndex = e.NewEditIndex;
            LoadgvTaskList();
        }

        //no action except refresh task list grid view
        protected void gvTaskList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTaskList.EditIndex = -1;

            LoadgvTaskList();
        }

        //update task list
        protected void gvTaskList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Get the TaskListID and name of the selected row. 
            string strTaskListID = gvTaskList.DataKeys[e.RowIndex].Value.ToString();
            string strTaskListName = ((TextBox)gvTaskList.Rows[e.RowIndex].FindControl("TextBox2")).Text;

            da = new SqlDataAdapter("UPDATE TaskList SET TaskListName ='" + strTaskListName + "' where TaskListId=" + strTaskListID, con);
            dt1 = new DataTable();
            da.Fill(dt1);

            //refresh task list grid view
            gvTaskList.EditIndex = -1;
            LoadgvTaskList();
        }

        //delete task list
        protected void gvTaskList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int deleted = 0;
            string strTaskListID = gvTaskList.DataKeys[e.RowIndex].Value.ToString();

            SqlCommand cmd = new SqlCommand("Delete_TaskList");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@TaskListId", strTaskListID);
            using (con)
            {
                con.Open();
                deleted = Convert.ToInt32(cmd.ExecuteScalar()); 
            }
            //display message if successful or not
            string message = string.Empty;
            switch (deleted)
            {
                case -1:
                    message = "Task exists under the list.\\nPlease delete task first.";
                    break;
                default:
                    message = "Delete successful";
                    break;
            }
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);

            //refresh task list grid view
            gvTaskList.EditIndex = -1;
            LoadgvTaskList();
        }
    }
}