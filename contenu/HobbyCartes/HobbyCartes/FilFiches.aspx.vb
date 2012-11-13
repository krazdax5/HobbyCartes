'--------------------------------------------------------------------------
' Titre: FilFiches.aspx.vb
' Auteur: Charles Levesque
' Date: Octobre 2012
'-------------------------------------------------------------------------

Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class FilFiches
    Inherits System.Web.UI.Page

    Private m_connection As MySqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_connection = New MySqlConnection(My.Resources.StringConnexionBdd)
        m_connection.Open()
        chargerListe(Entites.Collection.Type.Hockey)
    End Sub

    Private Sub chargerListe(sport As Entites.Collection.Type)
        Dim fiches As List(Of Entites.Fiche) = Entites.Fiche.ListeFichesOrdonnee(sport, m_connection)
        phFilFiches.Controls.Clear()

        If fiches IsNot Nothing Then
            For Each Fiche In fiches
                Dim nouvDiv As New HtmlGenericControl("div")
                nouvDiv.Attributes.Add("class", "listeFilFiches")

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
                nouvNom.Attributes.Add("class", "lnkbtnNomFilFiches")
                nouvNom.ID = "lnkbtnNom*" + Fiche.ID.ToString
                nouvNom.Text = Fiche.NomJoueur + ", " + Fiche.PrenomJoueur + " "
                nouvNom.NavigateUrl = "Fiche.aspx?idFiche=" + Fiche.ID.ToString
                nouvDiv.Controls.Add(nouvNom)

                'Année de la carte
                Dim nouvAnnee As New Label()
                nouvAnnee.Attributes.Add("class", "lblAnneeFilFiches")
                nouvAnnee.ID = "lblAnneeCarte" + Fiche.ID.ToString
                nouvAnnee.Text = "Année: " + Fiche.DateCarte.Year.ToString + " "
                nouvDiv.Controls.Add(nouvAnnee)

                'Éditeur de la carte
                Dim nouvEditeur As New Label()
                nouvEditeur.Attributes.Add("class", "lblEditeurFilFiches")
                nouvEditeur.ID = "lblEditeur" + Fiche.ID.ToString
                nouvEditeur.Text = "Éditeur: " + Fiche.Editeur.NomEditeur + " "
                nouvDiv.Controls.Add(nouvEditeur)

                'Valeur de la carte
                Dim nouvValeur As New Label()
                nouvValeur.Attributes.Add("class", "lblValeurFilFiches")
                nouvValeur.ID = "lblValeur" + Fiche.ID.ToString
                nouvValeur.Text = "Valeur: " + FormatCurrency(Fiche.Valeur, 2) + "CAD"
                nouvDiv.Controls.Add(nouvValeur)

                'Date de publication
                Dim nouvDatePub As New Label()
                nouvDatePub.Attributes.Add("class", "lblDatePubFilFiche")
                nouvDatePub.ID = "lblDatePub" + Fiche.ID.ToString
                nouvDatePub.Text = "Date de publication: " + Fiche.DatePublication.ToString
                nouvDiv.Controls.Add(nouvDatePub)

                'Détenteur
                Dim nouvMembre As New HyperLink()
                nouvMembre.Attributes.Add("class", "lblMembreFilFiches")
                nouvMembre.ID = "lblMembre" + Fiche.ID.ToString
                nouvMembre.Text = "Détenteur: " + Fiche.PseudoDetenteur()
                nouvMembre.NavigateUrl = "Membreinfo.aspx?pseudo=" + Fiche.PseudoDetenteur()
                nouvDiv.Controls.Add(nouvMembre)

                phFilFiches.Controls.Add(nouvDiv)
            Next
        End If
    End Sub

    Protected Sub lnkbtnHockey_click(sender As Object, e As EventArgs) Handles lnkbtnHockey.Click
        chargerListe(Entites.Collection.Type.Hockey)
    End Sub

    Protected Sub lnkbtnBaseball_click(sender As Object, e As EventArgs) Handles lnkbtnBaseball.Click
        chargerListe(Entites.Collection.Type.Baseball)
    End Sub

    Protected Sub lnkbtnBasketball_click(sender As Object, e As EventArgs) Handles lnkbtnBasketball.Click
        chargerListe(Entites.Collection.Type.Basketball)
    End Sub

    Protected Sub lnkbtnFootball_click(sender As Object, e As EventArgs) Handles lnkbtnFootball.Click
        chargerListe(Entites.Collection.Type.Football)
    End Sub

    Protected Sub Page_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        m_connection.Close()
    End Sub

End Class