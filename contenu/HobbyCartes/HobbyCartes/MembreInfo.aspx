<%@ Page MasterPageFile="~/Membre.master" %>

<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="info">
        <div id="entete">
            <div id="photo">
                <img alt="photo" src="img/profil.jpg" />
            </div>
            <div id="btnMessage">
                <asp:Button runat="server" Text="Envoyer un message" Font-Size="Large" Height="50px" />
            </div>
            <div id="nom">
                Homer Simpson
            </div>
        </div>
        <div id="description">
            Pseudo : homer<br />
            Adresse mail : doh@simpson.com <br />
            Ville : Lévis<br />
            Code postal : X9X 9X9
        </div>
    </div>
</asp:Content>
