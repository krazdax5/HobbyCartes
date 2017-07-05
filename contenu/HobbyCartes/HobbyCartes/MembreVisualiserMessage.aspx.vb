'--------------------------------------------------------------------------
' Titre: MembreVisualiserMessage.aspx.vb
' Auteur: Loïc Vial
' Date: Octobre 2012
'-------------------------------------------------------------------------

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
        initSession()

        ' Ouvre la connexion a la bdd
        Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBd2)
        dbCon.Open()

        ' Recupere le message désiré via l'id passée par l'url
        Dim idMessage As Integer = Request.QueryString("idMessage")
        m_message = New Entites.Message(idMessage)

        ' Vérifie si l'utilisateur courant y a acces
        Dim connected As Boolean = Boolean.Parse(Session("connected"))
        Dim idMembre As Integer = Integer.Parse(Session("idMembre"))
        If Not connected Or m_message.idDestinataire <> idMembre Then
            Erreur.afficherErreur("Vous n'avez pas accès à ce message !", Page)
        Else
            ' Affiche le message
            visualiserMessageTitre.InnerText = m_message.objet
            lblDestinateur.Text = Entites.Membre.getNomCompletEtPseudoParId(m_message.idDestinateur)
            lblDestinataire.Text = Entites.Membre.getNomCompletEtPseudoParId(m_message.idDestinataire)
            visualiserMessageContenu.InnerHtml = m_message.contenu.Replace(vbCrLf, "<br />")
        End If
    End Sub

    ''' <summary>
    ''' Clic sur le bouton "Répondre"
    ''' </summary>
    Protected Sub visualiserMessageBtnRepondre_Click() Handles btnvisualiserMessageBtnRepondre.Click
        Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBd2)
        dbCon.Open()
        Dim pseudo As String = Entites.Membre.getNomUtilisateurParId(m_message.idDestinateur, dbCon)
        dbCon.Close()
        Response.Redirect("MembreEnvoiMessage.aspx?pseudo=" & pseudo & "&reponse=" & m_message.objet)
    End Sub

    ''' <summary>
    ''' Clic sur le bouton "Supprimer"
    ''' </summary>
    Protected Sub visualiserMessageBtnSupprimer_Click() Handles btnvisualiserMessageBtnSupprimer.Click
        Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBd2)
        dbCon.Open()
        m_message.supprimer()
        dbCon.Close()
        Response.Redirect("MembreVisualiserMessages.aspx")
    End Sub

    ''' <summary>
    ''' Clic sur le bouton "Retour"
    ''' </summary>
    Protected Sub visualiserMessageBtnRetour_Click() Handles btnvisualiserMessageBtnRetour.Click
        Response.Redirect("MembreVisualiserMessages.aspx")
    End Sub

    Private Sub initSession()
        If Session("connected") Is Nothing Then
            Session.Add("connected", False)
            Session.Timeout = 30
        End If
        If Session("idMembre") Is Nothing Then
            Session.Add("idMembre", -1)
        End If
        If Session("Admin") Is Nothing Then
            Session.Add("Admin", False)
        End If
    End Sub
End Class