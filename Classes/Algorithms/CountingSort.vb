Public Class Countingsort
    Implements ImethodAlgorithms
    Private Shared iterations As Integer = 0

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        Dim n As Integer = arr.Length

        ' Encontrar el rango del arreglo
        Dim max As Integer = FindMax(arr)

        ' Crear un arreglo de conteo y un arreglo resultado
        Dim count(max) As Integer
        Dim output(n - 1) As Integer

        ' Inicializar el arreglo de conteo
        For i As Integer = 0 To max
            count(i) = 0
        Next

        ' Contar la frecuencia de cada elemento
        For i As Integer = 0 To n - 1
            count(arr(i)) += 1
        Next

        ' Actualizar el arreglo de conteo para contener las posiciones reales
        For i As Integer = 1 To max
            count(i) += count(i - 1)
        Next

        ' Construir el arreglo de salida
        For i As Integer = n - 1 To 0 Step -1
            output(count(arr(i)) - 1) = arr(i)
            count(arr(i)) -= 1

            ' Imprimir el arreglo completo en cada intercambio
            Console.WriteLine($"[ {String.Join(", ", output)} ]")
            iterations += 1 ' Incrementa el número de iteraciones
        Next

        ' Copiar el arreglo de salida de vuelta al arreglo original
        For i As Integer = 0 To n - 1
            arr(i) = output(i)
        Next

        Console.WriteLine($"Number of iterations: {iterations}")
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementación para ordenar un array de doubles
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
