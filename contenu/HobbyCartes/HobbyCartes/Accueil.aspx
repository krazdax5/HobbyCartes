<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/HobbyCartes.master" CodeBehind="~/Accueil.aspx.vb" Inherits="HobbyCartes.Accueil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
    <div id="default">
        <h1>Description du site</h1>
        <div id="MessageAcceuil">
           Hobby-Cartes est un site permettant aux passionnés de cartes de sports à collectionner d'échanger à propos leur passion, montré leur collection et échanger des cartes. Connectez-vous où inscrivez-vous dès maintenant pour pouvoir profiter pleinement de l'expérience HobbyCarte!
        </div>

        <h1>Nouveautés / Mises à jour :</h1>
        <ul>
            <li>Connexion de base créer</li>
            <li>Affichage des fiches par ID</li>
            <li>File de fiche terminée</li>
            <li>MembreListeCarte fonctionnel</li>
            <li>Envoie de message en fonction</li>
        </ul>

        <h1>Nouveaux membres:</h1>
        <div class="Listemembre">
            <asp:PlaceHolder ID="phNouvMembre" runat="server">
            
            </asp:PlaceHolder>
        </div>
    </div>
</asp:Content>
