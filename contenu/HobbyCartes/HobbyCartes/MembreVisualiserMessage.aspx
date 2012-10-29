<%@ Page MasterPageFile="~/Membre.master" Inherits="HobbyCartes.MembreVisualiserMessage" CodeBehind="~/MembreVisualiserMessage.aspx.vb" %>

<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="visualiserMessage">
        <h1 id="visualiserMessageTitre" runat="server" />
        <div class="visualiserMessageContenu">
            <p id="visualiserMessageContenu" runat="server" />
            <asp:Button id="visualiserMessageBtnRepondre" runat="server" Text="Répondre" />
        </div>
    </div>
</asp:Content>
