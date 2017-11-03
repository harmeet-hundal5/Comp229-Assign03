<%@ Page Title="" Language="C#" MasterPageFile="~/Comp.Master" AutoEventWireup="true" CodeBehind="Course.aspx.cs" Inherits="Comp229_Assign01.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="grey_background">
 <div class="container">
  <div class="Reservation_form_outer WhatWeDo-outer">
   <div class="Image_content">
   <img src="images/page-3_img01.jpg"/>
   </div>


   
    <div class="Right_content">
   <asp:GridView ID="grdviewstudent" runat="server"></asp:GridView>

                      <p>   <asp:Label ID="lblname" runat="server" Text="Enter Your First Name"></asp:Label>
             <asp:RequiredFieldValidator ID="reqtxtname" runat="server" ErrorMessage="*" ControlToValidate="txtname" ForeColor="Red" ></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="rwgname" runat="server"
                  ControlToValidate="txtname" ErrorMessage="Enter Valid name"
                  ValidationExpression="^([A-z][A-Za-z]*\s*[A-Za-z]*)$" ForeColor="Red"></asp:RegularExpressionValidator>                   
               <br />    <asp:TextBox ID="txtname" runat="server" ></asp:TextBox></p>
            <p><asp:Label ID="lbllastname" runat="server" Text="Enter Lastname"></asp:Label>
                  <asp:RequiredFieldValidator ID="reqtxtlastname" runat="server" ErrorMessage="*" ControlToValidate="txtlastname" ForeColor="Red" ></asp:RequiredFieldValidator>
                     <br />                      
                             <asp:TextBox ID="txtlastname" runat="server" ></asp:TextBox></p>
                    <p><asp:Label ID="lblCourse" runat="server" Text="Select Course"></asp:Label></p>
                     <br />                      
                 
            <asp:DropDownList ID="drpdownlist" runat="server" >
            </asp:DropDownList>
            <br />

         <asp:Button ID="btnsbmit" runat="server" cssclass="btn btn-default-red about-btn-style" Text="Update" OnClick="btnsbmit_Click"  />
 <br />
          
              
              <div id="ikli" runat="server">

                              
                 
         <asp:GridView ID="GridView1"    runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2"  >
             <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
             <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
             <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
             <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
             <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#FFF1D4" />
             <SortedAscendingHeaderStyle BackColor="#B95C30" />
             <SortedDescendingCellStyle BackColor="#F1E5CE" />
             <SortedDescendingHeaderStyle BackColor="#93451F" />
             <Columns>
                 <asp:BoundField DataField="CourseID" HeaderText="ID" Visible="false" />                 
                 <asp:BoundField DataField="StudentID" HeaderText="StudentID" Visible="false" ></asp:BoundField>
                 <asp:BoundField DataField="EnrollmentID" HeaderText="EnrollmentID" Visible="false"></asp:BoundField>
        <asp:HyperLinkField Text="Update" ItemStyle-HorizontalAlign="Center" DataNavigateUrlFields="CourseID,StudentID,EnrollmentID" DataNavigateUrlFormatString="Update.aspx?courseid={0}&studentId={1}&enrolmentid={2}" ></asp:HyperLinkField>
           <asp:HyperLinkField Text="delete" ItemStyle-HorizontalAlign="Center" DataNavigateUrlFields="CourseID,StudentID,EnrollmentID" DataNavigateUrlFormatString="Update.aspx?courseid={0}&studentId={1}&enentid={2}" ></asp:HyperLinkField>
        
                    </Columns>

<%--              <Columns>
              <asp:BoundField DataField="CourseID"  HtmlEncode="False" DataFormatString="<a  href='update.aspx?courseid={0}'>update course </a>" />
                
               <asp:BoundField DataField="StudentID"  HtmlEncode="False" DataFormatString="<a  href='update.aspx?Studentid={0}'>Remove Course</a>" />
                </Columns>--%>
               </asp:GridView>
            
          
      
         
                  
                  
              </div>
                <asp:Label ID="lblmsg" runat="server" ></asp:Label>
   
        

   
    </div>
  </div>
 </div>
</section>

</asp:Content>
