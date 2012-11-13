<%@ Page MasterPageFile="~/Membre.master" CodeBehind="MembreGererCollections.aspx.vb" Inherits="HobbyCartes.MembreGererCollections" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="membreGererCollections" >
        <h1>Collections</h1>

        <table class="membreGererCollectionsTableCollections" >
            <tr>
                <td>Mes collections : </td>
                <td><asp:DropDownList id="comboCollections" runat="server" /></td>
                <td><asp:Button id="btnSupprimerCollection" runat="server" text="Supprimer la collection" OnClientClick="javascript:return confirm('Voulez vous vraiment supprimer cette collection ?');"  /></td>
            </tr>
            <tr>
                <td>Collections disponibles : </td>
                <td><asp:DropDownList id="comboCollectionsDisponibles" runat="server" /></td>
                <td><asp:Button id="btnAjouterCollection" runat="server" text="Ajouter cette nouvelle collection" /></td>
            </tr>
        </table>

        <p>Liste des cartes pour la collection séléctionnée : </p>
        <asp:table runat="server" id="tableListeFiches" cssclass="membreGererCollectionsTableListeFiches">
            <asp:TableHeaderRow>
                <asp:TableCell>Nom</asp:TableCell>
                <asp:TableCell>Prénom</asp:TableCell>
                <asp:TableCell>Etat de la fiche</asp:TableCell>
                <asp:TableCell>Chabada</asp:TableCell>
                <asp:TableCell>Position</asp:TableCell>
            </asp:TableHeaderRow>
        </asp:table>

    </div>
</asp:Content>
