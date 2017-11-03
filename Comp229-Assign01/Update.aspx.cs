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
    
    public partial class WebForm3 : System.Web.UI.Page
    {
        string  courseid="";
           string  studentId="";
           string Enrollid = "";
         
           string enentid = "";

        protected void Page_Load(object sender, EventArgs e)
           {
               courseid = Request.QueryString["courseid"];
               studentId = Request.QueryString["studentId"];
               Enrollid = Request.QueryString["enrolmentid"];
               enentid = Request.QueryString["enentid"];
               if (!IsPostBack)
               {
                   binddrpdownlist();
                  
                   if (string.IsNullOrEmpty(Page.Title))
                   {
                       Page.Title = ConfigurationManager.AppSettings["contactpage"];  //title saved in web.config
                   }
                   if (Request.QueryString["courseid"] != null && Request.QueryString["studentId"] != null && Request.QueryString["enrolmentid"] != null)
                   {

                       var conn = ConfigurationManager.ConnectionStrings["Comp229Assign03ConnectionString"].ConnectionString;
                       SqlConnection s = new SqlConnection(conn);
                       s.Open();
                       SqlCommand sd = new SqlCommand("select Enrollments.EnrollmentID,  Courses.CourseID, Students.StudentID,Students.LastName,Students.FirstMidName,Courses.Title from students inner join  Enrollments on students.StudentID=Enrollments.StudentID inner join Courses on Enrollments.CourseID=Courses.CourseID where students.StudentID='" + studentId + "' and Courses.CourseID='" + courseid + "'", s);
                       SqlDataReader dr = sd.ExecuteReader();
                       while (dr.Read())
                       {
                           txtname.Text = dr["FirstMidName"].ToString();
                           txtlastname.Text = dr["LastName"].ToString();
                           string top = dr["Title"].ToString();
                           Session["enrollid"] = dr["EnrollmentID"].ToString();
                           drpdownlist.ClearSelection();
                           drpdownlist.Items.FindByValue(courseid).Selected = true;
                           btndelete.Visible = false;
                           btnupdate.Visible = true;
                       }
                   }
                   else if (Request.QueryString["studentId"] != null && Request.QueryString["courseid"] != null && Request.QueryString["enentid"] != null)
                   {
                       var conn = ConfigurationManager.ConnectionStrings["Comp229Assign03ConnectionString"].ConnectionString;
                       SqlConnection s = new SqlConnection(conn);
                       s.Open();
                       SqlCommand sd = new SqlCommand("select Enrollments.EnrollmentID,  Courses.CourseID, Students.StudentID,Students.LastName,Students.FirstMidName,Courses.Title from students inner join  Enrollments on students.StudentID=Enrollments.StudentID inner join Courses on Enrollments.CourseID=Courses.CourseID where students.StudentID='" + studentId + "' and Courses.CourseID='" + courseid + "'", s);
                       SqlDataReader dr = sd.ExecuteReader();
                       while (dr.Read())
                       {
                           txtname.Text = dr["FirstMidName"].ToString();
                           txtlastname.Text = dr["LastName"].ToString();
                           string top = dr["Title"].ToString();
                           Session["enrollid"] = dr["EnrollmentID"].ToString();
                           drpdownlist.ClearSelection();
                           drpdownlist.Items.FindByValue(courseid).Selected = true;
                           drpdownlist.Enabled = false;
                           btndelete.Visible = true;
                           btnupdate.Visible = false;
                       }
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
        protected void contact_button_Click(object sender, EventArgs e)
        {

           
           // contactMessage.Text = contactEmail.Text = contactName.Text = "";
            //Response.Redirect("default.aspx");
        }

        protected void btnupdate_Click(object sender, EventArgs e)
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
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@FirstMidName", txtname.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtlastname.Text);
                    cmd.Parameters.AddWithValue("@EnrollmentID", Enrollid);
                     cmd.Parameters.AddWithValue("@CourseID", drpdownlist.SelectedValue);
                    cmd.Connection = s;
                    s.Open();
                    cmd.ExecuteNonQuery();
                    s.Close();
                  
                    Server.Transfer("Course.aspx");
                }
            }
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            var conn = ConfigurationManager.ConnectionStrings["Comp229Assign03ConnectionString"].ConnectionString;
            SqlConnection s = new SqlConnection(conn);
            s.Open();
            using (SqlCommand cmd = new SqlCommand("Student_CRUD"))
            {
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", studentId);
                    cmd.Parameters.AddWithValue("@FirstMidName", txtname.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtlastname.Text);
                    cmd.Parameters.AddWithValue("@EnrollmentID", enentid);
                    cmd.Parameters.AddWithValue("@CourseID", drpdownlist.SelectedValue);
                    cmd.Connection = s;
                    s.Open();
                    cmd.ExecuteNonQuery();
                    s.Close();

                    Server.Transfer("Course.aspx");
                }
            }
        }
    }
}