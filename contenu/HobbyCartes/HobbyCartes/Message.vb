Imports MySql.Data.MySqlClient

Namespace Entitees

    Public Class Message

        Private m_id As Integer

        Private m_idDestinateur As Integer

        Private m_idDestinataire As Integer

        Private m_objet As String

        Private m_contenu As String

        ''' <summary>
        ''' Construit un message
        ''' </summary>
        Public Sub New(id As Integer, idDestinateur As Integer, idDestinataire As Integer, objet As String, contenu As String)
            m_id = id
            m_idDestinataire = idDestinataire
            m_idDestinateur = m_idDestinateur
            m_objet = objet
            m_contenu = contenu
        End Sub

        ''' <summary>
        ''' Accesseur du l'id du destinateur
        ''' </summary>
        Public ReadOnly Property idDestinateur() As Integer
            Get
                Return m_idDestinateur
            End Get
        End Property

        ''' <summary>
        ''' Accesseur du l'id du destinataire
        ''' </summary>
        Public ReadOnly Property idDestinataire() As Integer
            Get
                Return m_idDestinataire
            End Get
        End Property

        ''' <summary>
        ''' Accesseur du l'id du message
        ''' </summary>
        Public ReadOnly Property id() As Integer
            Get
                Return m_id
            End Get
        End Property

        ''' <summary>
        ''' Accesseur de l'objet du message
        ''' </summary>
        Public ReadOnly Property objet() As String
            Get
                Return m_objet
            End Get
        End Property

        ''' <summary>
        ''' Accesseur du contenu du message
        ''' </summary>
        Public ReadOnly Property contenu() As String
            Get
                Return m_contenu
            End Get
        End Property

        ''' <summary>
        ''' Recupere et retourne la liste des messages dont le destinataire est le membre dont l'id est passee en parametre
        ''' </summary>
        Public Shared Function getListe(idMembre As Integer, dbCon As MySqlConnection) As List(Of Message)
            Dim listeMessages As List(Of Message) = New List(Of Message)
            Dim dbCom As MySqlCommand = New MySqlCommand("SELECT * FROM message WHERE iddestinataire=" & idMembre, dbCon)
            Dim dbRead As MySqlDataReader = dbCom.ExecuteReader()
            While dbRead.Read()
                Dim message As Message = New Message(dbRead.GetInt32("idmess"),
                                                     dbRead.GetInt32("iddestinataire"),
                                                     dbRead.GetInt32("iddestinateur"),
                                                     dbRead.GetString("objet"),
                                                     dbRead.GetString("mess"))
                listeMessages.Add(message)
            End While
            dbRead.Close()
            Return listeMessages
        End Function

    End Class

End Namespace
