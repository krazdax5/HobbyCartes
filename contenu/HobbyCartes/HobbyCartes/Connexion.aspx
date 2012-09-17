<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
    <div id="connexion">
        <h1>Connexion</h1>
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
                    <td></td>
                    <td><asp:Button ID="Button1" runat="server" Text="Valider" /></td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>