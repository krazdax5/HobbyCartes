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
        If Not (txtRecherche.Text = "") And Not (txtRecherche.Text = " ") Then
            RechercherFiche()
            RechercherMembre()
        Else
            MembreNonTrouve()
            FicheNonTrouve()

        End If

    End Sub

    Private Sub RechercherMembre()
        Dim Membres As List(Of Entites.Membre) = Entites.Membre.Rechercher(txtRecherche.Text, m_connection)

        If Membres IsNot Nothing Then
            If Not (Membres.Count = 0) Then
                Dim Nombre As Integer = Membres.Count
                For value As Integer = 0 To Nombre - 1
                    Dim Membre As Entites.Membre = Membres(value)
                    Dim nouvDiv As New HtmlGenericControl("div")
                    nouvDiv.Attributes.Add("class", "membreRechercher")

                    'Image
                    Dim nouvA As New HtmlGenericControl("a")
                    nouvA.Attributes.Add("href", "Membreinfo.aspx?pseudo=" + Membre.getNomUtilisateurParId(Membre.id, m_connection))

                    Dim nouvImage As New Image()
                    nouvImage.ID = "img" + Membre.id.ToString
                    nouvImage.ImageUrl = Membre.Image
                    nouvImage.Attributes.Add("alt", "imgAvant" + Membre.id.ToString)
                    nouvImage.Attributes.Add("class", "imgRecherche")
                    nouvA.Controls.Add(nouvImage)
                    nouvDiv.Controls.Add(nouvA)

                    'Nouveau Membre
                    Dim nouvMembre As New Label
                    nouvMembre.Attributes.Add("class", "lblMembreAcceuil")
                    nouvMembre.ID = "lblMembre2" + Membre.id.ToString
                    'Label avec un balise a, font et 2 balises br dedans pour rediriger vers la page MembreInfo
                    nouvMembre.Text = "<a href=" & Chr(34) & "Membreinfo.aspx?pseudo=" + Membre.getNomUtilisateurParId(Membre.id, m_connection) & Chr(34) & _
                                        "STYLE=" & Chr(34) & "TEXT-DECORATION: NONE" & Chr(34) & "><font color=" & Chr(34) & "B8C3B8" & Chr(34) & ">" & _
                                        Membre.getNomUtilisateurParId(Membre.id, m_connection) + " <br/> <br/></font></a>"
                    nouvDiv.Controls.Add(nouvMembre)

                    'Date d'inscription
                    Dim nouvDateInscription As New Label()
                    nouvDateInscription.Attributes.Add("class", "lblDateInscription")
                    nouvDateInscription.ID = "lblDateInscription" + Membre.id.ToString
                    nouvDateInscription.Text = "Date d'inscription: " + Membre.DateInscription.Day.ToString + "-" & _
                                                Membre.DateInscription.Month.ToString + "-" + Membre.DateInscription.Year.ToString
                    nouvDiv.Controls.Add(nouvDateInscription)

                    phRechercherMembre.Controls.Add(nouvDiv)
                Next
            Else
                MembreNonTrouve()
            End If
        End If
    End Sub

    Private Sub RechercherFiche()
        Dim Fiches As List(Of Entites.Fiche) = Entites.Fiche.Rechercher(txtRecherche.Text, m_connection)

        If Fiches IsNot Nothing Then
            If Not (Fiches.Count = 0) Then
                For Each Fiche In Fiches
                    Dim nouvDiv As New HtmlGenericControl("div")
                    nouvDiv.Attributes.Add("class", "FichesRechercher")

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
            Else
                FicheNonTrouve()
            End If
        End If
    End Sub

    Private Sub MembreNonTrouve()
        Dim nouvDivMembre As New HtmlGenericControl("div")
        nouvDivMembre.Attributes.Add("class", "NonTrouve")

        Dim nouvMembre As New Label
        nouvMembre.Text = "Aucun résultat de recherche"
        nouvDivMembre.Controls.Add(nouvMembre)

       phRechercherMembre.Controls.Add(nouvDivMembre)
    End Sub

    Private Sub FicheNonTrouve()
        Dim nouvDivFiche As New HtmlGenericControl("div")
        nouvDivFiche.Attributes.Add("class", "NonTrouve")
        Dim nouvFiche As New Label
        nouvFiche.Text = "Aucun résultat de recherche"
        nouvDivFiche.Controls.Add(nouvFiche)

        phRechercheFiche.Controls.Add(nouvDivFiche)
    End Sub

End Class