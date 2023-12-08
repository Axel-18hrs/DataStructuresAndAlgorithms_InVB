Public Module OperationsTree
    Public Sub TreeMenu()
        Dim tree As New BinaryTree()

        Do
            Console.Clear()
            Console.WriteLine("Binary Tree {vbCrLf}" &
                              $"1. Add node{vbCrLf}" &
                              $"2. Search node{vbCrLf}" &
                              $"3. Delete node{vbCrLf}" &
                              $"4. Display tree{vbCrLf}" &
                              $"5. PreOrder Traversal{vbCrLf}" &
                              $"6. PostOrder Traversal{vbCrLf}" &
                              $"7. InOrder Traversal{vbCrLf}" &
                              $"0. Exit{vbCrLf}")

            Dim choice As Integer
            If Not Integer.TryParse(Console.ReadLine(), choice) Then
                [Default]()
                Continue Do
            End If

            Select Case choice
                Case 1
                    Console.Write("Enter a value: ")
                    Dim opt As Integer
                    If Integer.TryParse(Console.ReadLine(), opt) Then
                        tree.Add(opt)
                    Else
                        [Default]()
                        Continue Do
                    End If

                Case 2
                    Console.Write("Enter the value of the node to search: ")
                    Dim opti As Integer
                    If Integer.TryParse(Console.ReadLine(), opti) Then
                        tree.Search(opti)
                    Else
                        [Default]()
                        Continue Do
                    End If

                Case 3
                    Console.Write("Enter the value of the node to delete: ")
                    Dim opt_ As Integer
                    If Integer.TryParse(Console.ReadLine(), opt_) Then
                        tree.Delete(opt_)
                    Else
                        [Default]()
                        Continue Do
                    End If

                Case 4
                    Console.Clear()
                    tree.PrintTree()
                    Console.WriteLine("Press a key to exit")

                Case 5
                    Console.Clear()
                    Console.WriteLine($"PreOrder Traversal: {String.Join(" ", tree.GetPreOrden())}")

                Case 6
                    Console.Clear()
                    Console.WriteLine($"PostOrder Traversal: {String.Join(" ", tree.GetPostOrden())}")

                Case 7
                    Console.Clear()
                    Console.WriteLine($"InOrder Traversal: {String.Join(" ", tree.GetInOrden())}")

                Case 0
                    Return

                Case Else
                    [Default]()
            End Select

            Console.ReadKey()
        Loop While True
    End Sub

    Public Sub [Default]()
        Console.WriteLine($"{vbCrLf}Invalid input. Please enter a valid number.")
        Console.ReadKey()
    End Sub
End Module
