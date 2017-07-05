'--------------------------------------------------------------------------
' Titre: Acceuil.aspx.vb
' Auteur: Jean-François Collin
' Date: Octobre 2012
'--------------------------------------------------------------------------

Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Accueil
    Inherits System.Web.UI.Page

    Private m_connection As MySqlConnection
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        initSession(Session)
        m_connection = New MySqlConnection(My.Resources.StringConnexionBd2)
        m_connection.Open()
        NouveauxMembre()
        m_connection.Close()
    End Sub

    Public Sub NouveauxMembre()
        Dim Membres As List(Of Entites.Membre) = Entites.Membre.ListeMembresOrdonnee(m_connection)
        Dim Nombre As Integer = Membres.Count

        If (Nombre > 5) Then
            Nombre = 5
        End If


        If Membres IsNot Nothing Then
            For value As Integer = 0 To Nombre - 1
                Dim Membre As Entites.Membre = Membres(value)
                Dim nouvDiv As New HtmlGenericControl("div")
                nouvDiv.Attributes.Add("class", "membre")

                'Image
                Dim nouvA As New HtmlGenericControl("a")
                nouvA.Attributes.Add("href", "MembreInfo.aspx?pseudo=" + Membre.getNomUtilisateurParId(Membre.id, m_connection))
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
                nouvMembre.Text = "<a href=" & Chr(34) & "MembreInfo.aspx?pseudo=" + Membre.getNomUtilisateurParId(Membre.id, m_connection) & Chr(34) & _
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

    Public Shared Sub initSession(session As HttpSessionState)
        If session("connected") Is Nothing Then
            session.Add("connected", False)
            session.Timeout = 30
        End If
        If session("idMembre") Is Nothing Then
            session.Add("idMembre", -1)
        End If
        If session("Admin") Is Nothing Then
            session.Add("Admin", False)
        End If
    End Sub
End Class