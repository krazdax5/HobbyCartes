﻿Imports MySql.Data.MySqlClient

''' <summary>
''' Page de visualisation des messages du membre
''' </summary>
Public Class MembreVisualiserMessages
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' La liste des messages
    ''' </summary>
    ''' <remarks></remarks>
    Private messages As List(Of Entites.Message)

    ''' <summary>
    ''' La connexion a la base de donnees
    ''' </summary>
    Private dbCon As MySqlConnection

    ''' <summary>
    ''' La liste des boites a cocher pour la suppression de messages
    ''' </summary>
    ''' <remarks></remarks>
    Private checkBoxes As List(Of CheckBox)

    ''' <summary>
    ''' Chargement de la page
    ''' </summary>
    Protected Sub Page_Load() Handles Me.Load
        ' Si l'utilisateur n'est pas connecté, erreur
        If Not Boolean.Parse(Session("connected")) Then
            Erreur.afficherErreur("Connectez vous pour visualiser vos messages !", Me)
        End If

        ' Initialise la liste des checkboxes
        checkBoxes = New List(Of CheckBox)

        ' Ouvre la connexion a la base de donnees
        dbCon = New MySqlConnection(My.Resources.StringConnexionBdd)
        dbCon.Open()

        ' Chargement de la liste de messages avec l'id du membre connecté
        Dim idMembre As Integer = Integer.Parse(Session("idMembre"))
        messages = Entites.Message.getListe(idMembre, dbCon)
        For Each message As Entites.Message In messages
            ajoute_message(message)
        Next

        ' Ajoute le bouton "Supprimer"
        Dim btnSupprimer As Button = New Button()
        btnSupprimer.CssClass = "btnSuppr"
        btnSupprimer.Text = "Supprimer"
        Dim btnSupprimerCell As TableCell = New TableCell()
        btnSupprimerCell.ColumnSpan = 3
        btnSupprimerCell.Controls.Add(btnSupprimer)
        Dim btnSupprimerRow As TableRow = New TableRow()
        btnSupprimerRow.Cells.Add(btnSupprimerCell)
        listeMessages.Rows.Add(btnSupprimerRow)
    End Sub

    ''' <summary>
    ''' Fermeture de la page
    ''' </summary>
    Protected Sub Page_Unload() Handles Me.Unload
        If Not IsNothing(dbCon) Then
            dbCon.Close()
        End If
    End Sub

    ''' <summary>
    ''' Ajoute un message a la liste des messages sur la vue
    ''' </summary>
    Private Sub ajoute_message(message As Entites.Message)
        Dim destinateurText As Label = New Label()
        destinateurText.Text = Entites.Membre.getNomUtilisateurParId(message.idDestinateur, dbCon)

        Dim destinateurCell As TableCell = New TableCell()
        destinateurCell.Controls.Add(destinateurText)

        Dim objetLnk As HyperLink = New HyperLink()
        objetLnk.Text = message.objet
        objetLnk.NavigateUrl = "MembreVisualiserMessage.aspx?idMessage=" & message.id
        Dim objetCell As TableCell = New TableCell()
        objetCell.Controls.Add(objetLnk)
        objetCell.CssClass = "colObjet"

        Dim selectChk As CheckBox = New CheckBox()
        Dim selectCell As TableCell = New TableCell()
        selectCell.Controls.Add(selectChk)
        checkBoxes.Add(selectChk)

        Dim ligne As TableRow = New TableRow()
        ligne.Cells.Add(selectCell)
        ligne.Cells.Add(destinateurCell)
        ligne.Cells.Add(objetCell)

        listeMessages.Rows.Add(ligne)
    End Sub

    ''' <summary>
    ''' Clic sur le bouton "Supprimer"
    ''' </summary>
    Private Sub btnSuppr_Click() Handles btnSuppr.Click
        ' Supprime tous les messages selectionnes de la base de donnees
        For i As Integer = 1 To checkBoxes.Count
            If checkBoxes(i - 1).Checked Then
                messages(i - 1).supprimer(dbCon)
            End If
        Next
        ' Refresh la page
        Response.Redirect(Request.RawUrl)
    End Sub

End Class