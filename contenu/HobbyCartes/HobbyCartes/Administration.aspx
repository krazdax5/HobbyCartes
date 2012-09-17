<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
<div id="administration">
     <div id="boutons">
        <div>
            <a>Envoyer un communiqué</a>
        </div>
        <div>
            <a>Supprimer</a>
        </div>
    </div>
    <table id="membres">
        <thead>
            <tr>
                <th class="colonne1">Membre</th>
                <th class="colonne2"><asp:CheckBox runat="server" /> select all</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td class="colonne1"><img src="img/profil.jpg" />Pseudo<br />Vues : 195, Fiches : 51</td>
                <td class="colonne2"><asp:CheckBox ID="CheckBox1" runat="server" /></td>
            </tr>
            <tr>
                <td class="colonne1"><img src="img/profil.jpg" />Pseudo<br />Vues : 195, Fiches : 51</td>
                <td class="colonne2"><asp:CheckBox ID="CheckBox2" runat="server" /></td>
            </tr>
            <tr>
                <td class="colonne1"><img src="img/profil.jpg" />Pseudo<br />Vues : 195, Fiches : 51</td>
                <td class="colonne2"><asp:CheckBox ID="CheckBox3" runat="server" /></td>
            </tr>
        </tbody>
    </table>
</div>
</asp:Content>
