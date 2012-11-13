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
    End Sub

    ''' <summary>
    ''' Retourne une ligne de tableau representant la fiche passée en parametre
    ''' </summary>
    Private Function getFicheRow(fiche As Entites.Fiche) As TableRow
        Dim row As TableRow = New TableRow

        Dim cell As TableCell = New TableCell
        Dim lab As Label = New Label()
        lab.Text = fiche.NomJoueur
        cell.Controls.Add(lab)
        row.Cells.Add(cell)

        cell = New TableCell
        lab = New Label()
        lab.Text = fiche.PrenomJoueur
        cell.Controls.Add(lab)
        row.Cells.Add(cell)

        cell = New TableCell
        lab = New Label()
        lab.Text = fiche.Etatfiche.ToString
        cell.Controls.Add(lab)
        row.Cells.Add(cell)

        cell = New TableCell
        lab = New Label()
        lab.Text = fiche.Numero
        cell.Controls.Add(lab)
        row.Cells.Add(cell)

        cell = New TableCell
        lab = New Label()
        lab.Text = fiche.Position
        cell.Controls.Add(lab)
        row.Cells.Add(cell)

        Return row
    End Function

End Class