﻿Namespace Entitees

    Public Class Carte

        Public Enum Etat
            Impeccable
            Bonne
            Moyenne
            Passable
            Pietre
        End Enum

        Private annee As String

        Private nomJoueur As String

        Private prenomJoueur As String

        Private numeroJoueur As Integer

        Private isRecrue As Boolean

        Private position As String

        Private numerotation As Integer

        Private valeur As Double

        Private myEtat As Etat

        Private imageDevant As String

        Private imageDerriere As String

        Private publicationSurSite As Date

        Private commentaires As List(Of Commentaire)

    End Class

End Namespace
