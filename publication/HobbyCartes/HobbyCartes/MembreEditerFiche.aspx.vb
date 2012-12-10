'--------------------------------------------------------------------------
' Titre: MembreEditerFiche.aspx.vb
' Auteur: Loïc Vial
' Date: 20 Novembre 2012
'-------------------------------------------------------------------------

Imports MySql.Data.MySqlClient
Imports System.IO

Public Class MembreEditerFiche
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' L'id du membre connecté
    ''' </summary>
    Dim idMembre As Integer

    ''' <summary>
    ''' L'id de la fiche qu'on veut editer (-1 = nouvelle fiche)
    ''' </summary>
    Dim idFiche As Integer

    Dim exImageAvant As String
    Dim exImageArriere As String

    ''' <summary>
    ''' Initialisation de la page
    ''' </summary>
    Protected Sub Page_Init() Handles Me.Init
        Accueil.initSession(Session)

        ' Vérifie si l'utilisateur est connecté
        Dim connected As Boolean = Boolean.Parse(Session("connected"))
        Dim isAdmin As Boolean = Boolean.Parse(Session("Admin"))
        If Not connected Then Erreur.afficherErreur("Vous devez être connecté pour éditer une fiche.", Page)

        ' Recupere l'id du membre
        If isAdmin And Not IsNothing(Request.QueryString("pseudo")) Then
            idMembre = Entites.Membre.getIDbyPseudo(Request.QueryString("pseudo"))
        Else
            idMembre = Session("idMembre")
        End If

        ' Recupere l'id de la fiche (-1 = nouvelle fiche)
        idFiche = Request.QueryString("idFiche")

        ' Verifie si le membre a bien accès a la fiche
        If Not idFiche = -1 And Not Entites.Membre.isPropreFiche(idFiche, idMembre) Then
            Erreur.afficherErreur("Vous n'avez pas le droit d'éditer une fiche qui n'est pas la votre", Page)
        End If

        ' Initialise les composantes de selection
        initDropDownCollection()
        initDropDownEditeur()
        initDropDownEquipe()
        initDropDownEtat()

        ' Si on edite une fiche existante, alors on pre-rempli les champs
        If idFiche <> -1 Then
            Dim fiche As Entites.Fiche = New Entites.Fiche(idFiche)
            dropDownCollection.SelectedValue = fiche.CollectionType
            txtNomJoueur.Text = fiche.NomJoueur
            txtPrenomJoueur.Text = fiche.PrenomJoueur
            dropDownEquipe.SelectedValue = fiche.Equipe.Nom
            txtNumeroJoueur.Text = fiche.Numero
            txtPosition.Text = fiche.Position
            chkRecrue.Checked = fiche.Recrue
            dropDownEtat.SelectedValue = fiche.Etatfiche.ToString
            txtValeur.Text = fiche.Valeur
            dropDownEditeur.SelectedValue = fiche.Editeur.nomEditeur
            txtAnnee.Text = fiche.DateCarte.Year
            exImageAvant = fiche.ImageAvant
            imageAvant.ImageUrl = fiche.ImageAvant
            exImageArriere = fiche.ImageArriere
            imageArriere.ImageUrl = fiche.ImageArriere
        Else
            exImageAvant = ""
            exImageArriere = ""
        End If

    End Sub

    ''' <summary>
    ''' Chargement de la page
    ''' </summary>
    Protected Sub Page_Load() Handles Me.Load

    End Sub

    ''' <summary>
    ''' Initialise la composante de selection d'une collection
    ''' </summary>
    Private Sub initDropDownCollection()
        For Each typeCol As Entites.Collection.Type In System.Enum.GetValues(GetType(Entites.Collection.Type))
            If Entites.Collection.existe(idMembre, typeCol) Then
                dropDownCollection.Items.Add(typeCol.ToString)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Initialise la composante de selection d'un editeur
    ''' </summary>
    Private Sub initDropDownEditeur()
        For Each editeur As Entites.Editeur In Entites.Editeur.getAll()
            dropDownEditeur.Items.Add(editeur.nomEditeur)
        Next
    End Sub

    ''' <summary>
    ''' Initialise la composante de selection d'une equipe
    ''' </summary>
    Private Sub initDropDownEquipe()
        For Each equipe As Entites.Equipe In Entites.Equipe.getAll()
            dropDownEquipe.Items.Add(equipe.Nom)
        Next
    End Sub

    ''' <summary>
    ''' Initialise la composante de selection d'un etat
    ''' </summary>
    Private Sub initDropDownEtat()
        For Each etat As Entites.Fiche.Etat In [Enum].GetValues(GetType(Entites.Fiche.Etat))
            dropDownEtat.Items.Add(etat.ToString)
        Next
    End Sub

    ''' <summary>
    ''' Clic sur le bouton "Enregistrer"
    ''' </summary>
    Protected Sub btnEnregistrer_Click() Handles btnEnregistrer.Click
        Dim fiche As Entites.Fiche = New Entites.Fiche
        fiche.ID = idFiche
        fiche.IDCollection = Entites.Collection.getIdCollectionParTypeEtMembre(idMembre, System.Enum.Parse(GetType(Entites.Collection.Type), dropDownCollection.SelectedValue))
        fiche.NomJoueur = txtNomJoueur.Text
        fiche.PrenomJoueur = txtPrenomJoueur.Text
        fiche.Equipe = New Entites.Equipe(dropDownEquipe.SelectedValue)
        fiche.Numero = txtNumeroJoueur.Text
        fiche.Position = txtPosition.Text
        fiche.Recrue = chkRecrue.Checked
        fiche.Etatfiche = System.Enum.Parse(GetType(Entites.Fiche.Etat), dropDownEtat.SelectedValue)
        fiche.Valeur = txtValeur.Text
        fiche.Editeur = New Entites.Editeur(dropDownEditeur.SelectedValue)
        fiche.DateCarte = New Date(txtAnnee.Text, 1, 1)
        If chkImageAvant.Checked Then
            fiche.ImageAvant = ""
        Else
            fiche.ImageAvant = exImageAvant
        End If
        If chkImageArriere.Checked Then
            fiche.ImageArriere = ""
        Else
            fiche.ImageArriere = exImageArriere
        End If

        If idFiche = -1 Then idFiche = fiche.getNextid

        If Not chkImageAvant.Checked And fuImageAvant.HasFile Then
            Try
                If fuImageAvant.PostedFile.ContentType.Equals("image/jpeg") Then
                    Dim chemin As String = "img/" + idFiche.ToString + "_avant.jpg"
                    Dim fichier As FileStream = New FileStream(Server.MapPath("~/") + chemin, FileMode.OpenOrCreate)
                    Dim data As Byte() = fuImageAvant.FileBytes
                    fichier.Write(data, 0, data.Length)
                    fichier.Close()
                    fiche.ImageAvant = chemin
                Else
                    lbImageAvant.Text = "Seulement JPEG!"
                End If
            Catch ex As Exception
                lbImageAvant.Text = ex.Message
            End Try
        End If

        If Not chkImageArriere.Checked And fuImageArriere.HasFile Then
            Try
                If fuImageArriere.PostedFile.ContentType.Equals("image/jpeg") Then
                    Dim chemin As String = "img/" + idFiche.ToString + "_arriere.jpg"
                    Dim fichier As FileStream = New FileStream(Server.MapPath("~/") + chemin, FileMode.OpenOrCreate)
                    Dim data As Byte() = fuImageArriere.FileBytes
                    fichier.Write(data, 0, data.Length)
                    fichier.Close()
                    fiche.ImageArriere = chemin
                Else
                    lbImageArriere.Text = "Seulement JPEG!"
                End If
            Catch ex As Exception
                lbImageArriere.Text = ex.Message
            End Try
        End If

        fiche.sauvegarde()
        If Boolean.Parse(Session("Admin")) And Not IsNothing(Request.QueryString("pseudo")) Then
            Response.Redirect("MembreGererCollections.aspx?pseudo=" & Request.QueryString("pseudo"))
        Else
            Response.Redirect("MembreGererCollections.aspx")
        End If
    End Sub

    Protected Sub chkImageAvant_CheckedChanged() Handles chkImageAvant.CheckedChanged
        If chkImageAvant.Checked Then
            fuImageAvant.Enabled = False
            imageAvant.Visible = False
        Else
            fuImageAvant.Enabled = True
            imageAvant.Visible = True
        End If
    End Sub

    Protected Sub chkImageArriere_CheckedChanged() Handles chkImageArriere.CheckedChanged
        If chkImageArriere.Checked Then
            fuImageArriere.Enabled = False
            imageArriere.Visible = False
        Else
            fuImageArriere.Enabled = True
            imageArriere.Visible = True
        End If
    End Sub

End Class