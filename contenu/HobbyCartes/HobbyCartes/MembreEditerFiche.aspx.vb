Imports MySql.Data.MySqlClient

Public Class MembreEditerFiche
    Inherits System.Web.UI.Page

    Dim m_idMembre As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Accueil.initSession(Session)

        ' Vérifie si l'utilisateur est connecté
        Dim connected As Boolean = Boolean.Parse(Session("connected"))
        If Not connected Then Erreur.afficherErreur("Vous devez être connecté pour gérer vos collections.", Page)

        ' Recupere l'id du membre et charge toutes ses collections
        m_idMembre = Integer.Parse(Session("idMembre"))

        initDropDownCollection()
        initDropDownEditeur()
        initDropDownEquipe()

    End Sub

    Private Sub initDropDownCollection()
        For Each typeCol As Entites.Collection.Type In System.Enum.GetValues(GetType(Entites.Collection.Type))
            If Entites.Collection.existe(m_idMembre, typeCol) Then
                dropDownCollection.Items.Add(typeCol.ToString)
            End If
        Next
    End Sub

    Private Sub initDropDownEditeur()
        For Each editeur As Entites.Editeur In Entites.Editeur.getAll()
            dropDownEditeur.Items.Add(editeur.nomEditeur)
        Next
    End Sub

    Private Sub initDropDownEquipe()
        For Each equipe As Entites.Equipe In Entites.Equipe.getAll()
            DropDownEquipe.Items.Add(equipe.Nom)
        Next
    End Sub

End Class