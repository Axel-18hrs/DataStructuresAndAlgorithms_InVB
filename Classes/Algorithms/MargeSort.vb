Public Class Mergesort
    Implements ImethodAlgorithms
    Private swaps As Integer = 0
    Private iterations As Integer = 0
    Private recursions As Integer = 0

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        MergeSort(arr)
        Console.WriteLine($"Number of swaps: {swaps}")
        Console.WriteLine($"Number of iterations: {iterations}")
        Console.WriteLine($"Number of recursions: {recursions}")
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementación para ordenar un array de doubles
    End Sub

    Private Sub MergeSort(arr As Integer())
        If arr.Length < 2 Then
            Return
        End If

        Dim mid As Integer = arr.Length \ 2
        Dim left As Integer() = New Integer(mid - 1) {}
        Dim right As Integer() = New Integer(arr.Length - mid - 1) {}

        Array.Copy(arr, 0, left, 0, mid)
        Array.Copy(arr, mid, right, 0, arr.Length - mid)

        MergeSort(left)
        MergeSort(right)
        Merge(arr, left, right)
        recursions += 1 ' Incrementa el número de recursiones
    End Sub

    Private Sub Merge(arr As Integer(), left As Integer(), right As Integer())
        Dim i As Integer = 0, j As Integer = 0, k As Integer = 0

        While i < left.Length AndAlso j < right.Length
            If left(i) <= right(j) Then
                arr(k) = left(i)
                i += 1
            Else
                arr(k) = right(j)
                j += 1
            End If
            k += 1
            swaps += 1 ' Incrementa el número de intercambios
            iterations += 1 ' Incrementa el número de iteraciones
            Console.WriteLine($"[ {String.Join(", ", arr)} ]")
        End While

        While i < left.Length
            arr(k) = left(i)
            i += 1
            k += 1
            swaps += 1 ' Incrementa el número de intercambios
            iterations += 1 ' Incrementa el número de iteraciones
            Console.WriteLine($"[ {String.Join(", ", arr)} ]")
        End While

        While j < right.Length
            arr(k) = right(j)
            j += 1
            k += 1
            swaps += 1 ' Incrementa el número de intercambios
            iterations += 1 ' Incrementa el número de iteraciones
            Console.WriteLine($"[ {String.Join(", ", arr)} ]")
        End While
    End Sub
End Class
