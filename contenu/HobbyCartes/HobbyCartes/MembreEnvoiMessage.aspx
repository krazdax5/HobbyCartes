<%@ Page MasterPageFile="~/Membre.master" Inherits="HobbyCartes.MembreEnvoiMessage" CodeBehind="~/MembreEnvoiMessage.aspx.vb" %>

<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="membreEnvoiMessage">
        <h1>Envoyer un message à Homer Simpson</h1>
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
