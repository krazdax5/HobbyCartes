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

        Private m_annee As Date

        Private m_nomJoueur As String

        Private m_prenomJoueur As String

        Private m_numeroJoueur As Integer

        Private m_isRecrue As Boolean

        Private m_position As String

        Private m_numerotation As Integer

        Private m_valeur As Double

        Private m_myEtat As Etat

        Private m_imageDevant As String

        Private m_imageDerriere As String

        Private m_publicationSurSite As Date

        Private m_commentaires As ArrayList

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

            m_commentaires = New ArrayList()
            While dbReadfiche.Read
                Dim ComTemp As Commentaire = New Commentaire(dbReadfiche.GetString("destinateurcom"), dbReadfiche.GetInt32("idfiche"), dbReadfiche.GetInt32("idcommentaire"), dbReadfiche.GetString("messagecom"))
                m_commentaires.Add(ComTemp)
            End While
            dbReadfiche.Close()

            'Remplissage des autres attribues de la classe
            dbComFiche = New MySqlCommand("SELECT * FROM fiche WHERE idfiche=" + id, m_dbConnectionFiche)

            Try
                dbReadfiche = dbComFiche.ExecuteReader()

                While dbReadfiche.Read()
                    m_annee = dbReadfiche.GetDateTime("anneefi")
                    m_nomJoueur = dbReadfiche.GetString("nomjoueurfi")
                    m_prenomJoueur = dbReadfiche.GetString("prenomjoueurfi")
                    m_numeroJoueur = dbReadfiche.GetInt32("nojoueurfi")
                End While
            Catch ex As Exception

            End Try
        End Sub

        'Propriété qui retourne le nombre d'entré valide dans le tableau de commentaire
        Public ReadOnly Property nbCom() As Integer
            Get
                Return m_commentaires.Count
            End Get
        End Property

        'Retourne le commentaire à l'indice désirée
        Public Function ChercheCom(Indice As Integer) As Commentaire
            Return m_commentaires(Indice)
        End Function

        Public Function NouvCommentaire(Comm As Commentaire) As Integer
            Dim Com As Commentaire = New Commentaire()
            Com = Comm
            m_commentaires.Add(Com)
            Dim requete As MySqlCommand = New MySqlCommand("INSERT INTO commentaire(idfiche, destinateurcom, messagecom) VALUES('" +
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

        ''' <summary>
        ''' Retrouver la liste de toutes les fiches reliées à une collection.
        ''' </summary>
        ''' <param name="idCollection">Identificateur de la collection.</param>
        ''' <returns>Retourne une liste de fiches représentant les fiches de la collection.</returns>
        Public Shared Function retrouverListeMembre(ByVal idCollection As Integer, ByVal connection As MySqlConnection) As List(Of Entitees.Fiche)
            Dim liste As List(Of Entitees.Fiche) = New List(Of Entitees.Fiche)()
            Dim requete As MySqlCommand = New MySqlCommand("SELECT * FROM fiche WHERE idcollection='" + idCollection + "'")
            Dim dbRead As MySqlDataReader

            Try
                dbRead = requete.ExecuteReader()
                While dbRead.NextResult
                    Dim nouvFiche As Entitees.Fiche = New Entitees.Fiche(dbRead.GetInt32("idfiche"), connection)
                    liste.Add(nouvFiche)
                End While

                Return liste
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

    End Class

End Namespace
