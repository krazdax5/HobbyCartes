'--------------------------------------------------------------------------
' Titre: Membre.master.vb
' Auteur: Loïc Vial
' Date: Septembre 2012
'-------------------------------------------------------------------------

Imports MySql.Data.MySqlClient

''' <summary>
''' Page maitre pour l'affichage des informations, des cartes d'un membre, et pour l'envoi de messages
''' </summary>
Public Class Membre
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        initSession()

        Dim connected As Boolean = Boolean.Parse(Session("connected"))
        Dim idMembre As Integer = Integer.Parse(Session("idMembre"))
        Dim connection As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
        connection.Open()
        Dim pseudoMembre As String = Entites.Membre.getNomUtilisateurParId(idMembre, connection)
        connection.Close()
        Dim pseudo As String = Request.QueryString("pseudo")
        Dim surPropreProfil As Boolean = connected And (pseudo = Nothing OrElse pseudo.Equals(pseudoMembre))
        Dim surAutreProfil As Boolean = Not pseudo = Nothing AndAlso Not pseudo.Equals(pseudoMembre)

        If Not surPropreProfil And Not surAutreProfil Then
            Erreur.afficherErreur(Page)
        ElseIf surPropreProfil Then
            ongletGererCollections.Visible = True
            ongletVisualiserMessages.Visible = True
            ongletEnvoiMessage.Visible = False
        Else
            ongletInformations.HRef += "?pseudo=" & pseudo
            ongletListeCartes.HRef += "?pseudo=" & pseudo
            ongletGererCollections.Visible = False
            ongletVisualiserMessages.Visible = False
            If connected Then
                ongletEnvoiMessage.HRef += "?pseudo=" & pseudo
            Else
                ongletEnvoiMessage.Visible = False
            End If
        End If

        If Request.ServerVariables("URL").Equals("/MembreInfo.aspx") Then
            ongletInformations.Style.Add("background-color", "Black")
        ElseIf Request.ServerVariables("URL").Equals("/MembreListeCartes.aspx") Then
            ongletListeCartes.Style.Add("background-color", "Black")
        ElseIf Request.ServerVariables("URL").Equals("/MembreGererCollections.aspx") Or
            Request.ServerVariables("URL").Equals("/MembreEditerFiche.aspx") Then
            ongletGererCollections.Style.Add("background-color", "Black")
        ElseIf Request.ServerVariables("URL").Equals("/MembreVisualiserMessages.aspx") Or
            Request.ServerVariables("URL").Equals("/MembreVisualiserMessage.aspx") Then
            ongletVisualiserMessages.Style.Add("background-color", "Black")
        ElseIf Request.ServerVariables("URL").Equals("/MembreEnvoiMessage.aspx") Then
            ongletEnvoiMessage.Style.Add("background-color", "Black")
        End If
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