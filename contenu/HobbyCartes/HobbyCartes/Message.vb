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
        ''' Recupere et retourne la liste des messages dont le destinataire est le membre dont l'id est passee en parametre
        ''' </summary>
        Public Shared Function getListe(idMembre As Integer, dbCon As MySqlConnection) As List(Of Message)
            Dim listeMessages As List(Of Message) = New List(Of Message)
            Dim dbCom As MySqlCommand = New MySqlCommand("SELECT * FROM message WHERE iddestinataire=" & idMembre, dbCon)
            Dim dbRead As MySqlDataReader = dbCom.ExecuteReader()
            While dbRead.Read()
                Dim message As Message = New Message(dbRead.GetInt16("idmess"),
                                                     dbRead.GetInt16("iddestinataire"),
                                                     dbRead.GetInt16("iddestinateur"),
                                                     dbRead.GetString("objet"),
                                                     dbRead.GetString("mess"))
            End While
            dbRead.Close()
            Return listeMessages
        End Function

    End Class

End Namespace
