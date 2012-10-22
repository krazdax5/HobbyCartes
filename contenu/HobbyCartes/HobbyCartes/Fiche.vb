Imports MySql.Data
Imports MySql.Data.MySqlClient
Namespace Entitees

    Public Class Fiche

        Public Enum Etat
            impeccable = 1
            bonne
            moyenne
            passable
            pietre
        End Enum

        Private m_idEditeur As Integer

        Private m_idEquipe As Integer

        Private m_id As Integer

        Private m_annee As Date

        Private m_nomJoueur As String

        Private m_prenomJoueur As String

        Private m_numeroJoueur As Integer

        Private m_isRecrue As Boolean

        Private m_position As String

        Private m_numerotation As String

        Private m_valeur As Double

        Private m_Etat As Etat

        Private m_imageDevant As String

        Private m_imageDerriere As String

        Private m_publicationSurSite As Date

        Private m_commentaires As ArrayList

        Private m_dbConnectionFiche As MySqlConnection

        ''' <summary>
        ''' Identificateur de la fiche
        ''' </summary>
        Public ReadOnly Property ID As Integer
            Get
                Return m_id
            End Get
        End Property

        ''' <summary>
        ''' Chemin vers l'image du devant de la carte
        ''' </summary>
        Public ReadOnly Property ImageAvant As String
            Get
                Return m_imageDevant
            End Get
        End Property

        ''' <summary>
        ''' Nom de famille du joueur
        ''' </summary>
        Public ReadOnly Property NomJoueur As String
            Get
                Return m_nomJoueur
            End Get
        End Property

        ''' <summary>
        ''' Prénom du joueur
        ''' </summary>
        Public ReadOnly Property PrenomJoueur As String
            Get
                Return m_prenomJoueur
            End Get
        End Property

        ''' <summary>
        ''' Année de la série de la carte
        ''' </summary>
        Public ReadOnly Property DateCarte As Date
            Get
                Return m_annee
            End Get
        End Property

        ''' <summary>
        ''' Éditeur de la carte.
        ''' </summary>
        ''' <returns>Retourne une instance de la classe Entitees.Editeur</returns>
        Public ReadOnly Property Editeur As Entitees.Editeur
            Get
                Return New Entitees.Editeur(m_idEditeur, m_dbConnectionFiche)
            End Get
        End Property

        ''' <summary>
        ''' Valeur de la carte en dollar canadien
        ''' </summary>
        Public ReadOnly Property Valeur As Double
            Get
                Return m_valeur
            End Get
        End Property

        Public ReadOnly Property DatePublication As Date
            Get
                Return m_publicationSurSite
            End Get
        End Property

        ''' <summary>
        ''' Constructeur par defaut. Lorsque la construction a échoué, l'identificateur est -1. 
        ''' </summary>
        Public Sub New(id As Integer, dbCon As MySqlConnection)
            m_dbConnectionFiche = dbCon
            m_id = id
            Dim Indice As Integer = 0
            Dim dbComFiche As MySqlCommand = New MySqlCommand("SELECT * FROM commentaire WHERE idfiche=" & id, m_dbConnectionFiche)
            Dim dbReadfiche As MySqlDataReader = dbComFiche.ExecuteReader()
            Dim etat As String

            m_commentaires = New ArrayList()
            While dbReadfiche.Read
                Dim ComTemp As Commentaire = New Commentaire(dbReadfiche.GetString("destinateurcom"), dbReadfiche.GetInt32("idfiche"), dbReadfiche.GetInt32("idcommentaire"), dbReadfiche.GetString("messagecom"))
                m_commentaires.Add(ComTemp)
            End While
            dbReadfiche.Close()

            'Remplissage des autres attribues de la classe
            dbComFiche = New MySqlCommand("SELECT * FROM fiche WHERE idfiche=" + id.ToString, m_dbConnectionFiche)

            Try
                dbReadfiche = dbComFiche.ExecuteReader()

                While dbReadfiche.Read()
                    m_idEditeur = dbReadfiche.GetInt32("idediteur")
                    m_idEquipe = dbReadfiche.GetInt32("idequipe")
                    m_annee = dbReadfiche.GetDateTime("anneefi")
                    m_nomJoueur = dbReadfiche.GetString("nomjoueurfi")
                    m_prenomJoueur = dbReadfiche.GetString("prenomjoueurfi")
                    m_numeroJoueur = dbReadfiche.GetInt32("nojoueurfi")
                    m_isRecrue = dbReadfiche.GetBoolean("recruefi")
                    m_position = dbReadfiche.GetString("positionfi")
                    If dbReadfiche("numerotationfi") IsNot DBNull.Value Then
                        m_numerotation = dbReadfiche.GetString("numerotationfi")
                    End If
                    m_valeur = dbReadfiche.GetFloat("valeurfi")
                    etat = dbReadfiche.GetString("etatfi")

                    'Détermination de m_Etat
                    Select Case etat
                        Case "impeccable"
                            m_Etat = Fiche.Etat.impeccable
                        Case "bonne"
                            m_Etat = Fiche.Etat.bonne
                        Case "moyenne"
                            m_Etat = Fiche.Etat.moyenne
                        Case "passable"
                            m_Etat = Fiche.Etat.passable
                        Case "pietre"
                            m_Etat = Fiche.Etat.pietre
                    End Select

                    m_imageDevant = dbReadfiche.GetString("imagedevantfi")
                    m_imageDerriere = dbReadfiche.GetString("imagederrierefi")
                    m_publicationSurSite = dbReadfiche.GetDateTime("publicationsursitefi")
                End While

                dbReadfiche.Close()
            Catch ex As Exception
                m_id = -1
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
        ''' Fonction qui retourne le nom d'utilisateur du membre à qui appartient la fiche.
        ''' </summary>
        ''' <returns>Retourne une chaîne de caractère correspondant au nom d'utilistateur du membre. Retourne nulle si erreur.</returns>
        Public Function PseudoDetenteur() As String
            Dim requete As MySqlCommand = New MySqlCommand("SELECT membre.nomutilisateurmem FROM membre " +
                                                           "JOIN collection ON collection.idmembre = membre.idmembre " +
                                                           "JOIN fiche ON fiche.idcollection = collection.idcollection " +
                                                           "WHERE fiche.idfiche=" + m_id.ToString, m_dbConnectionFiche)
            Dim reader As MySqlDataReader
            Dim pseudo As String

            Try
                reader = requete.ExecuteReader()
                reader.Read()
                pseudo = reader.GetString("nomutilisateurmem")
                reader.Close()
                Return pseudo
            Catch ex As Exception
                Return Nothing
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
                dbRead.Close()
                Return liste
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' Fonction permettant de recevoir une liste de fiche du plus récent au plus vieux par sport.
        ''' </summary>
        ''' <param name="connection">Connection à une base de donnée MySQL.</param>
        ''' <param name="sport">Type de sport.</param>
        ''' <returns>Retourne une liste de fiches. Si un problème, retourne une valeur nulle.</returns>
        Public Shared Function ListeFichesOrdonnee(sport As Entitees.Collection.Type, connection As MySqlConnection) As List(Of Entitees.Fiche)
            Dim ids As List(Of Integer) = New List(Of Integer)()
            Dim fiches As List(Of Entitees.Fiche) = New List(Of Entitees.Fiche)()
            Dim requete As MySqlCommand = New MySqlCommand("SELECT fiche.idfiche FROM fiche " +
                                                           "JOIN collection ON collection.idcollection = fiche.idcollection " +
                                                           "WHERE collection.typecol='" + sport.ToString.ToLower + "' " +
                                                           "ORDER BY fiche.publicationsursitefi DESC", connection)
            Dim reader As MySqlDataReader

            Try
                reader = requete.ExecuteReader()

                'Récuprération des identificateurs en ordre
                While reader.Read()
                    ids.Add(reader.GetInt32("idfiche"))
                End While
                reader.Close()

                'Construction de la liste de fiches
                For Each identificateur In ids
                    fiches.Add(New Entitees.Fiche(identificateur, connection))
                Next

                Return fiches
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

    End Class

End Namespace
