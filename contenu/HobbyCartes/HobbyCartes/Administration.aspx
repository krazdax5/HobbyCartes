<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.master" %>

<asp:Content ContentPlaceHolderID="cphCorps" runat="server">
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
                    <th class="membre">Membre</th>
                    <th class="checkbox"><asp:CheckBox runat="server" /> select all</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td class="membre"><img src="img/profil.jpg" />Pseudo<br />Vues : 195, Fiches : 51</td>
                    <td class="checkbox"><asp:CheckBox ID="CheckBox1" runat="server" /></td>
                </tr>
                <tr>
                    <td class="membre"><img src="img/profil.jpg" />Pseudo<br />Vues : 195, Fiches : 51</td>
                    <td class="checkbox"><asp:CheckBox ID="CheckBox2" runat="server" /></td>
                </tr>
                <tr>
                    <td class="membre"><img src="img/profil.jpg" />Pseudo<br />Vues : 195, Fiches : 51</td>
                    <td class="checkbox"><asp:CheckBox ID="CheckBox3" runat="server" /></td>
                </tr>
            </tbody>
        </table>
    </div>
</asp:Content>
