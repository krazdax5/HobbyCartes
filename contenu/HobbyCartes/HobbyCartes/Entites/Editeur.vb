﻿'--------------------------------------------------------------------------
' Titre: Editeur.vb
' Auteur: Charles Levesque
' Date: Septembre 2012
' Contribution: Loïc Vial
'--------------------------------------------------------------------------

Imports MySql.Data
Imports MySql.Data.MySqlClient

Namespace Entites

    ''' <summary>
    ''' Editeur
    ''' </summary>
    Public Class Editeur

        ''' <summary>
        ''' Le nom de l'editeur
        ''' </summary>
        Private m_nom As String

        ''' <summary>
        ''' L'id de l'editeur
        ''' </summary>
        Private m_id As Integer

        ''' <summary>
        ''' Accesseur du nom
        ''' </summary>
        Public ReadOnly Property nomEditeur As String
            Get
                Return m_nom
            End Get
        End Property

        ''' <summary>
        ''' Accesseur de l'id
        ''' </summary>
        Public ReadOnly Property idEditeur As String
            Get
                Return m_id
            End Get
        End Property

        ''' <summary>
        ''' Constructeur par défaut. m_id est -1 si la construction échoue.
        ''' </summary>
        ''' <param name="id">Identificateur de l'éditeur.</param>
        Public Sub New(id As Integer)
            Dim connection As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
            connection.Open()
            Dim requete As MySqlCommand = New MySqlCommand("SELECT * FROM editeur WHERE idediteur=" + id.ToString, connection)

            Try
                Dim reader As MySqlDataReader = requete.ExecuteReader()
                reader.Read()

                m_nom = reader.GetString("nomed")
                m_id = id
                reader.Close()
            Catch ex As Exception
                m_nom = ""
                m_id = -1
            Finally
                connection.Close()
            End Try
        End Sub

    End Class

End Namespace
