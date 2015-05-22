<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="toolkit.aspx.cs" Inherits="Risk.toolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Création ou chargement d'une carte</title>
    <style type="text/css">

        .terrain { background-color:#BD8D46}
        .eau { background-color:#0000AA}
        
        .terrain,.eau {
            width:30px;
            height:30px;
            margin:auto;
            padding: 0 0 0 0;
        }

        table.jeu, table.jeu tr, table.jeu td {
              margin:auto;
            padding: 0 0 0 0;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:Label ID="Label_Horizontale" runat="server" Text="Horizontale"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox_x_max" runat="server" Text="5" MaxLength="2"></asp:TextBox> <br /><br />
        <asp:Label ID="Label_Verticale" runat="server" Text="Verticale"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox_y_max" runat="server" Text="5" MaxLength="2"></asp:TextBox> <br /><br />
        <asp:Button ID="Button_generer" runat="server" Text="Générer une carte vide" OnClick="Button_generer_Click" />

        <br />
        <br />

        <asp:Label ID="Label_Message_Monde" runat="server" Text=""></asp:Label>

        <br />

        <table class="jeu">
        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
        <ItemTemplate>
            <tr>
                <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="" CssClass='<%# DataBinder.Eval(Container.DataItem,"style_css")  %>' OnClick="Button1_Click" />
                    </td>
                </ItemTemplate>
                </asp:Repeater>
            </tr>
        </ItemTemplate>
        </asp:Repeater>
        </table>
    </div>
        <asp:TextBox ID="TextBox_nom_monde" runat="server" MaxLength="25"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button_enregistrer" runat="server" OnClick="Button_enregistrer_Click" Text="Enregistrer" />

        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel_liste_monde" runat="server">
            <ContentTemplate>
                <asp:ListBox ID="ListBox_monde_dispo" runat="server" Height="130px" Width="250px" BackColor="White"></asp:ListBox>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />

        <asp:Button ID="Button_ouvrir_monde" runat="server" Text="Ouvrir monde" Width="118px" OnClick="Button_ouvrir_monde_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button_lancer_partie" runat="server" Text="Lancer partie" />

        <script type="text/javascript">

        function on_refresh() {
            __doPostBack('<%= UpdatePanel_liste_monde.ClientID %>', '');
        }
        setInterval(on_refresh, 3000);
    </script>
    </form>
</body>
</html>
