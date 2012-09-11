<%@ Page Language="vb"  MasterPageFile="~/Membre.master" CodeBehind="MembreAjoutCarte.aspx.vb" Inherits="HobbyCartes.MembreAjoutCarte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <h1>Ajouter une nouvelle carte</h1>
    <table>
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
                N° : 
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
                Série : 
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" />
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
</asp:Content>
