Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class Password
    Private PassWd As String
    Private EncryptionKey As String = "A98Gaoi@as7jntakDahEh234r9a08syh31"
    Property text As String
        Get
            Return PassWd
        End Get
        Set(value As String)
            PassWd = value
        End Set
    End Property
    Public Sub New(ByVal pass As String)
        text = pass
    End Sub

    Public Sub encrypt()
        Dim clearbytes As Byte() = Encoding.Unicode.GetBytes(PassWd)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64, &H76, &H65, &H64, &H65, &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearbytes, 0, clearbytes.Length)
                    cs.Close()
                End Using
                PassWd = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
    End Sub
    Public Sub decrypt()
        Dim cipherBytes As Byte() = Convert.FromBase64String(PassWd)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64, &H76, &H65, &H64, &H65, &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                PassWd = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
    End Sub
End Class
