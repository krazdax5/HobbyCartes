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
        Dim message As String = Session("errorMessage")

        If IsNothing(message) Then
            erreurDescription.InnerText = "Une erreur interne est survenue"
        Else
            erreurDescription.InnerHtml = message.Replace(vbCrLf, "<br />")
        End If

        If IsNothing(previousURL) Then
            erreurBoutonRetour.PostBackUrl = "Accueil.aspx"
        Else
            erreurBoutonRetour.PostBackUrl = previousURL
        End If
    End Sub

    ''' <summary>
    ''' Affiche un message d'erreur par défaut
    ''' </summary>
    Public Shared Sub afficherErreur(currentPage As Page)
        afficherErreur(Nothing, currentPage, DirectCast(Nothing, Page))
    End Sub

    ''' <summary>
    ''' Affiche la page d'erreur decrivant un message d'erreur
    ''' </summary>
    Public Shared Sub afficherErreur(txtErreur As String, currentPage As Page)
        afficherErreur(txtErreur, currentPage, DirectCast(Nothing, Page))
    End Sub

    ''' <summary>
    ''' Affiche la page d'erreur decrivant un message d'erreur
    ''' </summary>
    Public Shared Sub afficherErreur(txtErreur As String, currentPage As Page, previousPage As Page)
        If IsNothing(previousPage) Then
            afficherErreur(txtErreur, currentPage, DirectCast(Nothing, Uri))
        Else
            afficherErreur(txtErreur, currentPage, previousPage.Request.Url)
        End If
    End Sub

    ''' <summary>
    ''' Affiche la page d'erreur decrivant un message d'erreur
    ''' </summary>
    Public Shared Sub afficherErreur(txtErreur As String, currentPage As Page, previousURL As Uri)
        If IsNothing(previousURL) Then
            currentPage.Session("errorPreviousURL") = Nothing
        Else
            currentPage.Session("errorPreviousURL") = previousURL.ToString
        End If
        currentPage.Session("errorMessage") = txtErreur
        currentPage.Response.Redirect("Erreur.aspx")
    End Sub

    ''' <summary>
    ''' Affiche la page d'erreur decrivant une exception
    ''' </summary>
    Public Shared Sub afficherException(ex As Exception, currentPage As Page, previousPage As Page)
        If IsNothing(ex) Then
            afficherErreur(Nothing, currentPage, previousPage)
        Else
            afficherErreur(ex.ToString, currentPage, previousPage)
        End If
    End Sub

    ''' <summary>
    ''' Affiche la page d'erreur decrivant une exception
    ''' </summary>
    Public Shared Sub afficherException(ex As Exception, currentPage As Page, previousURL As Uri)
        If IsNothing(ex) Then
            afficherErreur(Nothing, currentPage, previousURL)
        Else
            afficherErreur(ex.ToString, currentPage, previousURL)
        End If
    End Sub

End Class