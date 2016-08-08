Public Class LoginInfoForm
    Dim serv As New server()
    Dim Index As Int16
    Sub New(ByVal ServerSystem As String, ByVal serverIndex As Int16)
        ' This call is required by the designer.
        Form1.Enabled = False
        InitializeComponent()
        If ServerSystem = "Olympus" Then
            serv = ServerList.CernerOlympus.Item(serverIndex)
        ElseIf ServerSystem = "Ibus" Then
            serv = ServerList.CernerIbus.Item(serverIndex)
        ElseIf ServerSystem = "Oracle" Then
            serv = ServerList.CernerOracle.Item(serverIndex)
        ElseIf ServerSystem = "Backend" Or ServerSystem = "AIX" Then
            serv = ServerList.BackendServers.Item(serverIndex)
        End If
        Index = serverIndex
        Me.Text = Me.Text & " " & serv.Servername
        Me.ShowDialog()
    End Sub
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim temp() As String = Split(UsernameTextBox.Text, "\")
        If UsernameTextBox.Text.Contains("\") And temp.Count = 2 Then
            Dim passwd As New Password(PasswordTextBox.Text)
            passwd.encrypt()

            'Password encryption and decryption test
            'Dim x As String = passwordText.text
            'passwordText.encrypt()
            'Dim y As String = passwordText.text
            'passwordText.decrypt()
            'Dim z As String = passwordText.text
            'MsgBox("your Password " & x & " encrypts to:" & vbCrLf & y & vbCrLf & "And decrypts back to: " & z)

            serv.Password = passwd.text
            serv.Username = temp(1)
            serv.Network = temp(0)
            If serv.ServerSystem = "Olympus" Then
                ServerList.CernerOlympus.Item(Index) = serv
            ElseIf serv.ServerSystem = "Ibus" Then
                ServerList.CernerIbus.Item(Index) = serv
            ElseIf serv.ServerSystem = "Oracle" Then
                ServerList.CernerOracle.Item(Index) = serv
            ElseIf serv.ServerSystem = "Backend" Or serv.ServerSystem = "AIX" Then
                ServerList.BackendServers.Item(Index) = serv
            ElseIf serv.ServerSystem = "Citrix" Then
                ServerList.CernerCitrix.Item(Index) = serv
            End If
            If Save_checkBox.Checked Then
                serv.writeToDB()
            End If
            Form1.Enabled = True
                Me.Close()
            Else
                MsgBox("the Username is in an invalid format!" & vbCrLf & "Please make sure it is set up as ""Netowrk\Username""")
        End If
    End Sub
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Form1.Enabled = True
        Me.Close()
    End Sub

End Class
