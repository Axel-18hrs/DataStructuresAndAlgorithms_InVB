Friend Class Combsort
    Implements ImethodAlgorithms

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        Dim n As Integer = arr.Length

        ' Initialize the gap size
        Dim gap As Integer = n

        ' Reduction factor
        Dim shrink As Double = 1.3

        Dim swapped As Boolean

        Do
            ' Apply a minimum gap of 1
            If gap > 1 Then
                gap = CInt(gap / shrink)
            End If

            swapped = False

            ' Perform comparisons and swaps
            For i As Integer = 0 To n - gap - 1
                If arr(i) > arr(i + gap) Then
                    Swap(arr(i), arr(i + gap))
                    swapped = True
                End If
            Next
        Loop While gap > 1 OrElse swapped
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementation for double arrays (pending)
    End Sub

    Private Sub Swap(ByRef a As Integer, ByRef b As Integer)
        Dim temp As Integer = a
        a = b
        b = temp
    End Sub
End Class
