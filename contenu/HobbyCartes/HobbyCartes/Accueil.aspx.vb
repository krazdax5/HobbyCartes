Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Accueil
    Inherits System.Web.UI.Page

    Private m_connection As MySqlConnection
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("connected") Is Nothing Then
            Session.Add("connected", False)
            Session.Timeout = 30
        End If
        m_connection = New MySqlConnection("Server=localhost;Database=test;Uid=root;Pwd=toor;")
        m_connection.Open()
        NouveauxMembre()
    End Sub

    Public Sub NouveauxMembre()
        Dim Membres As List(Of Entitees.Membre) = Entitees.Membre.ListeMembresOrdonnee(m_connection)
        Dim Nombre As Integer = Membres.Count

        If (Nombre > 5) Then
            Nombre = 5
        End If


        If Membres IsNot Nothing Then
            For value As Integer = 0 To Nombre - 1
                Dim Membre As Entitees.Membre = Membres(value)
                Dim nouvDiv As New HtmlGenericControl("div")
                nouvDiv.Attributes.Add("class", "membre")

                'Image
                Dim nouvA As New HtmlGenericControl("a")
                nouvA.Attributes.Add("href", "Membreinfo.aspx?pseudo=" + Membre.getNomUtilisateurParId(Membre.id, m_connection))
                Dim nouvImage As New Image()
                nouvImage.ID = "img" + Membre.id.ToString
                nouvImage.ImageUrl = Membre.Image
                nouvImage.Attributes.Add("alt", "imgAvant" + Membre.id.ToString)
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

                phNouvMembre.Controls.Add(nouvDiv)
            Next
        End If
    End Sub
End Class