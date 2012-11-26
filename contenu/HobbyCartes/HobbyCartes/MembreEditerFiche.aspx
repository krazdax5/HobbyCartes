<%@ Page MasterPageFile="~/Membre.master" CodeBehind="MembreEditerFiche.aspx.vb" Inherits="HobbyCartes.MembreEditerFiche" AutoEventWireup="false" %>

<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="membreEditerFiche" >
        <h1>Editer une fiche</h1>
        <div class="line" ></div>
        <table>
            <tr>
                <td>Collection : </td>
                <td><asp:DropDownList ID="dropDownCollection" runat="server" /></td>
            </tr>
            <tr>
                <td>Nom joueur : </td>
                <td><asp:TextBox ID="txtNomJoueur" runat="server" /> * 
                <asp:RequiredFieldValidator controltovalidate="txtNomJoueur" ErrorMessage="Requis" runat="server" /></td>
            </tr>
            <tr>
                <td>Prenom joueur : </td>
                <td><asp:TextBox ID="txtPrenomJoueur" runat="server" /> * 
                <asp:RequiredFieldValidator controltovalidate="txtPrenomJoueur" ErrorMessage="Requis" runat="server" /></td>
            </tr>
            <tr>
                <td>Equipe : </td>
                <td><asp:DropDownList ID="dropDownEquipe" runat="server" />  
                <!-- <asp:Button ID="btnEquipe" runat="server" Text="Ajouter nouveau" /> --></td>
            </tr>
            <tr>
                <td>Numéro joueur : </td>
                <td><asp:TextBox ID="txtNumeroJoueur" runat="server" /> * 
                <asp:RequiredFieldValidator controltovalidate="txtNumeroJoueur" ErrorMessage="Requis" runat="server" />
                <asp:RangeValidator ID="RangeValidator2" MinimumValue="0" MaximumValue="99" controltovalidate="txtNumeroJoueur" ErrorMessage="Incorrect" runat="server" /></td>
            </tr>
            <tr>
                <td>Position : </td>
                <td><asp:TextBox ID="txtPosition" runat="server" /> * 
                <asp:RequiredFieldValidator controltovalidate="txtPosition" ErrorMessage="Requis" runat="server" /></td>
            </tr>
            <tr>
                <td>Recrue : </td>
                <td><asp:CheckBox ID="chkRecrue" runat="server" /></td>
            </tr>
            <tr>
                <td>Etat de la fiche : </td>
                <td><asp:dropdownlist id="dropDownEtat" runat="server" /></td>
            </tr>
            <tr>
                <td>Valeur : </td>
                <td><asp:TextBox ID="txtValeur" runat="server" /> * 
                <asp:RequiredFieldValidator controltovalidate="txtValeur" ErrorMessage="Requis" runat="server" />
                <asp:RangeValidator MinimumValue="0" MaximumValue="999999999" controltovalidate="txtValeur" ErrorMessage="Incorrect" runat="server" /></td>
            </tr>
            <tr>
                <td>Editeur : </td>
                <td><asp:DropDownList ID="dropDownEditeur" runat="server" />  
                <!-- <asp:Button ID="btnEditeur" runat="server" Text="Ajouter nouveau" /> --></td>
            </tr>
            <tr>
                <td>Année : </td>
                <td><asp:TextBox ID="txtAnnee" runat="server" /> * 
                <asp:RequiredFieldValidator controltovalidate="txtAnnee" ErrorMessage="Requis" runat="server" />
                <asp:RangeValidator MinimumValue="0" MaximumValue="3000" controltovalidate="txtAnnee" ErrorMessage="Incorrect" runat="server" /></td>
            </tr>
            <tr>
                <td>Image avant : </td>
                <td><asp:FileUpload id="fuImageAvant" runat="server" /><br />
                <asp:Label runat="server" ID="lbImageAvant" Text="/!\ Images JPEG seulement" />
                <asp:Image runat="server" ID="imageAvant" cssclass="img" /><br />
                <asp:CheckBox runat="server" autopostback="true" ID="chkImageAvant" /> Aucune image</td>
            </tr>
            <tr>
                <td>Image arrière : </td>
                <td><asp:FileUpload ID="fuImageArriere" runat="server" /><br />
                <asp:Label runat="server" ID="lbImageArriere" Text="/!\ Images JPEG seulement" />
                <asp:Image runat="server" ID="imageArriere" cssclass="img" /><br />
                <asp:CheckBox runat="server" autopostback="true" ID="chkImageArriere" /> Aucune image</td>
            </tr>
            <tr>
                <td colspan="2" class="align_center"><asp:Button ID="btnEnregistrer" runat="server" Text="Enregistrer" /></td>
            </tr>
        </table>

    </div>
</asp:Content>