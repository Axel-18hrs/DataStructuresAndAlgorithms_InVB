Friend Class CocktailSort
    Implements ImethodAlgorithms

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        CocktailSort(arr)
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementation for double arrays (pending)
    End Sub

    Public Sub CocktailSort(arr As Integer())
        Dim n As Integer = arr.Length
        Dim swapped As Boolean = True
        Dim start As Integer = 0
        Dim [end] As Integer = n - 1

        While swapped
            ' Move from left to right
            swapped = False
            For i As Integer = start To [end] - 1
                If arr(i) > arr(i + 1) Then
                    Swap(arr, i, i + 1)
                    swapped = True
                End If
            Next

            If Not swapped Then
                Exit While
            End If

            [end] -= 1

            ' Move from right to left
            swapped = False
            For i As Integer = [end] - 1 To start Step -1
                If arr(i) > arr(i + 1) Then
                    Swap(arr, i, i + 1)
                    swapped = True
                End If
            Next

            start += 1
        End While
    End Sub

    Private Sub Swap(arr As Integer(), i As Integer, j As Integer)
        Dim temp As Integer = arr(i)
        arr(i) = arr(j)
        arr(j) = temp
    End Sub
End Class
