<%@ Page MasterPageFile="~/Membre.master" CodeBehind="MembreGererCollections.aspx.vb" Inherits="HobbyCartes.MembreGererCollections" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="membreGererCollections" >
        <h1>Collections</h1>

        <table class="membreGererCollectionsTableCollections" >
            <tr>
                <td>Mes collections : </td>
                <td><asp:DropDownList id="cboCollections" runat="server" AutoPostBack="true" /></td>
                <td><asp:Button id="btnSupprimerCollection" runat="server" text="Supprimer la collection" OnClientClick="javascript:return confirm('Voulez vous vraiment supprimer cette collection ainsi que toutes les fiches qui la composent?');"  /></td>
            </tr>
            <tr>
                <td>Collections disponibles : </td>
                <td><asp:DropDownList id="cboCollectionsDisponibles" runat="server" /></td>
                <td><asp:Button id="btnAjouterCollection" runat="server" text="Ajouter cette nouvelle collection" /></td>
            </tr>
        </table>

        <p>Liste des fiches pour la collection séléctionnée : </p>
        <asp:table runat="server" id="tblListeFiches" cssclass="membreGererCollectionsTableListeFiches">

        </asp:table>

    </div>
</asp:Content>
