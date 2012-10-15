<%@ Page MasterPageFile="~/Membre.master" Language="VB" CodeBehind="~/MembreListeCartes.aspx.vb" Inherits="HobbyCartes.MembreListeCartes" %>
<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="onglets">
        <ul>
            <li runat="server" id="ongletHockey" onclick="ongletHockey_click">Hockey</li>
            <li runat="server" id="ongletBaseball" onclick="ongletBaseball_click">BaseBall</li>
            <li runat="server" id="ongletBasketBall" onclick="ongletBasketball_click">BasketBall</li>
            <li runat="server" id="ongletFootball" onclick="ongletFootball_click">FootBall</li>
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
