<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.master" CodeBehind="~/Fiche.aspx.vb" Inherits="HobbyCartes.Fiche" %>
<asp:Content ContentPlaceHolderID="cphCorps" runat="server">
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
                        <td><img alt="avant" src="img/avant.jpg" /></td>
                        <td><img alt="arriere" src="img/arriere.jpg" /></td>
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
            <asp:TextBox ID="txtCom" TextMode="MultiLine" Rows="10" Columns="100" runat="server" />
        </p>
        <p>
            <asp:Button runat="server" id="btnCom" text="Envoyer" />
        </p>
            </div>
            <div id="AfficheCommentaire">
                <asp:PlaceHolder runat="server" ID="TestCom"/> 
                <div class="commentaire">
                   
                   
                </div>
                <div class="commentaire">
                    Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
                    Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
                    Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
                    Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
                    Commentaire commentaire 
                </div>
                <div class="commentaire">
                    Commentaire commentaire 
                    Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
                    Commentaire commentaire 
                    Commentaire commentaire 
                    Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>
