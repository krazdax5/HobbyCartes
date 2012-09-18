<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
    <div id="recherche">
        Rechercher : 
        <asp:TextBox runat="server" ID="txtRecherche" Width="400px" />
        <asp:Button runat="server" Text="Rechercher" />
    </div>
    <table id="resultat">
        <thead>
            <tr>
                <th class="membre">Résultats par membres</th>
                <th class="fiche">Résultats par fiches</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td class="membre">
                    <a href="MembreInfo.aspx">
                        <img src="img/profil.jpg" />Pseudo
                    </a>
                </td>
                <td class="fiche">
                    <a href="Fiche.aspx">
                        <img src="img/avant.jpg" />Nom joueur<br />
                        Série<br />
                        Année
                    </a>
                </td>
            </tr>
            <tr>
                <td class="membre">
                    <img src="img/profil.jpg" />Pseudo
                </td>
                <td class="fiche">
                    <img src="img/avant.jpg" />Nom joueur<br />
                    Série<br />
                    Année
                </td>
            </tr>
            <tr>
                <td class="membre">
                    <img src="img/profil.jpg" />Pseudo
                </td>
                <td class="fiche">
                    
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>