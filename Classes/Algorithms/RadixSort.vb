Friend Class RadixSort
    Implements ImethodAlgorithms

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        Dim max As Integer = FindMax(arr)

        ' Apply Radix Sort for each digit position
        For exp As Integer = 1 To CInt(Math.Floor(CDbl(max / exp)))
            CountingSort(arr, exp)
        Next
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementation for double arrays (pending)
    End Sub

    Private Sub CountingSort(arr As Integer(), exp As Integer)
        Dim n As Integer = arr.Length
        Dim output(n - 1) As Integer
        Dim count(9) As Integer

        ' Initialize the count array
        For i As Integer = 0 To 9
            count(i) = 0
        Next

        ' Count the frequency of each element at the current digit position
        For i As Integer = 0 To n - 1
            count((arr(i) \ exp) Mod 10) += 1
        Next

        ' Update the count array to contain the actual positions
        For i As Integer = 1 To 9
            count(i) += count(i - 1)
        Next

        ' Build the output array
        For i As Integer = n - 1 To 0 Step -1
            output(count((arr(i) \ exp) Mod 10) - 1) = arr(i)
            count((arr(i) \ exp) Mod 10) -= 1
        Next

        ' Copy the output array back to the original array
        For i As Integer = 0 To n - 1
            arr(i) = output(i)
        Next
    End Sub

    Private Function FindMax(arr As Integer()) As Integer
        Dim max As Integer = arr(0)
        For i As Integer = 1 To arr.Length - 1
            If arr(i) > max Then
                max = arr(i)
            End If
        Next
        Return max
    End Function
End Class
