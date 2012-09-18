<%@ Page Language="vb" MasterPageFile="~/Membre.master" CodeBehind="MembreInfo.aspx.vb" Inherits="HobbyCartes.MembreInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="page_membre_entete">
        <div id="page_membre_photo">
            <img alt="photo" src="img/profil.jpg" />
        </div>
        <div id="page_membre_btnMessage">
            <asp:Button ID="btnMessage" runat="server" Text="Envoyer un message" Font-Size="Large" Height="50px" />
        </div>
        <div id="page_membre_nom">
            Homer Simpson
        </div>
    </div>
    <div id="page_membre_description">
        Pseudo : homer<br />
        Adresse mail : doh@simpson.com <br />
        Ville : Lévis<br />
        Code postal : X9X 9X9
    </div>
</asp:Content>
