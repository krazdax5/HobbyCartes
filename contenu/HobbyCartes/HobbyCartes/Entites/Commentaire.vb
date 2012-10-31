Namespace Entites

    Public Class Commentaire

        Private destinateur As String

        Private message As String

        Private IDFiche As Integer

        Private IDCommentaire As Integer

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
        Public Sub New(ByVal Dest As String, ByVal FicheID As Integer)
            destinateur = Dest
            IDFiche = FicheID
        End Sub

        ''' <summary>
        ''' Construit un commentaire avec tout
        ''' </summary>
        ''' 
        Public Sub New(ByVal Dest As String, ByVal FicheID As Integer, ByVal CommentaireID As Integer, ByVal messages As String)
            destinateur = Dest
            IDFiche = FicheID
            IDCommentaire = CommentaireID
            message = messages
        End Sub

        ''' <summary>
        ''' Accesseur et mutateur du message du commentaire
        ''' </summary>
        Public Property pMessage() As String
            Get
                Return Message
            End Get
            Set(ByVal value As String)
                message = value
            End Set
        End Property

        ''' <summary>
        ''' Accesseur et mutateur du message du commentaire
        ''' </summary>
        Public Property pDestinateur() As String
            Get
                Return destinateur
            End Get
            Set(ByVal value As String)
                destinateur = value
            End Set
        End Property

        Public Property pIDFiche() As Integer
            Get
                Return IDFiche
            End Get
            Set(ByVal value As Integer)
                IDFiche = value
            End Set
        End Property

        Public Property pIDCommentaire() As Integer
            Get
                Return IDCommentaire
            End Get
            Set(ByVal value As Integer)
                IDCommentaire = value
            End Set
        End Property

    End Class

End Namespace
