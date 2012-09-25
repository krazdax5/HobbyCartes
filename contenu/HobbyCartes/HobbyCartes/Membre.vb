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
            ' TODO
        End Sub

        ''' <summary>
        ''' Verifie l'existence d'un membre avec un nom d'utilisateur
        ''' </summary>
        ''' <returns>True si un utilisateur avec ce nom d'utilisateur existe, false sinon</returns>
        Public Shared Function existe(nomUtilisateur As String) As Boolean
            ' TODO 
            Return False
        End Function



    End Class

End Namespace