<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
    <table id="tblRecherche">
        <tr>
            <td><asp:Label runat="server" ID="lblRecherche" Text="Rechercher: "  /></td>
            <td><asp:TextBox runat="server" ID="txtRecherche" Width="500px" /></td>
        </tr>
    </table>
    <div class="recherche">
        <div class="recherche2" id="d1">
            <asp:Label runat="server" Text="Résultats par membres:" />
        </div>
        <div class="recherche2">
            <asp:Label ID="Label1" runat="server" Text="Résultats par fiches:" />
            <div id="liste_cartes">
                <div class="carte">
                    <img src="img/avant.jpg" /> Nom joueur : <br />
                    Série : <br />
                    Année :  
                </div>
                <div class="carte">
                    <img src="img/avant.jpg" /> Nom joueur : <br />
                    Série : <br />
                    Année :  
                </div>
                <div class="carte">
                    <img src="img/avant.jpg" /> Nom joueur : <br />
                    Série : <br />
                    Année :  
                </div>
            </div>
        </div>
    </div>
</asp:Content>