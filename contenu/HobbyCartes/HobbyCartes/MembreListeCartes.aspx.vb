Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class MembreListeCartes
    Inherits System.Web.UI.Page

    Private m_sportEnCours As Entitees.Collection.Type = Entitees.Collection.Type.Hockey
    Private m_membre As Entitees.Membre
    Private m_collection As Entitees.Collection
    Private m_connection As MySqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_connection = New MySqlConnection("Server=localhost;Database=test;Uid=root;Pwd=toor;")
        m_connection.Open()

        m_membre = New Entitees.Membre(1, m_connection)
        m_collection = New Entitees.Collection(m_membre.id, m_sportEnCours, m_connection)
    End Sub

    Private Sub chargementListe()
        
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Unload
        m_connection.Close()
    End Sub

End Class