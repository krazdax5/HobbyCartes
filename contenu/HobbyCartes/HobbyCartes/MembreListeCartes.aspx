<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HobbyCartes.Master" CodeBehind="MembreListeCartes.aspx.vb" Inherits="HobbyCartes.MembreListeCartes" Theme="MainTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
    <div id="page_membre_onglets">
        <a href="/MembreInfo.aspx" class="onglet">Informations</a>
        <a class="onglet" href="/MembreListeCartes.aspx">Liste des cartes</a>
        <a class="onglet" href="/MembreAjoutCarte.aspx">Ajouter une carte</a>
    </div>
    <div id="page_membre_contenu">
        <div id="menu_sport">
            <div class="item_sport">
                Hockey
            </div>
            <div class="item_sport">
                Basketball
            </div>
            <div class="item_sport">
                Football
            </div>
            <div class="item_sport">
                Baseball
            </div>
            <div class="clear" />
        </div>
        <div id="liste_cartes">
            <div class="carte">
                <img src="img/avant.jpg" /> Nom joueur : <br />
                Série : <br />
                Année :  
            </div>
            <div class="carte">
                <img src="img/avant.jpg" /> Nom joueur : <br />
                Série : <br />
                Année :  
            </div>
            <div class="carte">
                <img src="img/avant.jpg" /> Nom joueur : <br />
                Série : <br />
                Année :  
            </div>
        </div>
    </div>
</asp:Content>
