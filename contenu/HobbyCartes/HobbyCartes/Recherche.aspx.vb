Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Recherche
    Inherits System.Web.UI.Page

    Private m_connection As MySqlConnection
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_connection = New MySqlConnection(My.Resources.StringConnexionBdd)
        m_connection.Open()
    End Sub

    Private Sub Rechercher() Handles btnRechercher.Click
        Dim Fiches As List(Of Entites.Fiche) = Entites.Fiche.Rechercher(txtRecherche.Text, m_connection)
        Dim Nombre As Integer = Fiches.Count

        If Fiches IsNot Nothing Then
            For Each Fiche In Fiches
                Dim nouvDiv As New HtmlGenericControl("div")
                nouvDiv.Attributes.Add("class", "FichesRecherche")

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
                nouvNom.Attributes.Add("class", "lnkbtnNomFichesRechercher")
                nouvNom.ID = "lnkbtnNom*" + Fiche.ID.ToString
                nouvNom.Text = Fiche.NomJoueur + ", " + Fiche.PrenomJoueur + " "
                nouvNom.NavigateUrl = "Fiche.aspx?idFiche=" + Fiche.ID.ToString
                nouvDiv.Controls.Add(nouvNom)

                'Année de la carte
                Dim nouvAnnee As New Label()
                nouvAnnee.Attributes.Add("class", "lblAnneeFichesRechercher")
                nouvAnnee.ID = "lblAnneeCarte" + Fiche.ID.ToString
                nouvAnnee.Text = "Année: " + Fiche.DateCarte.Year.ToString + " "
                nouvDiv.Controls.Add(nouvAnnee)

                'Éditeur de la carte
                Dim nouvEditeur As New Label()
                nouvEditeur.Attributes.Add("class", "lblEditeurFichesRechercher")
                nouvEditeur.ID = "lblEditeur" + Fiche.ID.ToString
                nouvEditeur.Text = "Éditeur: " + Fiche.Editeur.NomEditeur + " "
                nouvDiv.Controls.Add(nouvEditeur)

                'Valeur de la carte
                Dim nouvValeur As New Label()
                nouvValeur.Attributes.Add("class", "lblValeurFichesRechercher")
                nouvValeur.ID = "lblValeur" + Fiche.ID.ToString
                nouvValeur.Text = "Valeur: " + FormatCurrency(Fiche.Valeur, 2) + "CAD"
                nouvDiv.Controls.Add(nouvValeur)

                'Date de publication
                Dim nouvDatePub As New Label()
                nouvDatePub.Attributes.Add("class", "lblDatePubFicheRechercher")
                nouvDatePub.ID = "lblDatePub" + Fiche.ID.ToString
                nouvDatePub.Text = "Date de publication: " + Fiche.DatePublication.ToString
                nouvDiv.Controls.Add(nouvDatePub)

                'Détenteur
                Dim nouvMembre As New HyperLink()
                nouvMembre.Attributes.Add("class", "lblMembreFichesRechercher")
                nouvMembre.ID = "lblMembre" + Fiche.ID.ToString
                nouvMembre.Text = "Détenteur: " + Fiche.PseudoDetenteur()
                nouvMembre.NavigateUrl = "Membreinfo.aspx?pseudo=" + Fiche.PseudoDetenteur()
                nouvDiv.Controls.Add(nouvMembre)

                phRechercheFiche.Controls.Add(nouvDiv)
            Next
        End If
    End Sub

End Class