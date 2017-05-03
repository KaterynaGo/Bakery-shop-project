<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="page3b.aspx.cs" Inherits="page3b" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <article>
    <asp:GridView ID="GridView1" runat="server"  OnRowCommand="GridView1_RowCommand" >
        <Columns>
<asp:TemplateField>
<HeaderTemplate> My Action
</HeaderTemplate>
<ItemTemplate> 
<asp:Button ID="addbtn" runat="server" text="Add"  CommandArgument='<%#Eval("productname")%>' CausesValidation="True" UseSubmitBehavior="False"/>
</ItemTemplate>
</asp:TemplateField>
            </Columns>
    </asp:GridView>
        <br />
        <asp:Label ID="lblSales" runat="server" Text="Christmas Sales" Font-Size="XX-Large"></asp:Label>
        <br />
        <p>&nbsp;</p>
        <asp:Label ID="Label1" runat="server" Text="Please input the price of your item:"></asp:Label>
        <asp:TextBox ID="txtItemPrice" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Culculate" OnClick="Button1_Click" />
        <asp:Label ID="lblNewPrice" runat="server" Text="Label"></asp:Label>
        </article>
</asp:Content>

