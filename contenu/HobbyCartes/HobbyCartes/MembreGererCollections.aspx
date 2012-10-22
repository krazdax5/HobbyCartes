<%@ Page MasterPageFile="~/Membre.master" CodeBehind="MembreGererCollections.aspx.vb" Inherits="HobbyCartes.MembreGererCollections" AutoEventWireup="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <div id="membreGererCollections" >
        <h1>Collections</h1>
        Mes collections : <asp:DropDownList id="comboCollections" runat="server" />
        <asp:Button runat="server" text="Supprimer la collection" Enabled="false" />
        <br />
        <asp:Button runat="server" text="Ajouter une nouvelle collection" />
        <table style="display:none">
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
    </div>
</asp:Content>
