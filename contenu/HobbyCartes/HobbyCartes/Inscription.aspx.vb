Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Inscription
    Inherits System.Web.UI.Page

    Dim m_connection As MySqlConnection
    Dim m_membre As Entitees.Membre

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_connection = New MySqlConnection("Server=G264-11;Database=test;Uid=root;Pwd=toor;")
        m_connection.Open()

        m_membre = New Entitees.Membre(1, m_connection)

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

        If (Not m_membre.nouvMembre(txtPrenom.Text, txtNom.Text, txtVille.Text, txtCodePostal.Text, txtCourriel.Text, txtUtilisateur.Text, txtMotPasse.Text, msgErreur)) Then
            lblMessage.Text = msgErreur
            lblMessage.Visible = True
        Else
            Response.Redirect("Default.aspx")
        End If
    End Sub
End Class