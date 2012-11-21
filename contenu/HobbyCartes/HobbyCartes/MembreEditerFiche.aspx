<%@ Page MasterPageFile="~/Membre.master" CodeBehind="MembreEditerFiche.aspx.vb" Inherits="HobbyCartes.MembreEditerFiche" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="membreEditerFiche" >
        <h1>Editer une fiche</h1>
        <div class="line" />
        <table>
            <tr>
                <td>Collection : </td>
                <td><asp:DropDownList ID="dropDownCollection" runat="server" /></td>
            </tr>
            <tr>
                <td>Editeur : </td>
                <td><asp:DropDownList ID="dropDownEditeur" runat="server" />  <asp:Button ID="btnEditeur" runat="server" Text="Ajouter nouveau" /></td>
            </tr>
            <tr>
                <td>Equipe : </td>
                <td><asp:DropDownList ID="DropDownEquipe" runat="server" />  <asp:Button ID="btnEquipe" runat="server" Text="Ajouter nouveau" /></td>
            </tr>
            <tr>
                <td>Année : </td>
                <td><asp:TextBox ID="txtAnnee" runat="server" /></td>
            </tr>
            <tr>
                <td>Nom joueur : </td>
                <td><asp:TextBox ID="TextBox1" runat="server" /></td>
            </tr>
            <tr>
                <td>Prenom joueur : </td>
                <td><asp:TextBox ID="TextBox2" runat="server" /></td>
            </tr>
            <tr>
                <td>Numéro joueur : </td>
                <td><asp:TextBox ID="TextBox3" runat="server" /></td>
            </tr>
            <tr>
                <td>Recrue : </td>
                <td><asp:CheckBox ID="chkRecrue" runat="server" /></td>
            </tr>
            <tr>
                <td>Position : </td>
                <td><asp:TextBox ID="TextBox4" runat="server" /></td>
            </tr>
            <tr>
                <td>Valeur : </td>
                <td><asp:TextBox ID="TextBox5" runat="server" /></td>
            </tr>
            <tr>
                <td>Etat : </td>
                <td><asp:dropdownlist runat="server" /></td>
            </tr>
            <tr>
                <td>Image avant : </td>
                <td><asp:FileUpload runat="server" /></td>
            </tr>
            <tr>
                <td>Image arrière : </td>
                <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
            </tr>
        </table>

    </div>
</asp:Content>