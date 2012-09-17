<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
    <div id="inscription">
        <h1>Inscription</h1>
        <table>
            <tbody>
                <tr>
                    <td>Nom d'utilisateur : </td>
                    <td><asp:TextBox ID="txtUsername" runat="server" /></td>
                </tr>
                <tr>
                    <td>Mot de passe : </td>
                    <td><asp:TextBox ID="txtPassword" runat="server" /></td>
                </tr>
                <tr>
                    <td>Répetez le mot de passe : </td>
                    <td><asp:TextBox ID="TextBox1" runat="server" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button runat="server" Text="Valider" /></td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>