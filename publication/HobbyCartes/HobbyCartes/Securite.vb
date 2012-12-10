Imports System.Text
Imports System.Security.Cryptography

Public Class Securite

    Public Shared Function ComparerMotPasses(motPass1 As String, motPass2 As String) As Boolean
        Dim tmpMotPass1() As Byte = Convert.FromBase64String(motPass1)
        Dim tmpMotPass2() As Byte = Convert.FromBase64String(motPass2)

        Try
            For i As Integer = 0 To (tmpMotPass1.Length - 1)

                'Si les octets ne concordent pas
                If Not tmpMotPass1(i).Equals(tmpMotPass2(i)) Then
                    Return False
                End If

            Next

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function HashPass(motPass As String, salt As String) As String
        Dim tmpMotPass As String = Nothing
        Dim tmpSalt() As Byte = Encoding.UTF8.GetBytes(salt)

        'Ajout d'un peu de sel au mot de passe!
        tmpMotPass = Convert.ToBase64String(tmpSalt) + motPass

        'Obtient les octets du mot de passe et les hachent en SHA2
        Dim octets() As Byte = New SHA384Managed().ComputeHash(Encoding.UTF8.GetBytes(tmpMotPass))

        'Retourne le hash en SHA2
        Return Convert.ToBase64String(octets)
    End Function

End Class
