<%@ Page MasterPageFile="~/Membre.master" Language="VB" CodeBehind="~/MembreListeCartes.aspx.vb" Inherits="HobbyCartes.MembreListeCartes" %>
<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="onglets">
        <ul>
            <li>Hockey</li>
            <li>BaseBall</li>
            <li>BasketBall</li>
            <li>FootBall</li>
        </ul>
    </div>
    <div id="liste_contenu">
        <asp:PlaceHolder ID="phHockey" runat="server" Visible="false">
    
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phBaseball" runat="server" Visible="false">
    
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phBasketball" runat="server" Visible="false">
    
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phFootball" runat="server" Visible="false">
    
        </asp:PlaceHolder>
    </div>
</asp:Content>
