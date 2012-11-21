'--------------------------------------------------------------------------
' Titre: Equipe.vb
' Auteur: Jean-François Collin
' Date: Septembre 2012
'--------------------------------------------------------------------------

Imports MySql.Data
Imports MySql.Data.MySqlClient
Namespace Entites

    Public Class Equipe

        Private m_nom As String

        Private m_ID As Integer

        Public ReadOnly Property Nom As String
            Get
                Return m_nom
            End Get
        End Property

        'Constructeur de L'équipe
        Public Sub New(id As Integer)
            Dim connection As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
            connection.Open()
            Dim requete As MySqlCommand = New MySqlCommand("SELECT * FROM equipe WHERE idequipe=" + id.ToString, connection)
            Dim reader As MySqlDataReader
            reader = requete.ExecuteReader()
            reader.Read()
            m_nom = reader.GetString("nomeq")
            m_ID = id
            reader.Close()
            connection.Close()
        End Sub

        Public Shared Function getAll() As List(Of Equipe)
            Dim retour As List(Of Equipe) = New List(Of Equipe)
            Dim connection As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
            connection.Open()
            Dim requete As MySqlCommand = New MySqlCommand("SELECT idequipe FROM equipe", connection)
            Dim reader As MySqlDataReader = requete.ExecuteReader()
            While reader.Read()
                retour.Add(New Equipe(Integer.Parse(reader.GetString("idequipe"))))
            End While
            reader.Close()
            connection.Close()
            Return retour
        End Function

    End Class





End Namespace
