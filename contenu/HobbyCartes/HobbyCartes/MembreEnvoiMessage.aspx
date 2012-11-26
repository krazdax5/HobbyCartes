<%@ Page MasterPageFile="~/Membre.master" Inherits="HobbyCartes.MembreEnvoiMessage" CodeBehind="~/MembreEnvoiMessage.aspx.vb" %>

<%-- Page d'envoi de message d'un membre a un autre --%>
<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="membreEnvoiMessage">
        <h1>Nouveau message</h1>
        <table>
            <tbody>
                <tr>
                    <td>Destinateur</td>
                    <td class="maxCol"><asp:label ID="lblDestinateur" runat="server" /></td>
                </tr>
                <tr>
                    <td>Destinataire</td>
                    <td class="maxCol"><asp:label ID="lblDestinataire" runat="server" /></td>
                </tr>
                 <tr>
                    <td>Objet</td>
                    <td class="maxCol"><asp:TextBox ID="txtObjet" runat="server" MaxLength="30" Width="100%" /></td>
                </tr>
                <tr>
                    <td class="maxCol" colspan="2"><asp:TextBox ID="txtContenu" TextMode="MultiLine" Rows="20" runat="server" Width="100%" /></td>
                </tr>
                <tr>
                    <td class="maxCol" colspan="2"><asp:CheckBox runat="server" ID="chkMessagerieExterne" /> 
                    Envoi sur messagerie externe
                    </td>
                </tr>
                <tr>
                    <td class="maxCol" colspan="2"><asp:Button runat="server" id="btnEnvoyer" text="Envoyer" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtObjet" ForeColor="Red" Font-Bold="true" ErrorMessage="Vous devez spécifier un objet !" />
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>