﻿<%@ Page MasterPageFile="~/Membre.master" Language="VB" CodeBehind="~/MembreListeCartes.aspx.vb" Inherits="HobbyCartes.MembreListeCartes" %>
<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="onglets">
        <ul>
            <li runat="server" id="ongletHockey"><asp:LinkButton ID="lnkbtnHockey" runat="server" OnClick="lnkbtnHockey_click" CssClass="lnkbtnOnlgets">Hockey</asp:LinkButton></li>
            <li runat="server" id="ongletBaseball"><asp:LinkButton ID="lnkbtnBaseball" runat="server" OnClick="lnkbtnBaseball_click" CssClass="lnkbtnOnlgets">BaseBall</asp:LinkButton></li>
            <li runat="server" id="ongletBasketBall"><asp:LinkButton ID="lnkbtnBasketball" runat="server" OnClick="lnkbtnBasketball_click" CssClass="lnkbtnOnlgets">BasketBall</asp:LinkButton></li>
            <li runat="server" id="ongletFootball"><asp:LinkButton ID="lnkbtnFootball" runat="server" OnClick="lnkbtnFootball_click" CssClass="lnkbtnOnlgets">FootBall</asp:LinkButton></li>
        </ul>
    </div>
    <div id="liste_contenu">
        <asp:PlaceHolder ID="phMembreListeCartes" runat="server">
           
        </asp:PlaceHolder>
        
        <asp:Label ID="lblPasDeFiche" runat="server" Text="" CssClass="lblPasDeFiches"></asp:Label>
        
    </div>
</asp:Content>
