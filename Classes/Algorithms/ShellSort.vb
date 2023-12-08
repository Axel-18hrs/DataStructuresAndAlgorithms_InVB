Friend Class ShellSort
    Implements ImethodAlgorithms

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        ShellSort(arr)
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementation for double arrays (pending)
    End Sub

    Public Sub ShellSort(array As Integer())
        ' Get the length of the array
        Dim n As Integer = array.Length
        ' Get the size of the gap between elements
        Dim gap As Integer = n \ 2

        Console.WriteLine(vbLf & "Start of the Shell Sort algorithm:")

        ' While the gap between elements is greater than 0
        While gap > 0
            Console.WriteLine($"{vbLf}Current Gap: {gap}")

            ' Apply the insertion algorithm for each subarray with the size of the gap
            For i As Integer = gap To n - 1
                ' Save the current value of the element in a temporary variable
                Dim temp As Integer = array(i)
                Dim j As Integer = i

                Console.WriteLine($"{vbLf}Comparing {temp} with the elements in its subarray:")

                ' Perform the insertion
                While j >= gap AndAlso array(j - gap) > temp
                    ' Shift elements to the right until the correct position is found
                    array(j) = array(j - gap)
                    j -= gap

                    PrintArray(array)
                End While

                ' Place the temporary value in the correct position in the subarray
                array(j) = temp
                Console.WriteLine($"Insert {temp} at position {j} in the subarray:")
                PrintArray(array)
            Next

            ' Reduce the gap between elements by half in each iteration
            gap \= 2
        End While

        Console.WriteLine($"{vbLf}End of the Shell Sort algorithm:")
    End Sub

    Private Sub PrintArray(array As Integer())
        For Each num As Integer In array
            Console.Write(num & " ")
        Next
        Console.WriteLine()
    End Sub
End Class
