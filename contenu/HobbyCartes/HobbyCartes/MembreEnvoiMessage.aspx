﻿<%@ Page MasterPageFile="~/Membre.master" Inherits="HobbyCartes.MembreEnvoiMessage" CodeBehind="~/MembreEnvoiMessage.aspx.vb" %>

<%-- Page d'envoi de message d'un membre a un autre --%>
<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="membreEnvoiMessage">
        <h1>Envoyer un message à <asp:label ID="lbNom" runat="server" /></h1>
        <p>
            Objet : <asp:TextBox ID="txtObjet" runat="server" Columns="100" /><br />
        </p>
        <p>
            Contenu : <br />
            <asp:TextBox ID="txtContenu" TextMode="MultiLine" Rows="20" Columns="80" runat="server" />
        </p>
        <p>
            <asp:Button runat="server" id="btnEnvoyer" text="Envoyer" />
        </p>
    </div>
</asp:Content>