Public Class Pigeonhole
    Implements ImethodAlgorithms
    Private swaps As Integer = 0
    Private iterations As Integer = 0

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        PigeonholeSort(arr)
        Console.WriteLine($"Number of swaps: {swaps}")
        Console.WriteLine($"Number of iterations: {iterations}")
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementación para ordenar un array de doubles
    End Sub

    Private Sub PigeonholeSort(arr As Integer())
        Dim min As Integer = arr(0)
        Dim max As Integer = arr(0)
        Dim range, i, j, index As Integer

        For a As Integer = 1 To arr.Length - 1
            If arr(a) > max Then
                max = arr(a)
            End If
            If arr(a) < min Then
                min = arr(a)
            End If
        Next

        range = max - min + 1
        Dim pigeonholes As Integer() = New Integer(range - 1) {}

        For i = 0 To arr.Length - 1
            pigeonholes(i) = 0
        Next

        For i = 0 To arr.Length - 1
            pigeonholes(arr(i) - min) += 1
        Next

        index = 0

        For j = 0 To range - 1
            While pigeonholes(j) > 0
                arr(index) = j + min
                pigeonholes(j) -= 1
                swaps += 1 ' Incrementa el número de intercambios
                iterations += 1 ' Incrementa el número de iteraciones
                Console.WriteLine($"[ {String.Join(", ", arr)} ]")
                index += 1
            End While
        Next
    End Sub
End Class

