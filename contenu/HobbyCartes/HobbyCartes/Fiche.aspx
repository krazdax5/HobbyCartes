<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/HobbyCartes.Master" CodeBehind="Fiche.aspx.vb" Inherits="HobbyCartes.WebForm1" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
    <h1>Nom du joueur:</h1>
    <div id="infos">
        <table>
            <tr>
                <th>Avant</th>
                <th>Arrière</th>
            </tr>
            <tr>
                <th>une image</th>
                <th>une autre image</th>
            </tr>
        </table>

        <p>
            Informations sur le joueur...
        </p>
    </div>
    <div id="commentaires">
        <h1>Commentaires</h1>
        <p>
            Fil de commentaires...
        </p>
    </div>
</asp:Content>
