Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Connexion
    Inherits System.Web.UI.Page

    Private m_connection As MySqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMessage.Visible = False

        If Boolean.Parse(Session("connected")) Then
            Response.Redirect("Accueil.aspx")
        End If

        m_connection = New MySqlConnection(My.Resources.StringConnexionBdd)
        m_connection.Open()
    End Sub

    Protected Sub btnConnexion_OnClick(sender As Object, e As EventArgs) Handles btnConnexion.Click
        Dim pseudo As String = txtUtilisateur.Text
        Dim motPasse As String = txtMotPasse.Text

        If Entitees.Membre.ConnexionMembre(pseudo, motPasse, m_connection) Then
            Session("connected") = True
            Response.Redirect("Accueil.aspx")
        Else
            lblMessage.Visible = True
            lblMessage.Text = "La connexion à échoué. Vérifier votre nom d'utilisateur et votre mot de passe."
        End If
    End Sub

End Class