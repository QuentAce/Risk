<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Risk._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Accueil</h1>
        <h2>Authentification</h2>
        <asp:Label ID="Label_message" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="TextBox_login" runat="server"></asp:TextBox><br />
        <asp:TextBox ID="TextBox_mdp" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:Button ID="Button_ok" runat="server" Text="OK" OnClick="Button_ok_Click" /><br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/inscription.aspx">Inscription</asp:HyperLink><br />
    </div>
    </form>
</body>
</html>
