<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.master" CodeBehind="~/Administration.aspx.vb" Inherits="HobbyCartes.Administration" %>

<asp:Content ContentPlaceHolderID="cphCorps" runat="server">
    <div id="administration">
         <div id="boutons">
            <ul>
                <li runat="server"><asp:LinkButton ID="lnkbtnCommu" runat="server" CssClass="lnkbtnAdmin">Envoyer un communiqué</asp:LinkButton></li>
                <li runat="server"><asp:LinkButton ID="lnkbtnSupp" runat="server" CssClass="lnkbtnAdmin">Supprimé</asp:LinkButton></li>
            </ul>
        </div>
        <br />
        <div id="ContenuAdmin">
            <asp:PlaceHolder ID="phAdmin" runat="server">
                
            </asp:PlaceHolder>
        </div>
        <asp:UpdatePanel ID="uppanAdmin" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnSup" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSup" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
