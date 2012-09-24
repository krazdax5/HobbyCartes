<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.master" %>

<asp:Content ContentPlaceHolderID="cphCorps" runat="server">
    <div id="connexion">
        <h1>Connexion</h1>
        <table>
            <tbody>
                <tr>
                    <td>Nom d'utilisateur : </td>
                    <td><asp:TextBox ID="txtNomUtilisateur" runat="server" /></td>
                </tr>
                <tr>
                    <td>Mot de passe : </td>
                    <td><asp:TextBox ID="txtMotDePasse" runat="server" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnValider" runat="server" Text="Valider" /></td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>