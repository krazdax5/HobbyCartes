﻿<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.master" CodeBehind="~/Administration.aspx.vb" Inherits="HobbyCartes.Administration" %>

<asp:Content ContentPlaceHolderID="cphCorps" runat="server">
    <asp:ScriptManager ID="smAdmin" runat="server" />
    
    <div id="administration">
         <div id="boutons">
            <ul>
                <li runat="server"><asp:LinkButton ID="lnkbtnCommu" runat="server" CssClass="lnkbtnAdmin">Envoyer un communiqué</asp:LinkButton></li>
                <li runat="server"><asp:LinkButton ID="lnkbtnSupp" runat="server" CssClass="lnkbtnAdmin">Supprimé</asp:LinkButton></li>
            </ul>
        </div>
        
        
        <div id="ContenuAdmin">
        <asp:UpdatePanel ID="uppanAdmin" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="phAdminMembre" runat="server" >
                
                 </asp:PlaceHolder>
                <asp:Button ID="btnSup" runat="server" Text="Supprimer" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSup" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
