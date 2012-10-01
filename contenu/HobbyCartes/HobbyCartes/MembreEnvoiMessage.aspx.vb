Imports MySql.Data.MySqlClient

Public Class MembreEnvoiMessage
    Inherits System.Web.UI.Page

    Private dbCon As MySqlConnection

    Private membre As Entitees.Membre

    Protected Sub Page_Load() Handles Me.Load
        ' Connexion a la base de donnees
        dbCon = New MySqlConnection("Server=G264-11;Database=test;Uid=root;Pwd=toor;")
        dbCon.Open()
        ' Chargement du membre avec le parametre "id" de l'url
        Dim idMembre As Integer = Request.QueryString("id")
        membre = New Entitees.Membre(idMembre, dbCon)
        ' Application du nom du membre sur le label "Nom"
        lbNom.Text = membre.nomComplet
    End Sub

    Protected Sub btnEnvoyer_Click() Handles btnEnvoyer.Click

    End Sub

    Protected Sub Page_Unload() Handles Me.Unload
        dbCon.Close()
    End Sub
End Class