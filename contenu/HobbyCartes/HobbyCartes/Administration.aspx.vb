Imports MySql.Data
Imports MySql.Data.MySqlClient


Public Class Administration
    Inherits System.Web.UI.Page
    Private m_connection As MySqlConnection
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_connection = New MySqlConnection(My.Resources.StringConnexionBdd)
        m_connection.Open()

        If Not Session("Admin") Is Nothing Then
            If Not Boolean.Parse(Session("Admin")) Then
                Response.Redirect("Accueil.aspx")
            End If
        Else
            Response.Redirect("Accueil.aspx")
        End If
        AdminMembre()
    End Sub

    Private Sub AdminMembre() Handles lnkbtnSupp.Click
        Dim Membres As List(Of Entites.Membre) = Entites.Membre.ListeMembresOrdonnee(m_connection)

        If Membres IsNot Nothing Then
            For Each Membre In Membres
                Dim nouvDiv As New HtmlGenericControl("div")
                nouvDiv.Attributes.Add("class", "membreAdmin")

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
                nouvMembre.Attributes.Add("class", "lblMembreAdmin")
                nouvMembre.ID = "lblMembre2" + Membre.id.ToString
                'Label avec un balise a, font et 2 balises br dedans pour rediriger vers la page MembreInfo
                nouvMembre.Text = "<a href=" & Chr(34) & "Membreinfo.aspx?pseudo=" + Membre.getNomUtilisateurParId(Membre.id, m_connection) & Chr(34) & _
                                    "STYLE=" & Chr(34) & "TEXT-DECORATION: NONE" & Chr(34) & "><font color=" & Chr(34) & "B8C3B8" & Chr(34) & ">" & _
                                    Membre.getNomUtilisateurParId(Membre.id, m_connection) + " <br/> <br/></font></a>"
                nouvDiv.Controls.Add(nouvMembre)

                'Date d'inscription
                Dim nouvDateInscription As New Label()
                nouvDateInscription.Attributes.Add("class", "lblDateInscriptionAdmin")
                nouvDateInscription.ID = "lblDateInscription" + Membre.id.ToString
                nouvDateInscription.Text = "Date d'inscription: " + Membre.DateInscription.Day.ToString + "-" & _
                                            Membre.DateInscription.Month.ToString + "-" + Membre.DateInscription.Year.ToString
                nouvDiv.Controls.Add(nouvDateInscription)

                Dim ckSup As New CheckBox
                ckSup.ID = "ck" + Membre.id.ToString
                ckSup.CssClass = "CheckBAdmin"
                nouvDiv.Controls.Add(ckSup)

                phAdmin.Controls.Add(nouvDiv)
            Next
        End If
        
    End Sub

End Class