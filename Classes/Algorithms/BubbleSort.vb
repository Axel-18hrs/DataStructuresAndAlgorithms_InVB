Friend Class BubbleSort
    Implements ImethodAlgorithms

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        BubbleSort(arr)
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementación para arrays de tipo double (pendiente)
    End Sub

    Public Sub BubbleSort(array As Integer())
        For i As Integer = 0 To array.Length - 2
            For j As Integer = 0 To array.Length - i - 2
                If array(j) > array(j + 1) Then
                    Dim temp As Integer = array(j)
                    array(j) = array(j + 1)
                    array(j + 1) = temp
                End If
            Next
        Next
    End Sub
End Class
