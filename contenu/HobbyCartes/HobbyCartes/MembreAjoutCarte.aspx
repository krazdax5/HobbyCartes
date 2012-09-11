<%@ Page Language="vb"  MasterPageFile="~/Membre.master" CodeBehind="MembreAjoutCarte.aspx.vb" Inherits="HobbyCartes.MembreAjoutCarte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <h1>Ajouter une nouvelle carte</h1>

    <table id="FormulaireAjoutCarte">
    <tbody>
        <tr>
            <td>
                Type de carte :
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Text="Hockey" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Nom du joueur : 
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Prénom du joueur : 
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
        </tr>
       <tr>
            <td>
                N° du joueur : 
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" />
            </td>
       </tr>
       <tr>
            <td>
                Equipe : 
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" />
            </td>
       </tr>
       <tr>
            <td>
                Éditeur : 
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" />
            </td>
       </tr>
       <tr>
            <td>
                Année : 
            </td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" />
            </td>
       </tr>
       <tr>
            <td>
                Recrue : 
            </td>
            <td>
                <asp:CheckBox ID="CheckBox1" runat="server" />
            </td>
       </tr>
       <tr>
            <td>
                Position : 
            </td>
            <td>
                <asp:TextBox ID="TextBox7" runat="server" />
            </td>
       </tr>
       <tr>
            <td>
                Numérotation de la carte : 
            </td>
            <td>
                <asp:TextBox ID="TextBox8" runat="server" />
            </td>
       </tr>
       <tr>
            <td>
                Valeur ($) : 
            </td>
            <td>
                <asp:TextBox ID="TextBox9" runat="server" />
            </td>
       </tr>
       <tr>
            <td>
                Etat :
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem Text="Impeccable" />
                </asp:DropDownList>
            </td>
       </tr>
       <tr>
            <td>
                Image avant :
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
       </tr>
       <tr>
            <td>
                Image arrière :
            </td>
            <td>
                <asp:FileUpload ID="FileUpload2" runat="server" />
            </td>
       </tr>
    </tbody>
    </table>
    <asp:Button ID="Button1" runat="server" Text="Valider" />
</asp:Content>
