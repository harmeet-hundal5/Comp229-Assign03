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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Page.Title))
            {
                Page.Title = ConfigurationManager.AppSettings["DefaultTitle"];  //title saved in web.config
            }

            bindGridView();
            binddrpdownlist();
            }


     
 
        protected void grdviewstudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdviewstudent.PageIndex = e.NewPageIndex;
            bindGridView(); //bindgridview will get the data source and bind it again
        }
        protected void bindGridView()
        {
           // SqlConnection s = new SqlConnection("Data Source=.;Initial Catalog=Comp229Assign03;Integrated Security=True");
            var  conn = ConfigurationManager.ConnectionStrings["Comp229Assign03ConnectionString"].ConnectionString;
            SqlConnection s = new SqlConnection(conn);
            s.Open();
            SqlDataAdapter sd = new SqlDataAdapter("select StudentID,FirstMidName,LastName from Students", s);
            DataSet df = new DataSet();
            sd.Fill(df);

          
            grdviewstudent.DataSource = df;
            grdviewstudent.DataBind();
            s.Close();
        
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
        protected void btnsbmit_Click(object sender, EventArgs e)
        {
            string id = "0";
            var conn = ConfigurationManager.ConnectionStrings["Comp229Assign03ConnectionString"].ConnectionString;
            SqlConnection s = new SqlConnection(conn);
            s.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "addstudent";
                cmd.Parameters.Add("@FirstMidName", SqlDbType.VarChar).Value = txtname.Text.Trim();
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtlastname.Text.Trim();
                cmd.Parameters.Add("@EnrollmentDate", SqlDbType.DateTime).Value = DateTime.Now.ToShortDateString();
               cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Connection = s;
                try
                {
                  
                    cmd.ExecuteNonQuery();
                    id = cmd.Parameters["@id"].Value.ToString();
                    lblmsg.Text = "Record inserted successfully. ID = " + id;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
          
            
                txtname.Text = "";
                txtlastname.Text = "";

                SqlCommand sden = new SqlCommand("insert into Enrollments values('" + drpdownlist.SelectedValue + "','" + id + "','" +10 + "')", s);
                sden.ExecuteNonQuery();
                lblmsg.Text = "Record inserted Sucessfully";
            
           
        }
  
    }
}