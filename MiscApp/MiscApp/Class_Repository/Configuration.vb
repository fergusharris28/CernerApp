Imports System.IO
Imports System.Net
Public Class Configuration
    Inherits Object

    Dim CenerHomeURL As String = ""
    Dim configPath As String = "configuration\Configuration.txt"
    Dim CernerSys As Cerner

    Public Sub New()
        Try
            CernerSys = New Cerner
            If File.Exists(configPath) Then
                ' if yes read the file
                Load()
            Else
                ' else create a new one and alert the user to the effect that the application needs to be configured
                CreateConfig()
            End If
        Catch e As Exception
            MsgBox(e.Message,, "ERROR")
            Exit Sub
        End Try
    End Sub
    Public Sub Load()
        Dim configtxt As String
        Using SR As StreamReader = File.OpenText(configPath)
            configtxt = SR.ReadToEnd()
        End Using
        Dim stringtext() As String = Split(configtxt, vbCrLf)
        For i = 0 To stringtext.Count - 1
            If stringtext(i).Contains("#") Then
                Continue For
            ElseIf stringtext(i).Contains(":") Then
                If stringtext(i).Contains("Serverlist") Then
                    Dim test As Boolean = True
                    While test
                        Dim serverX As New server

                        i += 1
                        If stringtext(i).Contains("End") Then
                            Exit While
                        Else
                            Try
                                Dim Stringarray1() = Split(stringtext(i), " ")
                                For Each item As String In Stringarray1

                                    If item = "" Then
                                        Continue For
                                    ElseIf item.Contains("Servername") Then
                                        Dim Splittext() As String = Split(item, "=")
                                        serverX.Servername = Splittext(1)
                                    ElseIf item.Contains("attr") Then
                                        Dim Splittext() As String = Split(item, "=")
                                        serverX.ServerType = Splittext(1)
                                    ElseIf item.Contains("env") Then
                                        Dim splittext() As String = Split(item, "=")
                                        serverX.ServerEnvironment = splittext(1)
                                    Else
                                        Dim Splittext() As String = Split(item, "=")
                                        serverX.ServerSystem = Splittext(1)
                                    End If
                                Next
                            Catch ex As Exception
                                MsgBox("Error Parsing Servers in Configuation.txt")
                            End Try
                        End If
                        serverX.GetIP()
                        ServerList.Add(serverX)
                    End While
                ElseIf stringtext(i).Contains("CernerHome") Then
                    i += 1
                    Try
                        Dim temp() = Split(stringtext(i), "=")
                        CenerHomeURL = temp(1)
                        If Directory.Exists(CenerHomeURL) Then
                            For Each folder As String In Directory.GetDirectories(CenerHomeURL)
                                If folder.Contains("target") Then
                                    Dim tempstring1() = Split(folder, "_")
                                    Dim tempstring2() = Split(tempstring1(0), CenerHomeURL & "\")
                                    CernerSys.Domains.Add(tempstring2(1))
                                Else
                                    Continue For
                                End If
                            Next
                        Else
                            Throw New Exception("Directory Does not Exist!!")
                        End If
                    Catch e As Exception
                        MsgBox(e.Message)
                    End Try

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''                                                     ''
                    ''   add new configuation.txt parsing here as needed   ''
                    ''                                                     ''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If
            End If
        Next
    End Sub
    Sub createConfig()

    End Sub
End Class