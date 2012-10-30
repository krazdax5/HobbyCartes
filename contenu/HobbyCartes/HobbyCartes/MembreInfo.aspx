<%@ Page Language="VB" MasterPageFile="~/Membre.master" CodeBehind="~/MembreInfo.aspx.vb" Inherits="HobbyCartes.MembreInfo" %>

<asp:Content ContentPlaceHolderID="cphPageMembreContenu" runat="server">
<asp:ScriptManager ID="smMembreInfo" runat="server"/>
    <div id="info">
        <div id="entete">

            <!-- Tableau 1D pour l'affichage de l'entête -->
            <asp:Table ID="tblEntete" runat="server" Width="100%">
                <asp:TableHeaderRow runat="server">
                    <asp:TableHeaderCell runat="server"><asp:Image 
                                                            ID="imgProfil" 
                                                            runat="server" 
                                                            ImageUrl="~/img/profil.jpg" 
                                                            Width="150px" 
                                                            Height="150px" 
                                                            ImageAlign="Left" /></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server"><asp:Label ID="lblPeusdo" runat="server" Font-Size="XX-Large" ForeColor="Red"></asp:Label></asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server"><asp:Button ID="btnEnvoyerMessage" runat="server" Text="Envoyer un message" Height="50px" Width="180px" /></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>

        <div id="description">
             <!-- Tableau pour afficher les informations du membre -->
             <asp:Table ID="tblDescription" runat="server" Width="100%">
                        
                        <asp:TableRow runat="server" CssClass="trDescription">
                            <asp:TableCell runat="server" CssClass="gauche"><asp:Label ID="lblPrenom" runat="server" Text="Prénom:" AssociatedControlID="txtPrenom" CssClass="lblDescription"></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server" CssClass="centre"><asp:Label ID="lblPrenom_membre" runat="server" Text=""></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox runat="server" ID="txtPrenom" Width="85%" Visible="false"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="trDescription">
                            <asp:TableCell runat="server" CssClass="gauche"><asp:Label ID="lblNom" runat="server" Text="Nom:" AssociatedControlID="txtNom" CssClass="lblDescription"></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server" CssClass="centre"><asp:Label ID="lblNom_membre" runat="server" Text=""></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtNom" runat="server" Width="85%" Visible="false"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="trDescription">
                            <asp:TableCell runat="server" CssClass="gauche"><asp:Label ID="lblUtilisateur" runat="server" Text="Nom d'utilisateur:" AssociatedControlID="txtUtilisateur" CssClass="lblDescription"></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server" CssClass="centre"><asp:Label ID="lblUtilisateur_membre" runat="server" Text=""></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtUtilisateur" runat="server" Width="85%" Visible="false"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="trDescription">
                            <asp:TableCell runat="server" CssClass="gauche"><asp:Label ID="lblVille" runat="server" Text="Ville:" AssociatedControlID="txtVille" CssClass="lblDescription"></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server" CssClass="centre"><asp:Label ID="lblVille_membre" runat="server" Text=""></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtVille" runat="server" Width="85%" Visible="false"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="trDescription">
                            <asp:TableCell runat="server" CssClass="gauche"><asp:Label ID="lblCodePostal" runat="server" Text="Code Postal:" AssociatedControlID="txtCodePostal" CssClass="lblDescription"></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server" CssClass="centre"><asp:Label ID="lblCodePostal_membre" runat="server" Text=""></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtCodePostal" runat="server" Width="85%" Visible="false"></asp:TextBox><br />
                                <asp:RegularExpressionValidator 
                                    ID="regexCodePostal" 
                                    runat="server" 
                                    ErrorMessage="Le format n'est pas conforme!"
                                    ControlToValidate="txtCodePostal"
                                    ValidationExpression="^[a-zA-Z][0-9][a-zA-Z]\s*[0-9][a-zA-Z][0-9]$"
                                    EnableClientScript="false"></asp:RegularExpressionValidator>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server" CssClass="trDescription">
                            <asp:TableCell runat="server" CssClass="gauche"><asp:Label ID="lblCourriel" runat="server" Text="Courriel:" AssociatedControlID="txtCourriel" CssClass="lblDescription"></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server" CssClass="centre"><asp:Label ID="lblCourriel_membre" runat="server" Text=""></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtCourriel" runat="server" Width="85%" Visible="false"></asp:TextBox><br />
                                <asp:RegularExpressionValidator 
                                    ID="regexCourriel" 
                                    runat="server" 
                                    ErrorMessage="Le format n'est pas conforme!" 
                                    ControlToValidate="txtCourriel" 
                                    ValidationExpression="^[a-zA-Z0-9\-\._]+@([a-zA-Z0-9\-_]+\.)+[a-zA-Z]{2,4}$" 
                                    EnableClientScript="false"></asp:RegularExpressionValidator>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server"><asp:Label ID="lblArrierePlan" runat="server" Text="Arrière Plan"></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server"><asp:FileUpload ID="fuArrierePlan" runat="server" Visible="false" /></asp:TableCell>
                            <asp:TableCell runat="server"><asp:Label ID="lblfuMessage" runat="server" Text=""></asp:Label></asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server">
                            <asp:TableCell ColumnSpan="3" runat="server">
                                <asp:ValidationSummary ID="vsDescription" runat="server" />
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server">
                            <asp:TableCell ColumnSpan="3" runat="server"><asp:Button ID="btnEnregistrer" runat="server" Text="Enregistrer les modifications" CssClass="buttonAlign" Visible="false" /></asp:TableCell>
                        </asp:TableRow>

             </asp:Table>

             <!-- Contrôle pour afficher un message destiné à l'utilisateur -->
             <asp:Label ID="lblMessage" runat="server" Text="Message" Visible="false"></asp:Label>
        </div>

    </div>
</asp:Content>
