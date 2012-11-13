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
    ''' Dictionnaire des collections de cartes du membre.
    ''' </summary>
    Dim collections As Dictionary(Of Entites.Collection.Type, Entites.Collection)

    ''' <summary>
    ''' L'identifiant du membre connecté
    ''' </summary>
    Dim idMembre As Integer

    ''' <summary>
    ''' Chargement de la page
    ''' </summary>
    Protected Sub Page_Load() Handles Me.Load
        ' If IsPostBack Then Return

        ' Vérifie si l'utilisateur est connecté
        Dim connected As Boolean = Boolean.Parse(Session("connected"))
        If Not connected Then Erreur.afficherErreur("Vous devez être connecté pour gérer vos collections.", Page)

        ' Recupere l'id du membre et charge toutes ses collections
        idMembre = Integer.Parse(Session("idMembre"))
        collections = New Dictionary(Of Entites.Collection.Type, Entites.Collection)
        comboCollections.Items.Clear()
        comboCollectionsDisponibles.Items.Clear()
        Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
        dbCon.Open()
        For Each typeCol As Entites.Collection.Type In System.Enum.GetValues(GetType(Entites.Collection.Type))
            If Not Entites.Collection.existe(idMembre, typeCol) Then
                comboCollectionsDisponibles.Items.Add(typeCol.ToString)
            Else
                collections.Add(typeCol, New Entites.Collection(idMembre, typeCol, dbCon))
                comboCollections.Items.Add(typeCol.ToString)
            End If
        Next
        dbCon.Close()

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

        ' Affiche toutes les cartes de la collection sous le bouton "ajouter une nouvelle collection"
        ' On click sur une carte, detail de la carte

    End Sub

    ''' <summary>
    ''' Clic sur le bouton "Supprimer la collection"
    ''' </summary>
    Protected Sub BtnSupprimerCollection_Click() Handles btnSupprimerCollection.Click
        'collections(Entites.Collection.Type.Parse(GetType(Entites.Collection.Type), comboCollections.SelectedValue)).supprimer()
        'collections.Remove(Entites.Collection.Type.Parse(GetType(Entites.Collection.Type), comboCollections.SelectedValue))
        comboCollectionsDisponibles.Items.Add(comboCollections.SelectedValue)
        comboCollections.Items.Remove(comboCollections.SelectedValue)
    End Sub

    ''' <summary>
    ''' Clic sur le bouton "Ajouter une collection"
    ''' </summary>
    Protected Sub BtnAjouterCollection_Click() Handles btnAjouterCollection.Click
        Dim newType As Entites.Collection.Type = Entites.Collection.Type.Parse(GetType(Entites.Collection.Type), comboCollectionsDisponibles.SelectedValue)
        Entites.Collection.ajouter(idMembre, newType)
        comboCollections.Items.Add(comboCollectionsDisponibles.SelectedValue)
        comboCollectionsDisponibles.Items.Remove(comboCollectionsDisponibles.SelectedValue)
    End Sub

End Class