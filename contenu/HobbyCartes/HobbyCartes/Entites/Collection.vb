<<<<<<< HEAD
﻿Imports MySql.Data
=======
﻿'--------------------------------------------------------------------------
' Titre: Collection.vb
' Auteur: Charles Levesque
' Date: Septembre 2012
' Contribution: Loïc Vial
'--------------------------------------------------------------------------

Imports MySql.Data
>>>>>>> Adminstration terminé
Imports MySql.Data.MySqlClient

Namespace Entites

    Public Class Collection

        Public Enum Type
            Hockey
            Baseball
            Football
            Basketball
<<<<<<< HEAD
=======
            aucun
>>>>>>> Adminstration terminé
        End Enum

        ''' <summary>
        ''' Identificateur de la collection
        ''' </summary>
        Private m_id As Integer

        ''' <summary>
        ''' Représente le sport de la collection.
        ''' </summary>
        Private m_type As Type

        ''' <summary>
        ''' Représente la liste de cartes de la collection.
        ''' </summary>
        Private m_fiches As List(Of Entites.Fiche) = New List(Of Entites.Fiche)

        ''' <summary>
        ''' Connexion à la base de données MySQL
        ''' </summary>
        Private m_connection As MySqlConnection

        ''' <summary>
        ''' Identificateur de la collection
        ''' </summary>
        Public ReadOnly Property ID As Integer
            Get
                Return m_id
            End Get
        End Property

        ''' <summary>
        ''' Liste de fiches de la collection
        ''' </summary>
        Public ReadOnly Property ListeFiches As List(Of Entites.Fiche)
            Get
                Return m_fiches
            End Get
        End Property

        ''' <summary>
        ''' Type de sport de la collection (hockey, baseball, basketball ou football)
        ''' </summary>
        Public ReadOnly Property TypeCollection As Entites.Collection.Type
            Get
                Return m_type
            End Get
        End Property

        ''' <summary>
        ''' Construit une collection à partir de l'identificateur du membre qui le détient
        ''' et du sport désiré.
        ''' </summary>
        ''' <param name="idMembre">Identificateur du membre à qui appartient la collection.</param>
        Public Sub New(ByVal idMembre As Integer, ByVal dbCon As MySqlConnection)
            m_connection = dbCon
            Dim sport As List(Of String) = New List(Of String)()

            Dim requete As MySqlCommand = New MySqlCommand("SELECT typecol FROM collection WHERE" +
                                                           " idmembre='" + idMembre.ToString + "'", m_connection)

            Try
                Dim reader As MySqlDataReader = requete.ExecuteReader()

                'Récupération des collections du membre
                While reader.Read()
                    sport.Add(reader.GetString("typecol"))
                End While

                reader.Close()

                Select Case sport(0)
                    Case "hockey"
                        m_type = Type.Hockey
                    Case "football"
                        m_type = Type.Football
                    Case "baseball"
                        m_type = Type.Baseball
                    Case "basketball"
                        m_type = Type.Basketball
                    Case Else
<<<<<<< HEAD
                        m_type = Nothing
                End Select

            Catch ex As Exception
                m_type = Nothing
=======
                        m_type = Type.aucun
                End Select

            Catch ex As Exception
                m_type = Type.aucun
