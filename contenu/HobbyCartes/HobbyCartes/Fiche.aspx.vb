Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Fiche

    Inherits System.Web.UI.Page

    Dim m_connection As MySqlConnection
    'Dim m_Membre As Entitees.Membre
    Dim m_Fiche As Entitees.Fiche

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_connection = New MySqlConnection("Server=G264-11;Database=test;Uid=root;Pwd=toor;")
        m_connection.Open()

        m_Fiche = New Entitees.Fiche(1, m_connection)
        Dim NbCom As Integer = m_Fiche.nbCom()



        For value As Integer = 0 To NbCom - 1

            'Création et remplissage de l'objet commentaire temporaire
            Dim Com As Entitees.Commentaire = New Entitees.Commentaire
            Com = m_Fiche.iCom(value)
            AfficheCom(Com)
        Next

    End Sub

    Protected Sub btnEnvoyer_Click() Handles btnCom.Click
        If (txtCom.Text = "") Then
            Return
        End If
        Dim Com As Entitees.Commentaire = New Entitees.Commentaire
        Com.pMessage() = txtCom.Text
        txtCom.Text = ""
        Com.pIDFiche() = 1
        Com.pDestinateur() = "Jean Coutue"
        Dim IDCom As Integer = m_Fiche.NouvCommentaire(Com)
        AfficheNouvCom(IDCom)

    End Sub

    Private Sub AfficheCom(Com As Entitees.Commentaire)

        'Crée dymaniquement une nouvelle division pour afficher un commentaire
        Dim NouvDiv As New HtmlGenericControl("div")
        NouvDiv.Attributes.Add("class", "commentaire")
        NouvDiv.ID = Com.pIDCommentaire.ToString()

        'Ajout de la nouvelle division
        uppanCommentaire.ContentTemplateContainer.Controls.Add(NouvDiv)


        'Création d'un lbl pour le commentaire
        Dim lblCom As New Label
        Dim Commentaires As String = Com.pDestinateur + " dit : <br/><br/>" + Com.pMessage()
        lblCom.Text = Commentaires

        'ajout du commentaires
        Dim placeHolderCom As Control = uppanCommentaire.ContentTemplateContainer.FindControl(Com.pIDCommentaire.ToString())
        placeHolderCom.Controls.Add(lblCom)

    End Sub

    Private Sub AfficheNouvCom(IDCom As Integer)
        'Création et remplissage de l'objet commentaire temporaire
        Dim Com As Entitees.Commentaire = New Entitees.Commentaire
        Com = m_Fiche.iCom(m_Fiche.nbCom - 1)
        AfficheCom(Com)
    End Sub




End Class