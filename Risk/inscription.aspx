<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inscription.aspx.cs" Inherits="Risk.inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Inscription</h1>
        <asp:Label ID="Label_message" runat="server" Text=""></asp:Label>

        <asp:Panel ID="Panel_inscription" runat="server">

    <table>
            <tr>
                <td><asp:Label ID="Label_Login" runat="server" Text="Login"></asp:Label></td>
                <td><asp:TextBox ID="TextBox_Login" runat="server" MaxLength="20"></asp:TextBox></td>
             </tr>
            <tr>
                <td><asp:Label ID="Label_mdp" runat="server" Text="Mot de passe"></asp:Label></td>
                <td><asp:TextBox ID="TextBox_mdp" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label_confirmer_mdp" runat="server" Text="Confirmer Mdp"></asp:Label></td>
                <td><asp:TextBox ID="TextBox_mdp_confirm" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label_nom" runat="server" Text="Nom"></asp:Label></td>
                <td><asp:TextBox ID="TextBox_nom" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label_prenom" runat="server" Text="Prénom"></asp:Label></td>
                <td><asp:TextBox ID="TextBox_prenom" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="Button_inscription" runat="server" Text="Valider" OnClick="Button_inscription_Click" /></td>
            </tr>
        </table>
            </asp:Panel>
    </div>
        <div id="mon_javascript" runat="server"></div>
    </form>
</body>
</html>
