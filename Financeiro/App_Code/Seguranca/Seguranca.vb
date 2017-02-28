Imports Microsoft.VisualBasic
Imports System.Security.Cryptography
Imports MySql
Imports MySql.Data.MySqlClient

Public Class Seguranca
    Public Shared Function MD5(ByVal texto As String) As String
        Dim provider As New MD5CryptoServiceProvider
        Dim byHash() As Byte
        Dim hash As String = String.Empty

        byHash = provider.ComputeHash(System.Text.Encoding.UTF8.GetBytes(texto))
        provider.Clear()

        hash = BitConverter.ToString(byHash).Replace("-", String.Empty)

        Return hash
    End Function

End Class
