﻿<%@ Page Language="vb" MasterPageFile="~/Membre.master" CodeBehind="MembreListeCartes.aspx.vb" Inherits="HobbyCartes.MembreListeCartes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPageMembreContenu" runat="server">
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
</asp:Content>