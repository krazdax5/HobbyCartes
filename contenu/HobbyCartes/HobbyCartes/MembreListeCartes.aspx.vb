Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class MembreListeCartes
    Inherits System.Web.UI.Page

    Private m_sportEnCours As Entitees.Collection.Type
    Private m_membre As Entitees.Membre
    Private m_collection As Entitees.Collection
    Private m_connection As MySqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblPasDeFiche.Visible = False
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
        m_collection.chargementNouvCollection(m_sportEnCours, m_membre.id)
        m_sportEnCours = m_collection.TypeCollection

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
            Case Entitees.Collection.Type.aucun
                Return False
        End Select
        Return True
    End Function

    Private Function chargementListe(placeHolder As PlaceHolder) As Boolean
        'Détermination de l'existance d'une liste de fiche dans la collection
        If Not m_collection.ListeFiches Is Nothing Then
            placeHolder.Controls.Clear()

            'Affichage de chaque fiche en version abrégée
            For Each fiche In m_collection.ListeFiches
                'Nouvelle division
                Dim nouvDiv As New HtmlGenericControl("div")
                nouvDiv.Attributes.Add("class", "listeFiches")
                nouvDiv.ID = fiche.ID.ToString

                'Image de la fiche
                Dim nouvImgAvant As New Image()
                nouvImgAvant.ImageUrl = fiche.ImageAvant
                nouvImgAvant.Attributes.Add("alt", "imgAvant" + fiche.ID.ToString)
                nouvImgAvant.Width = 100
                nouvImgAvant.Height = 125
                nouvDiv.Controls.Add(nouvImgAvant)

                'Prénom et nom
                Dim nouvNom As New HyperLink()
                nouvNom.Attributes.Add("class", "lnkbtnNomFiches")
                nouvNom.ID = "lnkbtnNom*" + fiche.ID.ToString
                nouvNom.Text = fiche.NomJoueur + ", " + fiche.PrenomJoueur + " "
                nouvNom.NavigateUrl = "Fiche.aspx?idFiche=" + fiche.ID.ToString
                nouvDiv.Controls.Add(nouvNom)

                'Année de la carte
                Dim nouvAnnee As New Label()
                nouvAnnee.Attributes.Add("class", "lblAnneeFiches")
                nouvAnnee.ID = "lblAnneeCarte" + fiche.ID.ToString
                nouvAnnee.Text = "Année: " + fiche.DateCarte.Year.ToString + " "
                nouvDiv.Controls.Add(nouvAnnee)

                'Éditeur de la carte
                Dim nouvEditeur As New Label()
                nouvEditeur.Attributes.Add("class", "lblEditeurFiches")
                nouvEditeur.ID = "lblEditeur" + fiche.ID.ToString
                nouvEditeur.Text = "Éditeur: " + fiche.Editeur.NomEditeur + " "
                nouvDiv.Controls.Add(nouvEditeur)

                'Valeur de la carte
                Dim nouvValeur As New Label()
                nouvValeur.Attributes.Add("class", "lblValeurFiches")
                nouvValeur.ID = "lblValeur" + fiche.ID.ToString
                nouvValeur.Text = "Valeur: " + FormatCurrency(fiche.Valeur, 2) + "CAD"
                nouvDiv.Controls.Add(nouvValeur)

                'Affichage de la fiche abrégée
                placeHolder.Controls.Add(nouvDiv)
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

    Protected Sub lnkbtnHockey_click(sender As Object, e As EventArgs) Handles lnkbtnHockey.Click
        m_sportEnCours = Entitees.Collection.Type.Hockey
        If Not changementSport() Then
            changerVisibilite(Entitees.Collection.Type.Hockey, True)
        End If
    End Sub

    Protected Sub lnkbtnBaseball_click(sender As Object, e As EventArgs) Handles lnkbtnBaseball.Click
        m_sportEnCours = Entitees.Collection.Type.Baseball
        If Not changementSport() Then
            changerVisibilite(Entitees.Collection.Type.Baseball, True)
        End If
    End Sub

    Protected Sub lnkbtnBasketball_click(sender As Object, e As EventArgs) Handles lnkbtnBasketball.Click
        m_sportEnCours = Entitees.Collection.Type.Basketball
        If Not changementSport() Then
            changerVisibilite(Entitees.Collection.Type.Basketball, True)
        End If
    End Sub

    Protected Sub lnkbtnFootball_click(sender As Object, e As EventArgs) Handles lnkbtnFootball.Click
        m_sportEnCours = Entitees.Collection.Type.Football
        If Not changementSport() Then
            changerVisibilite(Entitees.Collection.Type.Football, True)
        End If
    End Sub

    Protected Sub page_unload(sender As Object, e As EventArgs) Handles Me.Unload
        m_connection.Close()
    End Sub

End Class