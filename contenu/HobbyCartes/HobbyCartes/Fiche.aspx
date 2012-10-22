﻿<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.master" CodeBehind="~/Fiche.aspx.vb" Inherits="HobbyCartes.Fiche" %>
<asp:Content ContentPlaceHolderID="cphCorps" runat="server">
    <asp:ScriptManager ID="smFiche" runat="server"/>
    
    <div id="fiche">
        <h1>Nom du joueur : Nom Joueur</h1>
        <div id="info">
            <table>
                <tbody>
                    <tr>
                        <th>Avant</th>
                        <th>Arrière</th>
                    </tr>
                    <tr>
                        <td><img id="imgavant" alt="avant" src="" /></td>
                        <td><img id="imgArriere" alt="arriere" src="" /></td>
                    </tr>
                </tbody>
            </table>
            <div id="description">
                Equipe : bleh Team<br />
                N° : 42<br />
                Description : ceci est un joueur qui joue. Toussa toussa.<br />
                N° carte : 42<br />
                Série : bleh<br />
            </div>
        </div>
        <div id="commentaires">
            <h1>Commentaires</h1>
            <div class="ÉcrireCommentaire">
                <p>
            Commenter : <br />
            <asp:UpdatePanel ID="uppantxtCommentaire" runat="server">
                 <ContentTemplate>
                    <asp:TextBox ID="txtCom" TextMode="MultiLine" Rows="10" Columns="100" runat="server" />
                    
                 </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnCom" EventName="Click" />
                 </Triggers>
            </asp:UpdatePanel>
        </p>
        <p>
            <asp:Button runat="server" id="btnCom" text="Envoyer" />
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
