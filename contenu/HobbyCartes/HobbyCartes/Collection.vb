Imports MySql.Data
Imports MySql.Data.MySqlClient

Namespace Entitees

    Public Class Collection

        Public Enum Type
            Hockey
            Football
            Basketball
            Baseball
        End Enum

        ''' <summary>
        ''' Identificateur de la collection
        ''' </summary>
        Private m_id As Integer

        ''' <summary>
        ''' Représente le sport de la collection.
        ''' </summary>
        Private m_type As Type

        ''' <summary>
        ''' Représente la liste de cartes de la collection.
        ''' </summary>
        Private m_fiches As List(Of Fiche)

        ''' <summary>
        ''' Connection à la base de données MySQL
        ''' </summary>
        Private m_connection As MySqlConnection

        ''' <summary>
        ''' Identificateur de la collection
        ''' </summary>
        Public ReadOnly Property ID As Integer
            Get
                Return m_id
            End Get
        End Property

        ''' <summary>
        ''' Liste de fiches de la collection
        ''' </summary>
        Public ReadOnly Property ListeFiches As List(Of Entitees.Fiche)
            Get
                Return m_fiches
            End Get
        End Property

        ''' <summary>
        ''' Type de sport de la collection (hockey, baseball, basketball ou football)
        ''' </summary>
        Public ReadOnly Property TypeCollection As Entitees.Collection.Type
            Get
                Return m_type
            End Get
        End Property

        ''' <summary>
        ''' Construit une collection à partir de l'identificateur du membre qui le détient
        ''' et du sport désiré.
        ''' </summary>
        ''' <param name="idMembre">Identificateur du membre à qui appartient la collection.</param>
        ''' <param name="type">Type de sport des cartes. Exemple: Cartes de hockey</param>
        Public Sub New(ByVal idMembre As Integer, ByVal type As Type, dbCon As MySqlConnection)
            m_connection = dbCon
        End Sub

        Private Function constructionCollection(ByVal idMembre As Integer, ByVal type As Type, ByRef idCollection As Integer) As Boolean
            Dim sport As String = ""
            Dim reader As MySqlDataReader
            Dim id As Integer

            'Détermination du sport
            Select Case type
                Case Collection.Type.Baseball
                    sport = "baseball"
                Case Collection.Type.Basketball
                    sport = "basketball"
                Case Collection.Type.Football
                    sport = "football"
                Case Collection.Type.Hockey
                    sport = "hockey"
            End Select

            Dim requete As MySqlCommand = New MySqlCommand("SELECT * FROM collection WHERE" +
                                                           " idmembre='" + idMembre.ToString +
                                                           "' AND type='" + sport + "'")

            Try
                reader = requete.ExecuteReader()

                'Récupération de l'identificateur
                While reader.NextResult
                    id = reader.GetInt32("idcollection")
                End While

                idCollection = id
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class

End Namespace