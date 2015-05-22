<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="risk_accueil.aspx.cs" Inherits="Risk.risk_accueil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Risk</h1>
        <asp:Label ID="Label_accueil" runat="server" Text=""></asp:Label>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:Panel ID="Panel_pseudo" runat="server">
            <asp:Label ID="Label_pseudo" runat="server" Text="Pseudo : "></asp:Label>
            <asp:TextBox ID="TextBox_pseudo" runat="server"></asp:TextBox><asp:Button ID="Button_valider_pseudo" runat="server" Text="Valider" OnClick="Button_valider_pseudo_Click" /><br />
        </asp:Panel>
        <br />
        <asp:Label ID="Label_message" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label_liste_partie" runat="server" Text="Liste des parties"></asp:Label><br />
        <br />

        <asp:UpdatePanel ID="UpdatePanel_liste_partie" runat="server">
            <ContentTemplate>
            <asp:ListBox ID="ListBox_Partie" runat="server" Height="137px" Width="213px"></asp:ListBox><br />
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:Button ID="Button_rejoindre_partie" runat="server" Text="Rejoindre" /><br />
        <br />
        <br />
        <asp:Button ID="Button_creer_partie" runat="server" Text="Créer" OnClick="Button_creer_partie_Click" /><br />

        <script type="text/javascript">
            function refresh() {
                __doPostBack('<%= UpdatePanel_liste_partie.ClientID %>','')
            }
            setInterval(refresh, 5000);

        </script>



    </div>
    </form>
</body>
</html>
