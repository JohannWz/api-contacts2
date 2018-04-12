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
            Voici la liste de vos contacts :<br />
            <asp:GridView ID="gvContacts" runat="server" OnSelectedIndexChanged="gvContacts_SelectedIndexChanged">
                <Columns>
                    <asp:ButtonField Text="Afficher" />
                    <asp:ButtonField Text="Modifier" />
                    <asp:ButtonField Text="Supprimer" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
