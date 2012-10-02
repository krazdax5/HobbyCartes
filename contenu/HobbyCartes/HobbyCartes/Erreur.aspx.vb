''' <summary>
''' Page d'erreur standard
''' </summary>
Public Class Erreur
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Chargement de la page
    ''' </summary>
    Protected Sub Page_Load() Handles Me.Load
        Dim previousURL As String = Session("errorPreviousURL")
        Dim exception As String = Session("errorMessage")

        If IsNothing(exception) Then
            erreurDescription.InnerText = "Une erreur interne est survenue"
        Else
            erreurDescription.InnerText = exception
        End If

        If IsNothing(previousURL) Then
            erreurBoutonRetour.PostBackUrl = "Default.aspx"
        Else
            erreurBoutonRetour.PostBackUrl = previousURL
        End If
    End Sub

    ''' <summary>
    ''' Affiche la page d'erreur decrivant une exception
    ''' </summary>
    Public Shared Sub afficherException(ex As Exception, previousPage As Page, currentPage As Page)
        If Not IsNothing(previousPage) Then
            afficherException(ex, previousPage.Request.Url, currentPage)
        Else
            afficherException(ex, DirectCast(Nothing, Uri), currentPage)
        End If
    End Sub

    ''' <summary>
    ''' Affiche la page d'erreur decrivant une exception
    ''' </summary>
    Public Shared Sub afficherException(ex As Exception, previousURL As Uri, currentPage As Page)
        currentPage.Session("errorPreviousURL") = previousURL.ToString
        currentPage.Session("errorMessage") = ex.ToString
        currentPage.Response.Redirect("Erreur.aspx")
        'If Not IsNothing(ex) And Not IsNothing(previousPage) Then
        'currentPage.Response.Redirect("Erreur.aspx?description=" & ex.Message & "&previous=" & previousPage.AbsoluteUri)
        'ElseIf Not IsNothing(previousPage) Then
        'currentPage.Response.Redirect("Erreur.aspx?previous=" & previousPage.AbsoluteUri)
        'ElseIf Not IsNothing(ex) Then
        '    currentPage.Response.Redirect("Erreur.aspx?description=" & ex.Message & )
        'Else
        'currentPage.Response.Redirect("Erreur.aspx")
        'End If
    End Sub

End Class