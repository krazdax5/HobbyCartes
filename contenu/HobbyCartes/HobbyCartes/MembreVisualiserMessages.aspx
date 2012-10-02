<%@ Page MasterPageFile="~/Membre.master" Inherits="HobbyCartes.MembreVisualiserMessages" CodeBehind="~/MembreVisualiserMessages.aspx.vb" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="visualiser_messages">
        <h1>Messagerie</h1>
        <div id="liste_messages" runat="server" />
        <div id="btnSuppr">
            <asp:Button runat="server" Text="Valider" />
        </div>
    </div>
</asp:Content>
