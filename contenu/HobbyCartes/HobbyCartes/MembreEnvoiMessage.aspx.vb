Public Class MembreEnvoiMessage
    Inherits System.Web.UI.Page

    Private membre As Entitees.Membre

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim idMembre As Integer = Request.QueryString("id")
        membre = New Entitees.Membre(idMembre)
        lbNom.Text = membre.nomComplet
    End Sub

    Protected Sub btnEnvoyer_Click() Handles btnEnvoyer.Click

    End Sub
End Class