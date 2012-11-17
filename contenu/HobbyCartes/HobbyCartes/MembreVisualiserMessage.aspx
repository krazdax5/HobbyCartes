<%@ Page MasterPageFile="~/Membre.master" Inherits="HobbyCartes.MembreVisualiserMessage" CodeBehind="~/MembreVisualiserMessage.aspx.vb" %>

<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
<asp:ScriptManager ID="smVisuMessage" runat="server"/>
    <div id="visualiserMessage">
        <h1 id="visualiserMessageTitre" runat="server" />
        <div class="visualiserMessageDest" id="visualiserMessageDestinateur" runat="server" >
            De : <asp:Label runat="server" ID="lblDestinateur" /><br />
            A : <asp:Label runat="server" ID="lblDestinataire" />
        </div>
        <div class="visualiserMessageContenu">
            <p id="visualiserMessageContenu" runat="server" />
                <asp:Button id="btnvisualiserMessageBtnRepondre" runat="server" Text="Répondre" />
                <asp:Button id="btnvisualiserMessageBtnSupprimer" OnClientClick="javascript:return confirm('Voulez vous vraiment supprimer ce message ?');" runat="server" Text="Supprimer" />
                <asp:Button id="btnvisualiserMessageBtnRetour" runat="server" Text="Retour" />
        </div>
    </div>
</asp:Content>
