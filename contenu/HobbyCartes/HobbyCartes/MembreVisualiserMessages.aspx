<%@ Page Language="vb" MasterPageFile="~/Membre.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="visualiser_messages">
        <h1>Messagerie</h1>
        <div class="message">
            <div class="boxSuppr">Supprimer <asp:CheckBox runat="server" /></div>
            Destinateur : Bob<br />
            Objet : Hej !
        </div>
        <div class="message">
            <div class="boxSuppr">Supprimer <asp:CheckBox ID="CheckBox1" runat="server" /></div>
            Destinateur : Bob<br />
            Objet : Hej !
        </div>
        <div class="message">
            <div class="boxSuppr">Supprimer <asp:CheckBox ID="CheckBox2" runat="server" /></div>
            Destinateur : Bob<br />
            Objet : Hej !
        </div>
        <div class="message">
            <div class="boxSuppr">Supprimer <asp:CheckBox ID="CheckBox3" runat="server" /></div>
            Destinateur : Bob<br />
            Objet : Hej !
        </div>
        <div id="btnSuppr">
            <asp:Button runat="server" Text="Valider" />
        </div>
    </div>
</asp:Content>
