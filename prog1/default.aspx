 <%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="prog1._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:BasaDateConnectionString %>" 
        DeleteCommand="DELETE FROM [rashodi] WHERE [id] = @id" 
        InsertCommand="INSERT INTO [rashodi] ([id], [data], [summa], [kategory]) VALUES (@id, @data, @summa, @kategory)" 
        onselecting="SqlDataSource1_Selecting" SelectCommand="SELECT * FROM [rashodi]" 
        UpdateCommand="UPDATE [rashodi] SET [data] = @data, [summa] = @summa, [kategory] = @kategory WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="data" Type="DateTime" />
            <asp:Parameter Name="summa" Type="Double" />
            <asp:Parameter Name="kategory" Type="Byte" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="data" Type="DateTime" />
            <asp:Parameter Name="summa" Type="Double" />
            <asp:Parameter Name="kategory" Type="Byte" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</p>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:BasaDateConnectionString %>" 
        SelectCommand="SELECT * FROM [kategotys]"></asp:SqlDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        DataKeyNames="id" DataSourceID="rashodi" DefaultMode="Insert" 
        oniteminserted="DetailsView1_ItemInserted">
        <Fields>
            <asp:TemplateField HeaderText="Категория">
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="kategorys" 
                        DataTextField="name" DataValueField="id" SelectedValue='<%# Bind("answer1") %>' 
                        Width="300px">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" InsertText="Send" 
                ShowCancelButton="False" ShowInsertButton="True">
            <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
        </Fields>
    </asp:DetailsView>
</asp:Content>
