<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
    Mot(s) Clé(s): 
    <asp:TextBox ID="txtRecherche" runat="server"></asp:TextBox>
    <table id="ResultatRecherche">
        <tr>
            <td>
                Membres
            </td>
            <td>
                Fiches
            </td>
        </tr>
        <tr>
            <td>
                <img alt="photo" src="img/profil.jpg" /><br />
                Pseudo : Blehbleh<br />
                Nom : Homer simpson
            </td>
            <td>
                <img alt="photo" src="img/avant.jpg" /><br />
                Nom joueur : <br />
                Série : <br />
                Année :  
            </td>
        </tr>
        <tr>
            <td>
                <img alt="photo" src="img/profil.jpg" /><br />
                Pseudo : Blehbleh<br />
                Nom : Homer simpson
            </td>
            <td>
                <img alt="photo" src="img/avant.jpg" /><br />
                Nom joueur : <br />
                Série : <br />
                Année :  
            </td>
        </tr>
        <tr>
            <td>
                <img alt="photo" src="img/profil.jpg" /><br />
                Pseudo : Blehbleh<br />
                Nom : Homer simpson
            </td>
            <td>
                <img src="img/avant.jpg" /><br />
                Nom joueur : <br />
                Série : <br />
                Année :  
            </td>
        </tr>
    </table>
</asp:Content>