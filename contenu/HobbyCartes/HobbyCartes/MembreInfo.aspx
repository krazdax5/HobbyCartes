<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HobbyCartes.Master" CodeBehind="MembreInfo.aspx.vb" Inherits="HobbyCartes.Membre" Theme="MainTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
    <div id="page_membre_onglets">
        <a href="/MembreInfo.aspx" class="onglet">Informations</a>
        <a class="onglet" href="/MembreListeCartes.aspx">Liste des cartes</a>
        <a class="onglet" href="/MembreAjoutCarte.aspx">Ajouter une carte</a>
    </div>
    <div id="page_membre_contenu">
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
            Pseudo : bleh bleh <br />
            Adresse mail : bleh@bleh.com <br />
        </div>
    </div>
</asp:Content>
