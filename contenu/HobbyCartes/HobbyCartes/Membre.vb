Imports MySql.Data
Imports MySql.Data.MySqlClient

Namespace Entitees

    Public Class Membre

        Private prenom As String

        Private nom As String

        Private nomUtilisateur As String

        Private motDePasse As String

        Private ville As String

        Private codePostal As String

        Private courriel As String

        Private isAdmin As Boolean

        Private arrierePlan As String

        Private collections As Dictionary(Of Collection.Type, Collection)

        ''' <summary>
        ''' Constructeur par defaut.
        ''' </summary>
        Public Sub New()
            prenom = "Homer"
            nom = "Simpson"
            nomUtilisateur = "hsimpson"
        End Sub

        ''' <summary>
        ''' Construit un membre avec son id dans la base de donnees
        ''' </summary>
        Public Sub New(id As Integer)
            Dim dbCon As MySqlConnection = New MySqlConnection("Server=G264-11;Database=test;Uid=root;Pwd=toor;")
            Dim dbCom As MySqlCommand = New MySqlCommand("SELECT * FROM membre WHERE idmembre=" & id, dbCon)
            Dim dbRead As MySqlDataReader
            dbCon.Open()
            dbRead = dbCom.ExecuteReader()
            dbRead.Read()
            prenom = dbRead.GetString("prenom")
            nom = dbRead.GetString("nom")
            dbCon.Close()
        End Sub

        ''' <summary>
        ''' Verifie l'existence d'un membre avec un nom d'utilisateur
        ''' </summary>
        ''' <returns>True si un utilisateur avec ce nom d'utilisateur existe, false sinon</returns>
        Public Shared Function existe(nomUtilisateur As String) As Boolean
            ' TODO 
            Return False
        End Function

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