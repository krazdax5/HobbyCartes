'--------------------------------------------------------------------------
' Titre: Administration.aspx.vb
' Auteur: Jean-François Collin
' Date: 12 novembre 2012
' Contribution : Charles Levesque
'--------------------------------------------------------------------------

Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Administration
    Inherits System.Web.UI.Page
    Private m_connection As MySqlConnection
    Private m_checkBoxes As List(Of CheckBox)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_connection = New MySqlConnection(My.Resources.StringConnexionBdd)
        m_connection.Open()

        ' Initialise la liste des checkboxes
        m_checkBoxes = New List(Of CheckBox)

        If Not Session("Admin") Is Nothing Then
            If Not Boolean.Parse(Session("Admin")) Then
                Response.Redirect("Accueil.aspx")
            End If
        Else
            Response.Redirect("Accueil.aspx")
        End If
        AdminMembre()
    End Sub

    Private Sub AdminMembre()
        Dim Membres As List(Of Entites.Membre) = Entites.Membre.ListeMembresOrdonnee(m_connection)
        m_checkBoxes.Clear()
        If Membres IsNot Nothing Then
            For Each Membre In Membres
                If Not Membre.nomUtilisateur.Equals("admin") Then
                    Dim nouvDiv As New HtmlGenericControl("div")
                    nouvDiv.Attributes.Add("class", "membreAdmin")
                    nouvDiv.ID = "divMembre" + Membre.id.ToString

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

                    'Nombre de Fiches
                    Dim nbFiche As New Label
                    nbFiche.Attributes.Add("class", "lblnbFiche")
                    nbFiche.ID = "lblNb" + Membre.id.ToString
                    nbFiche.Text = "<br/> <br/> Nombre de fiches : " + Membre.nombreFiche.ToString
                    nouvDiv.Controls.Add(nbFiche)

                    Dim cbSup As New CheckBox
                    cbSup.ID = "cb" + Membre.id.ToString
                    cbSup.CssClass = "CheckBAdmin"
                    nouvDiv.Controls.Add(cbSup)
                    m_checkBoxes.Add(cbSup)
                    phAdminMembre.Controls.Add(nouvDiv)
                End If
            Next
        End If

    End Sub

    Private Sub SupMembre() Handles lnkbtnSupp.Click
        Dim NomDiv As String
        Dim DivSup As New HtmlGenericControl("div")
        Dim Membres As List(Of Entites.Membre) = Entites.Membre.ListeMembresOrdonnee(m_connection)
        cbTous.Checked = False
        For Each Membre In Membres
            If Not Membre.nomUtilisateur.Equals("admin") Then
                NomDiv = "divMembre" + Membre.id.ToString
                DivSup = uppanAdmin.ContentTemplateContainer.FindControl(NomDiv)

                Dim cbSup As New CheckBox
                cbSup = DivSup.FindControl("cb" + Membre.id.ToString)

                'Supprime les commentaires dont les Checkbox sont cochés
                If (cbSup.Checked) Then
                    If (Entites.Membre.SupMembre(Membre.id, m_connection)) Then
                        phAdminMembre.Controls.Remove(DivSup)
                    Else

                    End If
                End If
            End If
        Next
    End Sub

    Private Sub Selecttous() Handles cbTous.CheckedChanged

        If cbTous.Checked = True Then
            For Each Check In m_checkBoxes
                Check.Checked = True
            Next
        Else
            For Each Check In m_checkBoxes
                Check.Checked = False
            Next
        End If

    End Sub

    Private Sub AfficherMessage() Handles lnkbtnCommu.Click
        lblDialogue.Text = "<script type='text/javascript'>AfficherMessage();</script>"
    End Sub

    Private Sub EnvoyerMessage() Handles btnEnvoyer.Click
        Dim i As Integer = 0
        Dim Admin As Entites.Membre = New Entites.Membre(Integer.Parse(Session("idMembre")), m_connection)
        For Each checkbox In m_checkBoxes
            If checkbox.Checked Then
                Admin.envoyerMessage(New Entites.Membre(Integer.Parse(checkbox.ID.Remove(0, 2)), m_connection), "Communiqué", txtMessage.Text)
                checkbox.Checked = False
                i += 1
            End If
        Next
        cbTous.Checked = False

        If (i = 0) Then
            lblDialogue.Text = "Aucun destinataire sélectionné"
        Else
            lblDialogue.Text = "Le communiqué a bien été envoyé"
            txtMessage.Text = ""
        End If
        
    End Sub

    Private Sub AnnulerMessage() Handles btnAnnuler.Click
        For Each checkbox In m_checkBoxes
            If checkbox.Checked Then
                checkbox.Checked = False
            End If
        Next
        cbTous.Checked = False
        txtMessage.Text = ""
        lblDialogue.Text = ""
    End Sub

    Private Sub Sauvegarde() Handles btnSauvegarde.Click
        Dim chemin As String = Server.MapPath("~/sauvegardes/sauvegarde.sql")

        If File.Exists(chemin) Then
            File.Delete(chemin)
        End If

        Process.Start("c:\\Program Files (x86)\\MySQL\\MySQL Server 5.5\\bin\\mysqldump.exe", "-uroot -ptoor --result-file=""" + chemin + """ --all-databases")

    End Sub

    Private Sub Obtenir() Handles btnObtenir.Click
        If File.Exists(Server.MapPath("~/sauvegardes/sauvegarde.sql")) Then
            Response.AppendHeader("Content-Disposition", "attachment; filename=hobbycartes_db.sql")
            Response.TransmitFile(Server.MapPath("~/sauvegardes/sauvegarde.sql"))
            Response.End()
        Else
            lblErreur.Text = "Le fichier de sauvegarde n'existe pas. Sauvegarder la base de données avant de pouvoir récupérer le fichier."
        End If
    End Sub
End Class