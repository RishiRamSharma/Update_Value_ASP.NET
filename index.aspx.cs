using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace teacher_project
{
    public partial class index : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["techKey"].ConnectionString;
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        protected void save_btn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert teacher_table values(@teachid,@teachname,@teachsub,@teachdept)";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@teachid", TextId.Text);
            cmd.Parameters.AddWithValue("@teachname", TextName.Text);
            cmd.Parameters.AddWithValue("@teachsub", TextSub.Text);
            cmd.Parameters.AddWithValue("@teachdept", TextDep.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            clear_refactor();
            display_refactor();

        }

        private void clear_refactor()
        {
            TextId.Text = string.Empty;
            TextName.Text = string.Empty;
            TextSub.Text = string.Empty;
            TextDep.Text = string.Empty;
            TextId.Focus();
        }

        protected void display_btn_Click(object sender, EventArgs e)
        {
            display_refactor();
        }

        private void display_refactor(){
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from teacher_table";
            cmd.Connection = conn;
            SqlDataReader teachReader;
            teachReader = cmd.ExecuteReader();
            ShowList.DataTextField = "TeacherName";
            ShowList.DataValueField = "TeacherID";
            ShowList.DataSource = teachReader;
            ShowList.DataBind();
            teachReader.Close();
            cmd.Dispose();
        }

        protected void ShowList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from teacher_table where TeacherID = @teachid";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@teachid", ShowList.SelectedValue);
            SqlDataReader teachReader = cmd.ExecuteReader();
            if (teachReader.HasRows)
            {
                teachReader.Read();
                TextId.Text = teachReader["TeacherID"].ToString();
                TextName.Text = teachReader["TeacherName"].ToString();
                TextSub.Text = teachReader["TeacherSubject"].ToString();
                TextDep.Text = teachReader["TeacherDept"].ToString();

            }
            teachReader.Close();
            cmd.Dispose();
        }

        protected void update_btn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update teacher_table set TeacherName=@teachname, TeacherSubject=@teachsub, TeacherDept=@teachdept where TeacherID=@teachid";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@teachid", TextId.Text);
            cmd.Parameters.AddWithValue("@teachname", TextName.Text);
            cmd.Parameters.AddWithValue("@teachsub", TextSub.Text);
            cmd.Parameters.AddWithValue("@teachdept", TextDep.Text);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            display_refactor();
            clear_refactor();
            
        }
    }
}