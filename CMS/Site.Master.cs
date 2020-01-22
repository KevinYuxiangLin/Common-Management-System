using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using CMS.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Principal;

namespace CMS
{
    //to get the user id, user name, project list
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        int user_id;

        static string strConnString = ConfigurationManager.ConnectionStrings["WebFormConnectionString"].ConnectionString;

        //property of User_Id
        public int User_Id
        {
            get
            {
                return user_id;
            }
        }
        //property of User_Name
        public string User_Name
        {
            get
            {
                return GetUser();
            }
        }
        //retrieve the user id from previous page passing
        protected void Page_Load(object sender, EventArgs e)
        {
             user_id = (int)(Session["UserId"]);
        }

        //retrieve user name by user id
        public string GetUser()
        {
            string user_name = "";
            string sql = "select UserName from Users where UserId = " + user_id;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                user_name = (string)cmd.ExecuteScalar();
            }
            return user_name;
        }
        
        //retrieve project list by user id using query
        public IQueryable<View_Projects> GetProjects()
        {
            var _db = new CMS.Models.Model1();
             
            var query = from project in _db.View_Projects
                        where project.UserId == user_id
                                select project;
            return query;
        }
    }
}
