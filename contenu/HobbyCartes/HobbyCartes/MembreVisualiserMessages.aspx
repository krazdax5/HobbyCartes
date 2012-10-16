<%@ Page MasterPageFile="~/Membre.master" Inherits="HobbyCartes.MembreVisualiserMessages" CodeBehind="~/MembreVisualiserMessages.aspx.vb" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="visualiserMessages">
        <h1>Messagerie</h1>
        <asp:Table id="listeMessages" runat="server" />
        <asp:Button cssclass="btnSuppr" id="btnSuppr" runat="server" Text="Supprimer" />
    </div>
</asp:Content>
