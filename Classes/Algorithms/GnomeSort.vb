Public Class Gnomesort
    Implements ImethodAlgorithms
    Private iterations As Integer = 0
    Private swaps As Integer = 0

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        GnomeSort(arr)
        Console.WriteLine($"Number of iterations: {iterations}")
        Console.WriteLine($"Number of swaps: {swaps}")
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementación para ordenar un array de doubles
    End Sub

    Private Sub GnomeSort(arr As Integer())
        Dim n As Integer = arr.Length
        Dim index As Integer = 0

        While index < n
            If index = 0 Then
                index += 1
            End If

            If arr(index) >= arr(index - 1) Then
                index += 1
            Else
                Swap(arr(index), arr(index - 1))
                index -= 1

                ' Imprimir el arreglo en cada iteración
                Console.WriteLine($"[ {String.Join(", ", arr)} ]")
                iterations += 1
            End If
        End While
    End Sub

    Private Sub Swap(ByRef a As Integer, ByRef b As Integer)
        Dim temp As Integer = a
        a = b
        b = temp
        swaps += 1
    End Sub
End Class

