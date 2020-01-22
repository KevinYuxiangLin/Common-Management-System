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
    //display detail tasks by user, update task progress by checked task id
    public partial class FullList : System.Web.UI.Page
    {
        static string strConnString = ConfigurationManager.ConnectionStrings["WebFormConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);

        SqlDataAdapter da;
        DataTable dt;

        string user_id;
        string taskid;

        //get the user id and load grid view with tasks
        protected void Page_Load(object sender, EventArgs e)
        {
            user_id = Request.QueryString["id"];

            if (!this.IsPostBack)
            {
                LoadFullList();
            }
        }

        //load all tasks by user with all columns into grid view
        public void LoadFullList()
        {
            con = new SqlConnection(strConnString);
            da = new SqlDataAdapter("Select * from View_all where UserId = " + user_id, con);
            dt = new DataTable();
            da.Fill(dt);
            FullListGridView.DataSource = dt;
            FullListGridView.DataBind();
        }

        //click "change progress" button action
        protected void btnChk_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in FullListGridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("CompleteCheck") as CheckBox);
                    if (chkRow.Checked)
                    {
                        //finding out which row has check box checked, get the taskId and call update method
                        taskid = row.Cells[1].Text;
                        UpdateCompletion(taskid);
                    }
                }
            }
        }

        //update task progress by taskId
        public void UpdateCompletion(string TaskId)
        {
            //call stored procedure
            SqlCommand cmd = new SqlCommand("Update_TaskProgress");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@TaskId", TaskId);
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            //refresh the grid view display after the update
            LoadFullList();
        }
    }
}