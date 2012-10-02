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
        Dim dbCon As MySqlConnection = New MySqlConnection("Server=G264-11;Database=test;Uid=root;Pwd=toor;")
        dbCon.Open()
        Dim idMessage As Integer = Request.QueryString("id")
        Dim message As Entitees.Message = New Entitees.Message(idMessage, dbCon)
        dbCon.Close()
        visualiserMessageTitre.InnerText = message.objet
        visualiserMessageContenu.InnerText = message.contenu
    End Sub

End Class