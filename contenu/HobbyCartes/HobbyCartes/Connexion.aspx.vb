Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.IO

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
        Dim id As Integer
        Dim chemin As String
        Dim Membre As Entitees.Membre
        id = Entitees.Membre.ConnexionMembre(pseudo, motPasse, m_connection)

        If Not id.Equals(-1) Then
            Session("connected") = True
            Session("idMembre") = id

            chemin = Entitees.Membre.getImagebyID(id, m_connection, Entitees.Membre.TypeImage.arriereplan)

            If Not chemin.Equals("*") Then
                Dim cook As HttpCookie = New HttpCookie(id.ToString + "_arriereplan", chemin)
                Response.Cookies.Clear()
                Response.Cookies.Add(cook)
            End If

            Membre = New Entitees.Membre(id, m_connection)
            If Membre.isAdmin Then
                Session("Admin") = True
            End If
            Response.Redirect("Accueil.aspx")
        Else
            lblMessage.Visible = True
            lblMessage.Text = "La connexion à échoué. Vérifier votre nom d'utilisateur et votre mot de passe."
        End If
    End Sub

End Class