Public Class BubbleSort
    Implements ImethodAlgorithms
    Private swaps As Integer = 0
    Private iterations As Integer = 0

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        BubbleSort(arr)
        Console.WriteLine($"Number of swaps: {swaps}")
        Console.WriteLine($"Number of iterations: {iterations}")
    End Sub

    Public Sub Sort(array As Double()) Implements ImethodAlgorithms.Sort
        ' Implementación para ordenar un array de doubles y mostrar pasos
    End Sub

    Private Sub BubbleSort(array As Integer())
        For i As Integer = 0 To array.Length - 1
            For j As Integer = 0 To array.Length - i - 2
                iterations += 1 ' Incrementa el número de iteraciones
                If array(j) > array(j + 1) Then
                    swaps += 1 ' Incrementa el número de intercambios
                    Dim temp As Integer = array(j)
                    array(j) = array(j + 1)
                    array(j + 1) = temp

                    Console.WriteLine($"[ {String.Join(", ", array)} ]")
                End If
            Next
        Next
    End Sub
End Class

