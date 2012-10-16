Imports MySql.Data.MySqlClient

''' <summary>
''' Page de visualisation d'un seul message
''' </summary>
Public Class MembreVisualiserMessage
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' Chargement de la page
    ''' </summary>
    Protected Sub Page_Load() Handles Me.Load
        Dim dbCon As MySqlConnection = New MySqlConnection("Server=localhost;Database=test;Uid=root;Pwd=toor;")
        dbCon.Open()
        Dim idMessage As Integer = Request.QueryString("id")
        Dim message As Entitees.Message = New Entitees.Message(idMessage, dbCon)
        dbCon.Close()
        visualiserMessageTitre.InnerText = message.objet
        visualiserMessageContenu.InnerHtml = message.contenu.Replace(vbCrLf, "<br />")
    End Sub

End Class