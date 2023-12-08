Friend Class OperationsStack
    Public Shared Sub AllStackOperation(Of T)(stack As ImethodStacks(Of T))
        Dim stackTypeMessage As String = If(TypeOf stack Is DinamicStack(Of T), "Dynamic stack", "Static stack")

        Do
            Console.Clear()
            Console.WriteLine($"{stackTypeMessage} Menu {vbCrLf}" &
                              "1. Push {vbCrLf}" &
                              "2. Pop {vbCrLf}" &
                              "3. Peek {vbCrLf}" &
                              "4. Count {vbCrLf}" &
                              "5. Show Stack {vbCrLf}" &
                              "0. Exit {vbCrLf}")

            Dim choice
            If Not Integer.TryParse(Console.ReadLine(), choice) Then
                Deffault()
                Continue Do
            End If

            Select Case choice
                Case 1
                    Console.WriteLine($"{vbCrLf}Enter a value: ")
                    Dim input As String = Console.ReadLine()

                    Try
                        Dim newElement As T = DirectCast(Convert.ChangeType(input, GetType(T)), T)
                        stack.Push(newElement)
                        Console.WriteLine($"Element '{newElement}' added to the stack.")
                    Catch ex As InvalidCastException
                        Console.WriteLine($"Could not convert '{input}' to type {GetType(T).Name}.")
                    End Try

                Case 2
                    Console.WriteLine($"Element '{stack.Pop()}' removed from the stack.")

                Case 3
                    Console.WriteLine($"Element '{stack.Peek()}' is at the top of the stack.")

                Case 4
                    Console.WriteLine($"Number of elements in the stack: {stack.Count()}")

                Case 5
                    stack.Show()

                Case 0
                    Return

                Case Else
                    Deffault()
            End Select

            Console.ReadKey()
        Loop While True
    End Sub

    Public Shared Sub MenuStack()
        Do
            Console.Clear()
            Console.WriteLine("Types of stacks: {vbCrLf}" &
                              "1. Static stack {vbCrLf}" &
                              "2. Dynamic stack {vbCrLf}" &
                              "0. Exit {vbCrLf}")

            Dim choice As Integer
            If Not Integer.TryParse(Console.ReadLine(), choice) Then
                Deffault()
                Continue Do
            End If

            Select Case choice
                Case 1
                    Console.WriteLine("How many data do you want to store in the static stack?")
                    Dim cant As Integer
                    If Not Integer.TryParse(Console.ReadLine(), cant) Then
                        Deffault()
                        Continue Do
                    End If

                    AllStackOperation(New StaticStack(Of Object)(cant))

                Case 2
                    AllStackOperation(New DinamicStack(Of Object)())

                Case 0
                    Return

                Case Else
                    Deffault()
            End Select
        Loop While True
    End Sub

    Public Shared Sub Deffault()
        Console.WriteLine($"{vbCrLf}Invalid input. Please enter a valid number.")
        Console.ReadKey()
    End Sub
End Class
