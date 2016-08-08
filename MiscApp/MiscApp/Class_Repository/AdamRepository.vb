Public Class AdamRepository
    Private adams As List(Of AdamRepository)
    Private name As String

    Public Property Adam_Repository As List(Of AdamRepository)
        Get
            Return adams
        End Get
        Set(value As List(Of AdamRepository))
            adams = value
        End Set
    End Property
    Public Property Adam_Name As String
        Get
            Return name
        End Get
        Set(value As String)
            name = value
        End Set
    End Property
    Public Sub New()
        adams = New List(Of AdamRepository)
    End Sub
    Public Sub add(ByVal repo As AdamRepository)
        adams.Add(repo)
    End Sub
End Class
