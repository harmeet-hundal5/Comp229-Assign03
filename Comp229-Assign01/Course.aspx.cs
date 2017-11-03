using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Comp229_Assign01
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string Courseid="";
        string ty = "";
        protected void Page_Load(object sender, EventArgs e)
        {


            if(Session["Studentidr"]!=null)
            ty= Session["Studentidr"].ToString();
            Courseid = Request.QueryString["code"];
            if (string.IsNullOrEmpty(Page.Title))
            {

                if (Session["Studentidr"] != null &&Courseid!=null)
                {
                    if (!IsPostBack)
                    {
                        binddrpdownlist();
                      
                        Page.Title = ConfigurationManager.AppSettings["Resumepage"];  //title saved in web.config
                        var conn = ConfigurationManager.ConnectionStrings["Comp229Assign03ConnectionString"].ConnectionString;
                        SqlConnection s = new SqlConnection(conn);
                        s.Open();
                        SqlCommand sd = new SqlCommand("select Enrollments.EnrollmentID,  Courses.CourseID, Students.StudentID,Students.LastName,Students.FirstMidName,Courses.Title from students inner join  Enrollments on students.StudentID=Enrollments.StudentID inner join Courses on Enrollments.CourseID=Courses.CourseID where students.StudentID='" + ty + "' and Courses.CourseID='" + Courseid + "'", s);
                        SqlDataReader dr = sd.ExecuteReader();
                        while (dr.Read())
                        {
                            txtname.Text = dr["FirstMidName"].ToString();
                            txtlastname.Text = dr["LastName"].ToString();
                            string top = dr["Title"].ToString();
                            Session["enrollid"] = dr["EnrollmentID"].ToString();
                           drpdownlist.ClearSelection();
                            drpdownlist.Items.FindByValue(Courseid).Selected = true;
                        }

                    }

                }
                else
                {
                    lblname.Visible = false;
                    lbllastname.Visible = false;
                    btnsbmit.Visible = false;
                    txtlastname.Visible = false;
                    txtname.Visible = false;
                    lblCourse.Visible = false;
                    drpdownlist.Visible = false;
                    bindGridView();
                }

            }
        }

        protected void binddrpdownlist()
        {
            var conn = ConfigurationManager.ConnectionStrings["Comp229Assign03ConnectionString"].ConnectionString;
            SqlConnection s = new SqlConnection(conn);
            s.Open();
            SqlDataAdapter sd = new SqlDataAdapter("select CourseID,Title from Courses", s);
            DataSet df = new DataSet();
            sd.Fill(df);
            drpdownlist.DataSource = df;
            drpdownlist.DataBind();
            drpdownlist.DataTextField = "Title";
            drpdownlist.DataValueField = "CourseID";
            drpdownlist.DataBind();
            s.Close();

        }

        protected void grdviewstudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindGridView(); //bindgridview will get the data source and bind it again
        }
        protected void bindGridView()
        {
            var conn = ConfigurationManager.ConnectionStrings["Comp229Assign03ConnectionString"].ConnectionString;
            SqlConnection s = new SqlConnection(conn);
            s.Open();
            SqlDataAdapter sd = new SqlDataAdapter("select Enrollments.EnrollmentID, Courses.CourseID, Students.StudentID,Students.LastName as Lname,Students.FirstMidName As Name,Courses.Title from students inner join  Enrollments on students.StudentID=Enrollments.StudentID inner join Courses on Enrollments.CourseID=Courses.CourseID", s);
            DataSet df = new DataSet();
            sd.Fill(df);
            GridView1.DataSource = df;
            GridView1.DataBind();
            s.Close();

        }

        protected void btnsbmit_Click(object sender, EventArgs e)
        {
            var conn = ConfigurationManager.ConnectionStrings["Comp229Assign03ConnectionString"].ConnectionString;
            SqlConnection s = new SqlConnection(conn);
            s.Open();
            using (SqlCommand cmd = new SqlCommand("Student_CRUD"))
            {
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", ty);
                    cmd.Parameters.AddWithValue("@FirstMidName", txtname.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtlastname.Text);
                    cmd.Parameters.AddWithValue("@EnrollmentID", Session["enrollid"].ToString());

                    cmd.Parameters.AddWithValue("@CourseID", drpdownlist.SelectedValue);
                    cmd.Connection = s;
                    cmd.ExecuteNonQuery();
                    s.Close();
                    lblmsg.Text = "Record Updated Sucessfully";
                    Server.Transfer("default.aspx");
                }
            }
            
        }
  
    }
}