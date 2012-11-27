'--------------------------------------------------------------------------
' Titre: Fiche.vb
' Auteur: Charles Levesque
' Date: Septembre 2012
' Contribution: Jean-François Collin, Loïc Vial
'--------------------------------------------------------------------------

Imports MySql.Data
Imports MySql.Data.MySqlClient

Namespace Entites

    Public Class Fiche

        Public Enum Etat
            impeccable
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

        Private m_etat As Etat

        Private m_imageDevant As String

        Private m_imageDerriere As String

        Private m_publicationSurSite As Date

        Private m_commentaires As List(Of Commentaire)

        Private m_idCollection As Integer

        ''' <summary>
        ''' Identificateur de la fiche
        ''' </summary>
        Public Property ID As Integer
            Get
                Return m_id
            End Get
            Set(value As Integer)
                m_id = value
            End Set
        End Property

        ''' <summary>
        ''' Chemin vers l'image du devant de la carte
        ''' </summary>
        Public Property ImageAvant As String
            Get
                Return m_imageDevant
            End Get
            Set(value As String)
                m_imageDevant = value
            End Set
        End Property

        ''' <summary>
        ''' Chemin vers l'image du arriere de la carte
        ''' </summary>
        Public Property ImageArriere As String
            Get
                Return m_imageDerriere
            End Get
            Set(value As String)
                m_imageDerriere = value
            End Set
        End Property

        ''' <summary>
        ''' Nom de famille du joueur
        ''' </summary>
        Public Property NomJoueur As String
            Get
                Return m_nomJoueur
            End Get
            Set(value As String)
                m_nomJoueur = value
            End Set
        End Property

        ''' <summary>
        ''' Prénom du joueur
        ''' </summary>
        Public Property PrenomJoueur As String
            Get
                Return m_prenomJoueur
            End Get
            Set(value As String)
                m_prenomJoueur = value
            End Set
        End Property

        ''' <summary>
        ''' Année de la série de la carte
        ''' </summary>
        Public Property DateCarte As Date
            Get
                Return m_annee
            End Get
            Set(value As Date)
                m_annee = value
            End Set
        End Property

        ''' <summary>
        ''' Éditeur de la carte.
        ''' </summary>
        ''' <returns>Retourne une instance de la classe Entitees.Editeur</returns>
        Public Property Editeur As Entites.Editeur
            Get
                Return New Entites.Editeur(m_idEditeur)
            End Get
            Set(value As Entites.Editeur)
                m_idEditeur = value.idEditeur
            End Set
        End Property

        ''' <summary>
        ''' Valeur de la carte en dollar canadien
        ''' </summary>
        Public Property Valeur As Double
            Get
                Return m_valeur
            End Get
            Set(value As Double)
                m_valeur = value
            End Set
        End Property

        ''' <summary>
        ''' Date de publication sur le site
        ''' </summary>
        Public Property DatePublication As Date
            Get
                Return m_publicationSurSite
            End Get
            Set(value As Date)
                m_publicationSurSite = value
            End Set
        End Property

        ''' <summary>
        ''' Équipe de la fiche
        ''' </summary>
        Public Property Equipe As Equipe
            Get
                Return New Equipe(m_idEquipe)
            End Get
            Set(value As Equipe)
                m_idEquipe = value.id
            End Set
        End Property

        ''' <summary>
        ''' Numéro du joueur
        ''' </summary>
        Public Property Numero As Integer
            Get
                Return m_numeroJoueur
            End Get
            Set(value As Integer)
                m_numeroJoueur = value
            End Set
        End Property

        Public Property Position As String
            Get
                Return m_position
            End Get
            Set(value As String)
                m_position = value
            End Set
        End Property

        Public Property Recrue As Boolean
            Get
                Return m_isRecrue
            End Get
            Set(value As Boolean)
                m_isRecrue = value
            End Set
        End Property

        Public Property Numerotation As String
            Get
                Return m_numerotation
            End Get
            Set(value As String)
                m_numerotation = value
            End Set
        End Property

        Public Property Etatfiche As Entites.Fiche.Etat
            Get
                Return m_etat
            End Get
            Set(value As Entites.Fiche.Etat)
                m_etat = value
            End Set
        End Property

        Public Property IDCollection As Integer
            Get
                Return m_idCollection
            End Get
            Set(value As Integer)
                m_idCollection = value
            End Set
        End Property
        ''' <summary>
        ''' Propriété qui retourne le nombre d'entrée valide dans le tableau de commentaire
        ''' </summary>
        Public ReadOnly Property NbCom() As Integer
            Get
                Return m_commentaires.Count
            End Get
        End Property

        Public ReadOnly Property CollectionType As String
            Get
                Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
                dbCon.Open()
                Dim req As MySqlCommand = New MySqlCommand("SELECT typecol FROM collection WHERE idcollection=" & m_idCollection, dbCon)
                Dim read = req.ExecuteReader
                read.Read()
                Dim ret As String = read.GetString("typecol")
                read.Close()
                dbCon.Close()
                Return ret
            End Get
        End Property

        ''' <summary>
        ''' Constructeur par defaut
        ''' </summary>
        Public Sub New()
            m_idEditeur = -1
            m_idEquipe = -1
            m_id = -1
            m_annee = Nothing
            m_nomJoueur = ""
            m_prenomJoueur = ""
            m_numeroJoueur = 0
            m_isRecrue = False
            m_position = ""
            m_numerotation = ""
            m_valeur = 0
            m_etat = Etat.moyenne
            m_imageDevant = ""
            m_imageDerriere = ""
            m_publicationSurSite = Nothing
            m_commentaires = New List(Of Commentaire)
            m_idCollection = -1
        End Sub

        ''' <summary>
        ''' Constructeur via l'id de la fiche. Lorsque la construction a échoué, l'identificateur est -1. 
        ''' </summary>
        Public Sub New(id As Integer)
            Me.New()

            Dim dbCon = New MySqlConnection(My.Resources.StringConnexionBdd)
            dbCon.Open()
            m_id = id
            Dim Indice As Integer = 0
            Dim dbComFiche As MySqlCommand = New MySqlCommand("SELECT * FROM commentaire WHERE idfiche=" & id, dbCon)
            Dim dbReadfiche As MySqlDataReader = dbComFiche.ExecuteReader()
            Dim etat As String

            While dbReadfiche.Read
                Dim ComTemp As Commentaire = New Commentaire(dbReadfiche.GetString("destinateurcom"), dbReadfiche.GetInt32("idfiche"), dbReadfiche.GetInt32("idcommentaire"), dbReadfiche.GetString("messagecom"))
                m_commentaires.Add(ComTemp)
            End While
            dbReadfiche.Close()

            'Remplissage des autres attributs de la classe
            dbComFiche = New MySqlCommand("SELECT * FROM fiche WHERE idfiche=" + id.ToString, dbCon)

            Try
                dbReadfiche = dbComFiche.ExecuteReader()

                While dbReadfiche.Read()
                    m_idCollection = dbReadfiche.GetInt32("idcollection")
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
                            m_etat = Fiche.Etat.impeccable
                        Case "bonne"
                            m_etat = Fiche.Etat.bonne
                        Case "moyenne"
                            m_etat = Fiche.Etat.moyenne
                        Case "passable"
                            m_etat = Fiche.Etat.passable
                        Case "pietre"
                            m_etat = Fiche.Etat.pietre
                    End Select

                    If dbReadfiche("imagedevantfi") IsNot DBNull.Value Then
                        m_imageDevant = dbReadfiche.GetString("imagedevantfi")
                    End If
                    If dbReadfiche("imagederrierefi") IsNot DBNull.Value Then
                        m_imageDerriere = dbReadfiche.GetString("imagederrierefi")
                    End If
                    m_publicationSurSite = dbReadfiche.GetDateTime("publicationsursitefi")
                End While

                dbReadfiche.Close()
            Catch ex As Exception
                m_id = -1
            End Try

            dbCon.Close()
        End Sub

        ''' <summary>
        '''Retourne le commentaire à l'indice désirée
        ''' </summary>
        Public Function ChercheCom(Indice As Integer) As Commentaire
            Return m_commentaires(Indice)
        End Function

        Public Function NouvCommentaire(Comm As Commentaire) As Integer
            Dim dbCon = New MySqlConnection(My.Resources.StringConnexionBdd)
            dbCon.Open()
            Dim Com As Commentaire = New Commentaire()
            Com = Comm
            m_commentaires.Add(Com)
            Dim requete As MySqlCommand = New MySqlCommand("INSERT INTO commentaire(idfiche, destinateurcom, messagecom) VALUES('" +
                                                           Com.pIDFiche.ToString() + "','" +
                                                           Com.pDestinateur + "','" +
                                                           Com.pMessage + "')", dbCon)

            Try
                requete.ExecuteNonQuery()
                Return Integer.Parse(requete.LastInsertedId.ToString())
            Catch ex As Exception
                Return -1
            End Try
            dbCon.Close()
        End Function

        Public Function SupCommentaire(IDCom As String) As Boolean
            Dim dbCon = New MySqlConnection(My.Resources.StringConnexionBdd)
            dbCon.Open()
            Dim requete As MySqlCommand = New MySqlCommand("DELETE FROM commentaire WHERE idcommentaire='" + IDCom + "'", dbCon)

            Try
                requete.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                Return False
            End Try
            dbCon.Close()
        End Function

        ''' <summary>
        ''' Fonction qui retourne le nom d'utilisateur du membre à qui appartient la fiche.
        ''' </summary>
        ''' <returns>Retourne une chaîne de caractère correspondant au nom d'utilistateur du membre. Retourne nulle si erreur.</returns>
        Public Function PseudoDetenteur() As String
            Dim dbCon = New MySqlConnection(My.Resources.StringConnexionBdd)
            dbCon.Open()
            Dim requete As MySqlCommand = New MySqlCommand("SELECT membre.nomutilisateurmem FROM membre " +
                                                           "JOIN collection ON collection.idmembre = membre.idmembre " +
                                                           "JOIN fiche ON fiche.idcollection = collection.idcollection " +
                                                           "WHERE fiche.idfiche=" + m_id.ToString, dbCon)
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
            dbCon.Close()
        End Function

        ''' <summary>
        ''' Sauvegarde la fiche en base de donnees
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub sauvegarde()
            Dim dbCon = New MySqlConnection(My.Resources.StringConnexionBdd)
            dbCon.Open()
            Dim requete As MySqlCommand = New MySqlCommand
            If m_id = -1 Then
                requete = New MySqlCommand("INSERT INTO fiche(idcollection, idediteur, idequipe, " &
                                                               "anneefi, publicationsursitefi, " &
                                                               "nomjoueurfi, prenomjoueurfi, nojoueurfi, " &
                                                               "recruefi, positionfi, valeurfi, etatfi, imagedevantfi, imagederrierefi) " &
                                                               "VALUES(" & m_idCollection & ", " & m_idEditeur & ", " & m_idEquipe &
                                                               ", """ & m_annee.Year & "-" & m_annee.Month & "-" & m_annee.Day & """, NOW() " &
                                                               ", """ & m_nomJoueur & """, """ & m_prenomJoueur & """, " & Numero &
                                                               ", " & m_isRecrue & ", """ & m_position & """, """ & m_valeur &
                                                               """, """ & [Enum].GetName(GetType(Etat), m_etat) & """, """ & m_imageDevant & """, """ & m_imageDerriere & """)", dbCon)
            Else
                requete = New MySqlCommand("UPDATE fiche SET idcollection=" & m_idCollection & ", idediteur=" &
                                           m_idEditeur & ", idequipe=" & m_idEquipe & ", anneefi=""" &
                                           m_annee.Year & "-" & m_annee.Month & "-" & m_annee.Day & """, nomjoueurfi=""" &
                                           m_nomJoueur & """, prenomjoueurfi=""" & m_prenomJoueur & """, nojoueurfi=" &
                                           m_numeroJoueur & ", recruefi=" & m_isRecrue & ", positionfi=""" &
                                           m_position & """, valeurfi=" & m_valeur & ", etatfi=""" &
                                           [Enum].GetName(GetType(Etat), m_etat) & """, imagedevantfi=""" & m_imageDevant & """, imagederrierefi=""" & m_imageDerriere & """ " &
                                           "WHERE idfiche=" & m_id, dbCon)
            End If
            requete.ExecuteNonQuery()
            dbCon.Close()
        End Sub

        ''' <summary>
        ''' Retrouver la liste de toutes les fiches reliées à une collection.
        ''' </summary>
        ''' <param name="idCollection">Identificateur de la collection.</param>
        ''' <returns>Retourne une liste de fiches représentant les fiches de la collection.</returns>
        Public Shared Function RetrouverListeMembre(ByVal idCollection As Integer, ByVal connection As MySqlConnection) As List(Of Entites.Fiche)
            Dim liste As List(Of Entites.Fiche) = New List(Of Entites.Fiche)()
            Dim requete As MySqlCommand = New MySqlCommand("SELECT * FROM fiche WHERE idcollection='" + idCollection + "'")
            Dim dbRead As MySqlDataReader

            Try
                dbRead = requete.ExecuteReader()
                While dbRead.NextResult
                    Dim nouvFiche As Entites.Fiche = New Entites.Fiche(dbRead.GetInt32("idfiche"))
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
        Public Shared Function ListeFichesOrdonnee(sport As Entites.Collection.Type, connection As MySqlConnection) As List(Of Entites.Fiche)
            Dim ids As List(Of Integer) = New List(Of Integer)()
            Dim fiches As List(Of Entites.Fiche) = New List(Of Entites.Fiche)()
            Dim requete As MySqlCommand = New MySqlCommand("SELECT fiche.idfiche FROM fiche " +
                                                           "JOIN collection ON collection.idcollection = fiche.idcollection " +
                                                           "WHERE collection.typecol='" + sport.ToString.ToLower + "' " +
                                                           "ORDER BY fiche.publicationsursitefi DESC", connection)
            fiches = ListeCarte(requete, connection)

            Return fiches
        End Function

        Public Shared Function Rechercher(MotCle As String, connection As MySqlConnection) As List(Of Entites.Fiche)
            Dim fiches As List(Of Entites.Fiche) = New List(Of Entites.Fiche)()
            Dim requete As MySqlCommand = New MySqlCommand("SELECT idfiche FROM fiche WHERE CONCAT(prenomjoueurfi, ' ', nomjoueurfi) LIKE '" + MotCle & _
                                                           "%' OR CONCAT(nomjoueurfi, ' ', prenomjoueurfi) LIKE '" + MotCle + "%'", connection)
            fiches = ListeCarte(requete, connection)

            Return fiches

        End Function

        Private Shared Function ListeCarte(requete As MySqlCommand, connection As MySqlConnection) As List(Of Entites.Fiche)
            Dim ids As List(Of Integer) = New List(Of Integer)()
            Dim fiches As List(Of Entites.Fiche) = New List(Of Entites.Fiche)()

            Dim reader As MySqlDataReader

            Try
                reader = requete.ExecuteReader()

                'Récuprération des identificateurs
                While reader.Read()
                    ids.Add(reader.GetInt32("idfiche"))
                End While
                reader.Close()

                'Construction de la liste de fiches
                For Each identificateur In ids
                    fiches.Add(New Entites.Fiche(identificateur))
                Next

                Return fiches
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        ''' <summary>
        ''' Supprime une fiche
        ''' </summary>
        Public Shared Sub Supprimer(idFiche As Integer)
            Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
            dbCon.Open()
            Dim req As MySqlCommand = New MySqlCommand("DELETE FROM fiche WHERE idfiche=" & idFiche, dbCon)
            req.ExecuteNonQuery()
            dbCon.Close()
        End Sub

        ''' <summary>
        ''' Retourne l'id de la prochaine fiche qui sera crée
        ''' </summary>
        Public Shared Function getNextid() As Integer
            Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
            dbCon.Open()
            Dim req As MySqlCommand = New MySqlCommand("SELECT idfiche FROM fiche ORDER BY idfiche DESC LIMIT 0, 1", dbCon)
            Dim ret = req.ExecuteScalar + 1
            dbCon.Close()
            Return ret
        End Function

    End Class

End Namespace
