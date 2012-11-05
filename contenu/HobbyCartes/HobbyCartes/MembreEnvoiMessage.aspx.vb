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
    Private destinataire As Entites.Membre

    ''' <summary>
    ''' Le destinateur du message
    ''' </summary>
    Private destinateur As Entites.Membre

    ''' <summary>
    ''' L'objet du message
    ''' </summary>
    Private objet As String

    ''' <summary>
    ''' Le contenu du message
    ''' </summary>
    Private contenu As String

    ''' <summary>
    ''' Chargement de la page
    ''' </summary>
    Protected Sub Page_Load() Handles Me.Load
        ' Ouvre la connexion a la base de donnees
        dbCon = New MySqlConnection(My.Resources.StringConnexionBdd)
        dbCon.Open()

        Try
            ' Chargement du destinateur et du destinataire
            destinataire = New Entites.Membre(Entites.Membre.getIDbyPseudo(Request.QueryString("pseudo"), dbCon), dbCon)
            destinateur = New Entites.Membre(Integer.Parse(Session("idMembre")), dbCon)

            ' Pré-rempli l'objet en cas de réponse à un message
            If Request.QueryString("reponse") <> Nothing Then
                txtObjet.Text = "Re : " & Request.QueryString("reponse")
            End If
        Catch ex As Exception
            ' Affiche la page d'erreur en cas d'exception
            Erreur.afficherException(ex, Me, Request.UrlReferrer)
        End Try

        ' Application du nom complet du membre sur les labels "Destinataire" et "Destinateur"
        lblDestinataire.Text = destinataire.nomComplet & " (" & destinataire.nomUtilisateur & ")"
        lblDestinateur.Text = destinateur.nomComplet & " (" & destinateur.nomUtilisateur & ")"
    End Sub

    ''' <summary>
    ''' Clic sur le bouton "Envoyer"
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub btnEnvoyer_Click() Handles btnEnvoyer.Click
        ' Recupere l'objet et le contenu du message
        Dim objet As String = txtObjet.Text
        Dim contenu As String = txtContenu.Text
        Try
            ' Envoi du message au destinataire
            destinateur.envoyerMessage(destinataire, objet, contenu)
        Catch ex As Exception
            ' Affiche la page d'erreur en cas d'exception
            Erreur.afficherException(ex, Me, Page)
        End Try
        ' Affiche la page de succes si tout s'est bien passe
        Response.Write("<script LANGUAGE='JavaScript'>alert('Message envoyé avec succès !');</script>")
    End Sub

    ''' <summary>
    ''' Fermeture de la page
    ''' </summary>
    Protected Sub Page_Unload() Handles Me.Unload
        dbCon.Close() ' Ferme la connexion a la base de donnees
    End Sub
End Class