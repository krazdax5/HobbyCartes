Imports MySql.Data.MySqlClient

''' <summary>
''' Page d'envoi de message d'un membre a un autre
''' </summary>
Public Class MembreEnvoiMessage
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' La connexion a la base de donnees
    ''' </summary>
    Private dbCon As MySqlConnection

    ''' <summary>
    ''' Le destinataire du message
    ''' </summary>
    Private destinataire As Entitees.Membre

    ''' <summary>
    ''' Le destinateur du message
    ''' </summary>
    Private destinateur As Entitees.Membre

    ''' <summary>
    ''' Chargement de la page
    ''' </summary>
    Protected Sub Page_Load() Handles Me.Load
        ' Ouvre la connexion a la base de donnees
        dbCon = New MySqlConnection("Server=G264-11;Database=test;Uid=root;Pwd=toor;")
        dbCon.Open()
        ' Chargement du destinataire avec le parametre "id" de l'url
        Try
            Dim idDestinataire As Integer = Request.QueryString("id")
            destinataire = New Entitees.Membre(idDestinataire, dbCon)
        Catch ex As Exception
            ' Affiche la page d'erreur en cas d'exception
            Erreur.afficherException(ex, Request.UrlReferrer, Response)
        End Try
        ' Application du nom du membre sur le label "Nom"
        lbNom.Text = destinataire.nomComplet
        ' Chargement du destinateur avec la session de l'utilisateur
        ' destinateur = Session("membre")
        destinateur = New Entitees.Membre()
    End Sub

    ''' <summary>
    ''' Clic sur le bouton "Envoyer"
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub btnEnvoyer_Click() Handles btnEnvoyer.Click
        ' Recupere l'objet et le contenu du message
        Dim objet As String = txtObjet.Text
        Dim contenu As String = txtContenu.Text
        ' Envoi du message au destinataire
        Try
            destinateur.envoyerMessage(destinataire, objet, contenu, dbCon)
            ' Affiche la page de succes si tout s'est bien passe
            ' TODO
        Catch ex As Exception
            ' Affiche la page d'erreur en cas d'exception
            Erreur.afficherException(ex, Page, Response)
        End Try
    End Sub

    ''' <summary>
    ''' Fermeture de la page
    ''' </summary>
    Protected Sub Page_Unload() Handles Me.Unload
        dbCon.Close() ' Ferme la connexion a la base de donnees
    End Sub
End Class