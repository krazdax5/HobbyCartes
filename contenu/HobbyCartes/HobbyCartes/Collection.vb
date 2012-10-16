Imports MySql.Data
Imports MySql.Data.MySqlClient

Namespace Entitees

    Public Class Collection

        Public Enum Type
            Hockey = 1
            Baseball
            Football
            Basketball
            aucun
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
        Private m_fiches As List(Of Entitees.Fiche) = New List(Of Entitees.Fiche)

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
        Public Sub New(ByVal idMembre As Integer, ByVal dbCon As MySqlConnection)
            m_connection = dbCon
            Dim sport As List(Of String) = New List(Of String)()

            Dim requete As MySqlCommand = New MySqlCommand("SELECT typecol FROM collection WHERE" +
                                                           " idmembre='" + idMembre.ToString + "'", m_connection)

            Try
                Dim reader As MySqlDataReader = requete.ExecuteReader()

                'Récupération des collections du membre
                While reader.Read()
                    sport.Add(reader.GetString("typecol"))
                End While

                reader.Close()
                chargementNouvCollection(sport(0), idMembre)

            Catch ex As Exception
                m_type = Type.aucun
            End Try
        End Sub

        ''' <summary>
        ''' Chargement de la liste des fiches selon l'identificateur de la collection.
        ''' Si il n'y en a pas, la liste devient vide.
        ''' </summary>
        Private Sub chargementListeFiches()
            Dim requete As MySqlCommand = New MySqlCommand("SELECT idfiche FROM fiche WHERE idcollection='" + m_id.ToString + "'", m_connection)
            Dim reader As MySqlDataReader
            Dim listeID As List(Of Integer) = New List(Of Integer)()

            Try
                reader = requete.ExecuteReader()
                'Récuprération des fiches de la collection
                While reader.Read()
                    listeID.Add(reader.GetInt32("idfiche"))
                End While

                reader.Close()

                'Remplissage de la liste de fiches
                For Each identificateur In listeID
                    m_fiches.Add(New Entitees.Fiche(identificateur, m_connection))
                Next
            Catch ex As Exception
                m_fiches = Nothing
            End Try
        End Sub

        ''' <summary>
        ''' Chargement d'une nouvelle collection à partir d'un membre et d'un sport.
        ''' </summary>
        ''' <param name="sport">Représente un type de collection.</param>
        ''' <param name="idMembre">Identificateur du membre à qui appartient la collection.</param>
        Public Sub chargementNouvCollection(ByVal sport As String, ByVal idMembre As Integer)
            'Détermination du sport
            Select Case sport
                Case "hockey"
                    m_type = Collection.Type.Hockey
                Case "baseball"
                    m_type = Collection.Type.Baseball
                Case "basketball"
                    m_type = Collection.Type.Basketball
                Case "football"
                    m_type = Collection.Type.Football
                Case Else
                    m_type = Type.aucun
            End Select

            'Nouvelle commande pour récupérer l'identificateur de la collection
            Dim requete As MySqlCommand = New MySqlCommand("SELECT * FROM collection WHERE" +
                                       " idmembre='" + idMembre.ToString + "'" +
                                       " AND typecol='" + m_type.ToString.ToLower + "'", m_connection)
            Dim reader As MySqlDataReader

            Try
                reader = requete.ExecuteReader()

                'Récupération de l'identificateur de la collection
                While reader.Read()
                    m_id = reader.GetInt32("idcollection")
                End While

                reader.Close()
                chargementListeFiches()
            Catch ex As Exception
                m_type = Type.aucun
                m_id = -1
            End Try

        End Sub

    End Class

End Namespace