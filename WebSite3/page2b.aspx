<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="page2b.aspx.cs" Inherits="page2b" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
      td:nth-child(odd){
          text-align:right;
      }
  </style> 
    <article>
        <asp:Table ID="formTable" runat="server">
        
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblSearchRecipeName" class="required" runat="server" Text="Name:" ></asp:Label></asp:TableCell>
       <asp:TableCell> <asp:TextBox ID="userRecipeName" runat="server"></asp:TextBox>
      <!-- <asp:RequiredFieldValidator id="rqdSearchRecipeName" ControlToValidate="userRecipeName" runat="server" ErrorMessage="Please Enter the Name of the recipe"></asp:RequiredFieldValidator>-->
        </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblSelectedCategory" runat="server"  Text="Category:"></asp:Label></asp:TableCell>
        <asp:TableCell><asp:DropDownList ID="categoryList" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>Bread</asp:ListItem>
            <asp:ListItem>Cake</asp:ListItem>
            <asp:ListItem>Pie</asp:ListItem>
            <asp:ListItem>Cookies</asp:ListItem>
            <asp:ListItem>Cupcakes</asp:ListItem>
           
        </asp:DropDownList>

        </asp:TableCell>
 
        </asp:TableRow>
       
            
        
        </asp:Table>
    
    <!--</form>-->
   <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click"  />
    <br />
<br />
<asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
 </article>
</asp:Content>

