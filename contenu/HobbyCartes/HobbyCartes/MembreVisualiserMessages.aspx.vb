Imports MySql.Data.MySqlClient

''' <summary>
''' Page de visualisation des messages du membre
''' </summary>
Public Class MembreVisualiserMessages
    Inherits System.Web.UI.Page

    ''' <summary>
    ''' La liste des messages
    ''' </summary>
    ''' <remarks></remarks>
    Private messages As List(Of Entitees.Message)

    ''' <summary>
    ''' La connexion a la base de donnees
    ''' </summary>
    Private dbCon As MySqlConnection

    ''' <summary>
    ''' Chargement de la page
    ''' </summary>
    Protected Sub Page_Load() Handles Me.Load
        ' Ouvre la connexion a la base de donnees
        dbCon = New MySqlConnection("Server=G264-11;Database=test;Uid=root;Pwd=toor;")
        dbCon.Open()
        ' Chargement de la liste de messages
        messages = Entitees.Message.getListe(1, dbCon)
        For i As Integer = 1 To 5

        Next
    End Sub

    ''' <summary>
    ''' Fermeture de la page
    ''' </summary>
    Protected Sub Page_Unload() Handles Me.Unload
        dbCon.Close()
    End Sub

End Class