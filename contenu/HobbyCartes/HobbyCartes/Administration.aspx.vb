Public Class Administration
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("Admin") Is Nothing Then
            If Not Boolean.Parse(Session("Admin")) Then
                Response.Redirect("Accueil.aspx")
            End If
        Else
            Response.Redirect("Accueil.aspx")
        End If
    End Sub

End Class