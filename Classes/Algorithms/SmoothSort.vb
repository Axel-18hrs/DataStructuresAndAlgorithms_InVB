Public Class SmoothSort
    Implements ImethodAlgorithms

    Private heap As Integer()

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        heap = arr
        Dim n As Integer = arr.Length

        For i As Integer = (n - 1) \ 2 To 0 Step -1
            SiftDown(i, n - 1)
        Next

        For i As Integer = n - 1 To 1 Step -1
            Swap(0, i)
            SiftDown(0, i - 1)
        Next
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementation for double arrays (pending)
    End Sub

    Private Sub SiftDown(root As Integer, [end] As Integer)
        Dim leftChild As Integer = 2 * root + 1
        While leftChild <= [end]
            Dim rightChild As Integer = leftChild + 1
            Dim swapIndex As Integer = root

            If heap(swapIndex) < heap(leftChild) Then
                swapIndex = leftChild
            End If

            If rightChild <= [end] AndAlso heap(swapIndex) < heap(rightChild) Then
                swapIndex = rightChild
            End If

            If swapIndex = root Then
                Return
            Else
                Swap(root, swapIndex)
                root = swapIndex
                leftChild = 2 * root + 1
            End If
        End While
    End Sub

    Private Sub Swap(i As Integer, j As Integer)
        Dim temp As Integer = heap(i)
        heap(i) = heap(j)
        heap(j) = temp
    End Sub
End Class
