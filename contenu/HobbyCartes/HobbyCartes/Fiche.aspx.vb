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

        'm_Membre = New Entitees.Membre(1, m_connection)
        m_Fiche = New Entitees.Fiche(1, m_connection)

        Dim NbCom As Integer = m_Fiche.nbCom()
        'Pour retrouver le controle TestCom
        'Dim placeHolder As Control = Me.Controls(0).FindControl("cphCorps")
        'Dim placeHolder2 As Control = placeHolder.FindControl("TestCom")

        For value As Integer = 0 To NbCom - 1
            'Crée dymaniquement une nouvelle division pour afficher un commentaire
            Dim NouvDiv As New HtmlGenericControl("div")
            NouvDiv.Attributes.Add("class", "commentaire")
            NouvDiv.ID = "ComNouv" + value.ToString()

            'Ajout de la nouvelle division
            TestCom.Controls.Add(NouvDiv)

            'Création et remplissage de l'objet commentaire temporaire
            Dim Com As Entitees.Commentaire = New Entitees.Commentaire
            Com = m_Fiche.iCom(value)

            'Création d'un membre temporaire
            If Not Com Is Nothing Then
                Dim MembreTemp = New Entitees.Membre(Com.pDestinateur, m_connection)

                'Création d'un lbl pour le commentaire
                Dim lblCom As New Label
                Dim Commentaires As String = MembreTemp.nomComplet() + " dit : <br/><br/>" + Com.pMessage()
                lblCom.Text = Commentaires

                'ajout du commentaires
                Dim placeHolderCom As Control = TestCom.FindControl("ComNouv" + value.ToString())
                placeHolderCom.Controls.Add(lblCom)
            End If

        Next



    End Sub

    Protected Sub btnEnvoyer_Click() Handles btnCom.Click
        ''Crée dymaniquement une nouvelle division pour afficher un commentaire
        'Dim NouvDiv As New HtmlGenericControl("div")
        'NouvDiv.Attributes.Add("class", "commentaire")
        'NouvDiv.ID = "ComNouv"

        ''Création et remplissage de l'objet commentaire
        'Dim Com As Entitees.Commentaire
        'Com = New Entitees.Commentaire(1, 1)
        'Com.pMessage() = txtCom.Text

        ''Pour retrouver le controle TestCom
        'Dim placeHolder As Control = Me.Controls(0).FindControl("cphCorps")
        'Dim placeHolder2 As Control = placeHolder.FindControl("TestCom")

        ''Ajout de la nouvelle division
        'placeHolder2.Controls.Add(NouvDiv)

        ''Création d'un lbl pour le commentaire
        'Dim lblCom As New Label
        'Dim Commentaires As String = m_Membre.nomComplet() + " dit : <br/>" + Com.pMessage()
        'lblCom.Text = Commentaires



        'Dim placeHolderCom As Control = placeHolder.FindControl("ComNouv")
        'placeHolderCom.Controls.Add(lblCom)



    End Sub

End Class