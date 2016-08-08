Public Class Attributes
    Private name As String
    Private values As List(Of String)

    Public Property Attribute_Values As List(Of String)
        Get
            Return values
        End Get
        Set(value As List(Of String))
            values = value
        End Set
    End Property
    Public Property Attribute_Name As String
        Get
            Return name
        End Get
        Set(value As String)
            name = value
        End Set
    End Property
    Public Sub New(ByVal attrName As String, attrVals As List(Of String))
        Attribute_Values = New List(Of String)
        Attribute_Name = attrName
        Attribute_Values = attrVals
    End Sub
    Public Sub New()
        Attribute_Values = New List(Of String)
        name = ""
    End Sub
    Public Sub Add_Value(ByVal Val As String)
        values.Add(Val)
    End Sub
End Class
