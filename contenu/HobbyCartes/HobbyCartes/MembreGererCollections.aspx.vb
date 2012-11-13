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
    Dim idMembre As Integer

    ''' <summary>
    ''' Initialisation de la page
    ''' </summary>
    Protected Sub Page_Init() Handles Me.Init
        Accueil.initSession(Session)

        ' Vérifie si l'utilisateur est connecté
        Dim connected As Boolean = Boolean.Parse(Session("connected"))
        If Not connected Then Erreur.afficherErreur("Vous devez être connecté pour gérer vos collections.", Page)

        ' Recupere l'id du membre et charge toutes ses collections
        idMembre = Integer.Parse(Session("idMembre"))
        ' collections = New Dictionary(Of Entites.Collection.Type, Entites.Collection)
        Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
        dbCon.Open()
        For Each typeCol As Entites.Collection.Type In System.Enum.GetValues(GetType(Entites.Collection.Type))
            If Not Entites.Collection.existe(idMembre, typeCol) Then
                comboCollectionsDisponibles.Items.Add(typeCol.ToString)
            Else
                ' collections.Add(typeCol, New Entites.Collection(idMembre, typeCol, dbCon))
                comboCollections.Items.Add(typeCol.ToString)
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

        If comboCollections.Items.Count <> 0 Then
            Dim type As Entites.Collection.Type = Entites.Collection.Type.Parse(GetType(Entites.Collection.Type), comboCollections.SelectedValue)
            remplirListeFiches(Entites.Collection.getIdCollectionParTypeEtMembre(idMembre, type))
        End If
        ' On click sur une carte, detail de la carte

    End Sub

    Private Sub majBoutons()
        If comboCollections.Items.Count = 0 Then
            btnSupprimerCollection.Enabled = False
        Else
            btnSupprimerCollection.Enabled = True
        End If
        If comboCollectionsDisponibles.Items.Count = 0 Then
            btnAjouterCollection.Enabled = False
        Else
            btnAjouterCollection.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Clic sur le bouton "Supprimer la collection"
    ''' </summary>
    Protected Sub BtnSupprimerCollection_Click() Handles btnSupprimerCollection.Click
        Dim oldType As Entites.Collection.Type = Entites.Collection.Type.Parse(GetType(Entites.Collection.Type), comboCollections.SelectedValue)
        Entites.Collection.supprimer(idMembre, oldType)
        comboCollectionsDisponibles.Items.Add(comboCollections.SelectedValue)
        comboCollections.Items.Remove(comboCollections.SelectedValue)
        majBoutons()
        Response.Redirect("MembreGererCollections.aspx")
    End Sub

    ''' <summary>
    ''' Clic sur le bouton "Ajouter une collection"
    ''' </summary>
    Protected Sub BtnAjouterCollection_Click() Handles btnAjouterCollection.Click
        Dim newType As Entites.Collection.Type = Entites.Collection.Type.Parse(GetType(Entites.Collection.Type), comboCollectionsDisponibles.SelectedValue)
        Entites.Collection.ajouter(idMembre, newType)
        comboCollections.Items.Add(comboCollectionsDisponibles.SelectedValue)
        comboCollectionsDisponibles.Items.Remove(comboCollectionsDisponibles.SelectedValue)
        majBoutons()
        Response.Redirect("MembreGererCollections.aspx")
    End Sub

    ''' <summary>
    ''' Rempli le tableau de la liste des fiches avec une collection
    ''' </summary>
    Private Sub remplirListeFiches(idCollection As Integer)
        Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
        dbCon.Open()
        Dim typeCol As Entites.Collection.Type = Entites.Collection.Type.Parse(GetType(Entites.Collection.Type), comboCollections.SelectedValue)
        Dim Collection As Entites.Collection = New Entites.Collection(idMembre, typeCol, dbCon)
        dbCon.Close()
        For i As Integer = 0 To Collection.ListeFiches.Count - 1
            tableListeFiches.Rows.Add(getFicheRow(Collection.ListeFiches.Item(i)))
        Next
        ' Ajoute une ligne pour ajouter une fiche a la collection
        Dim rowBtnAjouter As TableRow = New TableRow
        Dim cellBtnAjouter As TableCell = New TableCell
        Dim btnAjouter As Button = New Button
        btnAjouter.Text = "Ajouter une fiche"
        cellBtnAjouter.Controls.Add(btnAjouter)
        cellBtnAjouter.ColumnSpan = 11
        rowBtnAjouter.Cells.Add(cellBtnAjouter)
        tableListeFiches.Rows.Add(rowBtnAjouter)
    End Sub

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

    Private Sub btnSuppr_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnSuppr As Button = DirectCast(sender, Button)
        Dim idFiche As String = btnSuppr.ID.Substring(8)
        Entites.Fiche.supprimer(idFiche)
        Response.Redirect("MembreGererCollections.aspx")
    End Sub

    Private Sub btnVoir_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnVoir As Button = DirectCast(sender, Button)
        Dim idFiche As String = btnVoir.ID.Substring(7)
        Response.Redirect("Fiche.aspx?idFiche=" & idFiche)
    End Sub
End Class