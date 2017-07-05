'--------------------------------------------------------------------------
' Titre: Connexion.aspx.vb
' Auteur: Charles Levesque
' Date: 29 Octobre 2012
'-------------------------------------------------------------------------

Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.IO
Imports HobbyCartes.ServiceSecurite

Public Class Connexion
    Inherits System.Web.UI.Page

    Private m_connection As MySqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMessage.Visible = False

        m_connection = New MySqlConnection(My.Resources.StringConnexionBd2)
        m_connection.Open()
    End Sub

    Protected Sub btnConnexion_OnClick(sender As Object, e As EventArgs) Handles btnConnexion.Click
        Dim pseudo As String = txtUtilisateur.Text
        Dim motPasse As String = txtMotPasse.Text

        'Sécurité mot de passe
        Dim securite As Securite_hcClient = New Securite_hcClient()
        motPasse = securite.HashPass(motPasse, pseudo)

        Dim id As Integer
        Dim chemin As String
        Dim Membre As Entites.Membre
        id = Entites.Membre.ConnexionMembre(pseudo, motPasse, m_connection)

        If Not id.Equals(-1) Then
            Session("connected") = True
            Session("idMembre") = id

            chemin = Entites.Membre.getImagebyID(id, m_connection, Entites.Membre.TypeImage.arriereplan)

            If Not chemin.Equals("*") Then
                Dim cook As HttpCookie = New HttpCookie(id.ToString + "_arriereplan", chemin)
                Response.Cookies.Clear()
                Response.Cookies.Add(cook)
            End If

            Membre = New Entites.Membre(id, m_connection)
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