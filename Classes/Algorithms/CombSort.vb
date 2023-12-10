Friend Class Combsort
    Implements ImethodAlgorithms
    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        CombSortAlgorithm(arr)
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementación para ordenar un array de doubles
    End Sub

    Private Sub CombSortAlgorithm(arr As Integer())
        Dim n As Integer = arr.Length

        ' Inicializar el tamaño del salto
        Dim gap As Integer = n

        ' Factor de reducción
        Dim shrink As Double = 1.3

        Dim swapped As Boolean

        Do
            ' Aplicar un salto mínimo de 1
            If gap > 1 Then
                gap = CInt(gap / shrink)
            End If

            swapped = False

            ' Realizar comparaciones y swaps
            For i As Integer = 0 To n - gap - 1
                If arr(i) > arr(i + gap) Then
                    Swap(arr(i), arr(i + gap))
                    swapped = True
                    Console.WriteLine($"[ {String.Join(", ", arr)} ]")
                End If
            Next
        Loop While gap > 1 OrElse swapped
    End Sub

    Private Sub Swap(ByRef a As Integer, ByRef b As Integer)
        Dim temp As Integer = a
        a = b
        b = temp
    End Sub
End Class
