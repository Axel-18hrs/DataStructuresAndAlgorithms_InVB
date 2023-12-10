Public Class Insertionsort
    Implements ImethodAlgorithms
    Private swaps As Integer = 0
    Private iterations As Integer = 0

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        InsertionSortAlgorithm(arr)
        Console.WriteLine($"Number of swaps: {swaps}")
        Console.WriteLine($"Number of iterations: {iterations}")
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementación para ordenar un array de doubles
    End Sub

    Public Sub InsertionSortAlgorithm(arr As Integer())
        Dim n As Integer = arr.Length
        For i As Integer = 1 To n - 1
            Dim key As Integer = arr(i)
            Dim j As Integer = i - 1

            ' Mover los elementos del subarreglo arr(0..i-1) que son mayores que key
            ' a una posición adelante de su posición actual
            While j >= 0 AndAlso arr(j) > key
                arr(j + 1) = arr(j)
                j = j - 1
                swaps += 1 ' Incrementa el número de intercambios
                iterations += 1 ' Incrementa el número de iteraciones
            End While
            arr(j + 1) = key

            ' Imprimir el arreglo en cada iteración
            Console.WriteLine($"[ {String.Join(", ", arr)} ]")
            iterations += 1 ' Incrementa el número de iteraciones
        Next
    End Sub
End Class

