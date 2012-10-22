<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.master" CodeBehind="~/Fiche.aspx.vb" Inherits="HobbyCartes.Fiche" %>
<asp:Content ContentPlaceHolderID="cphCorps" runat="server">
    <asp:ScriptManager ID="smFiche" runat="server"/>
    
    <div id="fiche">
        <asp:PlaceHolder ID="phFiche" runat="server">
        
        <div id="info">
            <table id="TImage">
                <tbody>
                    <tr>
                        <td colspan="2"><asp:Label runat="server" ID="lblNomJoueur" CssClass="lblNomJoueur"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="lblInfoImg">Avant</td>
                        <td class="lblInfoImg">Arrière</td>
                    </tr>
                    <tr>
                        <td><asp:Image ID="imgAvant" AlternateText ="avant" runat="server"/> </td>
                        <td><asp:Image ID="imgArriere" AlternateText ="arriere" runat="server"/></td>
                    </tr>
                </tbody>
            </table>
            <br />
            <br />
            <div id="description">
                <table id="TFiche">
                    <tbody>
                        <tr>
                            <td class="gauche">Éditeur: </td>
                            <td> <asp:Label runat="server" ID="lblEditeur" CssClass="lblInfo" /> </td>
                            <td class="gauche"> Année: </td>
                            <td> <asp:Label runat="server" ID="lblAnne" CssClass="lblInfo" /> </td>
                        </tr>
                        <tr>
                            <td class="gauche">Valeur: </td>
                            <td> <asp:Label runat="server" ID="lblValeur" CssClass="lblInfo" /> </td>
                            <td class="gauche"> Détenteur: </td>
                            <td> <asp:HyperLink runat="server" ID="hpDetenteur" CssClass="lblInfo" /> </td>
                        </tr>
                        <tr>
                            <td class="gauche">Équipe: </td>
                            <td> <asp:Label runat="server" ID="lblEquipe" CssClass="lblInfo" /> </td>
                            <td class="gauche">Numéro: </td>
                            <td> <asp:Label runat="server" ID="lblNumero" CssClass="lblInfo" /> </td>
                        </tr>
                        <tr>
                            <td class="gauche">Position: </td>
                            <td> <asp:Label runat="server" ID="lblPosition" CssClass="lblInfo" /> </td>
                            <td class="gauche">Recrue: </td>
                            <td> <asp:Label runat="server" ID="lblRecrue" CssClass="lblInfo" /> </td>
                        </tr>
                        <tr>
                            <td class="gauche">Numérotation: </td>
                            <td> <asp:Label runat="server" ID="lblNumerotation" CssClass="lblInfo" /> </td>
                            <td class="gauche">État: </td>
                            <td> <asp:Label runat="server" ID="lblEtat" CssClass="lblInfo" /> </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="gauche">Date publication: </td>
                            <td colspan="2"> <asp:Label runat="server" ID="lblDatePub" CssClass="lblInfo" /> </td>                            
                        </tr>
                        
                    </tbody>
                </table>
            </div>
        </div>
        </asp:PlaceHolder>
        <div id="commentaires">
            <h1>Commentaires</h1>
            <div class="ÉcrireCommentaire">                
            <h2>Commenter :</h2> <br />
            <asp:UpdatePanel ID="uppantxtCommentaire" runat="server">
                 <ContentTemplate>
                    <asp:TextBox ID="txtCom" TextMode="MultiLine" Rows="5" Columns="80" runat="server" CssClass="TextCom" />
                    
                 </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnCom" EventName="Click" />
                 </Triggers>
            </asp:UpdatePanel>
        <p>
            <br />
            <asp:Button runat="server" id="btnCom" text="Envoyer" Width="150" Height="50" BorderStyle="Solid" BorderColor="Red" Font-Size="Large" ForeColor="Red"/>
        </p>
            </div>
            <div id="AfficheCommentaire">
                
                
                <asp:UpdatePanel ID="uppanCommentaire" runat="server">
                    <ContentTemplate>
                        <asp:PlaceHolder ID="phCommentaire" runat="server">
                        </asp:PlaceHolder>
                    </ContentTemplate>
                        <Triggers>
                            <asp:ASyncPostBackTrigger ControlID="btnCom" EventName="Click" />
                            <asp:ASyncPostBackTrigger ControlID="btnSup" EventName="Click" />                            
                        </Triggers>
                </asp:UpdatePanel>
                <asp:Button ID="btnSup" runat="server" Text="Supprimer" />
                
            </div>
        </div>
    </div>
</asp:Content>
