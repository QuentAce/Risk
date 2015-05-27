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


    </div>

    <div id="pied">
        <asp:Button ID="But_fin_de_phase" runat="server" Text="Fin de phase" Width="150px" />
        <asp:Button ID="But_fin_de_tour" runat="server" Text="Fin de tour" Width="150px" />
    </div>
    </div>
    </form>
</body>
</html>
