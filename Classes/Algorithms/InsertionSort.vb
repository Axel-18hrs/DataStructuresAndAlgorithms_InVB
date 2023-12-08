Friend Class InsertionSort
    Implements ImethodAlgorithms

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        InsertionSortAlgorithm(arr)
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementation for double arrays (pending)
    End Sub

    Public Sub InsertionSortAlgorithm(arr As Integer())
        Dim n As Integer = arr.Length
        For i As Integer = 1 To n - 1
            Dim key As Integer = arr(i)
            Dim j As Integer = i - 1

            ' Move elements of the subarray arr[0..i-1] that are greater than key
            ' to one position ahead of their current position
            While j >= 0 AndAlso arr(j) > key
                arr(j + 1) = arr(j)
                j = j - 1
            End While
            arr(j + 1) = key
        Next
    End Sub
End Class

