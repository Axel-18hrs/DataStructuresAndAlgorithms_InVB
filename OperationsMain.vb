Friend Class OperationsMain
    Public Shared Sub MenuDataStructurs()
        Do
            Console.Clear()
            Console.WriteLine("Select a data struct:")
            Console.WriteLine($"1. Lists {vbCrLf}" &
                              $"2. Stacks {vbCrLf}" &
                              $"3. Queue {vbCrLf}" &
                              $"4. Trees {vbCrLf}" &
                              $"5. Graphs {vbCrLf}" &
                              $"0. Exit {vbCrLf}")

            Dim opt As Integer
            If Not Integer.TryParse(Console.ReadLine(), opt) Then
                OperationsList.Deffault()
                Continue Do
            End If

            Select Case opt
                Case 1
                    OperationsList.MenuList()
                Case 2
                    OperationsStack.MenuStack()
                Case 3
                    OperationsQueue.MenuQueue()
                Case 4
                    OperationsTree.TreeMenu()
                Case 5
                    OperationsGraph.MenuGraphs()
                Case 0
                    Return

                Case Else
                    OperationsList.Deffault()
            End Select
        Loop While True
    End Sub

    Public Shared Sub MenuAlgorithms_()
        OperationsAlgorithm.MenuAlgorithms()
    End Sub

    Public Shared Sub MainDS()
        Do
            Console.Clear()
            Console.WriteLine("Select a data structure or algorithm:")
            Console.WriteLine($"1. Algorithms{vbCrLf}" &
                              $"2. Data Structures{vbCrLf}" &
                              $"0. Exit{vbCrLf}")

            Dim num As Integer
            If Not Integer.TryParse(Console.ReadLine(), num) Then
                OperationsList.Deffault()
                Continue Do
            End If

            Select Case num
                Case 1
                    MenuAlgorithms_()
                Case 2
                    MenuDataStructurs()
                Case 0
                    Return
                Case Else
                    OperationsList.Deffault()
            End Select
        Loop While True
    End Sub
End Class
