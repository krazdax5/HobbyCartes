Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports HobbyCartes.ServiceSecurite

Public Class Inscription
    Inherits System.Web.UI.Page

    Dim m_connection As MySqlConnection
    Dim m_membre As Entites.Membre

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_connection = New MySqlConnection(My.Resources.StringConnexionBdd)

        m_connection.Open()

        m_membre = New Entites.Membre(m_connection)
    End Sub

    Protected Sub btnTerminer_clique(ByVal sender As Object, ByVal e As WizardNavigationEventArgs)
        lblMessage.Visible = False

        Dim msgErreur As String = ""
        Dim nomsUtilisés As ArrayList = m_membre.getNomsPseudo()
        Dim idNouvMembre As Integer

        If (nomsUtilisés.Contains(txtUtilisateur.Text)) Then
            lblMessage.Text = "Ce nom d'utilisateur est déjà utilisé!"
            lblMessage.Visible = True
            Return
        End If

        m_membre.prenom = txtPrenom.Text
        m_membre.nom = txtNom.Text
        m_membre.nomUtilisateur = txtUtilisateur.Text
        m_membre.Ville = txtVille.Text
        m_membre.CodePostal = txtCodePostal.Text
        m_membre.Courriel = txtCourriel.Text

        'Sécurité du mot de passe
        Dim securite As Securite_hcClient = New Securite_hcClient()
        Dim motPasse As String = securite.HashPass(txtMotPasse.Text, m_membre.nomUtilisateur)
        Dim motPasse2 As String = securite.HashPass(txtRepMotPasse.Text, m_membre.nomUtilisateur)

        If securite.ComparerMotPasses(motPasse, motPasse2) Then

            If (Not m_membre.nouvMembre(m_membre, motPasse, msgErreur, idNouvMembre)) Then
                lblMessage.Text = msgErreur
                lblMessage.Visible = True
            Else
                Session("connected") = True
                Session("idMembre") = idNouvMembre
                Session("Admin") = m_membre.isAdmin
                Response.Redirect("Accueil.aspx")
            End If
        Else
            lblMessage.Text = "Les mots de passes ne sont pas identiques!"
            lblMessage.Visible = True
            Return
        End If
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        m_connection.Close()
    End Sub
End Class