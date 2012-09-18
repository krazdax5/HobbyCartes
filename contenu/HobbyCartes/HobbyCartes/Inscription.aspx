<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
    <div id="inscription">
        <h1>Inscription</h1>
        <table>
            <tbody>
                <tr>
                    <td>Prénom : </td>
                    <td><asp:TextBox ID="TextBox2" runat="server" /></td>
                </tr>
                <tr>
                    <td>Nom : </td>
                    <td><asp:TextBox ID="TextBox3" runat="server" /></td>
                </tr>
                <tr>
                    <td>Nom d'utilisateur (pseudo) : </td>
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
                    <td>Ville : </td>
                    <td><asp:TextBox ID="TextBox4" runat="server" /></td>
                </tr>
                <tr>
                    <td>Code postal : </td>
                    <td><asp:TextBox ID="TextBox5" runat="server" /></td>
                </tr>
                <tr>
                    <td>Adresse courriel : </td>
                    <td><asp:TextBox ID="TextBox6" runat="server" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button runat="server" Text="Valider" /></td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>