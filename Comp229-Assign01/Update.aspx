<%@ Page Title="" Language="C#" MasterPageFile="~/Comp.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Comp229_Assign01.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
  <div class="about-content">
    <div class="container">
        <h1>Contact Us</h1>
         <div class="about-left-img"> <img src="images/index-2-341x624.png" class="img-responsive chef-img"/> </div>
        <div class="about-right-content">
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

         <asp:Button ID="btnupdate" runat="server" cssclass="btn btn-default-red about-btn-style" Text="Update" OnClick="btnupdate_Click"   />
              <asp:Button ID="btndelete" runat="server" cssclass="btn btn-default-red about-btn-style" Text="Delete" OnClick="btndelete_Click"   />
 <br />
           </div>
       
    </div>
  </div>
</section>
</asp:Content>
