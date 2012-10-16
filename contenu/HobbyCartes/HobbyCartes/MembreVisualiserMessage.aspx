<%@ Page MasterPageFile="~/Membre.master" Inherits="HobbyCartes.MembreVisualiserMessage" CodeBehind="~/MembreVisualiserMessage.aspx.vb" %>

<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="visualiser_message">
        <h1 id="visualiserMessageTitre" runat="server" />
        <p id="visualiserMessageContenu" class="contenu" runat="server" />
    </div>
</asp:Content>
