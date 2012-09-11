<%@ Page Language="vb" MasterPageFile="~/Membre.master" CodeBehind="MembreEnvoiMessage.aspx.vb" Inherits="HobbyCartes.MembreEnvoiMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPageMembreContenu" runat="server">
    <table id="tMessage">
        <tbody>
            <tr>
                <td>
                   Destinataire : 
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Titre du Message : 
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Contenu:
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Width="500px" Height="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnEnvoye" runat="server" Text="Envoyer" Width="75px" />
                    <asp:Button ID="btnAnnule" runat="server" Text="Annuler" Width="75px" />
                </td>
                
            </tr>
        </tbody>
    </table>

</asp:Content>
