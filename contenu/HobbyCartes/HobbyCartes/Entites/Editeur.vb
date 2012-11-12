'--------------------------------------------------------------------------
' Titre: Editeur.vb
' Auteur: Charles Levesque
' Date: Septembre 2012
'--------------------------------------------------------------------------

Imports MySql.Data
Imports MySql.Data.MySqlClient

Namespace Entites

    Public Class Editeur

        Private m_nom As String

        Private m_id As Integer

        Private m_connection As MySqlConnection

        Public ReadOnly Property NomEditeur As String
            Get
                Return m_nom
            End Get
        End Property

        ''' <summary>
        ''' Constructeur par défaut. m_id est -1 si la construction échoue.
        ''' </summary>
        ''' <param name="id">Identificateur de l'éditeur.</param>
        ''' <param name="connection">Connection à la base de données MySQL.</param>
        Public Sub New(id As Integer, connection As MySqlConnection)
            m_connection = connection
            Dim requete As MySqlCommand = New MySqlCommand("SELECT * FROM editeur WHERE idediteur=" + id.ToString, connection)
            Dim reader As MySqlDataReader

            Try
                reader = requete.ExecuteReader()
                reader.Read()

                m_nom = reader.GetString("nomed")
                m_id = id
                reader.Close()
            Catch ex As Exception
                m_id = -1
            End Try
        End Sub

    End Class

End Namespace
