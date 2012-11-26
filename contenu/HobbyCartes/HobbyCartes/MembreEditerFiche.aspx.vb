Imports MySql.Data.MySqlClient

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

    ''' <summary>
    ''' Initialisation de la page
    ''' </summary>
    Protected Sub Page_Init() Handles Me.Init
        Accueil.initSession(Session)

        ' Vérifie si l'utilisateur est connecté
        Dim connected As Boolean = Boolean.Parse(Session("connected"))
        If Not connected Then Erreur.afficherErreur("Vous devez être connecté pour éditer une fiche.", Page)

        ' Recupere l'id du membre
        idMembre = Session("idMembre")

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
            imageAvant.ImageUrl = fiche.ImageAvant
            imageArriere.ImageUrl = fiche.ImageArriere
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
            DropDownEquipe.Items.Add(equipe.Nom)
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


        fiche.sauvegarde()
        Response.Redirect("/MembreGererCollections.aspx")
    End Sub

End Class