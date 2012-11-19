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

    ''' <summary>
    ''' Initialisation de la page
    ''' </summary>
    Protected Sub Page_Init() Handles Me.Init
        Accueil.initSession(Session)

        ' Vérifie si l'utilisateur est connecté
        Dim connected As Boolean = Boolean.Parse(Session("connected"))
        If Not connected Then Erreur.afficherErreur("Vous devez être connecté pour gérer vos collections.", Page)

        ' Recupere l'id du membre et charge toutes ses collections
        m_idMembre = Integer.Parse(Session("idMembre"))
        ' collections = New Dictionary(Of Entites.Collection.Type, Entites.Collection)
        Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
        dbCon.Open()
        For Each typeCol As Entites.Collection.Type In System.Enum.GetValues(GetType(Entites.Collection.Type))
            If Not Entites.Collection.existe(m_idMembre, typeCol) Then
                cboCollectionsDisponibles.Items.Add(typeCol.ToString)
            Else
                ' collections.Add(typeCol, New Entites.Collection(idMembre, typeCol, dbCon))
                cboCollections.Items.Add(typeCol.ToString)
            End If
        Next
        dbCon.Close()
    End Sub

    ''' <summary>
    ''' Chargement de la page
    ''' </summary>
    Protected Sub Page_Load() Handles Me.Load
        ' Vérifie si l'utilisateur est connecté
        Dim connected As Boolean = Boolean.Parse(Session("connected"))
        If Not connected Then Erreur.afficherErreur("Vous devez être connecté pour gérer vos collections.", Page)

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
        Response.Redirect("MembreGererCollections.aspx")
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
        Response.Redirect("MembreGererCollections.aspx")
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
            Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
            dbCon.Open()
            Dim typeCol As Entites.Collection.Type = Entites.Collection.Type.Parse(GetType(Entites.Collection.Type), cboCollections.SelectedValue)
            Dim Collection As Entites.Collection = New Entites.Collection(m_idMembre, typeCol, dbCon)
            dbCon.Close()
            For i As Integer = 0 To Collection.ListeFiches.Count - 1
                tblListeFiches.Rows.Add(getFicheRow(Collection.ListeFiches.Item(i)))
            Next
        End If

        ' Ajoute une derniere ligne pour ajouter une nouvelle fiche a la collection
        Dim rowBtnAjouter As TableRow = New TableRow
        Dim cellBtnAjouter As TableCell = New TableCell
        Dim btnAjouter As Button = New Button
        btnAjouter.Text = "Ajouter une fiche"
        cellBtnAjouter.Controls.Add(btnAjouter)
        cellBtnAjouter.ColumnSpan = 11
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

        Dim cellEtatEntete As TableCell = New TableCell()
        Dim lblEtatEntete As Label = New Label()
        lblEtatEntete.Text = "Etat"
        cellEtatEntete.Controls.Add(lblEtatEntete)
        rowEntete.Cells.Add(cellEtatEntete)

        Dim cellNumeroEntete As TableCell = New TableCell()
        Dim lblNumeroEntete As Label = New Label()
        lblNumeroEntete.Text = "Numero"
        cellNumeroEntete.Controls.Add(lblNumeroEntete)
        rowEntete.Cells.Add(cellNumeroEntete)

        Dim cellRecrueEntete As TableCell = New TableCell()
        Dim lblRecrueEntete As Label = New Label()
        lblRecrueEntete.Text = "Recrue"
        cellRecrueEntete.Controls.Add(lblRecrueEntete)
        rowEntete.Cells.Add(cellRecrueEntete)

        Dim cellValeurEntete As TableCell = New TableCell()
        Dim lblValeurEntete As Label = New Label()
        lblValeurEntete.Text = "Valeur"
        cellValeurEntete.Controls.Add(lblValeurEntete)
        rowEntete.Cells.Add(cellValeurEntete)

        Dim cellEquipeEntete As TableCell = New TableCell()
        Dim lblEquipeEntete As Label = New Label()
        lblEquipeEntete.Text = "Equipe"
        cellEquipeEntete.Controls.Add(lblEquipeEntete)
        rowEntete.Cells.Add(cellEquipeEntete)

        Dim cellEditeurEntete As TableCell = New TableCell()
        Dim lblEditeurEntete As Label = New Label()
        lblEditeurEntete.Text = "Editeur"
        cellEditeurEntete.Controls.Add(lblEditeurEntete)
        rowEntete.Cells.Add(cellEditeurEntete)

        Dim cellPositionEntete As TableCell = New TableCell()
        Dim lblPositionEntete As Label = New Label()
        lblPositionEntete.Text = "Position"
        cellPositionEntete.Controls.Add(lblPositionEntete)
        rowEntete.Cells.Add(cellPositionEntete)

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
        Dim labNom As Label = New Label()
        labNom.Text = fiche.NomJoueur
        cellNom.Controls.Add(labNom)
        row.Cells.Add(cellNom)

        Dim cellPrenom = New TableCell
        Dim labPrenom = New Label()
        labPrenom.Text = fiche.PrenomJoueur
        cellPrenom.Controls.Add(labPrenom)
        row.Cells.Add(cellPrenom)

        Dim cellEtat = New TableCell
        Dim labEtat = New Label()
        labEtat.Text = fiche.Etatfiche.ToString
        cellEtat.Controls.Add(labEtat)
        row.Cells.Add(cellEtat)

        Dim cellNumero = New TableCell
        Dim labNumero = New Label()
        labNumero.Text = fiche.Numero
        cellNumero.Controls.Add(labNumero)
        row.Cells.Add(cellNumero)

        Dim cellRecrue = New TableCell
        Dim labRecrue = New Label()
        labNumero.Text = fiche.Recrue
        cellRecrue.Controls.Add(labNumero)
        row.Cells.Add(cellRecrue)

        Dim cellValeur = New TableCell
        Dim labValeur = New Label()
        labValeur.Text = fiche.Valeur
        cellValeur.Controls.Add(labValeur)
        row.Cells.Add(cellValeur)

        Dim cellEquipe = New TableCell
        Dim labEquipe = New Label()
        labEquipe.Text = fiche.Equipe
        cellEquipe.Controls.Add(labEquipe)
        row.Cells.Add(cellEquipe)

        Dim cellEditeur = New TableCell
        Dim labEditeur = New Label()
        labEditeur.Text = fiche.Editeur.nomEditeur
        cellEditeur.Controls.Add(labEditeur)
        row.Cells.Add(cellEditeur)

        Dim cellPosition = New TableCell
        Dim labPosition = New Label()
        labPosition.Text = fiche.Position
        cellPosition.Controls.Add(labPosition)
        row.Cells.Add(cellPosition)

        Dim btnSupprCell As TableCell = New TableCell()
        Dim btnSuppr As Button = New Button()
        btnSuppr.Text = "Supprimer"
        btnSuppr.ID = "btnSuppr" & fiche.ID
        AddHandler btnSuppr.Click, AddressOf btnSuppr_Click
        btnSuppr.OnClientClick = "javascript:return confirm('Etes vous sur de vouloir supprimer cette fiche ?');"
        btnSupprCell.Controls.Add(btnSuppr)
        row.Cells.Add(btnSupprCell)

        Dim btnVoirCell As TableCell = New TableCell()
        Dim btnVoir As Button = New Button()
        btnVoir.Text = "Voir la fiche"
        btnVoir.ID = "btnVoir" & fiche.ID
        AddHandler btnVoir.Click, AddressOf btnVoir_Click
        btnVoirCell.Controls.Add(btnVoir)
        row.Cells.Add(btnVoirCell)

        Return row
    End Function

    ''' <summary>
    ''' Clic sur le bouton pour "Supprimer une fiche"
    ''' </summary>
    Private Sub btnSuppr_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnSuppr As Button = DirectCast(sender, Button)
        Dim idFiche As String = btnSuppr.ID.Substring(8)
        Entites.Fiche.supprimer(idFiche)
        Response.Redirect("MembreGererCollections.aspx")
    End Sub

    ''' <summary>
    ''' Clic sur le bouton pour "Voir le détail d'une fiche"
    ''' </summary>
    Private Sub btnVoir_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnVoir As Button = DirectCast(sender, Button)
        Dim idFiche As String = btnVoir.ID.Substring(7)
        Response.Redirect("Fiche.aspx?idFiche=" & idFiche)
    End Sub
End Class