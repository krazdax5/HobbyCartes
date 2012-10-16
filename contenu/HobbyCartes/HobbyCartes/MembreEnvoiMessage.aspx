<%@ Page MasterPageFile="~/Membre.master" Inherits="HobbyCartes.MembreEnvoiMessage" CodeBehind="~/MembreEnvoiMessage.aspx.vb" %>

<%-- Page d'envoi de message d'un membre a un autre --%>
<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="membreEnvoiMessage">
        <h1>Nouveau message</h1>
        <table>
            <tbody>
                <tr>
                    <td class="minCol">Destinateur</td>
                    <td><asp:label ID="lblDestinateur" runat="server" /></td>
                </tr>
                <tr>
                    <td class="minCol">Destinataire</td>
                    <td><asp:label ID="lblDestinataire" runat="server" /></td>
                </tr>
                 <tr>
                    <td class="minCol">Objet</td>
                    <td><asp:TextBox ID="txtObjet" runat="server" MaxLength="30" Width="100%" /></td>
                </tr>
                <!-- <tr>
                    <td colspan="2"> Contenu</td>
                </tr> -->
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