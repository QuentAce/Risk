﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="partie.aspx.cs" Inherits="Risk.Partie1" %>

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
    <div id="panel">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel_Partie" runat="server">
            <ContentTemplate>
                <table border="1">
                    <tr>
                        <td id="info_partie">
                            <asp:Label ID="Label_nom_monde_fixe" runat="server" Text="Nom du Monde : "></asp:Label>
                            <asp:Label ID="Label_nom_monde" runat="server" Text=""></asp:Label> <br />
                            <asp:Label ID="Label_num_tour_fixe" runat="server" Text="Tour n° : "></asp:Label>
                            <asp:Label ID="Label_num_tour" runat="server" Text=""></asp:Label> <br />
                            <asp:Label ID="Label_joueur_fixe" runat="server" Text="Joueur : "></asp:Label>
                            <asp:Label ID="Label_joueur" runat="server" Text=""></asp:Label> <br />
                            <asp:Label ID="Label_phase_fixe" runat="server" Text="Phase : "></asp:Label>
                            <asp:Label ID="Label_phase" runat="server" Text=""></asp:Label> <br />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div id="corps">

        <table class="jeu">
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <tr>
                <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="" CssClass='<%# DataBinder.Eval(Container.DataItem,"style_css")  %>' />
                    </td>
                </ItemTemplate>
                </asp:Repeater>
            </tr>
        </ItemTemplate>
        </asp:Repeater>
        </table>

    </div>

    <div id="pied">
        <asp:Button ID="But_fin_de_phase" runat="server" Text="Fin de phase" Width="150px" />
        <asp:Button ID="But_fin_de_tour" runat="server" Text="Fin de tour" Width="150px" OnClick="But_fin_de_tour_Click" />
    </div>
    </div>
    </form>
</body>
</html>
