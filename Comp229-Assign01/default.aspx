<%@ Page Title="" Language="C#" MasterPageFile="~/Comp.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Comp229_Assign01.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
  <div class="about-content">
    <div class="container">
        <h1>About Us</h1>
         <div class="about-left-img"> <img src="images/index-2-341x624.png" class="img-responsive chef-img"/> </div>
        <div class="about-right-content">
                
                
                
             <p>   I'm Harmeet Hundal
            I'm a Manila based <span>graphic designer</span>, <span>illustrator</span> and <span>webdesigner</span> creating awesome and
            effective visual identities for companies of all sizes around the globe.
  </p>
        
            <asp:GridView ID="grdviewstudent"  runat="server" OnPageIndexChanging="grdviewstudent_PageIndexChanging" AllowPaging="True" PageSize="5" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" >

          <Columns>
           

        <asp:BoundField DataField="StudentID" HtmlEncode="False" DataFormatString="<a href='Student.aspx?code={0}'>Click</a>" />
 
        
        </Columns>

                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />

            </asp:GridView>
<br />

            <h2>Add Student</h2>
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

            <asp:Button ID="btnsbmit" runat="server" cssclass="btn btn-default-red about-btn-style" Text="Submit" OnClick="btnsbmit_Click"  />
 <br />
           <%-- <a href="Surveypage.aspx" class="btn btn-default-red about-btn-style"> Add New Student</a>--%>
              <p>   <asp:Label ID="lblmsg" runat="server" ></asp:Label></p>
        </div>
        </div>
      </div>
    </section>
</asp:Content>
