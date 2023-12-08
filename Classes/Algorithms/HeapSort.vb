Friend Class Heapsort
    Implements ImethodAlgorithms

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        Dim n As Integer = arr.Length

        ' Build a max heap
        For i As Integer = n \ 2 - 1 To 0 Step -1
            Heapify(arr, n, i)
        Next

        ' Extract elements one by one from the heap
        For i As Integer = n - 1 To 1 Step -1
            ' Move the current root to the end
            Swap(arr(0), arr(i))

            ' Call heapify on the reduced sub-tree
            Heapify(arr, i, 0)
        Next
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementation for double arrays (pending)
    End Sub

    Private Shared Sub Heapify(arr As Integer(), n As Integer, i As Integer)
        Dim largest As Integer = i
        Dim left As Integer = 2 * i + 1
        Dim right As Integer = 2 * i + 2

        ' Compare with the left child
        If left < n AndAlso arr(left) > arr(largest) Then
            largest = left
        End If

        ' Compare with the right child
        If right < n AndAlso arr(right) > arr(largest) Then
            largest = right
        End If

        ' If the largest is not the root
        If largest <> i Then
            Swap(arr(i), arr(largest))

            ' Recursively heapify the affected sub-tree
            Heapify(arr, n, largest)
        End If
    End Sub

    Private Shared Sub Swap(ByRef a As Integer, ByRef b As Integer)
        Dim temp As Integer = a
        a = b
        b = temp
    End Sub
End Class
