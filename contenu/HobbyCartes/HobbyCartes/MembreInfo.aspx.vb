Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.IO

Public Class MembreInfo
    Inherits System.Web.UI.Page

    Dim m_connection As MySqlConnection
    Dim m_membre As Entitees.Membre

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_connection = New MySqlConnection(My.Resources.StringConnexionBdd)
        m_connection.Open()

        lblfuMessage.Text = ""
        lblfuProfilMessage.Text = ""

        Dim id As Integer
        Dim accesParId As Boolean = False

        id = Entitees.Membre.getIDbyPseudo(Request.QueryString("pseudo"), m_connection)

        'Vérifie si la page est accédée par pseudo
        If Not id.Equals(-1) Then
            m_membre = New Entitees.Membre(id, m_connection)
        Else
            'Ou par identificateur
            id = Integer.Parse(Session("idMembre"))
            If Not id.Equals(-1) Then
                m_membre = New Entitees.Membre(id, m_connection)
                accesParId = True
            Else
                m_membre = New Entitees.Membre(1, m_connection)
            End If
        End If

        'Détermination du droit à changer l'arrière-plan
        If Boolean.Parse(Session("connected")) Then
            If accesParId Then
                id = Integer.Parse(Session("idMembre"))

                If id.Equals(m_membre.id) Then
                    fuArrierePlan.Visible = True
                    fuImgProfil.Visible = True
                    txtCodePostal.Visible = True
                    txtCourriel.Visible = True
                    txtNom.Visible = True
                    txtPrenom.Visible = True
                    txtUtilisateur.Visible = True
                    txtVille.Visible = True
                    btnEnregistrer.Visible = True
                End If
            End If
        End If

        'Affichage des informations
        lblPrenom_membre.Text = m_membre.prenom
        lblNom_membre.Text = m_membre.nom
        lblUtilisateur_membre.Text = m_membre.nomUtilisateur
        lblPeusdo.Text = m_membre.nomUtilisateur
        lblVille_membre.Text = m_membre.Ville
        lblCodePostal_membre.Text = m_membre.CodePostal
        lblCourriel_membre.Text = m_membre.Courriel
        imgProfil.ImageUrl = m_membre.Image

    End Sub

    Protected Sub btnEnregistrer_click(sender As Object, e As EventArgs) Handles btnEnregistrer.Click
        If Page.IsValid Then
            lblMessage.Visible = False
            Dim liste As ArrayList = m_membre.getNomsPseudo
            Dim msgErreur As String = ""

            'S'assurer que le nom d'utilisateur n'est pas déjà utilisé
            If Not (txtUtilisateur.Text.Equals(m_membre.nomUtilisateur)) Then
                If Not txtUtilisateur.Text.Equals("") Then
                    If (liste.Contains(txtUtilisateur.Text)) Then
                        lblMessage.Text = "Ce nom d'utilisateur est déjà choisi!"
                        lblMessage.Visible = True
                        Return
                    End If
                End If
            End If

            'Enregistrement des informations si il y a lieu
            If Not txtPrenom.Text.Equals("") Then
                m_membre.prenom = txtPrenom.Text
                txtPrenom.Text = ""
            End If
            If Not txtNom.Text.Equals("") Then
                m_membre.nom = txtNom.Text
                txtNom.Text = ""
            End If
            If Not txtUtilisateur.Text.Equals("") Then
                m_membre.nomUtilisateur = txtUtilisateur.Text
                txtUtilisateur.Text = ""
            End If
            If Not txtVille.Text.Equals("") Then
                m_membre.Ville = txtVille.Text
                txtVille.Text = ""
            End If
            If Not txtCodePostal.Text.Equals("") Then
                m_membre.CodePostal = txtCodePostal.Text
                txtCodePostal.Text = ""
            End If
            If Not txtCourriel.Text.Equals("") Then
                m_membre.Courriel = txtCourriel.Text
                txtCourriel.Text = ""
            End If

            'Enregistrement de l'image d'arrière-plan
            If fuArrierePlan.HasFile Then
                Try
                    If fuArrierePlan.PostedFile.ContentType.Equals("image/jpeg") Then

                        If fuArrierePlan.PostedFile.ContentLength < 10240000 Then
                            Dim chemin As String = "img/" + m_membre.id.ToString + "_arriereplan.jpg"
                            Dim fichier As FileStream = New FileStream(Server.MapPath("~/") + chemin, FileMode.OpenOrCreate)

                            'Écriture du fichier à partir de ses octets
                            Dim data As Byte() = fuArrierePlan.FileBytes
                            fichier.Write(data, 0, data.Length)
                            fichier.Close()

                            'Association du chemin de l'arrière-plan dans la base de données
                            m_membre.EnregistrerChemin(chemin, Entitees.Membre.TypeImage.arriereplan)

                            lblfuMessage.Text = "Succès du transfert!"
                        Else
                            lblfuMessage.Text = "L'image est trop volumineuse!"
                        End If
                    Else
                        lblfuMessage.Text = "Seulement JPEG!"
                    End If
                Catch ex As Exception
                    lblfuMessage.Text = ex.Message
                End Try
            End If

            'Enregistrement de l'image de profil
            If fuImgProfil.HasFile Then
                Try
                    If fuImgProfil.PostedFile.ContentType.Equals("image/jpeg") Then
                        If fuArrierePlan.PostedFile.ContentLength < 102400 Then
                            Dim chemin As String = "img/" + m_membre.id.ToString + "_profil.jpg"
                            Dim fichier As FileStream = New FileStream(Server.MapPath("~/") + chemin, FileMode.OpenOrCreate)

                            'Écriture du fichier à partir de ses octets
                            Dim data As Byte() = fuImgProfil.FileBytes
                            fichier.Write(data, 0, data.Length)
                            fichier.Close()

                            'Association de l'image de profil avec le membre
                            m_membre.EnregistrerChemin(chemin, Entitees.Membre.TypeImage.profil)

                            lblfuProfilMessage.Text = "Succès du transfert"
                        Else
                            lblfuProfilMessage.Text = "L'image est trop volumineuse"
                        End If
                    Else
                        lblfuProfilMessage.Text = "Seulement JPEG!"
                    End If
                Catch ex As Exception
                    lblfuProfilMessage.Text = ex.Message
                End Try
            End If

            'Enregistrement définitif des informations dans la base de données
            If (m_membre.setAttMembre(msgErreur)) Then
                lblMessage.Text = "Les informations ont été enregistrées"
            Else
                lblMessage.Text = msgErreur
            End If

            'Affichage des nouvelles informations
            lblPrenom_membre.Text = m_membre.prenom
            lblNom_membre.Text = m_membre.nom
            lblUtilisateur_membre.Text = m_membre.nomUtilisateur
            lblPeusdo.Text = m_membre.nomUtilisateur
            lblVille_membre.Text = m_membre.Ville
            lblCodePostal_membre.Text = m_membre.CodePostal
            lblCourriel_membre.Text = m_membre.Courriel
            imgProfil.ImageUrl = m_membre.Image

            lblMessage.Visible = True
        End If
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        m_connection.Close()
    End Sub
End Class