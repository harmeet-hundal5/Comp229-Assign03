<%@ Page Title="" Language="C#" MasterPageFile="~/Comp.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Comp229_Assign01.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
  <div class="about-content">
    <div class="container">
        <h1>Student Info </h1>
         <div class="about-left-img"> <img src="images/index-2-341x624.png" class="img-responsive chef-img"/> </div>
        <div class="about-right-content">
          
             <asp:GridView ID="grdviewstudent"  runat="server" >

          <Columns>
           
             
        <asp:BoundField DataField="CourseID"  HtmlEncode="False" DataFormatString="<a  href='Course.aspx?code={0}'>Change Course</a>" />
 
        
        </Columns>

            </asp:GridView>
            
   

        </div>
        </div>
      </div>
    </section>
</asp:Content>
