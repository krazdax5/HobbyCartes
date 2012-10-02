Imports MySql.Data
Imports MySql.Data.MySqlClient
Namespace Entitees

    Public Class Fiche

        Public Enum Etat
            impeccable
            bonne
            moyenne
            passable
            pietre
        End Enum

        Private annee As String

        Private nomJoueur As String

        Private prenomJoueur As String

        Private numeroJoueur As Integer

        Private isRecrue As Boolean

        Private position As String

        Private numerotation As Integer

        Private valeur As Double

        Private myEtat As Etat

        Private imageDevant As String

        Private imageDerriere As String

        Private publicationSurSite As Date

        Private commentaires() As Commentaire

        Private m_dbConnectionFiche As MySqlConnection

        ''' <summary>
        ''' Constructeur par defaut.
        ''' </summary>
        Public Sub New(id As Integer, dbCon As MySqlConnection)
            m_dbConnectionFiche = dbCon
            Dim Indice As Integer = 0
            Dim dbComFiche As MySqlCommand = New MySqlCommand("SELECT * FROM commentaire WHERE idfiche=" & id, m_dbConnectionFiche)
            Dim dbReadfiche As MySqlDataReader = dbComFiche.ExecuteReader()
            commentaires = New Commentaire(dbReadfiche.FieldCount()) {}

            While dbReadfiche.Read
                Dim ComTemp As Commentaire = New Commentaire((Integer.Parse(dbReadfiche.GetString("destinateur"))), dbReadfiche.GetInt32("idfiche"), dbReadfiche.GetInt32("idcommentaire"), dbReadfiche.GetString("message"))
                commentaires(Indice) = ComTemp
                Indice += 1
            End While
            dbReadfiche.Close()

        End Sub

        Public ReadOnly Property nbCom() As Integer
            Get
                Return commentaires.Length
            End Get
        End Property

        Public Function iCom(Indice As Integer) As Commentaire
            Return commentaires(Indice)
        End Function


    End Class

End Namespace
