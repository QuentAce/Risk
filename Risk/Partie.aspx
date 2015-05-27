<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="partie.aspx.cs" Inherits="Risk.Partie1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table class="jeu">
        <asp:Repeater ID="Repeater1" runat="server" >
        <ItemTemplate>
            <tr>
                <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="" CssClass='<%# DataBinder.Eval(Container.DataItem,"style_css")  %>'  />
                    </td>
                </ItemTemplate>
                </asp:Repeater>
            </tr>
        </ItemTemplate>
        </asp:Repeater>
        </table>

    </div>
    </form>
</body>
</html>
