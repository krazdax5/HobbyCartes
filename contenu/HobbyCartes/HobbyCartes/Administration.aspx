<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.master" CodeBehind="~/Administration.aspx.vb" Inherits="HobbyCartes.Administration" %>

<asp:Content ContentPlaceHolderID="cphCorps" runat="server">
    <asp:ScriptManager ID="smAdmin" runat="server" />
    <script type="text/javascript">
        function AfficherMessage() {
            $(document).ready(function () {
                $("#dMessage").slideDown("slow");
            });
        }
        $(document).ready(function () {
            $("#dMessage").hide();
        });
    </script>

    <div id="administration">
        <asp:Label ID="lblDialogue" runat="server" Text=""></asp:Label>
         <div id="boutons">
            <ul>
                <li runat="server"><asp:LinkButton ID="lnkbtnCommu" runat="server" CssClass="lnkbtnAdmin">Envoyer un communiqué</asp:LinkButton></li>
                <li runat="server"><asp:LinkButton ID="lnkbtnSupp" runat="server" CssClass="lnkbtnAdmin">Supprimer</asp:LinkButton></li>
            </ul>
        </div>
        <asp:CheckBox runat="server" ID="ckTous" AutoPostBack="true" Text=" Sélectionner tout" CssClass="ckTouscss"/>
        <asp:Button runat="server" ID="btnSauvegarde" Text="Copie de sauvegarde" /><br />
        <asp:Button runat="server" ID="btnRestauration" Text="Restaurer" />
        <div id="dMessage">
                    <asp:Label ID="lblMessage" runat="server" Text="Entrez votre message:" /> <br /><br />
                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Width="100%" Height="100px"></asp:TextBox><br /><br />
                    <asp:Button runat="server" ID="btnEnvoyer" Text="Envoyer" Width="125px" Height="40px" />
                    <asp:Button runat="server" ID="btnAnnuler" Text="Annuler" Width="125px" Height="40px" />
        </div>
        
        <br />
        <div id="ContenuAdmin">
        
        <asp:UpdatePanel ID="uppanAdmin" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="phAdminMembre" runat="server" >
                
                 </asp:PlaceHolder>
                
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lnkbtnSupp" EventName="Click" />
                
            </Triggers>
        </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
