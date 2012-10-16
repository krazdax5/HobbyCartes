﻿<%@ Page MasterPageFile="~/Membre.master" Language="VB" CodeBehind="~/MembreListeCartes.aspx.vb" Inherits="HobbyCartes.MembreListeCartes" %>
<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="onglets">
        <ul>
            <li runat="server" id="ongletHockey"><asp:LinkButton ID="lnkbtnHockey" runat="server" OnClick="lnkbtnHockey_click">Hockey</asp:LinkButton></li>
            <li runat="server" id="ongletBaseball"><asp:LinkButton ID="lnkbtnBaseball" runat="server" OnClick="lnkbtnBaseball_click">BaseBall</asp:LinkButton></li>
            <li runat="server" id="ongletBasketBall"><asp:LinkButton ID="lnkbtnBasketball" runat="server" OnClick="lnkbtnBasketball_click">BasketBall</asp:LinkButton></li>
            <li runat="server" id="ongletFootball"><asp:LinkButton ID="lnkbtnFootball" runat="server" OnClick="lnkbtnFootball_click">FootBall</asp:LinkButton></li>
        </ul>
    </div>
    <div id="liste_contenu">
        <asp:PlaceHolder ID="phHockey" runat="server" Visible="false">
            <asp:Button ID="btnAjouterHockey" runat="server" Text="Ajouter la collection Hockey à mes collections" Visible="false" />
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="phBaseball" runat="server" Visible="false">
            <asp:Button ID="btnAjouterBaseball" runat="server" Text="Ajouter la collection Baseball à mes collections" Visible="false" />
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="phBasketball" runat="server" Visible="false">
            <asp:Button ID="btnAjouterBasketball" runat="server" Text="Ajouter la collection Basketball à mes collections" Visible="false" />
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="phFootball" runat="server" Visible="false">
            <asp:Button ID="btnAjouterFootball" runat="server" Text="Ajouter la collection Football à mes collections" Visible="false" />
        </asp:PlaceHolder>
        
        <asp:Label ID="lblPasDeFiche" runat="server" Text="Il n'y a pas de fiches dans votre collection." Visible="false"></asp:Label>
        
    </div>
</asp:Content>
