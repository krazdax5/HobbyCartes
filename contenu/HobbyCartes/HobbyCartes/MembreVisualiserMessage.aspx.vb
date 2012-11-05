Imports MySql.Data.MySqlClient

''' <summary>
''' Page de visualisation d'un seul message
''' </summary>
Public Class MembreVisualiserMessage
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Le message a visualiser
    ''' </summary>
    Dim m_message As Entites.Message

    ''' <summary>
    ''' Chargement de la page
    ''' </summary>
    Protected Sub Page_Load() Handles Me.Load
        ' Ouvre la connexion a la bdd
        Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
        dbCon.Open()

        ' Recupere le message désiré via l'id passée par l'url
        Dim idMessage As Integer = Request.QueryString("idMessage")
        m_message = New Entites.Message(idMessage, dbCon)
        dbCon.Close()

        ' Vérifie si l'utilisateur courant y a acces
        Dim connected As Boolean = Boolean.Parse(Session("connected"))
        Dim idMembre As Integer = Integer.Parse(Session("idMembre"))
        If Not connected Or m_message.idDestinataire <> idMembre Then
            Erreur.afficherErreur("Vous n'avez pas accès à ce message !", Page)
        Else
            visualiserMessageTitre.InnerText = m_message.objet
            visualiserMessageContenu.InnerHtml = m_message.contenu.Replace(vbCrLf, "<br />")
        End If
    End Sub

    ''' <summary>
    ''' Clic sur le bouton "Répondre"
    ''' </summary>
    Protected Sub visualiserMessageBtnRepondre_Click() Handles visualiserMessageBtnRepondre.Click
        Response.Redirect("MembreEnvoiMessage.aspx?idDestinataire=" & m_message.idDestinataire & "&idDestinateur=" & m_message.idDestinateur)
    End Sub

End Class