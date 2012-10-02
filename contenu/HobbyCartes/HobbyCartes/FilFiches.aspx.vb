Public Class FilFiches
    Inherits System.Web.UI.Page

    Private Enum Sports
        hockey
        baseball
        football
        basketball
    End Enum

    Private m_sport As Sports = Sports.hockey 'Sport présentement sélectionné
    Private m_listeCartesCourrante() As Fiche 'Tableau des fiches du sport présentement sélectionné

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case m_sport
            Case Sports.hockey

            Case Sports.football

            Case Sports.baseball

            Case Sports.basketball

        End Select
    End Sub

End Class