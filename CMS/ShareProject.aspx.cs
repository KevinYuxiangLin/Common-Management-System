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
    //display shared project grid view, share or undo share a project
    public partial class ShareProject : System.Web.UI.Page
    {
        string user_id;
        string project_id;

        static string strConnString = ConfigurationManager.ConnectionStrings["WebFormConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);

        SqlDataAdapter da, da1, da2;
        DataTable dt, dt1, dt2;

        protected void Page_Load(object sender, EventArgs e)
        {
            user_id = Request.QueryString["id"];

            //populate shared project grid view and project drop down, user drop down
            if (!IsPostBack)
            {
                LoadShared();

                LoadProject();

                da1 = new SqlDataAdapter("Select UserId, UserName from Users where UserId != " + user_id, con);
                dt1 = new DataTable();
                da1.Fill(dt1);
                UserDropDownList.DataSource = dt1;
                UserDropDownList.DataTextField = "UserName";
                UserDropDownList.DataValueField = "UserId";
                UserDropDownList.DataBind();
            }
        }

        //populate the grid view with shared project data by user id
        public void LoadShared()
        {
            con = new SqlConnection(strConnString);
            da2 = new SqlDataAdapter("Select ProjectId, ProjectName, OwnerName, SharedByUsers from View_SharedProjects_Users where UserId = " + user_id, con);
            dt2 = new DataTable();
            da2.Fill(dt2);
            SharedGridView.DataSource = dt2;
            SharedGridView.DataBind();
        }

        //populate the project drop down by user id
        public void LoadProject()
        {
            da = new SqlDataAdapter("Select p.ProjectId, ProjectName from Projects p inner join UserProject up on p.projectId = up.projectId where UserId = " + user_id, con);
            dt = new DataTable();
            da.Fill(dt);
            ProjectDropDownList.DataSource = dt;
            ProjectDropDownList.DataTextField = "ProjectName";
            ProjectDropDownList.DataValueField = "ProjectId";
            ProjectDropDownList.DataBind();
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        //call stored procedure to add new shared project
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            int insertId = 0;
            string constr = ConfigurationManager.ConnectionStrings["WebFormConnectionString"].ConnectionString;

            //if field not filled up, not proceeding
            if (UserDropDownList.SelectedValue == "" || ProjectDropDownList.SelectedValue == "")
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "All fields have to be filled up." + "');", true);
            }
            else
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("Insert_UserProject"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@UserId", UserDropDownList.SelectedValue);
                            cmd.Parameters.AddWithValue("@ProjectId", ProjectDropDownList.SelectedValue);
                            cmd.Connection = con;
                            con.Open();
                            insertId = Convert.ToInt32(cmd.ExecuteScalar());
                            con.Close();
                        }
                    }
                    //display message if successful or not
                    string message = string.Empty;
                    switch (insertId)
                    {
                        case -1:
                            message = "Project already shared.";
                            break;
                        default:
                            message = "Share successful";
                            break;
                    }
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                }
            }
 
            //refresh the shared project grid view
            LoadShared();
        }

        //get the project id by checked box, call method to remove share
        protected void btnChk_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in SharedGridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("CompleteCheck") as CheckBox);
                    if (chkRow.Checked)
                    {
                        project_id = row.Cells[1].Text;
                        RemoveShare(project_id);
                    }
                }
            }
        }

        //undo share for the checked project
        public void RemoveShare(string ProjectId)
        {
            int retId = 0;

            //call stored procedure to undo share
            SqlCommand cmd = new SqlCommand("Update_UserProject");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@UserId", user_id);
            using (con)
            {
                con.Open();
                retId = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

            }

            //display message if successful or not
            string message = string.Empty;
            switch (retId)
            {
                case -1:
                    message = "Undo share a project can only be done by project owner.";
                    break;
                default:
                    message = "Undo share successful";
                    break;
            }
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);

            //refresh the shared project grid view and project drop down
            LoadShared();
            LoadProject();
        }
    }
}