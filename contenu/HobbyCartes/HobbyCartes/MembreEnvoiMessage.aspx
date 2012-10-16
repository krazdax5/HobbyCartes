<%@ Page MasterPageFile="~/Membre.master" Inherits="HobbyCartes.MembreEnvoiMessage" CodeBehind="~/MembreEnvoiMessage.aspx.vb" %>

<%-- Page d'envoi de message d'un membre a un autre --%>
<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="membreEnvoiMessage">
        <table>
            <tbody>
                <tr>
                    <td>Destinateur : </td>
                    <td class="col2"><asp:label ID="lblDestinateur" runat="server" /></td>
                </tr>
                <tr>
                    <td>Destinataire : </td>
                    <td class="col2"><asp:label ID="lblDestinataire" runat="server" /></td>
                </tr>
                 <tr>
                    <td>Objet : </td>
                    <td class="col2"><asp:TextBox ID="txtObjet" runat="server" MaxLength="30" Width="100%" /></td>
                </tr>
                <tr>
                    <td colspan="2"> Contenu : </td>
                </tr>
                <tr>
                    <td colspan="2"><asp:TextBox ID="txtContenu" TextMode="MultiLine" Rows="20" runat="server" Width="100%" /></td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Button runat="server" id="btnEnvoyer" text="Envoyer" /></td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>