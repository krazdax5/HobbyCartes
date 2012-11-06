<%@ Page Language="vb" MasterPageFile="~/HobbyCartes.Master" CodeBehind="~/Inscription.aspx.vb" Inherits="HobbyCartes.Inscription" %>

<asp:Content ContentPlaceHolderID="cphCorps" runat="server">
    <div id="inscription">
        <asp:Wizard 
            ID="wizInscription" 
            runat="server" 
            ActiveStepIndex="0" 
            CssClass="wizInscription"
            SideBarButtonStyle-Font-Underline="false" 
            SideBarButtonStyle-Width="200px"
            SideBarButtonStyle-CssClass="wizInscriptionSideBtn" OnFinishButtonClick="btnTerminer_clique">

            <WizardSteps>
                <asp:WizardStep ID="wizEtapePerso" runat="server" Title="Informations personnelles" StepType="Start">
                    <asp:Table ID="tblFormulairePerso" runat="server">

                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server"><asp:Label ID="lblPrenom" runat="server" Text="Prénom:" AssociatedControlID="txtPrenom"></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox runat="server" ID="txtPrenom"></asp:TextBox>
                                <asp:RequiredFieldValidator 
                                    ID="rfvPrenom" 
                                    runat="server" 
                                    ErrorMessage="*" 
                                    ControlToValidate="txtPrenom" 
                                    EnableClientScript="false"></asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server"><asp:Label ID="lblNom" runat="server" Text="Nom:" AssociatedControlID="txtNom"></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtNom" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator 
                                    ID="rfvNom" 
                                    runat="server" 
                                    ErrorMessage="*" 
                                    ControlToValidate="txtNom" 
                                    EnableClientScript="false"></asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server"><asp:Label ID="lblVille" runat="server" Text="Ville:" AssociatedControlID="txtVille"></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtVille" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator 
                                    ID="rfvVille" runat="server" 
                                    ErrorMessage="*" 
                                    ControlToValidate="txtVille" 
                                    EnableClientScript="false"></asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server"><asp:Label ID="lblCodePostal" runat="server" Text="Code Postal:" AssociatedControlID="txtCodePostal"></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtCodePostal" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator 
                                    ID="rfvCodePostal" 
                                    runat="server" 
                                    ErrorMessage="*" 
                                    ControlToValidate="txtCodePostal"
                                    EnableClientScript="false"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator 
                                    ID="regexCodePostal" 
                                    runat="server" 
                                    ErrorMessage="Le format n'est pas conforme!"
                                    ControlToValidate="txtCodePostal"
                                    ValidationExpression="^[a-zA-Z][0-9][a-zA-Z]\s*[0-9][a-zA-Z][0-9]$"
                                    EnableClientScript="false"></asp:RegularExpressionValidator>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server"><asp:Label ID="lblCourriel" runat="server" Text="Courriel:" AssociatedControlID="txtCourriel"></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtCourriel" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCourriel" runat="server" ErrorMessage="*" ControlToValidate="txtCourriel"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator 
                                    ID="regexCourriel" 
                                    runat="server" 
                                    ErrorMessage="Le format n'est pas conforme!" 
                                    ControlToValidate="txtCourriel" 
                                    ValidationExpression="^[a-zA-Z0-9\-\._]+@([a-zA-Z0-9\-_]+\.)+[a-zA-Z]{2,4}$" 
                                    EnableClientScript="false"></asp:RegularExpressionValidator>
                            </asp:TableCell>
                        </asp:TableRow>

                    </asp:Table>                   
                </asp:WizardStep>

                <asp:WizardStep ID="wizEtapeCompte" runat="server" Title="Informations du compte" StepType="Finish">
                    <asp:Table ID="tblFormulaireCompte" runat="server">

                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server"><asp:Label ID="lblUtilisateur" runat="server" Text="Nom d'utilisateur:" AssociatedControlID="txtUtilisateur"></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtUtilisateur" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator 
                                    ID="rfvUtilisateur" 
                                    runat="server" 
                                    ErrorMessage="*" 
                                    ControlToValidate="txtUtilisateur" 
                                    EnableClientScript="false"></asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server"><asp:Label ID="lblMotPasse" runat="server" Text="Mot de passe:" AssociatedControlID="txtMotPasse"></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtMotPasse" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator 
                                    ID="rfvMotPasse" 
                                    runat="server" 
                                    ErrorMessage="*" 
                                    ControlToValidate="txtMotPasse"
                                    EnableClientScript="false"></asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server"><asp:Label ID="lblRepMotPasse" runat="server" Text="Répéter mot de passe:" AssociatedControlID="txtRepMotPasse"></asp:Label></asp:TableCell>
                            <asp:TableCell runat="server">
                                <asp:TextBox ID="txtRepMotPasse" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator 
                                    ID="rfvRepMotPasse" 
                                    runat="server" 
                                    ErrorMessage="*" 
                                    ControlToValidate="txtRepMotPasse" 
                                    EnableClientScript="false"></asp:RequiredFieldValidator>
                                <asp:CompareValidator 
                                    ID="cvRepMotPasse" 
                                    runat="server" 
                                    ErrorMessage="Les mots de passe de sont pas identiques!" 
                                    ControlToValidate="txtRepMotPasse" 
                                    ControlToCompare="txtMotPasse" 
                                    ValueToCompare="txtMotPasse.Text"></asp:CompareValidator>
                            </asp:TableCell>
                        </asp:TableRow>

                    </asp:Table>
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
        <br />
        <asp:Label runat="server" ID="lblMessage" Visible="false" ForeColor="White" Font-Size="Large" />
    </div>
</asp:Content>