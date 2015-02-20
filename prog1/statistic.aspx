<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="statistic.aspx.cs" Inherits="prog1.statistic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="1">Сегодня</asp:ListItem>
        <asp:ListItem Value="2">Вчера</asp:ListItem>
        <asp:ListItem Value="3">Текущий месяц</asp:ListItem>
        <asp:ListItem Value="4">Предыдущий месяц</asp:ListItem>
        <asp:ListItem Value="5">Всё время</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Ответ" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="Ввод данных" />
&nbsp;&nbsp;
    <br />
    <br />
    <asp:ListBox ID="ListBox1" runat="server" Rows="6"></asp:ListBox>
</asp:Content>
