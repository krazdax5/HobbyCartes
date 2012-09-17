<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.Master" CodeBehind="Fiche.aspx.vb" Inherits="HobbyCartes.Fiche" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
    <h1>Nom du joueur : Nom Joueur</h1>
    <div id="info_fiche">
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
        <div id="description_fiche">
            Equipe : bleh Team<br />
            N° : 42<br />
            Description : ceci est un joueur qui joue. Toussa toussa.<br />
            N° carte : 42<br />
            Série : bleh<br />
        </div>
    </div>
    <div id="commentaires_fiche">
        <h1>Commentaires</h1>
        <div class="commentaire_fiche">
            Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
            Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
            Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
            Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
            Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
        </div>
        <div class="commentaire_fiche">
            Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
            Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
            Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
            Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
            Commentaire commentaire 
        </div>
        <div class="commentaire_fiche">
            Commentaire commentaire 
            Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
            Commentaire commentaire 
            Commentaire commentaire 
            Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire Commentaire commentaire 
        </div>
    </div>
</asp:Content>
