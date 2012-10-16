Imports MySql.Data.MySqlClient

''' <summary>
''' Page de visualisation des messages du membre
''' </summary>
Public Class MembreVisualiserMessages
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' La liste des messages
    ''' </summary>
    ''' <remarks></remarks>
    Private messages As List(Of Entitees.Message)

    ''' <summary>
    ''' La connexion a la base de donnees
    ''' </summary>
    Private dbCon As MySqlConnection

    ''' <summary>
    ''' Chargement de la page
    ''' </summary>
    Protected Sub Page_Load() Handles Me.Load
        ' Ouvre la connexion a la base de donnees
        dbCon = New MySqlConnection("Server=localhost;Database=test;Uid=root;Pwd=toor;")
        dbCon.Open()
        ' Chargement de la liste de messages
        messages = Entitees.Message.getListe(Request.QueryString("id"), dbCon)
        For Each message As Entitees.Message In messages
            ajoute_message(message)
        Next
    End Sub

    ''' <summary>
    ''' Fermeture de la page
    ''' </summary>
    Protected Sub Page_Unload() Handles Me.Unload
        dbCon.Close()
    End Sub

    ''' <summary>
    ''' Ajoute un message a la vue
    ''' </summary>
    Private Sub ajoute_message(message As Entitees.Message)
        Dim destinateurText As Label = New Label()
        destinateurText.Text = "Destinateur : " & Entitees.Membre.getNomUtilisateurParId(message.idDestinateur, dbCon) & "<br />"

        Dim objetText As Label = New Label()
        objetText.Text = "Objet : " & message.objet

        Dim messageLabel As HyperLink = New HyperLink()
        messageLabel.NavigateUrl = "MembreVisualiserMessage.aspx?id=" & message.id
        messageLabel.CssClass = "message"
        messageLabel.Controls.Add(destinateurText)
        messageLabel.Controls.Add(objetText)

        liste_messages.Controls.Add(messageLabel)
    End Sub

End Class