Imports MySql.Data
Imports MySql.Data.MySqlClient
Namespace Entitees

    Public Class Equipe

        Private m_nom As String
        Private m_ID As Integer
        Private m_dbConnectionEquipe As MySqlConnection

        Public ReadOnly Property Nom As String
            Get
                Return m_nom
            End Get
        End Property

        'Constructeur de L'équipe
        Public Sub New(id As Integer, dbCon As MySqlConnection)
            m_dbConnectionEquipe = dbCon
            Dim requete As MySqlCommand = New MySqlCommand("SELECT * FROM equipe WHERE idequipe=" + id.ToString, m_dbConnectionEquipe)
            Dim reader As MySqlDataReader

            Try
                reader = requete.ExecuteReader()
                reader.Read()

                m_nom = reader.GetString("nomeq")
                m_ID = id
                reader.Close()
            Catch ex As Exception
                m_ID = -1
            End Try
        End Sub


    End Class

    



End Namespace
