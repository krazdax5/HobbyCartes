<%@ Page MasterPageFile="~/Membre.master" Language="VB" CodeBehind="~/MembreListeCartes.aspx.vb" Inherits="HobbyCartes.MembreListeCartes" %>
<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="onglets">
        <ul>
            <li runat="server" id="ongletHockey">Hockey</li>
            <li runat="server" id="ongletBaseball">BaseBall</li>
            <li runat="server" id="ongletBasketBall">BasketBall</li>
            <li runat="server" id="ongletFootball">FootBall</li>
        </ul>
    </div>
    <div id="liste_contenu">
        <asp:PlaceHolder ID="phHockey" runat="server" Visible="true"></asp:PlaceHolder>
        <asp:PlaceHolder ID="phBaseball" runat="server" Visible="false"></asp:PlaceHolder>
        <asp:PlaceHolder ID="phBasketball" runat="server" Visible="false"></asp:PlaceHolder>
        <asp:PlaceHolder ID="phFootball" runat="server" Visible="false"></asp:PlaceHolder>
    </div>
</asp:Content>
