Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class MembreInfo
    Inherits System.Web.UI.Page

    Dim m_connection As MySqlConnection
    Dim m_membre As Entitees.Membre

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_connection = New MySqlConnection("Server=localhost;Database=test;Uid=root;Pwd=toor;")
        m_connection.Open()

        m_membre = New Entitees.Membre(1, m_connection)

        txtPrenom.Text = m_membre.prenom
        txtNom.Text = m_membre.nom
        txtUtilisateur.Text = m_membre.nomUtilisateur
        lblPeusdo.Text = m_membre.nomUtilisateur
        txtVille.Text = m_membre.Ville
        txtCodePostal.Text = m_membre.CodePostal
        txtCourriel.Text = m_membre.Courriel

    End Sub

    Protected Sub btnEnregistrer_click(sender As Object, e As EventArgs) Handles btnEnregistrer.Click
        lblMessage.Visible = False
        Dim test As String = txtPrenom.Text
        Dim liste As ArrayList = m_membre.getNomsPseudo
        Dim msgErreur As String = ""

        'S'assurer que le nom d'utilisateur n'est pas déjà utilisé
        If Not (txtUtilisateur.Text.Equals(m_membre.nomUtilisateur)) Then
            If (liste.Contains(txtUtilisateur.Text)) Then
                lblMessage.Text = "Ce nom d'utilisateur est déjà choisi!"
                lblMessage.Visible = True
                Return
            End If
        End If

        m_membre.prenom = txtPrenom.Text
        m_membre.nom = txtNom.Text
        m_membre.nomUtilisateur = txtUtilisateur.Text
        m_membre.Ville = txtVille.Text
        m_membre.CodePostal = txtCodePostal.Text
        m_membre.Courriel = txtCourriel.Text

        If (m_membre.setAttMembre(msgErreur)) Then
            lblMessage.Text = "Les informations ont été enregistrées"
        Else
            lblMessage.Text = msgErreur
        End If
        lblMessage.Visible = True
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        m_connection.Close()
    End Sub
End Class