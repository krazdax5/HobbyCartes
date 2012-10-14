Namespace Entitees

    Public Class Collection

        Public Enum Type
            Hockey
            Football
            Basketball
            Baseball
        End Enum

        ''' <summary>
        ''' Représente le sport de la collection.
        ''' </summary>
        Private m_type As Type

        ''' <summary>
        ''' Représente la liste de cartes de la collection.
        ''' </summary>
        Private m_cartes As List(Of Fiche)

        ''' <summary>
        ''' Construit une collection à partir de l'identificateur du membre qui le détient
        ''' et du sport désiré.
        ''' </summary>
        ''' <param name="idMembre">Identificateur du membre à qui appartient la collection.</param>
        ''' <param name="type">Type de sport des cartes. Exemple: Cartes de hockey</param>
        Public Sub New(ByVal idMembre As Integer, ByVal type As Type)

        End Sub
    End Class

End Namespace