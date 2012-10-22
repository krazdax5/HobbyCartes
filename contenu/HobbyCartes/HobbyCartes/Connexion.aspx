<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/HobbyCartes.master" CodeBehind="Connexion.aspx.vb" Inherits="HobbyCartes.Connexion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphCorps" runat="server">
    <div id="connexion">
        <asp:Table ID="tblConnexion" runat="server">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server"><asp:Label ID="lblUtilisateur" runat="server" Text="Nom d'utilisateur:"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="txtUtilisateur" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUtilisateur" runat="server" ErrorMessage="*" ControlToValidate="txtUtilisateur"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server">
                <asp:TableCell runat="server"><asp:Label ID="lblMotPasse" runat="server" Text="Mot de passe:"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server">
                    <asp:TextBox ID="txtMotPasse" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMotPasse" runat="server" ErrorMessage="*" ControlToValidate="txtMotPasse"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="btnConnexion" runat="server" Text="Connexion" OnClick="btnConnexion_OnClick" />

        <asp:Label ID="lblMessage" runat="server"  Visible="false"></asp:Label>

        <asp:ValidationSummary ID="vsConnexion" runat="server" />
    </div>
</asp:Content>

