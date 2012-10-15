Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class MembreListeCartes
    Inherits System.Web.UI.Page

    Private m_sportEnCours As Entitees.Collection.Type
    Private m_membre As Entitees.Membre
    Private m_collection As Entitees.Collection
    Private m_connection As MySqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_connection = New MySqlConnection("Server=localhost;Database=test;Uid=root;Pwd=toor;")
        m_connection.Open()

        'Détermination du membre en cours
        m_membre = New Entitees.Membre(1, m_connection)
        'Création de la collection du membre si existe
        m_collection = New Entitees.Collection(m_membre.id, m_connection)
        m_sportEnCours = m_collection.TypeCollection
        If Not changementSport() Then
            changerVisibilite(Entitees.Collection.Type.Hockey, True)
        End If
    End Sub

    Private Function changementSport() As Boolean
        'Détermintation de la liste à afficher
        Select Case m_sportEnCours
            Case Entitees.Collection.Type.Baseball
                changerVisibilite(Entitees.Collection.Type.Baseball, False)

                'Chargement de la liste de fiches pour Baseball
                If Not chargementListe(phBaseball) Then
                    lblPasDeFiche.Visible = True
                End If
            Case Entitees.Collection.Type.Basketball
                changerVisibilite(Entitees.Collection.Type.Basketball, False)

                'Chargement de la liste de fiches pour Basketball
                If Not chargementListe(phBasketball) Then
                    lblPasDeFiche.Visible = True
                End If
            Case Entitees.Collection.Type.Football
                changerVisibilite(Entitees.Collection.Type.Football, False)

                'Chargement de la liste de fiches pour Football
                If Not chargementListe(phFootball) Then
                    lblPasDeFiche.Visible = True
                End If
            Case Entitees.Collection.Type.Hockey
                changerVisibilite(Entitees.Collection.Type.Hockey, False)

                'Chargement de la liste de fiches pour Hockey
                If Not chargementListe(phHockey) Then
                    lblPasDeFiche.Visible = True
                End If
            Case Nothing
                Return False
        End Select
        Return True
    End Function

    Private Function chargementListe(placeHolder As PlaceHolder) As Boolean
        'Détermination de l'existance d'une liste de fiche dans la collection
        If Not m_collection.ListeFiches.Equals(Nothing) Then
            placeHolder.Controls.Clear()

            'Affichage de chaque fiche en version abrégée
            For Each fiche In m_collection.ListeFiches
                'TODO: Afficher la liste
            Next
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub changerVisibilite(ByVal sport As Entitees.Collection.Type, ByVal isSportNothing As Boolean)
        Select Case sport
            Case Entitees.Collection.Type.Baseball
                phBaseball.Visible = True
                phBasketball.Visible = False
                phFootball.Visible = False
                phHockey.Visible = False

                If isSportNothing Then
                    btnAjouterBaseball.Visible = True
                    btnAjouterBasketball.Visible = False
                    btnAjouterFootball.Visible = False
                    btnAjouterHockey.Visible = False
                End If
            Case Entitees.Collection.Type.Basketball
                phBaseball.Visible = False
                phBasketball.Visible = True
                phFootball.Visible = False
                phHockey.Visible = False

                If isSportNothing Then
                    btnAjouterBaseball.Visible = False
                    btnAjouterBasketball.Visible = True
                    btnAjouterFootball.Visible = False
                    btnAjouterHockey.Visible = False
                End If
            Case Entitees.Collection.Type.Football
                phBaseball.Visible = False
                phBasketball.Visible = False
                phFootball.Visible = True
                phHockey.Visible = False

                If isSportNothing Then
                    btnAjouterBaseball.Visible = False
                    btnAjouterBasketball.Visible = False
                    btnAjouterFootball.Visible = True
                    btnAjouterHockey.Visible = False
                End If
            Case Entitees.Collection.Type.Hockey
                phBaseball.Visible = False
                phBasketball.Visible = False
                phFootball.Visible = False
                phHockey.Visible = True

                If isSportNothing Then
                    btnAjouterBaseball.Visible = False
                    btnAjouterBasketball.Visible = False
                    btnAjouterFootball.Visible = False
                    btnAjouterHockey.Visible = True
                End If
        End Select
    End Sub

    Protected Sub ongletHockey_click(sender As Object, e As EventArgs)
        m_collection.chargementNouvCollection(Entitees.Collection.Type.Hockey, m_membre.id)
        m_sportEnCours = m_collection.TypeCollection

        If Not changementSport() Then
            changerVisibilite(Entitees.Collection.Type.Hockey, True)
        End If
    End Sub

    Protected Sub ongletBaseball_click(sender As Object, e As EventArgs)
        m_collection.chargementNouvCollection(Entitees.Collection.Type.Baseball, m_membre.id)
        m_sportEnCours = m_collection.TypeCollection

        If Not changementSport() Then
            changerVisibilite(Entitees.Collection.Type.Baseball, True)
        End If
    End Sub

    Protected Sub ongletBasketball_click(sender As Object, e As EventArgs)
        m_collection.chargementNouvCollection(Entitees.Collection.Type.Basketball, m_membre.id)
        m_sportEnCours = m_collection.TypeCollection

        If Not changementSport() Then
            changerVisibilite(Entitees.Collection.Type.Basketball, True)
        End If
    End Sub

    Protected Sub ongletFootball_click(sender As Object, e As EventArgs)
        m_collection.chargementNouvCollection(Entitees.Collection.Type.Football, m_membre.id)
        m_sportEnCours = m_collection.TypeCollection

        If Not changementSport() Then
            changerVisibilite(Entitees.Collection.Type.Football, True)
        End If
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Unload
        m_connection.Close()
    End Sub

End Class