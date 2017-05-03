<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="customerOrder.aspx.cs" Inherits="customerOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
      td:nth-child(odd){
          text-align:right;
      }
  </style> 
       <article>
     <h2>Please add your recipe here</h2>
        <asp:Table ID="formTable" runat="server">
        
        <asp:TableRow runat="server">
            <asp:TableCell><asp:Label ID="lblRecipe" class="required"  runat="server" Text="Order Name:" ></asp:Label></asp:TableCell>
       <asp:TableCell runat="server"> <asp:TextBox ID="userOrderName" runat="server"></asp:TextBox>
           <asp:RequiredFieldValidator id="rqdRecipeName" ControlToValidate="userOrderName" runat="server" ErrorMessage="Please Enter the name of your order"></asp:RequiredFieldValidator>
       </asp:TableCell>
        
        </asp:TableRow>
        <asp:TableRow runat="server">
            <asp:TableCell><asp:Label ID="lblCategory" class="required" runat="server"  Text=" Category:"></asp:Label></asp:TableCell>
        <asp:TableCell runat="server"><asp:DropDownList ID="categoryList" runat="server">
                       <asp:ListItem></asp:ListItem>
            <asp:ListItem>Bread</asp:ListItem>
            <asp:ListItem>Cake</asp:ListItem>
            <asp:ListItem>Pie</asp:ListItem>
            <asp:ListItem>Cookies</asp:ListItem>
            <asp:ListItem>Cupcakes</asp:ListItem>
        </asp:DropDownList>
            <asp:RequiredFieldValidator id="rqdCategoryList"  ControlToValidate="categoryList" runat="server" ErrorMessage="Please choose a category"></asp:RequiredFieldValidator>
        </asp:TableCell>
      </asp:TableRow>
        
            
            <asp:TableRow runat="server">
        <asp:TableCell><asp:Label ID="lblDescription" runat="server" Text="Recipe Description:" ></asp:Label></asp:TableCell>
        <asp:TableCell runat="server"><asp:TextBox ID="orderDescription" runat="server" Height="150px" Width="350px" ></asp:TextBox></asp:TableCell>
        
                </asp:TableRow>
        
        </asp:Table>

    
     <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click"/>
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
           <br />
    <br />
           </article>
</asp:Content>

