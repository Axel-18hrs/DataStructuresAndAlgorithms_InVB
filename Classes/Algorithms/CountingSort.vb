Friend Class CountingSort
    Implements ImethodAlgorithms

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        Dim n As Integer = arr.Length

        ' Find the range of the array
        Dim max As Integer = FindMax(arr)

        ' Create a counting array and an output array
        Dim count(max) As Integer
        Dim output(n - 1) As Integer

        ' Initialize the counting array
        For i As Integer = 0 To max
            count(i) = 0
        Next

        ' Count the frequency of each element
        For i As Integer = 0 To n - 1
            count(arr(i)) += 1
        Next

        ' Update the counting array to contain the actual positions
        For i As Integer = 1 To max
            count(i) += count(i - 1)
        Next

        ' Build the output array
        For i As Integer = n - 1 To 0 Step -1
            output(count(arr(i)) - 1) = arr(i)
            count(arr(i)) -= 1
        Next

        ' Copy the output array back to the original array
        For i As Integer = 0 To n - 1
            arr(i) = output(i)
        Next
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementation for double arrays (pending)
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
