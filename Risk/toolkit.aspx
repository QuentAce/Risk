<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="toolkit.aspx.cs" Inherits="Risk.toolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

        .terrain { background-color:#BD8D46}
        .eau { background-color:#0000AA}
        
        .terrain,.eau {
            width:30px;
            height:30px;
            margin:0 0 0 0;
            padding: 0 0 0 0;

        }

        table.jeu, table.jeu tr, table.jeu td {
              margin:0 0 0 0;
            padding: 0 0 0 0;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox_x_max" runat="server" Text="5"></asp:TextBox>
        <asp:TextBox ID="TextBox_y_max" runat="server" Text="4"></asp:TextBox>
        <asp:Button ID="Button_generer" runat="server" Text="Générer une carte vide" OnClick="Button_generer_Click" />

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
        <asp:Button ID="Button_enregistrer" runat="server" OnClick="Button_enregistrer_Click" Text="Enregistrer" />

        <asp:Button ID="Button_ouvrir_monde" runat="server" Text="Ouvrir monde" Width="118px" OnClick="Button_ouvrir_monde_Click" />
    </form>
</body>
</html>
