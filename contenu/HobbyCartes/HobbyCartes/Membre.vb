Imports MySql.Data
Imports MySql.Data.MySqlClient

Namespace Entitees

    Public Class Membre

        Private m_id As Integer

        Private m_prenom As String

        Private m_nom As String

        Private m_nomUtilisateur As String

        Private m_motDePasse As String

        Private m_ville As String

        Private m_codePostal As String

        Private m_courriel As String

        Private m_isAdmin As Boolean

        Private m_arrierePlan As String

        Private m_collections As Dictionary(Of Collection.Type, Collection)

        Private m_dbConnection As MySqlConnection


        ''' <summary>
        ''' Construit un membre vide avec une connection à une base de données.
        ''' </summary>
        ''' <param name="dbCon">Connection à une base de données MySQL.</param>
        ''' <remarks>
        ''' Peut être utilisé pour créer un nouveau membre.
        ''' </remarks>
        Public Sub New(dbCon As MySqlConnection)
            m_dbConnection = dbCon
        End Sub

        Public Shared Function getIDbyPseudo(pseudo As String, connection As MySqlConnection) As Integer
            Dim requete As MySqlCommand = New MySqlCommand("SELECT idmembre FROM membre WHERE nomutilisateurmem='" + pseudo + "'", connection)
            Dim reader As MySqlDataReader
            Dim id As Integer

            Try
                reader = requete.ExecuteReader()
                reader.Read()
                id = reader.GetInt32("idmembre")
                reader.Close()

                Return id
            Catch ex As Exception
                Return -1
            End Try
        End Function

        ''' <summary>
        ''' Construit un membre avec son id dans la base de donnees.
        ''' Le membre va se construire en chargeant ses attributs depuis la base de donnees passee en parametre.
        ''' Si aucun membre n'a cet id, une exception est levee.
        ''' </summary>
        Public Sub New(id As Integer, dbCon As MySqlConnection)
            ' Verification de l'existence du membre en bdd
            If Not existe(id, dbCon) Then
                Throw New ApplicationException("Aucun membre n'a l'id " & id & "!")
            End If
            ' Execution de la requete SQL
            Dim dbCom As MySqlCommand = New MySqlCommand("SELECT * FROM membre WHERE idmembre=" & id, dbCon)
            Dim dbRead As MySqlDataReader = dbCom.ExecuteReader()
            dbRead.Read()
            ' Chargement des attributs
            m_id = id
            m_prenom = dbRead.GetString("prenommem")
            m_nom = dbRead.GetString("nommem")
            m_nomUtilisateur = dbRead.GetString("nomutilisateurmem")
            m_motDePasse = dbRead.GetString("motpassemem")
            m_ville = dbRead.GetString("villemem")
            m_codePostal = dbRead.GetString("codepostalmem")
            m_courriel = dbRead.GetString("courrielmem")
            m_isAdmin = dbRead.GetBoolean("adminmem")
            If dbRead("arriereplanmem") IsNot DBNull.Value Then
                m_arrierePlan = dbRead.GetString("arriereplanmem")
            End If

            m_dbConnection = dbCon
            dbRead.Close()
        End Sub

        ''' <summary>
        ''' Verifie l'existence d'un membre avec un id dans la base de donnees.
        ''' </summary>
        ''' <returns>True si un utilisateur avec cet id existe, false sinon</returns>
        Private Shared Function existe(id As Integer, dbCon As MySqlConnection) As Boolean
            Dim dbCom As MySqlCommand = New MySqlCommand("SELECT COUNT(*) FROM membre WHERE idmembre=" & id, dbCon)
            Dim nb As Integer = dbCom.ExecuteScalar()
            Return (nb <> 0)
        End Function

        ''' <summary>
        ''' Accesseur du nom du membre
        ''' </summary>
        Public Property nom() As String
            Get
                Return m_nom
            End Get
            Set(value As String)
                m_nom = value
            End Set
        End Property

        ''' <summary>
        ''' Accesseur du prenom du membre
        ''' </summary>
        Public Property prenom() As String
            Get
                Return m_prenom
            End Get
            Set(value As String)
                m_prenom = value
            End Set
        End Property

        ''' <summary>
        ''' Accesseur du nom d'utilisateur (pseudonyme) du membre
        ''' </summary>
        Public Property nomUtilisateur() As String
            Get
                Return m_nomUtilisateur
            End Get
            Set(value As String)
                m_nomUtilisateur = value
            End Set
        End Property

        ''' <summary>
        ''' Accesseur du nom de la ville du membre.
        ''' </summary>
        ''' <value>Le nom de la ville.</value>
        ''' <returns>Retourne le nom de la ville.</returns>
        Public Property Ville As String
            Get
                Return m_ville
            End Get
            Set(value As String)
                m_ville = value
            End Set
        End Property

        ''' <summary>
        ''' Accesseur du code postal de la ville.
        ''' </summary>
        ''' <value>Le code postal de la ville</value>
        ''' <returns>Retourne le code postal de la ville</returns>
        Public Property CodePostal As String
            Get
                Return m_codePostal
            End Get
            Set(value As String)
                m_codePostal = value
            End Set
        End Property

        ''' <summary>
        ''' Accesseur de l'adresse courriel du membre. 
        ''' </summary>
        ''' <value>L'adresse courriel du membre</value>
        ''' <returns>Retourne le courriel du membre</returns>
        Public Property Courriel As String
            Get
                Return m_courriel
            End Get
            Set(value As String)
                m_courriel = value
            End Set
        End Property

        ''' <summary>
        ''' Accesseur du nom complet (Prenom Nom) du membre
        ''' </summary>
        Public ReadOnly Property nomComplet() As String
            Get
                Return prenom + " " + nom
            End Get
        End Property


        ''' <summary>
        ''' Accesseur de l'id du membre
        ''' </summary>
        Public ReadOnly Property id() As Integer
            Get
                Return m_id
            End Get
        End Property

        ''' <summary>
        ''' Envoie un message a un autre membre.
        ''' </summary>
        ''' <param name="destinataire">Le destinataire du message</param>
        ''' <param name="objet">L'objet du message</param>
        ''' <param name="contenu">Le contenu du message</param>
        Sub envoyerMessage(destinataire As Membre, objet As String, contenu As String)
            Dim dbCom As MySqlCommand = New MySqlCommand("INSERT INTO message (iddestinataire, iddestinateur, objetmes, mesmes) " &
                                                        "VALUES(" & destinataire.id & ", " & Me.id & ", '" & objet & "', '" & contenu & "');",
                                                        m_dbConnection)
            dbCom.ExecuteNonQuery()
        End Sub

        ''' <summary>
        ''' Crée un nouveau membre dans la base de données.
        ''' </summary>
        Public Function nouvMembre(ByVal membre As Entitees.Membre, ByVal motPass As String, ByRef msgErreur As String) As Boolean
            m_arrierePlan = ""
            m_codePostal = membre.CodePostal
            m_courriel = membre.Courriel
            m_ville = membre.Ville
            m_isAdmin = False
            m_motDePasse = motPass
            m_nom = membre.nom
            m_prenom = membre.prenom
            m_nomUtilisateur = membre.nomUtilisateur
            msgErreur = ""

            Dim requete As MySqlCommand = New MySqlCommand("INSERT INTO membre(prenommem, nommem, nomutilisateurmem, motpassemem, villemem, codepostalmem, courrielmem, adminmem, arriereplanmem) VALUES('" +
                                                           membre.prenom + "','" +
                                                           membre.nom + "','" +
                                                           membre.nomUtilisateur + "','" +
                                                           motPass + "','" +
                                                           membre.Ville + "','" +
                                                           membre.CodePostal + "','" +
                                                           membre.Courriel + "','0','" +
                                                           m_arrierePlan + "')", m_dbConnection)

            Try
                requete.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                msgErreur = ex.Message
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Retrouve la liste de tous les noms d'utilisateur dans la base de données.
        ''' </summary>
        Public Function getNomsPseudo() As ArrayList
            Dim requete As MySqlCommand = New MySqlCommand("SELECT nomutilisateurmem FROM membre", m_dbConnection)
            Dim lignes As MySqlDataReader = requete.ExecuteReader()
            Dim noms As ArrayList = New ArrayList()

            While lignes.Read()
                noms.Add(lignes.GetString("nomutilisateurmem"))
            End While

            lignes.Close()

            Return noms
        End Function

        ''' <summary>
        ''' Modifie les informations du membre dans la base de données.
        ''' </summary>
        ''' <param name="msgErreur">Message d'erreur si un problème survient</param>
        ''' <returns>Retourne True si tout s'est bien passé sinon retourne False</returns>
        Public Function setAttMembre(ByRef msgErreur As String) As Boolean
            Dim requete As MySqlCommand = New MySqlCommand("UPDATE membre SET " +
                                                           "prenommem='" + m_prenom + "', " +
                                                           "nommem='" + m_nom + "', " +
                                                           "nomutilisateurmem='" + m_nomUtilisateur + "', " +
                                                           "villemem='" + m_ville + "', " +
                                                           "codepostalmem='" + m_codePostal + "', " +
                                                           "courrielmem='" + m_courriel + "' WHERE idmembre='" + m_id.ToString + "'", m_dbConnection)

            Try
                requete.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                msgErreur = ex.Message
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Donne le nom d'utilisateur (= pseudo) d'un membre en fonction de son ID
        ''' </summary>
        Public Shared Function getNomUtilisateurParId(id As Integer, dbCon As MySqlConnection) As String
            Dim com As MySqlCommand = New MySqlCommand("SELECT nomutilisateurmem FROM membre WHERE idmembre=" & id, dbCon)
            Return com.ExecuteScalar()
        End Function

    End Class

End Namespace