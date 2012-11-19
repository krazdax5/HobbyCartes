<%@ Page MasterPageFile="~/Membre.master" CodeBehind="MembreEditerFiche.aspx.vb" Inherits="HobbyCartes.MembreEditerFiche" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="membreEditerFiche" >
        <h1>Editer une fiche</h1>
        <div class="line" />
        <table>
            <tr>
                <td>Collection : </td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" /></td>
            </tr>
            <tr>
                <td>Editeur : </td>
                <td><asp:DropDownList ID="DropDownList2" runat="server" /></td>
            </tr>
            <tr>
                <td>Equipe : </td>
                <td></td>
            </tr>
            <tr>
                <td>Année : </td>
                <td></td>
            </tr>
            <tr>
                <td>Nom joueur : </td>
                <td></td>
            </tr>
            <tr>
                <td>Prenom joueur : </td>
                <td></td>
            </tr>
            <tr>
                <td>Numéro joueur : </td>
                <td></td>
            </tr>
            <tr>
                <td>Recrue : </td>
                <td></td>
            </tr>
            <tr>
                <td>Position : </td>
                <td></td>
            </tr>
            <tr>
                <td>Valeur : </td>
                <td></td>
            </tr>
            <tr>
                <td>Etat : </td>
                <td></td>
            </tr>
            <tr>
                <td>Image avant : </td>
                <td></td>
            </tr>
            <tr>
                <td>Image arrière : </td>
                <td></td>
            </tr>
        </table>

    </div>
</asp:Content>