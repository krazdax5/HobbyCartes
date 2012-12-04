<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.Master" CodeBehind="~/Recherche.aspx.vb" Inherits="HobbyCartes.Recherche" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
<asp:ScriptManager ID="smFiche" runat="server"/>
    <div id="recherche">
        Rechercher : 
        <asp:TextBox runat="server" ID="txtRecherche" Width="400px" />
        <asp:Button id="btnRechercher" runat="server" Text="Rechercher" />
    </div>
    <div id="AfficherFiche">
            <h1>Fiches :</h1>
             <asp:UpdatePanel ID="uppanRechercheFiche" runat="server">
                     <ContentTemplate>
                        <asp:PlaceHolder ID="phRechercheFiche" runat="server">
                        </asp:PlaceHolder>                    
                     </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnRechercher" EventName="Click" />
                     </Triggers>
                </asp:UpdatePanel>
        </div>
        <div id="AfficherMembre">
            <h1>Membres :</h1>

            <asp:UpdatePanel ID="uppanRechercherMembre" runat="server">
                     <ContentTemplate>
                        <asp:PlaceHolder ID="phRechercherMembre" runat="server">
                        </asp:PlaceHolder>                    
                     </ContentTemplate>
                     <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnRechercher" EventName="Click" />
                     </Triggers>
                </asp:UpdatePanel>
          </div>  
          <div id="Test">
   
          </div> 
</asp:Content>