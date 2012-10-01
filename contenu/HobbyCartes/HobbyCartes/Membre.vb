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

        ''' <summary>
        ''' Constructeur par defaut.
        ''' </summary>
        Public Sub New()
            m_prenom = "Homer"
            m_nom = "Simpson"
            m_nomUtilisateur = "hsimpson"
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

    End Class

End Namespace