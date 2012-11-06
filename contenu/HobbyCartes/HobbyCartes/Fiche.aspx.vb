Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Fiche

    Inherits System.Web.UI.Page

    Dim m_connection As MySqlConnection
    Dim m_Membre As Entites.Membre
    Dim m_Fiche As Entites.Fiche
    Dim m_Admin As Boolean


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_Admin = True
        Dim idFiche As Integer = Request.QueryString("idFiche")
        Dim idMembre As Integer

        m_connection = New MySqlConnection(My.Resources.StringConnexionBdd)
        m_connection.Open()

        m_Fiche = New Entites.Fiche(idFiche, m_connection)
        Dim NbCom As Integer = m_Fiche.nbCom()

        'Affiche le bouton supprimer commentaires si le membre est administrateur
        idMembre = Integer.Parse(Session("idMembre"))
        If Not idMembre.Equals(-1) Then
            m_Membre = New Entites.Membre(idMembre, m_connection)
            If (m_Membre.isAdmin) Then
                btnSup.Visible = True
            End If
        Else
            m_Membre = New Entites.Membre(m_connection)
        End If

        AfficheFiche()

        For value As Integer = 0 To NbCom - 1
            'Création et remplissage de l'objet commentaire temporaire
            Dim Com As Entites.Commentaire = New Entites.Commentaire
            Com = m_Fiche.ChercheCom(value)
            AfficheCom(Com)
        Next

        If Not Boolean.Parse(Session("connected")) Then
            btnCom.Visible = False
            txtCom.Visible = False
            lblCom.Visible = True
        End If

    End Sub

    'Ajouter un commentaire
    Protected Sub btnEnvoyer_Click() Handles btnCom.Click
        If (txtCom.Text = "") Then
            Return
        End If
        Dim idFiche As Integer = Request.QueryString("idFiche")
        Dim Com As Entites.Commentaire = New Entites.Commentaire(m_Membre.nomUtilisateur, idFiche)
        Com.pMessage() = txtCom.Text
         Dim IDCom As Integer = m_Fiche.NouvCommentaire(Com)
        AfficheNouvCom(IDCom)
        txtCom.Text = ""
    End Sub

    'Supprimer un commentaire
    Protected Sub btnSup_Click() Handles btnSup.Click
        Dim NomDiv As String
        Dim DivSup As New HtmlGenericControl("div")

        For value As Integer = 0 To m_Fiche.nbCom - 1
            Dim Com As Entites.Commentaire = New Entites.Commentaire
            'Récupération de la division à vérifier
            Com = m_Fiche.ChercheCom(value)
            NomDiv = Com.pIDCommentaire.ToString()
            DivSup = uppanCommentaire.ContentTemplateContainer.FindControl(NomDiv)

            Dim ckSup As New CheckBox
            ckSup = DivSup.FindControl("ck" + NomDiv)

            'Supprime les commentaires dont les Checkbox sont cochés
            If (ckSup.Checked) Then
                m_Fiche.SupCommentaire(NomDiv)
                phCommentaire.Controls.Remove(DivSup)
            End If
        Next

    End Sub

    'Afficher un commentaire
    Private Sub AfficheCom(Com As Entites.Commentaire)
        'Crée dymaniquement une nouvelle division pour afficher un commentaire
        Dim NouvDiv As New HtmlGenericControl("div")
        NouvDiv.Attributes.Add("class", "commentaire")
        NouvDiv.ID = Com.pIDCommentaire.ToString()

        'Si le membre est administrateur, ajouter un CheckBox pour la suppression de commentaire
        If Not m_Membre.id.Equals(-1) Then
            If (m_Membre.isAdmin) Then
                Dim ckSup As New CheckBox
                ckSup.ID = "ck" + Com.pIDCommentaire.ToString()
                ckSup.CssClass = "CheckB"
                NouvDiv.Controls.Add(ckSup)
            End If
        End If

        'Création d'un lbl pour le commentaire
        Dim lblCom As New Label
        Dim Commentaires As String = Com.pDestinateur + " dit : <br/><br/>" + Com.pMessage()
        lblCom.Text = "<a href=" & Chr(34) & "Membreinfo.aspx?pseudo=" + Com.pDestinateur & Chr(34) & _
                                    "STYLE=" & Chr(34) & "TEXT-DECORATION: NONE" & Chr(34) & "><font color=" & Chr(34) & "B8C3B8" & Chr(34) & ">" & _
                                    Com.pDestinateur + "</a> dit : </font><br/><br/>" + Com.pMessage()

        'ajout du commentaires
        NouvDiv.Controls.Add(lblCom)

        'Ajout de la nouvelle division
        phCommentaire.Controls.Add(NouvDiv)

    End Sub

    'Afficher un nouveau commentaire
    Private Sub AfficheNouvCom(IDCom As Integer)
        'Création et remplissage de l'objet commentaire temporaire
        Dim Com As Entites.Commentaire = New Entites.Commentaire
        Com = m_Fiche.ChercheCom(m_Fiche.nbCom - 1)
        AfficheCom(Com)
    End Sub

    Private Sub AfficheFiche()
        lblNomJoueur.Text = m_Fiche.PrenomJoueur + " " + m_Fiche.NomJoueur
        imgAvant.ImageUrl = m_Fiche.ImageAvant
        imgArriere.ImageUrl = m_Fiche.ImageArriere
        lblEditeur.Text = m_Fiche.Editeur.NomEditeur
        lblAnne.Text = m_Fiche.DateCarte.Year.ToString()
        lblValeur.Text = FormatCurrency(m_Fiche.Valeur, 2) + "CAD"
        hpDetenteur.Text = m_Fiche.PseudoDetenteur()
        hpDetenteur.NavigateUrl = "membreinfo.aspx?pseudo=" + m_Fiche.PseudoDetenteur()
        lblEquipe.Text = m_Fiche.Equipe
        lblNumero.Text = m_Fiche.Numero.ToString()
        lblPosition.Text = m_Fiche.Position
        Dim isRecrue As Boolean = m_Fiche.Recrue

        If (isRecrue) Then
            lblRecrue.Text = "Oui"
        Else
            lblRecrue.Text = "Non"
        End If

        lblNumerotation.Text = m_Fiche.Numerotation
        lblEtat.Text = m_Fiche.Etatfiche.ToString()
        lblDatePub.Text = m_Fiche.DatePublication.ToString()

    End Sub

End Class