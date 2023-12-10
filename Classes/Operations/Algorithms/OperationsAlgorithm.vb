Imports System
Imports System.Collections.Generic

Public Class OperationsAlgorithm
    Private Shared _rand As New Random()

    Public Shared Function GenerarVectorDouble(Optional Minon As Integer = 0, Optional Lenght As Integer = 10, Optional values As Integer = 5) As Double()
        Dim _List As New List(Of Double)()

        For i As Integer = Minon To Lenght - 1
            If i < values Then
                Dim NewValor As Double = _rand.NextDouble()
                _List.Add(NewValor)
            Else
                Exit For
            End If
        Next
        Return _List.ToArray()
    End Function

    Public Shared Function GenerarVector(Optional Minon As Integer = 0, Optional Lenght As Integer = 10, Optional values As Integer = 5) As Integer()
        Dim _List As New List(Of Integer)()

        For i As Integer = Minon To Lenght - 1
            If i < values Then
                Dim NewValor As Integer = _rand.Next(Minon, Lenght + 1)
                If _List.Contains(NewValor) Then
                    i -= 1
                    Continue For
                End If
                _List.Add(NewValor)
            Else
                Exit For
            End If
        Next
        Return _List.ToArray()
    End Function

    Public Shared Sub Algorithm(algorithm As ImethodAlgorithms)
        Do
            Console.Clear()
            Dim minon As Integer
            Console.WriteLine("Enter the minimum range from which you want to generate your unordered array:")
            If Not Integer.TryParse(Console.ReadLine(), minon) Then
                OperationsList.Deffault()
                Continue Do
            End If

            Dim length As Integer
            Console.WriteLine(vbCrLf & "Enter the maximum range or limit where you want to generate your unordered array:")
            If Not Integer.TryParse(Console.ReadLine(), length) Then
                OperationsList.Deffault()
                Continue Do
            End If

            Dim values As Integer
            Console.WriteLine(vbCrLf & "Enter the number of values you want in your array:")
            If Not Integer.TryParse(Console.ReadLine(), values) Then
                OperationsList.Deffault()
                Continue Do
            End If

            If (TypeOf algorithm Is BucketSort OrElse TypeOf algorithm Is SelectionSort) AndAlso minon < 0 Then
                Console.WriteLine("Only values greater than or equal to zero are accepted.")
                Console.ReadKey()
                Continue Do
            End If

            If TypeOf algorithm Is BucketSort Then
                Dim arr As Double() = GenerarVectorDouble(minon, length, values)

                Console.WriteLine(vbCrLf & "Unordered array: ")
                Console.Write("[ " & String.Join(", ", arr) & " ]")
                Dim startTime As DateTime = DateTime.Now
                algorithm.Sort(arr)
                Console.WriteLine(vbCrLf & "Sorted array: ")
                Console.WriteLine("[ " & String.Join(", ", arr) & " ]")
                Console.WriteLine("Time: " & (DateTime.Now - startTime).ToString())
            Else
                Dim arr As Integer() = GenerarVector(minon, length, values)

                Console.WriteLine(vbCrLf & "Unordered array: ")
                Console.Write("[ " & String.Join(", ", arr) & " ]" & vbCrLf)
                Dim startTime As DateTime = DateTime.Now
                algorithm.Sort(arr)
                Console.WriteLine(vbCrLf & "Sorted array: ")
                Console.WriteLine("[ " & String.Join(", ", arr) & " ]")
                Console.WriteLine("Time: " & (DateTime.Now - startTime).ToString())
            End If

            Console.ReadKey()
            Exit Do
        Loop While True
    End Sub

    Public Shared Sub MenuAlgorithms()
        Do
            Console.Clear()
            Console.WriteLine("Select an algorithm:")
            Console.WriteLine("1. Binary Tree Sort" & vbLf &
                              "2. Bubble Sort" & vbLf &
                              "3. Bucket Sort" & vbLf &
                              "4. Cocktail Sort" & vbLf &
                              "5. Comb Sort" & vbLf &
                              "6. Counting Sort" & vbLf &
                              "7. Gnome Sort" & vbLf &
                              "8. Heap Sort" & vbLf &
                              "9. Insertion Sort" & vbLf &
                              "10. Merge Sort" & vbLf &
                              "11. Pigeonhole Sort" & vbLf &
                              "12. Quick Sort" & vbLf &
                              "13. Radix Sort" & vbLf &
                              "14. Selection Sort" & vbLf &
                              "15. Shell Sort" & vbLf &
                              "16. Smooth Sort" & vbLf &
                              "0. Exit" & vbLf)
            Dim opc As Integer
            If Not Integer.TryParse(Console.ReadLine(), opc) Then
                OperationsList.Deffault()
                Continue Do
            End If

            Select Case opc
                Case 1
                    Algorithm(New BinaryTreeSort())
                Case 2
                    Algorithm(New BubbleSort())
                Case 3
                    Algorithm(New BucketSort())
                Case 4
                    Algorithm(New CocktailSort())
                Case 5
                    Algorithm(New Combsort())
                Case 6
                    Algorithm(New CountingSort())
                Case 7
                    Algorithm(New GnomeSort())
                Case 8
                    Algorithm(New Heapsort())
                Case 9
                    Algorithm(New InsertionSort())
                Case 10
                    Algorithm(New Mergesort())
                Case 11
                    Algorithm(New Pigeonhole())
                Case 12
                    Algorithm(New QuickSort())
                Case 13
                    Algorithm(New RadixSort())
                Case 14
                    Algorithm(New SelectionSort())
                Case 15
                    Algorithm(New ShellSort())
                Case 16
                    Algorithm(New SmoothSort())
                Case 0
                    Exit Do
                Case Else
                    OperationsList.Deffault()
            End Select
        Loop While True
    End Sub
End Class
