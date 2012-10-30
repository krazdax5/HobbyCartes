Public Class HobbyCartes
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mnuProfil.Visible = False
        mnuAdmin.Visible = False
        If Not Session("connected") Is Nothing Then
            If Boolean.Parse(Session("connected")) Then
                lblConnecter.Text = "Connecté"
                lblConnecter.ForeColor = Drawing.Color.LightGreen
                hlnkConnection.Visible = False
                hlnkDeconnection.Visible = True

                mnuProfil.Visible = True

                Dim cook As HttpCookie = Request.Cookies(Integer.Parse(Session("idMembre")).ToString + "_arriereplan")
                If Not cook Is Nothing Then
                    siteBody.Style("background-image") = cook.Value
                End If

                If Boolean.Parse(Session("Admin")) Then
                    mnuAdmin.Visible = True
                End If
            Else
                lblConnecter.Text = "Déconnecté"
                lblConnecter.ForeColor = Drawing.Color.Red
                hlnkConnection.Visible = True
                hlnkDeconnection.Visible = False
            End If
        End If
    End Sub

    Protected Sub hlnkDeconnection_OnClick(sender As Object, e As EventArgs) Handles hlnkDeconnection.Click
        Session.Abandon()
        Response.Redirect("Accueil.aspx")
    End Sub

End Class