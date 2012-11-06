Imports System.Text
Imports System.Security.Cryptography
' REMARQUE : vous pouvez utiliser la commande Renommer du menu contextuel pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
Public Class ServiceHash
    Implements ISecurite_hc

    Public Function GetData(ByVal value As Integer) As String Implements ISecurite_hc.GetData
        Return String.Format("You entered: {0}", value)
    End Function

    Public Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType Implements ISecurite_hc.GetDataUsingDataContract
        If composite Is Nothing Then
            Throw New ArgumentNullException("composite")
        End If
        If composite.BoolValue Then
            composite.StringValue &= "Suffix"
        End If
        Return composite
    End Function
    Public Function ComparerMotPasses(motPass1 As String, motPass2 As String) As Boolean Implements ISecurite_hc.ComparerMotPasses
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
    Public Function HashPass(motPass As String, salt As String) As String Implements ISecurite_hc.HashPass
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
