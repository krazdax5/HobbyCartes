Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Inscription
    Inherits System.Web.UI.Page

    Dim m_connection As MySqlConnection
    Dim m_membre As Entitees.Membre

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_connection = New MySqlConnection(My.Resources.StringConnexionBdd)

        m_connection.Open()

        m_membre = New Entitees.Membre(m_connection)
    End Sub

    Protected Sub btnTerminer_clique(ByVal sender As Object, ByVal e As WizardNavigationEventArgs)
        lblMessage.Visible = False

        Dim msgErreur As String = ""
        Dim nomsUtilisés As ArrayList = m_membre.getNomsPseudo()

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

        If (Not m_membre.nouvMembre(m_membre, txtMotPasse.Text, msgErreur)) Then
            lblMessage.Text = msgErreur
            lblMessage.Visible = True
        Else
            Response.Redirect("Acceuil.aspx")
        End If
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        m_connection.Close()
    End Sub
End Class