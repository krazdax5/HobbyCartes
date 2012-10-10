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

        Private commentaires As ArrayList

        Private m_dbConnectionFiche As MySqlConnection

        Private m_NbCom As Integer

        ''' <summary>
        ''' Constructeur par defaut.
        ''' </summary>
        Public Sub New(id As Integer, dbCon As MySqlConnection)
            m_dbConnectionFiche = dbCon
            Dim Indice As Integer = 0
            Dim dbComFiche As MySqlCommand = New MySqlCommand("SELECT * FROM commentaire WHERE idfiche=" & id, m_dbConnectionFiche)
            Dim dbReadfiche As MySqlDataReader = dbComFiche.ExecuteReader()
           commentaires = New ArrayList()
            While dbReadfiche.Read
                Dim ComTemp As Commentaire = New Commentaire(dbReadfiche.GetString("destinateur"), dbReadfiche.GetInt32("idfiche"), dbReadfiche.GetInt32("idcommentaire"), dbReadfiche.GetString("message"))
                commentaires.Add(ComTemp)
            End While
            dbReadfiche.Close()

        End Sub
        'Propriété qui retourne le nombre d'entré valide dans le tableau de commentaire
        Public ReadOnly Property nbCom() As Integer
            Get
                Return commentaires.Count
            End Get
        End Property



        'Retourne le commentaire à l'indice désirée
        Public Function iCom(Indice As Integer) As Commentaire
            Return commentaires(Indice)
        End Function


        Public Function NouvCommentaire(Comm As Commentaire) As Integer
            Dim Com As Commentaire = New Commentaire()
            Com = Comm
            commentaires.Add(Com)
            Dim requete As MySqlCommand = New MySqlCommand("INSERT INTO commentaire(idfiche, destinateur, message) VALUES('" +
                                                           Com.pIDFiche.ToString() + "','" +
                                                           Com.pDestinateur + "','" +
                                                           Com.pMessage + "')", m_dbConnectionFiche)

            Try
                requete.ExecuteNonQuery()
                Return Integer.Parse(requete.LastInsertedId.ToString())
            Catch ex As Exception
               Return -1
            End Try
        End Function

        Public Function SupCommentaire(IDCom As String) As Boolean
            Dim requete As MySqlCommand = New MySqlCommand("DELETE FROM commentaire WHERE idcommentaire='" + IDCom + "'", m_dbConnectionFiche)

            Try
                requete.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                Return False
            End Try

        End Function


    End Class

End Namespace
