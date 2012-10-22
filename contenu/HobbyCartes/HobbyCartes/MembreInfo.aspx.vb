Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class MembreInfo
    Inherits System.Web.UI.Page

    Dim m_connection As MySqlConnection
    Dim m_membre As Entitees.Membre

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_connection = New MySqlConnection("Server=localhost;Database=test;Uid=root;Pwd=toor;")
        m_connection.Open()

        Dim id As Integer = Entitees.Membre.getIDbyPseudo(Request.QueryString("pseudo"), m_connection)

        If Not id = -1 Then
            m_membre = New Entitees.Membre(id, m_connection)
        Else
            m_membre = New Entitees.Membre(1, m_connection)
        End If


        lblPrenom_membre.Text = m_membre.prenom
        lblNom_membre.Text = m_membre.nom
        lblUtilisateur_membre.Text = m_membre.nomUtilisateur
        lblPeusdo.Text = m_membre.nomUtilisateur
        lblVille_membre.Text = m_membre.Ville
        lblCodePostal_membre.Text = m_membre.CodePostal
        lblCourriel_membre.Text = m_membre.Courriel

    End Sub

    Protected Sub btnEnregistrer_click(sender As Object, e As EventArgs) Handles btnEnregistrer.Click
        If Page.IsValid Then
            lblMessage.Visible = False
            Dim liste As ArrayList = m_membre.getNomsPseudo
            Dim msgErreur As String = ""

            'S'assurer que le nom d'utilisateur n'est pas déjà utilisé
            If Not (txtUtilisateur.Text.Equals(m_membre.nomUtilisateur)) Then
                If Not txtUtilisateur.Text.Equals("") Then
                    If (liste.Contains(txtUtilisateur.Text)) Then
                        lblMessage.Text = "Ce nom d'utilisateur est déjà choisi!"
                        lblMessage.Visible = True
                        Return
                    End If
                End If
            End If

            If Not txtPrenom.Text.Equals("") Then
                m_membre.prenom = txtPrenom.Text
                txtPrenom.Text = ""
            End If
            If Not txtNom.Text.Equals("") Then
                m_membre.nom = txtNom.Text
                txtNom.Text = ""
            End If
            If Not txtUtilisateur.Text.Equals("") Then
                m_membre.nomUtilisateur = txtUtilisateur.Text
                txtUtilisateur.Text = ""
            End If
            If Not txtVille.Text.Equals("") Then
                m_membre.Ville = txtVille.Text
                txtVille.Text = ""
            End If
            If Not txtCodePostal.Text.Equals("") Then
                m_membre.CodePostal = txtCodePostal.Text
                txtCodePostal.Text = ""
            End If
            If Not txtCourriel.Text.Equals("") Then
                m_membre.Courriel = txtCourriel.Text
                txtCourriel.Text = ""
            End If

            If (m_membre.setAttMembre(msgErreur)) Then
                lblMessage.Text = "Les informations ont été enregistrées"
            Else
                lblMessage.Text = msgErreur
            End If

            lblPrenom_membre.Text = m_membre.prenom
            lblNom_membre.Text = m_membre.nom
            lblUtilisateur_membre.Text = m_membre.nomUtilisateur
            lblPeusdo.Text = m_membre.nomUtilisateur
            lblVille_membre.Text = m_membre.Ville
            lblCodePostal_membre.Text = m_membre.CodePostal
            lblCourriel_membre.Text = m_membre.Courriel

            lblMessage.Visible = True
        End If
    End Sub

    Protected Sub lol32(sender As Object, e As EventArgs) Handles txtCourriel.TextChanged
        Dim test As String = txtCourriel.Text

        Dim test2 As String = txtPrenom.Text

    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        m_connection.Close()
    End Sub
End Class