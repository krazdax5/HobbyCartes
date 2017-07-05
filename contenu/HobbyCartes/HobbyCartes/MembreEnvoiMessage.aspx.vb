'--------------------------------------------------------------------------
' Titre: MembreEnvoiMessage.aspx.vb
' Auteur: Loïc Vial
' Date: Novembre 2012
'-------------------------------------------------------------------------

Imports MySql.Data.MySqlClient

''' <summary>
''' Page d'envoi de message d'un membre a un autre
''' </summary>
Public Class MembreEnvoiMessage
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Le destinataire du message
    ''' </summary>
    Private m_destinataire As Entites.Membre

    ''' <summary>
    ''' Le destinateur du message
    ''' </summary>
    Private m_destinateur As Entites.Membre

    ''' <summary>
    ''' L'objet du message
    ''' </summary>
    Private m_objet As String

    ''' <summary>
    ''' Le contenu du message
    ''' </summary>
    Private m_contenu As String

    ''' <summary>
    ''' Chargement de la page
    ''' </summary>
    Protected Sub Page_Load() Handles Me.Load
        ' Ouvre la connexion a la base de donnees
        Dim dbCon As New MySqlConnection(My.Resources.StringConnexionBd2)
        dbCon.Open()

        Try
            ' Chargement du destinateur et du destinataire
            Dim idDestinataire As Integer = Entites.Membre.getIDbyPseudo(Request.QueryString("pseudo"), dbCon)
            m_destinataire = New Entites.Membre(idDestinataire, dbCon)
            Dim idDestinateur As Integer = Integer.Parse(Session("idMembre"))
            m_destinateur = New Entites.Membre(idDestinateur, dbCon)

            ' Pré-rempli l'objet en cas de réponse à un message
            If Request.QueryString("reponse") <> Nothing Then
                txtObjet.Text = "Re : " & Request.QueryString("reponse")
            End If

            ' Application du nom complet du membre sur les labels "Destinataire" et "Destinateur"
            lblDestinataire.Text = Entites.Membre.getNomCompletEtPseudoParId(idDestinataire)
            lblDestinateur.Text = Entites.Membre.getNomCompletEtPseudoParId(idDestinateur)
        Catch ex As Exception
            ' Affiche la page d'erreur en cas d'exception
            Erreur.afficherException(ex, Me, Request.UrlReferrer)
        End Try

        dbCon.Close()
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
            If chkMessagerieExterne.Checked Then
                m_destinateur.envoyerMessageExterne(m_destinataire, objet, contenu)
            Else
                m_destinateur.envoyerMessageInterne(m_destinataire, objet, contenu)
            End If
        Catch ex As Exception
            ' Affiche la page d'erreur en cas d'exception
            Erreur.afficherException(ex, Me, Page)
        End Try
        ' Affiche un message de succes si tout s'est bien passe
        Dim script As String = "<script language='javascript'>"
        script += "alert('Message envoyé avec succès !');"
        script += "window.location = 'MembreVisualiserMessages.aspx';"
        script += "</script>"
        Response.Write(script)
    End Sub
End Class