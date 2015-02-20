 <%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="prog1._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:BasaDateConnectionString2 %>" 
    SelectCommand="SELECT * FROM [kategorys]" 
        onselecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
    Дата:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
    Сумма:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server" style="margin-left: 0px"></asp:TextBox>
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <br />
    Критерий:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="DropDownList1" runat="server" 
    DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="id">
</asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Ввод" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        style="margin-bottom: 0px" Text="Отчет" />
    <br />
    <br />
    <asp:ListBox ID="ListBox1" runat="server" Font-Bold="False" Font-Italic="False" 
        Font-Overline="False" Font-Underline="False" Rows="30" Width="695px"></asp:ListBox>
    <br />
</asp:Content>
