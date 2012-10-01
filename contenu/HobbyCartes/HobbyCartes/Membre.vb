Imports MySql.Data
Imports MySql.Data.MySqlClient

Namespace Entitees

    Public Class Membre

        Private m_prenom As String

        Private m_nom As String

        Private m_nomUtilisateur As String

        Private m_motDePasse As String

        Private _mville As String

        Private m_codePostal As String

        Private m_courriel As String

        Private m_isAdmin As Boolean

        Private m_arrierePlan As String

        Private m_collections As Dictionary(Of Collection.Type, Collection)

        Private m_dbConnection As MySqlConnection

        ''' <summary>
        ''' Constructeur par defaut.
        ''' </summary>
        Public Sub New(dbCon As MySqlConnection)
            m_dbConnection = dbCon
        End Sub

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
            m_prenom = dbRead.GetString("prenom")
            m_nom = dbRead.GetString("nom")
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
        Public ReadOnly Property nom() As String
            Get
                Return m_nom
            End Get
        End Property

        ''' <summary>
        ''' Accesseur du prenom du membre
        ''' </summary>
        Public ReadOnly Property prenom() As String
            Get
                Return m_prenom
            End Get
        End Property

        ''' <summary>
        ''' Accesseur du nom d'utilisateur (pseudonyme) du membre
        ''' </summary>
        Public ReadOnly Property nomUtilisateur() As String
            Get
                Return m_nomUtilisateur
            End Get
        End Property

        ''' <summary>
        ''' Accesseur du nom complet (Prenom Nom) du membre
        ''' </summary>
        Public ReadOnly Property nomComplet() As String
            Get
                Return prenom + " " + nom
            End Get
        End Property

        Public Function nouvMembre(ByVal prenom As String, ByVal nom As String, ByVal ville As String, ByVal codePostal As String, ByVal courriel As String, ByVal nomUtilisateur As String, ByVal motPass As String) As Boolean
            m_arrierePlan = ""
            m_codePostal = codePostal
            m_courriel = courriel
            m_isAdmin = False
            m_motDePasse = motPass
            m_nom = nom
            m_prenom = prenom
            m_nomUtilisateur = nomUtilisateur

            Dim requete As MySqlCommand = New MySqlCommand("INSERT INTO membre(prenom, nom, nomutilisateur, motpasse, ville, codepostal, courriel, admin, arriereplan) VALUES('" +
                                                           prenom + "','" +
                                                           nom + "','" +
                                                           nomUtilisateur + "','" +
                                                           motPass + "','" +
                                                           ville + "','" +
                                                           codePostal + "','" +
                                                           courriel + "','" +
                                                           m_isAdmin.ToString + "','" +
                                                           m_arrierePlan + "')", m_dbConnection)

            Try
                requete.ExecuteNonQuery()
            Catch ex As Exception

            End Try
        End Function

        Public Function getNomsPseudo() As ArrayList
            Dim requete As MySqlCommand = New MySqlCommand("SELECT nomutilisateur FROM membre", m_dbConnection)
            Dim lignes As MySqlDataReader = requete.ExecuteReader()
            Dim noms As ArrayList = New ArrayList()

            While lignes.Read()
                noms.Add(lignes.GetString("nomutilisateur"))
            End While

            Return noms
        End Function

        ''' <summary>
        ''' Accesseur de l'id du membre
        ''' </summary>
        Public ReadOnly Property id() As Integer
            Get
                Return 1 ' TODO
            End Get
        End Property

        ''' <summary>
        ''' Envoie un message a un autre membre.
        ''' </summary>
        ''' <param name="destinataire">Le destinataire du message</param>
        ''' <param name="objet">L'objet du message</param>
        ''' <param name="contenu">Le contenu du message</param>
        Sub envoyerMessage(destinataire As Membre, objet As String, contenu As String, dbCon As MySqlConnection)
            Dim dbCom As MySqlCommand = New MySqlCommand("INSERT INTO message (iddestinataire, iddestinateur, objet, mess) " &
                                                        "VALUES(" & destinataire.id & ", " & Me.id & ", '" & objet & "', '" & contenu & "');",
                                                        dbCon)
            dbCom.ExecuteNonQuery()
        End Sub


    End Class

End Namespace