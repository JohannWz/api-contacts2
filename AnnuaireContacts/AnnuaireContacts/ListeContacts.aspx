<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListeContacts.aspx.cs" Inherits="AnnuaireContacts.ListeContacts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Voici la liste de vos contacts :<asp:GridView ID="gvListeContacts" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceContacts" DataKeyNames="auto_id" OnRowDeleted="gvListeContacts_deleted" OnRowUpdated="gvListeContacts_updated">
                <Columns>
                    <asp:BoundField DataField="auto_id" HeaderText="auto_id" InsertVisible="False" ReadOnly="True" SortExpression="auto_id" />
                    <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                    <asp:BoundField DataField="first_name" HeaderText="first_name" SortExpression="first_name" />
                    <asp:BoundField DataField="last_name" HeaderText="last_name" SortExpression="last_name" />
                    <asp:BoundField DataField="favorite" HeaderText="favorite" SortExpression="favorite" />
                    <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                    <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:SqlDataSource ID="SqlDataSourceContacts" runat="server" ConnectionString="<%$ ConnectionStrings:AnnuaireContactsConnectionString %>" SelectCommand="SELECT [auto_id], [id], [first_name], [last_name], [favorite], [email], [phone] FROM [Contacts] WHERE ([user_id] = @user_id) ORDER BY [favorite] DESC, [last_name]" DeleteCommand="DELETE FROM [Contacts] WHERE [auto_id] = @auto_id" InsertCommand="INSERT INTO [Contacts] ([id], [first_name], [last_name], [favorite], [email], [phone]) VALUES (@id, @first_name, @last_name, @favorite, @email, @phone)" UpdateCommand="UPDATE [Contacts] SET [id] = @id, [first_name] = @first_name, [last_name] = @last_name, [favorite] = @favorite, [email] = @email, [phone] = @phone WHERE [auto_id] = @auto_id">
                <DeleteParameters>
                    <asp:Parameter Name="auto_id" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                    <asp:Parameter Name="first_name" Type="String" />
                    <asp:Parameter Name="last_name" Type="String" />
                    <asp:Parameter Name="favorite" Type="Byte" />
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="phone" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:Parameter Name="user_id" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="id" Type="Int32" />
                    <asp:Parameter Name="first_name" Type="String" />
                    <asp:Parameter Name="last_name" Type="String" />
                    <asp:Parameter Name="favorite" Type="Byte" />
                    <asp:Parameter Name="email" Type="String" />
                    <asp:Parameter Name="phone" Type="String" />
                    <asp:Parameter Name="auto_id" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
