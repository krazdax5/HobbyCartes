<%@ Page MasterPageFile="~/Membre.master" %>

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
        <p id="btnEnvoyer">
            <asp:Button runat="server" text="Envoyer" />
        </p>
    </div>
</asp:Content>
