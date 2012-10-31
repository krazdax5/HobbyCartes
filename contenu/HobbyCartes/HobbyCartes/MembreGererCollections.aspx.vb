﻿Imports MySql.Data.MySqlClient

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
    ''' Chargement de la page
    ''' </summary>
    Protected Sub Page_Load() Handles Me.Load
        ' Recupere l'id du membre et charge toutes ses collections
        Dim idMembre As Integer = Request.QueryString("idMembre")
        collections = New Dictionary(Of Entites.Collection.Type, Entites.Collection)
        Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
        dbCon.Open()
        For Each typeCol As Entites.Collection.Type In System.Enum.GetValues(GetType(Entites.Collection.Type))
            If Not Entites.Collection.existe(idMembre, typeCol, dbCon) Then Continue For
            collections.Add(typeCol, New Entites.Collection(idMembre, typeCol, dbCon))
            comboCollections.Items.Add(typeCol.ToString)
        Next
        dbCon.Close()

        ' Supprimer la collection ?
        ' ' Fenetre de confirmation, pis DROP TABLE ALL CASCADE BULLSHIT DESTROY EVERYTHING

        ' Ajouter une nouvelle collection ? 
        ' ' Proposer le type de collection, pis add en bdd

        ' Affiche toutes les cartes de la collection sous le bouton "ajouter une nouvelle collection"
        ' On click sur une carte, detail de la carte


    End Sub

End Class