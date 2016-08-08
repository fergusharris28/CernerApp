Imports System.DirectoryServices

Public Class Form1
    Dim args As List(Of String)
    Dim config As Configuration



    Sub New()
        args = New List(Of String)

        If My.Application.CommandLineArgs.Count <> 0 Then
            For Each argument In My.Application.CommandLineArgs
                args.Add(argument)
            Next
        Else
            ' This call is required by the designer.
            InitializeComponent()
            config = New Configuration

            For Each serverX As server In ServerList.CernerOlympus
                If serverX.ServerType = "LDAP" And serverX.ServerSystem = "Olympus" Then
                    Me.OlyLDAPComboBox.Items.Add(serverX.Servername)
                End If
            Next

            ' Add any initialization after the InitializeComponent() call.
        End If
    End Sub
    Private Sub Form1_resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        AppTabs.Height = Me.Size.Height - 62 - 18
        AppTabs.Width = Me.Size.Width - 40
        Panel1.Height = AppTabs.Height
        Panel1.Width = AppTabs.Width - 374
        Me.Refresh()
    End Sub
    Private Sub OlyLDAPComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles OlyLDAPComboBox.SelectedIndexChanged
        If Me.OlyLDAPComboBox.SelectedItem.ToString <> Nothing Then
            Me.CerOlyProfComboBox.Enabled = True
            Dim counter = 0
            For Each serverX As server In ServerList.CernerOlympus
                If serverX.Servername = OlyLDAPComboBox.SelectedItem.ToString Then
                    CerEnvLabel.Text = serverX.ServerEnvironment
                    If serverX.ServerType = "LDAP" Then
                        Dim load = serverX.getLoginInfo()
                        If load = False Then
                            Dim form2 = New LoginInfoForm(serverX.ServerSystem, counter)
                            serverX = New server()
                            serverX = ServerList.CernerOlympus.Item(counter)
                        End If
                        If serverX.Profiles.Count = 0 Then
                            serverX.setLDAP()
                        End If
                        LoadProfiles(serverX.Profiles)
                        Exit For
                    End If
                End If
                counter += 1
            Next
            Me.Refresh()
        End If

    End Sub
    Private Sub LoadConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadConfigToolStripMenuItem.Click
        config = New Configuration
        For Each serverX As server In ServerList.CernerOlympus
            If serverX.ServerType = "LDAP" And serverX.ServerSystem = "Olympus" Then
                Me.OlyLDAPComboBox.Items.Add(serverX.Servername)
            End If
        Next
    End Sub
    Private Sub LoadProfiles(ByVal profile_list As List(Of String))
        Me.CerOlyProfComboBox.Enabled = True
        Me.CerOlyProfComboBox.Items.Clear()
        For Each prof As String In profile_list
            Me.CerOlyProfComboBox.Items.Add(prof)
        Next
        If Me.CerOlyProfComboBox.Items.Count <> 0 Then
            SentinelESMButton.Enabled = True
        Else
            SentinelESMButton.Enabled = False
        End If
    End Sub

    'testing updateing the LDAP progamatically.
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Port1 = 389
        Dim Partition1 = "DC=COM"
        Dim username1 = "srv_olympus"
        Dim network1 = "euh"
        Dim passWd1 = "Mw1818!"
        Dim profile_list1 = New List(Of String)
        Dim EntryOld = New DirectoryEntry("LDAP://tstoly07:" & Port1 & "/" & Partition1, network1 & "\" & username1, passWd1)
        EntryOld.RefreshCache()
        Dim EntryNew = New DirectoryEntry("LDAP://tstoly01:" & Port1 & "/" & Partition1, network1 & "\" & username1, passWd1)
        EntryNew.RefreshCache()

        Dim subentries1 As DirectoryEntries = EntryOld.Children
        Dim subentries2 As DirectoryEntries = EntryNew.Children

        EntryNew.CommitChanges()

        EntryNew.Dispose()
        EntryOld.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'this sub needs to be fixed so that it is more modular.  remove a lot of the hard coded information.
        Dim srvNM As String = Me.OlyLDAPComboBox.SelectedItem.ToString
        Dim Serv As New server
        Dim counter As Int16 = 0
        For Each serverX As server In ServerList.CernerOlympus
            If serverX.Servername <> srvNM Then
                counter += 1
                Continue For
            End If
            Dim load = serverX.getLoginInfo()
            If load = False Then
                Dim form2 = New LoginInfoForm(serverX.ServerSystem, counter)
                serverX = New server()
                serverX = ServerList.CernerOlympus.Item(counter)
            End If
            Serv = serverX
            Exit For
        Next
        Dim pass As New Password(Serv.Password)
        pass.decrypt()

        Dim ent = New DirectoryEntry("LDAP://" & srvNM & ":389/CN=Nodes,CN=" & CerEnvLabel.Text & ",CN=Enterprises,DC=management,DC=cerner,DC=com", Serv.Username, pass.text)

        Dim searcher As DirectorySearcher
        searcher = New DirectorySearcher(ent)
        searcher.PropertiesToLoad.Add("name")
        searcher.PropertiesToLoad.Add("cernerLastCheckedInDateTime")
        searcher.PageSize = 1000
        Try
            Dim result As SearchResultCollection = searcher.FindAll()

            Dim dtm As Date

            For Each res As SearchResult In result
                If res.Properties.Count <> 3 Then
                    Continue For
                End If
                Try
                    dtm = res.Properties("cernerLastCheckedInDateTime").Item(0)
                Catch ex As Exception
                    'MsgBox(ex.Message)
                    Continue For
                    'write to log
                End Try
                Dim serverX As New server(res.Properties("name").Item(0), "Application", "Citrix", "Prod")
                serverX.GetIP()
                ServerList.Add(serverX)
                serverX.writeToDB(dtm)
            Next
            result.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        searcher.Dispose()
    End Sub
End Class
