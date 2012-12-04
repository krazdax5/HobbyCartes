<%@ Page Language="VB" MasterPageFile="~/HobbyCartes.master" CodeBehind="~/FilFiches.aspx.vb" Inherits="HobbyCartes.FilFiches" %>

<asp:Content ContentPlaceHolderID="cphCorps" runat="server">
<div id="menuFilFiches">
    <ul>
        <li runat="server" id="ongletHockey"><asp:LinkButton ID="lnkbtnHockey" runat="server" OnClick="lnkbtnHockey_click" CssClass="lnkbtnOnlgets">Hockey</asp:LinkButton></li>
        <li runat="server" id="ongletBaseball"><asp:LinkButton ID="lnkbtnBaseball" runat="server" OnClick="lnkbtnBaseball_click" CssClass="lnkbtnOnlgets">BaseBall</asp:LinkButton></li>
        <li runat="server" id="ongletBasketBall"><asp:LinkButton ID="lnkbtnBasketball" runat="server" OnClick="lnkbtnBasketball_click" CssClass="lnkbtnOnlgets">BasketBall</asp:LinkButton></li>
        <li runat="server" id="ongletFootball"><asp:LinkButton ID="lnkbtnFootball" runat="server" OnClick="lnkbtnFootball_click" CssClass="lnkbtnOnlgets">FootBall</asp:LinkButton></li>
    </ul>
</div>
<div id="contenuFilFiches">
<asp:PlaceHolder ID="phFilFiches" runat="server">
    <asp:MultiView ID="mviewFilFiches" runat="server">
        
    </asp:MultiView>
</asp:PlaceHolder>
</div>
</asp:Content>
