Imports MySql.Data.MySqlClient

''' <summary>
''' Page maitre pour l'affichage des informations, des cartes d'un membre, et pour l'envoi de messages
''' </summary>
Public Class Membre
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    End Sub

End Class