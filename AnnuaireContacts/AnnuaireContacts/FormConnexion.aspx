<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormConnexion.aspx.cs" Inherits="AnnuaireContacts.FormConnexion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Connectez-vous à votre annuaire de contacts :<br />
            Email :
            <asp:TextBox ID="tbEmail" runat="server">johann.witz@viacesi.fr</asp:TextBox>
            <br />
            Mot de passe :
            <asp:TextBox ID="tbMdp" runat="server">test</asp:TextBox>
            <br />
            <asp:Button ID="tbEnvoyer" runat="server" OnClick="tbEnvoyer_Click" Text="Valider" />
        </div>
    </form>
</body>
</html>
