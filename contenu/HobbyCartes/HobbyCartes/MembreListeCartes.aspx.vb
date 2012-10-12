Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class MembreListeCartes
    Inherits System.Web.UI.Page

    Enum Sports
        hockey
        baseball
        basketball
        football
    End Enum

    Dim m_sportEnCours As Sports = Sports.hockey
    Dim m_membre As Entitees.Membre
    Dim m_connection As MySqlConnection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_connection = New MySqlConnection("Server=localhost;Database=test;Uid=root;Pwd=toor;")
        m_connection.Open()
        m_membre = New Entitees.Membre(1, m_connection)
    End Sub

End Class