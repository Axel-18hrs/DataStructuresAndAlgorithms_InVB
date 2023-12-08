Public Class BinaryNode
    Public Property Left As BinaryNode
    Public Property Right As BinaryNode
    Public Property Data As Integer

    Public Sub New(data As Integer)
        Me.Data = data
        Left = Nothing
        Right = Nothing
    End Sub
End Class
