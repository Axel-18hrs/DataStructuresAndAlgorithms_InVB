Public Class Radixsort
    Implements ImethodAlgorithms
    Private iterations As Integer = 0

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        Dim max As Integer = FindMax(arr)

        ' Aplicar Radix Sort para cada posición del dígito
        For exp As Integer = 1 To max \ 10
            CountingSort(arr, exp)
        Next

        Console.WriteLine($"Number of iterations: {iterations}")
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementación para ordenar un array de doubles
    End Sub

    Private Sub CountingSort(arr As Integer(), exp As Integer)
        Dim n As Integer = arr.Length
        Dim output As Integer() = New Integer(n - 1) {}
        Dim count As Integer() = New Integer(9) {}

        ' Inicializar el arreglo de conteo
        For i As Integer = 0 To 9
            count(i) = 0
        Next

        ' Contar la frecuencia de cada elemento en la posición actual del dígito
        For i As Integer = 0 To n - 1
            count((arr(i) \ exp) Mod 10) += 1
        Next

        ' Actualizar el arreglo de conteo para contener las posiciones reales
        For i As Integer = 1 To 9
            count(i) += count(i - 1)
        Next

        ' Construir el arreglo de salida
        For i As Integer = n - 1 To 0 Step -1
            output(count((arr(i) \ exp) Mod 10) - 1) = arr(i)
            count((arr(i) \ exp) Mod 10) -= 1
        Next

        ' Copiar el arreglo de salida de vuelta al arreglo original
        For i As Integer = 0 To n - 1
            arr(i) = output(i)
        Next

        PrintArray(arr)
    End Sub

    Private Sub PrintArray(arr As Integer())
        Console.WriteLine($"[ {String.Join(", ", arr)} ]")
        iterations += 1
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

