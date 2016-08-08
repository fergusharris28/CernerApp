Imports System.DirectoryServices
Imports System.IO
Imports System.Net
''' <summary>
''' 
''' </summary>
Public Class server
    Inherits Object
    'properties
    Private serName As String
    Private serIP As IPAddress
    Private sertype As String
    Private serSystem As String
    Private serEnvironment As String
    Private portNumber As Integer
    Private partitionDir As String
    Private ent As DirectoryEntry
    Private pass As String = ""
    Private user As String = ""
    Private net As String = ""
    Private profile_list As New List(Of String)
    'Private testing_strings As New List(Of String)

    'Property Constructors
    Public Property Servername As String
        Get
            Servername = serName
        End Get
        Set(value As String)
            serName = value
        End Set
    End Property
    Public Property ServerIP As IPAddress
        Get
            Return serIP
        End Get
        Set(value As IPAddress)
            serIP = value
        End Set
    End Property
    Public Property ServerType As String
        Get
            Return sertype
        End Get
        Set(value As String)
            sertype = value
        End Set
    End Property
    Public Property ServerSystem As String
        Get
            Return serSystem
        End Get
        Set(value As String)
            serSystem = value
        End Set
    End Property
    Public Property ServerEnvironment As String
        Set(value As String)
            serEnvironment = value
        End Set
        Get
            Return serEnvironment
        End Get
    End Property
    Public Property Port As Integer
        Get
            Return portNumber
        End Get
        Set(value As Integer)
            portNumber = value
        End Set
    End Property
    Public Property Partition As String
        Get
            Return partitionDir
        End Get
        Set(value As String)
            partitionDir = value
        End Set
    End Property
    Public Property Password As String
        Get
            Return pass
        End Get
        Set(value As String)
            pass = value
        End Set
    End Property
    Public Property Username As String
        Get
            Return user
        End Get
        Set(value As String)
            user = value
        End Set
    End Property
    Public Property Network As String
        Get
            Return net
        End Get
        Set(value As String)
            net = value
        End Set
    End Property
    Public Property Profiles As List(Of String)
        Get
            Return profile_list
        End Get
        Set(value As List(Of String))
            profile_list = value
        End Set
    End Property

    'Object Subroutines
    Public Sub New(Optional ByVal name As String = "", Optional ByRef type As String = "", Optional ByRef sys As String = "", Optional ByRef env As String = "")
        serName = name
        sertype = type
        serSystem = sys
        serEnvironment = env
        If name <> "" Then
            GetIP()
        End If
    End Sub
    Public Sub GetIP()
        Try
            Dim hostname As IPHostEntry = Dns.GetHostEntry(serName)
            Dim IP As IPAddress() = hostname.AddressList
            serIP = IP(0)
        Catch
            'write stuff to a log
        End Try
    End Sub
    Public Sub setLDAP(Optional ByVal svrPort As Int16 = 389, Optional ByVal svrPartition As String = "DC=COM")
        Port = svrPort
        Partition = svrPartition
        Dim passWd As New Password(Password)
        passWd.decrypt()
        Dim Text As String = passWd.text
        profile_list = New List(Of String)
        ent = New DirectoryEntry("LDAP://" & Servername & ":" & portNumber & "/" & "CN=Configuration,DC=management,DC=cerner," & svrPartition, Network & "\" & Username, Text)
        Try
            Dim Adam = getInfo(ent)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ent.Dispose()
    End Sub

    'object Functions
    Function getLoginInfo() As Boolean
        Dim test As New emorycernerappDataSet.server_loginDataTable
        Dim info As New List(Of String)
        getLoginInfo = False
        If Password = "" Or Username = "" Or Network = "" Then

            Dim query = New emorycernerappDataSetTableAdapters.server_loginTableAdapter
            Try
                test = query.GetDataByName(Servername)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            If test.Count <> 0 Then
                For Each dr As DataRow In test.Rows
                    If dr.Item(0) = Servername Then
                        Password = dr.Item(3)
                        Network = dr.Item(1)
                        Username = dr.Item(2)
                        getLoginInfo = True
                    End If
                Next
            End If
        Else
            getLoginInfo = True
        End If
        Return getLoginInfo
    End Function
    Function writeToDB() As Boolean
        Dim serverTbl As New emorycernerappDataSet.serverDataTable
        Dim LoginTbl As New emorycernerappDataSet.loginDataTable

        Dim serverAdapter As emorycernerappDataSetTableAdapters.serverTableAdapter
        Dim loginAdapter As emorycernerappDataSetTableAdapters.loginTableAdapter

        Dim test As Boolean = False
        Dim ID As Int16

        serverAdapter = New emorycernerappDataSetTableAdapters.serverTableAdapter
        loginAdapter = New emorycernerappDataSetTableAdapters.loginTableAdapter

        Try
            If ServerType = "LDAP" Then
                serverAdapter.ServerLDAPInsertQuery(Servername, ServerIP.ToString, "1", Environment)
            Else
                serverAdapter.ServerLDAPInsertQuery(Servername, ServerIP.ToString, "0", Environment)
            End If
            serverAdapter.FillBy(serverTbl, Servername)
            If serverTbl.Count <> 0 Then
                ID = serverTbl.Rows(0).Item(0)
            End If
            If Username <> "" And Password <> "" And Network <> "" Then
                loginAdapter.LoginInsertQuery(Username, Network, Password, ID)
            End If
            test = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        serverTbl.Dispose()
        LoginTbl.Dispose()
        serverAdapter.Dispose()
        loginAdapter.Dispose()
        Return test
    End Function
    Function writeToDB(ByVal Dtm As Date) As Boolean
        Dim serverTbl As New emorycernerappDataSet.serverDataTable
        Dim serverAdapter As emorycernerappDataSetTableAdapters.serverTableAdapter
        Dim test As Boolean = False


        serverAdapter = New emorycernerappDataSetTableAdapters.serverTableAdapter
        Try
            serverAdapter.FillBy(serverTbl, Servername)
            If serverTbl.Count = 0 Then
                serverAdapter.ServerInsertAppServerQuery(Servername, ServerIP.ToString, Dtm, "0", Environment)
            Else
                serverAdapter.UpdateDTMQuery(Dtm, Servername)
            End If
            test = True
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        serverTbl.Dispose()
        serverAdapter.Dispose()
        Return test
    End Function
    Private Function getInfo(ByVal Entry As DirectoryEntry, Optional ByVal profile As String = "") As AdamRepository
        Dim Adam As New AdamRepository
        Adam.Adam_Name = Entry.Name
        'get properties later if needed
        Try
            For Each EntryItem As DirectoryEntry In Entry.Children
                If EntryItem.Path.Contains("CN=.Settings") = True Then
                    Continue For
                Else
                    Dim splitText() As String = Split(EntryItem.Name, "=")
                    Dim passtext As String
                    If profile <> "" Then
                        passtext = profile & "." & splitText(1)
                    Else
                        passtext = splitText(1)
                    End If
                    profile_list.Add(passtext)
                    Dim NextAdam = getInfo(EntryItem, passtext)
                    Adam.add(NextAdam)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Adam
    End Function


    'The Code below loops through the Adam objects looking for specific text in the properties

    'Public Sub testing(ByVal Entry As DirectoryEntry)
    '    Dim Adam = getInfo2(Entry)
    'End Sub
    'Private Function getInfo2(ByVal Entry As DirectoryEntry, Optional ByVal profile As String = "") As AdamRepository
    '    Dim Adam As New AdamRepository
    '    Adam.Adam_Name = Entry.Name
    '    For Each DE As DirectoryEntry In Entry.Children
    '        For Each prop As PropertyValueCollection In DE.Properties
    '            Dim text1 As String
    '            text1 = DE.Name & ", " & prop.PropertyName & ", "
    '            If prop.Count = 1 Then
    '                Try
    '                    text1 += prop.Value & ", "
    '                Catch ex As Exception
    '                End Try
    '            ElseIf prop.Count > 1 Then
    '                For Each Val As String In prop.Value
    '                    text1 += Val & ", "
    '                Next
    '            Else
    '                Exit For
    '            End If
    '            If text1.Contains("ctx") Then
    '                testing_strings.Add(text1)
    '            End If
    '        Next
    '        Dim NewAdam = getInfo2(DE)
    '    Next
    '    Return Adam
    'End Function
End Class
