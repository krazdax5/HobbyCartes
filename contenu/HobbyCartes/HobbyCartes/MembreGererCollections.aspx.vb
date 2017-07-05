'--------------------------------------------------------------------------
' Titre: MembreGererCollections.aspx.vb
' Auteur: Loïc Vial
' Date: 6 Novembre 2012
'-------------------------------------------------------------------------

Imports MySql.Data.MySqlClient

''' <summary>
''' Page de gestion des collections de cartes du membre.
''' </summary>
Public Class MembreGererCollections
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' L'identifiant du membre connecté
    ''' </summary>
    Dim m_idMembre As Integer

    Dim isAdmin As Boolean
    Dim pseudo As String

    ''' <summary>
    ''' Initialisation de la page
    ''' </summary>
    Protected Sub Page_Init() Handles Me.Init
        Accueil.initSession(Session)

        ' Vérifie si l'utilisateur est connecté
        Dim connected As Boolean = Boolean.Parse(Session("connected"))
        If Not connected Then Erreur.afficherErreur("Vous devez être connecté pour gérer vos collections.", Page)

        isAdmin = Boolean.Parse(Session("Admin"))
        pseudo = Request.QueryString("pseudo")
        ' Recupere l'id du membre et charge toutes ses collections
        If isAdmin And Not IsNothing(pseudo) Then
            m_idMembre = Entites.Membre.getIDbyPseudo(pseudo)
        Else
            m_idMembre = Integer.Parse(Session("idMembre"))
        End If

        Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBd2)
        dbCon.Open()
        For Each typeCol As Entites.Collection.Type In System.Enum.GetValues(GetType(Entites.Collection.Type))
            If Not Entites.Collection.existe(m_idMembre, typeCol) Then
                cboCollectionsDisponibles.Items.Add(typeCol.ToString)
            Else
                cboCollections.Items.Add(typeCol.ToString)
            End If
        Next
        dbCon.Close()
    End Sub

    ''' <summary>
    ''' Chargement de la page
    ''' </summary>
    Protected Sub Page_Load() Handles Me.Load
        majBoutons()
        majListeFiches()
    End Sub

    ''' <summary>
    ''' Mise a jour des boutons pour "Supprimer" et "Ajouter" une collection
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub majBoutons()
        If cboCollections.Items.Count = 0 Then
            btnSupprimerCollection.Enabled = False
        Else
            btnSupprimerCollection.Enabled = True
        End If
        If cboCollectionsDisponibles.Items.Count = 0 Then
            btnAjouterCollection.Enabled = False
        Else
            btnAjouterCollection.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Clic sur le bouton "Supprimer la collection"
    ''' </summary>
    Protected Sub BtnSupprimerCollection_Click() Handles btnSupprimerCollection.Click
        Dim oldType As Entites.Collection.Type = Entites.Collection.Type.Parse(GetType(Entites.Collection.Type), cboCollections.SelectedValue)
        Entites.Collection.supprimer(m_idMembre, oldType)
        cboCollectionsDisponibles.Items.Add(cboCollections.SelectedValue)
        cboCollections.Items.Remove(cboCollections.SelectedValue)
        majBoutons()
        If isAdmin And Not IsNothing(pseudo) Then
            Response.Redirect("MembreGererCollections.aspx?pseudo=" & pseudo)
        Else
            Response.Redirect("MembreGererCollections.aspx")
        End If
    End Sub

    ''' <summary>
    ''' Clic sur le bouton "Ajouter une collection"
    ''' </summary>
    Protected Sub BtnAjouterCollection_Click() Handles btnAjouterCollection.Click
        Dim newType As Entites.Collection.Type = Entites.Collection.Type.Parse(GetType(Entites.Collection.Type), cboCollectionsDisponibles.SelectedValue)
        Entites.Collection.ajouter(m_idMembre, newType)
        cboCollections.Items.Add(cboCollectionsDisponibles.SelectedValue)
        cboCollectionsDisponibles.Items.Remove(cboCollectionsDisponibles.SelectedValue)
        majBoutons()
        If isAdmin And Not IsNothing(pseudo) Then
            Response.Redirect("MembreGererCollections.aspx?pseudo=" & pseudo)
        Else
            Response.Redirect("MembreGererCollections.aspx")
        End If
    End Sub

    ''' <summary>
    ''' Changement de selection dans la combobox des collections
    ''' </summary>
    Protected Sub cboCollections_SelectedIndexChanged() Handles cboCollections.SelectedIndexChanged
        majListeFiches()
    End Sub

    ''' <summary>
    ''' Met a jour le tableau de la liste des fiches en fonction de la collection selectionnee dans le combobox
    ''' </summary>
    Private Sub majListeFiches()
        ' Vide d'abord le tableau
        tblListeFiches.Rows.Clear()

        ' Ajoute l'entete du tableau
        tblListeFiches.Rows.Add(getHeaderRow)

        ' Si une collection est selectionnee dans la combobox, on ajoute toutes les fiches de la collection
        If cboCollections.Items.Count <> 0 Then
            Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBd2)
            dbCon.Open()
            Dim typeCol As Entites.Collection.Type = Entites.Collection.Type.Parse(GetType(Entites.Collection.Type), cboCollections.SelectedValue)
            Dim collection As Entites.Collection = New Entites.Collection(m_idMembre, typeCol, dbCon)
            dbCon.Close()
            For i As Integer = 0 To collection.ListeFiches.Count - 1
                tblListeFiches.Rows.Add(getFicheRow(Collection.ListeFiches.Item(i)))
            Next
        End If

        ' Ajoute une derniere ligne pour ajouter une nouvelle fiche a la collection
        Dim rowBtnAjouter As TableRow = New TableRow
        Dim cellBtnAjouter As TableCell = New TableCell
        Dim btnAjouter As Button = New Button
        If isAdmin And Not IsNothing(pseudo) Then
            btnAjouter.PostBackUrl = "MembreEditerFiche.aspx?idFiche=-1&pseudo=" & pseudo
        Else
            btnAjouter.PostBackUrl = "MembreEditerFiche.aspx?idFiche=-1"
        End If
        btnAjouter.Text = "Ajouter une nouvelle fiche"
        cellBtnAjouter.Controls.Add(btnAjouter)
        cellBtnAjouter.ColumnSpan = 13
        rowBtnAjouter.Cells.Add(cellBtnAjouter)
        tblListeFiches.Rows.Add(rowBtnAjouter)
    End Sub

    ''' <summary>
    ''' Retourne la ligne d'entete du tableau des fiches
    ''' </summary>
    Private Function getHeaderRow() As TableHeaderRow
        Dim rowEntete As TableHeaderRow = New TableHeaderRow
        rowEntete.CssClass = "membreGererCollectionsTableListeFichesHeader"

        Dim cellNomEntete As TableCell = New TableCell()
        Dim lblNomEntete As Label = New Label()
        lblNomEntete.Text = "Nom"
        cellNomEntete.Controls.Add(lblNomEntete)
        rowEntete.Cells.Add(cellNomEntete)

        Dim cellPrenomEntete As TableCell = New TableCell()
        Dim lblPrenomEntete As Label = New Label()
        lblPrenomEntete.Text = "Prenom"
        cellPrenomEntete.Controls.Add(lblPrenomEntete)
        rowEntete.Cells.Add(cellPrenomEntete)

        Dim cellEquipeEntete As TableCell = New TableCell()
        Dim lblEquipeEntete As Label = New Label()
        lblEquipeEntete.Text = "Equipe"
        cellEquipeEntete.Controls.Add(lblEquipeEntete)
        rowEntete.Cells.Add(cellEquipeEntete)

        Dim cellNumeroEntete As TableCell = New TableCell()
        Dim lblNumeroEntete As Label = New Label()
        lblNumeroEntete.Text = "Numero"
        cellNumeroEntete.Controls.Add(lblNumeroEntete)
        rowEntete.Cells.Add(cellNumeroEntete)

        Dim cellPositionEntete As TableCell = New TableCell()
        Dim lblPositionEntete As Label = New Label()
        lblPositionEntete.Text = "Position"
        cellPositionEntete.Controls.Add(lblPositionEntete)
        rowEntete.Cells.Add(cellPositionEntete)

        Dim cellRecrueEntete As TableCell = New TableCell()
        Dim lblRecrueEntete As Label = New Label()
        lblRecrueEntete.Text = "Recrue"
        cellRecrueEntete.Controls.Add(lblRecrueEntete)
        rowEntete.Cells.Add(cellRecrueEntete)

        Dim cellEtatEntete As TableCell = New TableCell()
        Dim lblEtatEntete As Label = New Label()
        lblEtatEntete.Text = "Etat"
        cellEtatEntete.Controls.Add(lblEtatEntete)
        rowEntete.Cells.Add(cellEtatEntete)

        Dim cellValeurEntete As TableCell = New TableCell()
        Dim lblValeurEntete As Label = New Label()
        lblValeurEntete.Text = "Valeur"
        cellValeurEntete.Controls.Add(lblValeurEntete)
        rowEntete.Cells.Add(cellValeurEntete)

        Dim cellEditeurEntete As TableCell = New TableCell()
        Dim lblEditeurEntete As Label = New Label()
        lblEditeurEntete.Text = "Editeur"
        cellEditeurEntete.Controls.Add(lblEditeurEntete)
        rowEntete.Cells.Add(cellEditeurEntete)

        Dim cellAnneeEntete As TableCell = New TableCell()
        Dim lblAnneeEntete As Label = New Label()
        lblAnneeEntete.Text = "Année"
        cellAnneeEntete.Controls.Add(lblAnneeEntete)
        rowEntete.Cells.Add(cellAnneeEntete)

        rowEntete.Cells.Add(New TableCell)
        rowEntete.Cells.Add(New TableCell)
        rowEntete.Cells.Add(New TableCell)

        Return rowEntete
    End Function

    ''' <summary>
    ''' Retourne une ligne de tableau representant la fiche passée en parametre
    ''' </summary>
    Private Function getFicheRow(fiche As Entites.Fiche) As TableRow
        Dim row As TableRow = New TableRow

        Dim cellNom As TableCell = New TableCell
        Dim labNom As Label = New Label
        labNom.Text = fiche.NomJoueur
        cellNom.Controls.Add(labNom)
        row.Cells.Add(cellNom)

        Dim cellPrenom = New TableCell
        Dim labPrenom = New Label()
        labPrenom.Text = fiche.PrenomJoueur
        cellPrenom.Controls.Add(labPrenom)
        row.Cells.Add(cellPrenom)

        Dim cellEquipe = New TableCell
        Dim labEquipe = New Label()
        labEquipe.Text = fiche.Equipe.Nom
        cellEquipe.Controls.Add(labEquipe)
        row.Cells.Add(cellEquipe)

        Dim cellNumero = New TableCell
        Dim labNumero = New Label()
        labNumero.Text = fiche.Numero
        cellNumero.Controls.Add(labNumero)
        row.Cells.Add(cellNumero)

        Dim cellPosition = New TableCell
        Dim labPosition = New Label()
        labPosition.Text = fiche.Position
        cellPosition.Controls.Add(labPosition)
        row.Cells.Add(cellPosition)

        Dim cellRecrue = New TableCell
        Dim labRecrue = New Label()
        If fiche.Recrue Then labRecrue.Text = "Oui" Else labRecrue.Text = "Non"
        cellRecrue.Controls.Add(labRecrue)
        row.Cells.Add(cellRecrue)

        Dim cellEtat = New TableCell
        Dim labEtat = New Label()
        labEtat.Text = fiche.Etatfiche.ToString
        cellEtat.Controls.Add(labEtat)
        row.Cells.Add(cellEtat)

        Dim cellValeur = New TableCell
        Dim labValeur = New Label()
        labValeur.Text = "$" & fiche.Valeur
        cellValeur.Controls.Add(labValeur)
        row.Cells.Add(cellValeur)

        Dim cellEditeur = New TableCell
        Dim labEditeur = New Label()
        labEditeur.Text = fiche.Editeur.nomEditeur
        cellEditeur.Controls.Add(labEditeur)
        row.Cells.Add(cellEditeur)

        Dim cellAnnee = New TableCell
        Dim labAnnee = New Label()
        labAnnee.Text = fiche.DateCarte.Year
        cellAnnee.Controls.Add(labAnnee)
        row.Cells.Add(cellAnnee)

        Dim btnSupprCell As TableCell = New TableCell()
        Dim btnSuppr As Button = New Button()
        btnSuppr.Text = "Supprimer"
        btnSuppr.ID = "btnSuppr" & fiche.ID
        AddHandler btnSuppr.Click, AddressOf btnSupprFiche_Click
        btnSuppr.OnClientClick = "javascript:return confirm('Etes vous sur de vouloir supprimer cette fiche ?');"
        btnSupprCell.Controls.Add(btnSuppr)
        row.Cells.Add(btnSupprCell)

        Dim btnVoirCell As TableCell = New TableCell()
        Dim btnVoir As Button = New Button()
        btnVoir.Text = "Voir"
        btnVoir.ID = "btnVoir" & fiche.ID
        AddHandler btnVoir.Click, AddressOf btnVoirFiche_Click
        btnVoirCell.Controls.Add(btnVoir)
        row.Cells.Add(btnVoirCell)

        Dim btnEditerCell As TableCell = New TableCell()
        Dim btnEditer As Button = New Button()
        btnEditer.Text = "Editer"
        btnEditer.ID = "btnEditer" & fiche.ID
        AddHandler btnEditer.Click, AddressOf btnEditerFiche_Click
        btnEditerCell.Controls.Add(btnEditer)
        row.Cells.Add(btnEditerCell)

        Return row
    End Function

    ''' <summary>
    ''' Clic sur le bouton pour "Supprimer une fiche"
    ''' </summary>
    Private Sub btnSupprFiche_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnSuppr As Button = DirectCast(sender, Button)
        Dim idFiche As String = btnSuppr.ID.Substring(8)
        Entites.Fiche.Supprimer(idFiche)
        If isAdmin And Not IsNothing(pseudo) Then
            Response.Redirect("MembreGererCollections.aspx?pseudo=" & pseudo)
        Else
            Response.Redirect("MembreGererCollections.aspx")
        End If
    End Sub

    ''' <summary>
    ''' Clic sur le bouton pour "Voir le détail d'une fiche"
    ''' </summary>
    Private Sub btnVoirFiche_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnVoir As Button = DirectCast(sender, Button)
        Dim idFiche As String = btnVoir.ID.Substring(7)
        Response.Redirect("Fiche.aspx?idFiche=" & idFiche)
    End Sub

    ''' <summary>
    ''' Clic sur le bouton pour "Editer une fiche"
    ''' </summary>
    Private Sub btnEditerFiche_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnEditer As Button = DirectCast(sender, Button)
        Dim idFiche As String = btnEditer.ID.Substring(9)
        If isAdmin And Not IsNothing(pseudo) Then
            Response.Redirect("MembreEditerFiche.aspx?idFiche=" & idFiche & "&pseudo=" & pseudo)
        Else
            Response.Redirect("MembreEditerFiche.aspx?idFiche=" & idFiche)
        End If
    End Sub

End Class