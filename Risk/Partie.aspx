<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="partie.aspx.cs" Inherits="Risk.Partie1" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Partie</title>

    <style type="text/css">

        table {
            margin:auto;
            padding:0 0 0 0;
        }
        #info_partie {
            font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
        }
        div {
            margin:auto;
            text-align:center;
            padding: 0 0 0 0;
        }
        .terrain { background-color:#BD8D46}
        .eau { background-color:#000}
        .j1 { background-color :#FFFF00}
        .j2 {background-color :#FF3399}
        
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
        <div id="panel">
        
            <asp:UpdatePanel ID="UpdatePanel_Partie" runat="server">
                <ContentTemplate>
                    <table border="1">
                        <tr>
                            <td id="info_partie" width="300px" height="100px">
                                <asp:Label ID="Label_nom_monde_fixe" runat="server" Text="Nom du Monde : "></asp:Label>
                                <asp:Label ID="Label_nom_monde" runat="server" Text=""></asp:Label> <br />
                                <asp:Label ID="Label_joueur_fixe" runat="server" Text="Joueur : "></asp:Label>
                                <asp:Label ID="Label_joueur" runat="server" Text=""></asp:Label> <br />
                                <asp:Label ID="Label_phase_fixe" runat="server" Text="Phase : "></asp:Label>
                                <asp:Label ID="Label_phase" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="espace_1">
            <table>
                <td height="40px"></td>
            </table>
        </div>
        <div id="corps">

            <table class="jeu">
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
            <ItemTemplate>
                <tr>
                    <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="2" CssClass='<%# DataBinder.Eval(Container.DataItem,"style_css")  %>' OnClick="Button1_Click" />
                        </td>
                    </ItemTemplate>
                    </asp:Repeater>
                </tr>
            </ItemTemplate>
            </asp:Repeater>
            </table>

        </div>

        <div id="espace_2">
            <table>
                <td height="40px"></td>
            </table>
        </div>

        <div id="pied">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="But_fin_de_phase" runat="server" Text="Fin de phase" Width="150px" OnClick="But_fin_de_phase_Click" />
                    <asp:Label ID="Label_attente" runat="server" Text="En attente de la fin de tour de votre adversaire !"></asp:Label>
                    <asp:Button ID="But_fin_de_tour" runat="server" Text="Fin de tour" Width="150px" OnClick="But_fin_de_tour_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
