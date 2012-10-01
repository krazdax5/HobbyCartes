Namespace Entitees

    Public Class Commentaire

        Private destinateur As Membre

        Private message As String

        Private IDFiche As Integer

        ''' <summary>
        ''' Construit un commentaire avec une destinataire et un Idfiche de la propriétaire
        ''' </summary>
        ''' 
        Public Sub New()
            'À faire
        End Sub

        ''' <summary>
        ''' Construit un commentaire avec une destinataire et un Idfiche de la propriétaire
        ''' </summary>
        ''' 
        Public Sub New(ByVal Dest As Membre, ByVal FicheID As Integer)
            destinateur = Dest
            IDFiche = FicheID
        End Sub

        ''' <summary>
        ''' Accesseur et mutateur du message du commentaire
        ''' </summary>
        Public Property accesMessage() As String
            Get
                Return Message
            End Get
            Set(ByVal value As String)
                message = value
            End Set
        End Property
    End Class

End Namespace
