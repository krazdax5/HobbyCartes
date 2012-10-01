Public Class Erreur
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.QueryString("description")) Then
            erreurDescription.InnerText = "Une erreur interne est survenue"
        Else
            erreurDescription.InnerText = Request.QueryString("description")
        End If
        If IsNothing(Request.QueryString("previous")) Then
            erreurBoutonRetour.PostBackUrl = "Default.aspx"
        Else
            erreurBoutonRetour.PostBackUrl = Request.QueryString("previous")
        End If
    End Sub

    Public Shared Sub afficherException(ex As Exception, previousPage As Page, response As HttpResponse)
        If Not IsNothing(previousPage) Then
            afficherException(ex, previousPage.Request.Url, response)
        Else
            afficherException(ex, DirectCast(Nothing, Uri), response)
        End If
    End Sub

    Public Shared Sub afficherException(ex As Exception, previousPage As Uri, response As HttpResponse)
        If Not IsNothing(ex) And Not IsNothing(previousPage) Then
            response.Redirect("Erreur.aspx?description=" & ex.Message & "&previous=" & previousPage.AbsoluteUri)
        ElseIf Not IsNothing(previousPage) Then
            response.Redirect("Erreur.aspx?previous=" & previousPage.AbsoluteUri)
        ElseIf Not IsNothing(ex) Then
            response.Redirect("Erreur.aspx?description=" & ex.Message)
        Else
            response.Redirect("Erreur.aspx")
        End If
    End Sub

End Class