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
    public partial class WebForm4 : System.Web.UI.Page
    {
        string StudentiD = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Page.Title))
            {
               
                Page.Title = ConfigurationManager.AppSettings["SurveyTitle"];  //title saved in web.config
                StudentiD = Request.QueryString["code"];
                Session["Studentidr"] = Request.QueryString["code"];
                if (!IsPostBack)
                {
                    SqlConnection s = new SqlConnection("Data Source=.;Initial Catalog=Comp229Assign03;Integrated Security=True");
                    s.Open();
                    SqlCommand sd = new SqlCommand("select Courses.CourseID, Students.StudentID,Students.LastName,Students.FirstMidName,Courses.Title,Enrollments.EnrollmentID from students inner join  Enrollments on students.StudentID=Enrollments.StudentID inner join Courses on Enrollments.CourseID=Courses.CourseID where students.StudentID='" + StudentiD + "'", s);
                    SqlDataReader dr = sd.ExecuteReader();
                        grdviewstudent.DataSource = dr;
                        grdviewstudent.DataBind();
                


                  
                }
            }
        }

     

       
    }
}