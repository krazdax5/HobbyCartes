<<<<<<< HEAD
﻿Imports MySql.Data.MySqlClient
=======
﻿'--------------------------------------------------------------------------
' Titre: Message.vb
' Auteur: Loïc Vial
' Date: Septembre 2012
'--------------------------------------------------------------------------

Imports MySql.Data.MySqlClient
>>>>>>> Adminstration terminé

Namespace Entites

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
            m_idDestinateur = idDestinateur
            m_objet = objet
            m_contenu = contenu
        End Sub

        ''' <summary>
        ''' Construit un message depuis la base de donnees.
        ''' Leve une exception si le message n'existe pas.
        ''' </summary>
<<<<<<< HEAD
        Public Sub New(id As Integer)
            Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
            dbCon.Open()
=======
        Public Sub New(id As Integer, dbCon As MySqlConnection)
>>>>>>> Adminstration terminé
            Dim dbCom As MySqlCommand = New MySqlCommand("SELECT * FROM message WHERE idmess=" & id, dbCon)
            Dim dbRead As MySqlDataReader = dbCom.ExecuteReader()
            dbRead.Read()
            m_id = id
            m_idDestinataire = dbRead.GetInt32("iddestinataire")
            m_idDestinateur = dbRead.GetInt32("iddestinateur")
            m_objet = dbRead.GetString("objetmes")
            m_contenu = dbRead.GetString("mesmes")
            dbRead.Close()
<<<<<<< HEAD
            dbCon.Close()
=======
>>>>>>> Adminstration terminé
        End Sub

        ''' <summary>
        ''' Accesseur de l'id du destinateur
        ''' </summary>
        Public ReadOnly Property idDestinateur() As Integer
            Get
                Return m_idDestinateur
            End Get
        End Property

        ''' <summary>
        ''' Accesseur de l'id du destinataire
        ''' </summary>
        Public ReadOnly Property idDestinataire() As Integer
            Get
                Return m_idDestinataire
            End Get
        End Property

        ''' <summary>
        ''' Accesseur de l'id du message
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
<<<<<<< HEAD
        Public Shared Function getListe(idMembre As Integer) As List(Of Message)
            Dim dbCon = New MySqlConnection(My.Resources.StringConnexionBdd)
            dbCon.Open()
=======
        Public Shared Function getListe(idMembre As Integer, dbCon As MySqlConnection) As List(Of Message)
>>>>>>> Adminstration terminé
            Dim listeMessages As List(Of Message) = New List(Of Message)
            Dim dbCom As MySqlCommand = New MySqlCommand("SELECT * FROM message WHERE iddestinataire=" & idMembre, dbCon)
            Dim dbRead As MySqlDataReader = dbCom.ExecuteReader()
            While dbRead.Read()
                Dim message As Message = New Message(dbRead.GetInt32("idmess"),
                                                     dbRead.GetInt32("iddestinateur"),
                                                     dbRead.GetInt32("iddestinataire"),
                                                     dbRead.GetString("objetmes"),
                                                     dbRead.GetString("mesmes"))
                listeMessages.Add(message)
            End While
            dbRead.Close()
<<<<<<< HEAD
            dbCon.Close()
=======
>>>>>>> Adminstration terminé
            Return listeMessages
        End Function

        ''' <summary>
        ''' Supprime le message de la base de donnees
        ''' </summary>
<<<<<<< HEAD
        Public Sub supprimer()
            Dim dbCon = New MySqlConnection(My.Resources.StringConnexionBdd)
            dbCon.Open()
            Dim dbCom As MySqlCommand = New MySqlCommand("DELETE FROM message WHERE idmess=" & m_id, dbCon)
            dbCom.ExecuteNonQuery()
            dbCon.close()
=======
        Public Sub supprimer(dbCon As MySqlConnection)
            Dim dbCom As MySqlCommand = New MySqlCommand("DELETE FROM message WHERE idmess=" & m_id, dbCon)
            dbCom.ExecuteNonQuery()
>>>>>>> Adminstration terminé
        End Sub

    End Class

End Namespace
