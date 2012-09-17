<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
    <div id="recherche">
        <asp:Label runat="server" ID="lblRecherche" Text="Rechercher: "  />
        <asp:TextBox runat="server" ID="txtRecherche" Width="500px" />
    </div>
    <table id="resultat">
        <thead>
            <tr>
                <th>Résultats par membres</th>
                <th>Résultats par fiches</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td class="membre">
                    <img src="img/profil.jpg" /> Pseudo
                </td>
                <td class="fiche">
                    <img src="img/avant.jpg" /> Nom joueur : <br />
                    Série : <br />
                    Année :  
                </td>
            </tr>
            <tr>
                <td class="membre">
                    <img src="img/profil.jpg" /> Pseudo
                </td>
                <td class="fiche">
                    <img src="img/avant.jpg" /> Nom joueur : <br />
                    Série : <br />
                    Année :  
                </td>
            </tr>
            <tr>
                <td class="membre">
                    <img src="img/profil.jpg" /> Pseudo
                </td>
                <td class="fiche">
                    <img src="img/avant.jpg" /> Nom joueur : <br />
                    Série : <br />
                    Année :  
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>