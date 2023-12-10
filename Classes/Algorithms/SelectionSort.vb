Friend Class Selectionsort
    Implements ImethodAlgorithms
    Private swaps As Integer = 0
    Private iterations As Integer = 0

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        Dim n As Integer = arr.Length

        For i As Integer = 0 To n - 2
            ' Encontrar el índice del mínimo elemento en el subarreglo no ordenado
            Dim minIndex As Integer = i
            For j As Integer = i + 1 To n - 1
                If arr(j) < arr(minIndex) Then
                    minIndex = j
                End If
            Next

            ' Intercambiar el mínimo encontrado con el primer elemento del subarreglo no ordenado
            Swap(arr(i), arr(minIndex))

            ' Imprimir el arreglo en cada iteración
            PrintArray(arr)
        Next

        Console.WriteLine($"Number of swaps: {swaps}")
        Console.WriteLine($"Number of iterations: {iterations}")
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementación para ordenar un array de doubles
    End Sub

    Private Sub PrintArray(arr As Integer())
        Console.WriteLine($"[ {String.Join(", ", arr)} ]")
        iterations += 1
    End Sub

    Private Sub Swap(ByRef a As Integer, ByRef b As Integer)
        Dim temp As Integer = a
        a = b
        b = temp
        swaps += 1 ' Incrementa el número de intercambios
    End Sub
End Class

