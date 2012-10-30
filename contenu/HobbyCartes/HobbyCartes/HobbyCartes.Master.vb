Public Class HobbyCartes
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mnuProfil.Visible = False

        If Not Session("connected") Is Nothing Then
            If Boolean.Parse(Session("connected")) Then
                mnuProfil.Visible = True

                Dim cook As HttpCookie = Request.Cookies(Integer.Parse(Session("idMembre")).ToString + "_arriereplan")
                If Not cook Is Nothing Then
                    siteBody.Style("background-image") = cook.Value
                End If
            End If
        End If
    End Sub

End Class