>>>>>>> Adminstration terminé
            End Try
        End Sub

        ''' <summary>
        ''' Construit une collection à partir de l'identificateur du membre qui le détient
        ''' et du type de collection (sport) désiré.
        ''' </summary>
        Public Sub New(idMembre As Integer, typeCol As Type, dbCon As MySqlConnection)
            m_connection = dbCon

            m_id = New MySqlCommand("SELECT idcollection FROM collection WHERE idmembre=" & idMembre & " AND typecol='" & typeCol.ToString & "'", m_connection).ExecuteScalar

            Dim req As MySqlCommand = New MySqlCommand("SELECT idfiche FROM fiche WHERE idcollection=" & m_id, m_connection)
            Dim read As MySqlDataReader = req.ExecuteReader
            Dim idFiches As List(Of Integer) = New List(Of Integer)
            While read.Read()
                idFiches.Add(read.GetInt32("idfiche"))
            End While
            read.Close()
            For Each idFiche As Integer In idFiches
                m_fiches.Add(New Fiche(idFiche, dbCon))
            Next
        End Sub

        ''' <summary>
        ''' Chargement de la liste des fiches selon l'identificateur de la collection.
        ''' Si il n'y en a pas, la liste devient vide.
        ''' </summary>
        Private Sub chargementListeFiches()
            Dim requete As MySqlCommand = New MySqlCommand("SELECT idfiche FROM fiche WHERE idcollection='" + m_id.ToString + "'", m_connection)
            Dim reader As MySqlDataReader
            Dim listeID As List(Of Integer) = New List(Of Integer)()

            Try
                reader = requete.ExecuteReader()
                'Récuprération des fiches de la collection
                While reader.Read()
                    listeID.Add(reader.GetInt32("idfiche"))
                End While

                reader.Close()
                m_fiches = New List(Of Entites.Fiche)()
                'Remplissage de la liste de fiches
                For Each identificateur In listeID
                    m_fiches.Add(New Entites.Fiche(identificateur, m_connection))
                Next
            Catch ex As Exception
                m_fiches = Nothing
            End Try
        End Sub

        ''' <summary>
        ''' Chargement d'une nouvelle collection à partir d'un membre et d'un sport.
        ''' </summary>
        ''' <param name="sport">Représente un type de collection.</param>
        ''' <param name="idMembre">Identificateur du membre à qui appartient la collection.</param>
        Public Sub chargementNouvCollection(ByVal sport As Entites.Collection.Type, ByVal idMembre As Integer)
            m_type = sport
            m_fiches = Nothing

            'Nouvelle commande pour récupérer l'identificateur de la collection
            Dim requete As MySqlCommand = New MySqlCommand("SELECT * FROM collection WHERE" +
                                       " idmembre='" + idMembre.ToString + "'" +
                                       " AND typecol='" + m_type.ToString.ToLower + "'", m_connection)
            Dim reader As MySqlDataReader

            Try
                reader = requete.ExecuteReader()

                'Récupération de l'identificateur de la collection
                If reader.Read() Then
                    m_id = reader.GetInt32("idcollection")
                    reader.Close()
                    chargementListeFiches()
                Else
<<<<<<< HEAD
                    m_type = Nothing
=======
                    m_type = Type.aucun
>>>>>>> Adminstration terminé
                    m_id = -1
                    reader.Close()
                End If

            Catch ex As Exception
<<<<<<< HEAD
                m_type = Nothing
=======
                m_type = Type.aucun
>>>>>>> Adminstration terminé
                m_id = -1
            End Try

        End Sub

        ''' <summary>
        ''' Retourne true ssi le membre dont l'identificateur est passé en parametre possede une collection du type passé en parametre.
        ''' </summary>
<<<<<<< HEAD
        Public Shared Function existe(idMembre As Integer, typeCol As Type) As Boolean
            Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
            dbCon.Open()
            Dim num As Integer = New MySqlCommand("SELECT COUNT(*) FROM collection WHERE idmembre=" & idMembre & " AND typecol='" & typeCol.ToString & "'", dbCon).ExecuteScalar
            dbCon.Close()
            Return num <> 0
        End Function

        ''' <summary>
        ''' Supprime la collection
        ''' </summary>
        Public Sub supprimer()
            Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
            dbCon.Open()
            Dim req As MySqlCommand = New MySqlCommand("DELETE FROM collection WHERE idcollection=" & m_id, dbCon)
            req.ExecuteNonQuery()
            dbCon.Close()
        End Sub

        ''' <summary>
        ''' Cree une nouvelle collection
        ''' </summary>
        Public Shared Sub ajouter(idMembre As Integer, typeCol As Type)
            Dim dbCon As MySqlConnection = New MySqlConnection(My.Resources.StringConnexionBdd)
            dbCon.Open()
            Dim req As MySqlCommand = New MySqlCommand("INSERT INTO collection (idmembre, typecol) VALUES (" & idMembre & ", '" & typeCol.ToString & "')", dbCon)
            req.ExecuteNonQuery()
            dbCon.Close()
        End Sub

=======
        Public Shared Function existe(idMembre As Integer, typeCol As Type, dbCon As MySqlConnection) As Boolean
            Return Not New MySqlCommand("SELECT COUNT(*) FROM collection WHERE idmembre=" & idMembre & " AND typecol='" & typeCol.ToString & "'", dbCon).ExecuteScalar = 0
        End Function

>>>>>>> Adminstration terminé
    End Class

End Namespace