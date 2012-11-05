' REMARQUE : vous pouvez utiliser la commande Renommer du menu contextuel pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
Imports System.Text
Imports System.Security.Cryptography

Public Class ServiceHash
    Implements securite_hc

    Public Sub New()
    End Sub

    Public Function GetData(ByVal value As Integer) As String Implements securite_hc.GetData
        Return String.Format("You entered: {0}", value)
    End Function

    Public Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType Implements securite_hc.GetDataUsingDataContract
        If composite Is Nothing Then
            Throw New ArgumentNullException("composite")
        End If
        If composite.BoolValue Then
            composite.StringValue &= "Suffix"
        End If
        Return composite
    End Function

    Public Function HashPass(ByVal motPass As String, ByVal salt As String) As String Implements securite_hc.HashPass
        Dim tmpMotPass As String = Nothing
        Dim tmpSalt() As Byte = Encoding.UTF8.GetBytes(salt)

        'Ajout d'un peu de sel au mot de passe!
        tmpMotPass = Convert.ToBase64String(tmpSalt) + motPass

        'Obtient les octets du mot de passe et les hachent en SHA2
        Dim octets() As Byte = New SHA384Managed().ComputeHash(Encoding.UTF8.GetBytes(tmpMotPass))

        'Retourne le hash en SHA2
        Return Convert.ToBase64String(octets)
    End Function

    Public Function ComparerMotPasses(ByVal motPass1 As String, ByVal motPass2 As String) As Boolean Implements securite_hc.ComparerMotPasses
        Dim tmpMotPass1() As Byte = Convert.FromBase64String(motPass1)
        Dim tmpMotPass2() As Byte = Convert.FromBase64String(motPass2)

        Try
            For i As Integer = 0 To (motPass1.Length - 1)

                'Si les octets ne concordent pas
                If Not tmpMotPass1(i).Equals(tmpMotPass2(i)) Then
                    Return False
                End If

                Return True
            Next
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
