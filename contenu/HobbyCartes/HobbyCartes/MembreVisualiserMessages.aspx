<%@ Page MasterPageFile="~/Membre.master" %>

<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="visualiser_messages">
        <h1>Messagerie</h1>
        <div id="liste_messages" runat="server" />
        <div class="message">
            <div class="boxSuppr">Supprimer <asp:CheckBox runat="server" /></div>
            Destinateur : Bob<br />
            Objet : Hej !
        </div>
        <div class="message">
            <div class="boxSuppr">Supprimer <asp:CheckBox runat="server" /></div>
            Destinateur : Bob<br />
            Objet : Hej !
        </div>
        <div class="message">
            <div class="boxSuppr">Supprimer <asp:CheckBox runat="server" /></div>
            Destinateur : Bob<br />
            Objet : Hej !
        </div>
        <div class="message">
            <div class="boxSuppr">Supprimer <asp:CheckBox runat="server" /></div>
            Destinateur : Bosb<br />
            Objet : Hej !
        </div>
        <div id="btnSuppr">
            <asp:Button runat="server" Text="Valider" />
        </div>
    </div>
</asp:Content>
