Imports System.DirectoryServices
Public Class Cerner
    Dim CerDomains As List(Of String)
    Dim CerBackend As List(Of server)
    Dim CerOracle As List(Of server)
    Dim CerOlympus As List(Of server)
    Dim CerIbus As List(Of server)
    Dim CerCitrix As List(Of server)
    Property Domains As List(Of String)
        Get
            Return CerDomains
        End Get
        Set(value As List(Of String))
            CerDomains = New List(Of String)
            CerDomains = value
        End Set
    End Property
    Property BackendServers As List(Of server)
        Get
            Return CerBackend
        End Get
        Private Set(value As List(Of server))
            CerBackend = New List(Of server)
            CerBackend = value
        End Set
    End Property
    Property CernerOracle As List(Of server)
        Get
            Return CerOracle
        End Get
        Private Set(value As List(Of server))
            CerOracle = New List(Of server)
            CerOracle = value
        End Set
    End Property
    Property CernerOlympus As List(Of server)
        Get
            Return CerOlympus
        End Get
        Private Set(value As List(Of server))
            CerOlympus = New List(Of server)
            CerOlympus = value
        End Set
    End Property
    Property CernerIbus As List(Of server)
        Get
            Return CerIbus
        End Get
        Private Set(value As List(Of server))
            CerIbus = New List(Of server)
            CerIbus = value
        End Set
    End Property
    Property CernerCitrix As List(Of server)
        Get
            Return CerCitrix
        End Get
        Set(value As List(Of server))
            CerCitrix = value
        End Set
    End Property
    Sub New()
        Domains = New List(Of String)
        CerBackend = New List(Of server)
        CerOracle = New List(Of server)
        CerOlympus = New List(Of server)
        CerIbus = New List(Of server)
        CerCitrix = New List(Of server)
    End Sub
    Sub Add(ByRef Serv As server)
        If Serv.ServerSystem = "Olympus" Then
            CerOlympus.Add(Serv)
        ElseIf Serv.ServerSystem = "Ibus" Then
            CerIbus.Add(Serv)
        ElseIf Serv.ServerSystem = "Oracle" Then
            CerOracle.Add(Serv)
        ElseIf Serv.ServerSystem = "AIX" Or Serv.ServerEnvironment = "Backend" Then
            CerBackend.Add(Serv)
        ElseIf Serv.ServerSystem = "Citrix" Then
            CerCitrix.Add(Serv)
        Else
            MsgBox("Error, the server " & Serv.Servername & " does not have an assigned ""System Type""")
        End If
    End Sub

End Class
