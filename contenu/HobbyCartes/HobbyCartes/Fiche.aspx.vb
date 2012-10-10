Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Fiche

    Inherits System.Web.UI.Page

    Dim m_connection As MySqlConnection
    'Dim m_Membre As Entitees.Membre
    Dim m_Fiche As Entitees.Fiche
    Dim m_Admin As Boolean
    Dim m_CheckBox As ArrayList

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_Admin = True
        m_CheckBox = New ArrayList()


        m_connection = New MySqlConnection("Server=localhost;Database=test;Uid=root;Pwd=toor;")
        m_connection.Open()

        m_Fiche = New Entitees.Fiche(1, m_connection)
        Dim NbCom As Integer = m_Fiche.nbCom()

        For value As Integer = 0 To NbCom - 1
            'Création et remplissage de l'objet commentaire temporaire
            Dim Com As Entitees.Commentaire = New Entitees.Commentaire
            Com = m_Fiche.ChercheCom(value)
            AfficheCom(Com)
        Next

        If (Not m_Admin) Then
            btnSup.Visible = False
        End If

    End Sub

    'Ajouter un commentaire
    Protected Sub btnEnvoyer_Click() Handles btnCom.Click
        If (txtCom.Text = "") Then
            Return
        End If
        Dim Com As Entitees.Commentaire = New Entitees.Commentaire
        Com.pMessage() = txtCom.Text
        Com.pIDFiche() = 1
        Com.pDestinateur() = "Jean Coutue"
        Dim IDCom As Integer = m_Fiche.NouvCommentaire(Com)
        AfficheNouvCom(IDCom)
        txtCom.Text = ""
    End Sub

    'Supprimer un commentaire
    Protected Sub btnSup_Click() Handles btnSup.Click
        Dim NomDiv As String
        Dim DivSup As New HtmlGenericControl("div")
        Dim tDivSup As New ArrayList

        For value As Integer = 0 To m_CheckBox.Count - 1
            Dim ckSup As New CheckBox
            ckSup = m_CheckBox(value)

            If (ckSup.Checked) Then
                NomDiv = ckSup.ID.Remove(0, 2)
                m_Fiche.SupCommentaire(NomDiv)
                DivSup = uppanCommentaire.ContentTemplateContainer.FindControl(NomDiv)
                uppanCommentaire.ContentTemplateContainer.Controls.Remove(DivSup)
                m_CheckBox.Add(value)
                tDivSup.Add(value)
            End If
        Next

        For value As Integer = tDivSup.Count - 1 To 0 Step -1
            m_CheckBox.RemoveAt(tDivSup(value))
        Next

    End Sub

    Private Sub AfficheCom(Com As Entitees.Commentaire)
        'Crée dymaniquement une nouvelle division pour afficher un commentaire
        Dim NouvDiv As New HtmlGenericControl("div")
        NouvDiv.Attributes.Add("class", "commentaire")
        NouvDiv.ID = Com.pIDCommentaire.ToString()

        'Si le membre est administrateur, ajouter un CheckBox pour la suppression de commentaire
        If (m_Admin) Then
            Dim ckSup As New CheckBox
            ckSup.ID = "ck" + Com.pIDCommentaire.ToString()
            ckSup.CssClass = "CheckB"
            m_CheckBox.Add(ckSup)
            NouvDiv.Controls.Add(ckSup)
        End If

        'Création d'un lbl pour le commentaire
        Dim lblCom As New Label
        Dim Commentaires As String = Com.pDestinateur + " dit : <br/><br/>" + Com.pMessage()
        lblCom.Text = Commentaires

        'ajout du commentaires
        NouvDiv.Controls.Add(lblCom)

        'Ajout de la nouvelle division
        uppanCommentaire.ContentTemplateContainer.Controls.Add(NouvDiv)
    End Sub

    Private Sub AfficheNouvCom(IDCom As Integer)
        'Création et remplissage de l'objet commentaire temporaire
        Dim Com As Entitees.Commentaire = New Entitees.Commentaire
        Com = m_Fiche.ChercheCom(m_Fiche.nbCom - 1)
        AfficheCom(Com)
    End Sub

    



End Class