'--------------------------------------------------------------------------
' Titre: MembreListeCartes.aspx.vb
' Auteur: Charles Levesque
' Date: Octobre 2012
'-------------------------------------------------------------------------

Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class MembreListeCartes
    Inherits System.Web.UI.Page

    Private m_membre As Entites.Membre
    Private m_collection As Entites.Collection
    Private m_connection As MySqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblPasDeFiche.Visible = False
        m_connection = New MySqlConnection(My.Resources.StringConnexionBd2)
        m_connection.Open()

        'Détermination du membre en cours
        Dim id As Integer
        Dim accesParId As Boolean = False

        id = Entites.Membre.getIDbyPseudo(Request.QueryString("pseudo"), m_connection)

        'Vérifie si la page est accédée par pseudo
        If Not id.Equals(-1) Then
            m_membre = New Entites.Membre(id, m_connection)
        Else
            'Ou par identificateur
            If Boolean.Parse(Session("connected")) Then
                id = Integer.Parse(Session("idMembre"))
                m_membre = New Entites.Membre(id, m_connection)
                accesParId = True
            Else
                Erreur.afficherErreur(Me)
            End If
        End If

        chargerListe(Entites.Collection.Type.hockey)
    End Sub

    Private Sub chargerListe(sport As Entites.Collection.Type)
        Dim col As Entites.Collection = New Entites.Collection(m_membre.id, sport, m_connection)
        phMembreListeCartes.Controls.Clear()

        If col.ListeFiches.Count = 0 Then
            lblPasDeFiche.Text = "Il n'y a pas de fiche dans cette collection"
            lblPasDeFiche.Visible = True
        Else
            lblPasDeFiche.Visible = False
            For Each Fiche In col.ListeFiches
                Dim nouvDiv As New HtmlGenericControl("div")
                nouvDiv.Attributes.Add("class", "listeFiches")

                'Image avant
                Dim nouvA As New HtmlGenericControl("a")
                nouvA.Attributes.Add("href", "Fiche.aspx?idFiche=" + Fiche.ID.ToString)
                Dim nouvImage As New Image()
                nouvImage.ID = "img" + Fiche.ID.ToString
                nouvImage.ImageUrl = Fiche.ImageAvant
                nouvImage.Attributes.Add("alt", "imgAvant" + Fiche.ID.ToString)
                nouvImage.Width = 100
                nouvImage.Height = 125
                nouvA.Controls.Add(nouvImage)
                nouvDiv.Controls.Add(nouvA)

                'Prénom et nom
                Dim nouvNom As New HyperLink()
                nouvNom.Attributes.Add("class", "lnkbtnNomFiches")
                nouvNom.ID = "lnkbtnNom*" + Fiche.ID.ToString
                nouvNom.Text = Fiche.NomJoueur + ", " + Fiche.PrenomJoueur + " "
                nouvNom.NavigateUrl = "Fiche.aspx?idFiche=" + Fiche.ID.ToString
                nouvDiv.Controls.Add(nouvNom)

                'Année de la carte
                Dim nouvAnnee As New Label()
                nouvAnnee.Attributes.Add("class", "lblAnneeFiches")
                nouvAnnee.ID = "lblAnneeCarte" + Fiche.ID.ToString
                nouvAnnee.Text = "Année: " + Fiche.DateCarte.Year.ToString + " "
                nouvDiv.Controls.Add(nouvAnnee)

                'Éditeur de la carte
                Dim nouvEditeur As New Label()
                nouvEditeur.Attributes.Add("class", "lblEditeurFiches")
                nouvEditeur.ID = "lblEditeur" + Fiche.ID.ToString
                nouvEditeur.Text = "Éditeur: " + Fiche.Editeur.nomEditeur + " "
                nouvDiv.Controls.Add(nouvEditeur)

                'Valeur de la carte
                Dim nouvValeur As New Label()
                nouvValeur.Attributes.Add("class", "lblValeurFiches")
                nouvValeur.ID = "lblValeur" + Fiche.ID.ToString
                nouvValeur.Text = "Valeur: " + FormatCurrency(Fiche.Valeur, 2) + "CAD"
                nouvDiv.Controls.Add(nouvValeur)

                phMembreListeCartes.Controls.Add(nouvDiv)
            Next
        End If
    End Sub

    Protected Sub lnkbtnHockey_click(sender As Object, e As EventArgs) Handles lnkbtnHockey.Click
        chargerListe(Entites.Collection.Type.hockey)
    End Sub

    Protected Sub lnkbtnBaseball_click(sender As Object, e As EventArgs) Handles lnkbtnBaseball.Click
        chargerListe(Entites.Collection.Type.baseball)
    End Sub

    Protected Sub lnkbtnBasketball_click(sender As Object, e As EventArgs) Handles lnkbtnBasketball.Click
        chargerListe(Entites.Collection.Type.basketball)
    End Sub

    Protected Sub lnkbtnFootball_click(sender As Object, e As EventArgs) Handles lnkbtnFootball.Click
        chargerListe(Entites.Collection.Type.football)
    End Sub

    Protected Sub page_unload(sender As Object, e As EventArgs) Handles Me.Unload
        m_connection.Close()
    End Sub

End Class