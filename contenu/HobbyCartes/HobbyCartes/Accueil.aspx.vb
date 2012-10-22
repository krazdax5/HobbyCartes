Public Class Accueil
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("connected") Is Nothing Then
            Session.Add("connected", False)
            Session.Timeout = 30
        End If
    End Sub

End Class