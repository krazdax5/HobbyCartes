'--------------------------------------------------------------------------
' Titre: Commentaire.vb
' Auteur: Jean-François Collin
' Date: Septembre 2012
'--------------------------------------------------------------------------

Namespace Entites

    Public Class Commentaire

        Private m_Destinateur As String

        Private m_Message As String

        Private m_IDFiche As Integer

        Private m_IDCommentaire As Integer

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
            m_Destinateur = Dest
            m_IDFiche = FicheID
        End Sub

        ''' <summary>
        ''' Construit un commentaire avec tout
        ''' </summary>
        ''' 
        Public Sub New(ByVal Dest As String, ByVal FicheID As Integer, ByVal CommentaireID As Integer, ByVal messages As String)
            m_Destinateur = Dest
            m_IDFiche = FicheID
            m_IDCommentaire = CommentaireID
            m_Message = messages
        End Sub

        ''' <summary>
        ''' Accesseur et mutateur du message du commentaire
        ''' </summary>
        Public Property pMessage() As String
            Get
                Return m_Message
            End Get
            Set(ByVal value As String)
                m_Message = value
            End Set
        End Property

        ''' <summary>
        ''' Accesseur et mutateur du message du commentaire
        ''' </summary>
        Public Property pDestinateur() As String
            Get
                Return m_Destinateur
            End Get
            Set(ByVal value As String)
                m_Destinateur = value
            End Set
        End Property

        Public Property pIDFiche() As Integer
            Get
                Return m_IDFiche
            End Get
            Set(ByVal value As Integer)
                m_IDFiche = value
            End Set
        End Property

        Public Property pIDCommentaire() As Integer
            Get
                Return m_IDCommentaire
            End Get
            Set(ByVal value As Integer)
                m_IDCommentaire = value
            End Set
        End Property

    End Class

End Namespace
