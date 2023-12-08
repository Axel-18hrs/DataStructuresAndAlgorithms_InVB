Public Class OperationsQueue
    Public Shared Sub ALQueueOperation(Of T)(queue As ImethodQueues(Of T))
        Dim queueTypeMessage As String = If(TypeOf queue Is RegularQueue(Of T), "Regular", If(TypeOf queue Is DoubleQueue(Of T), "Double", If(TypeOf queue Is PriorityQueue(Of T), "Priority", "Circle")))
        Dim operationCircularQueue As Boolean = TypeOf queue Is CircularQueue(Of T)

        Do
            Console.Clear()
            Console.WriteLine($"{queueTypeMessage} queue {vbCrLf}" &
                              $"1. Enqueue value {vbCrLf}" &
                              $"2. Dequeue value {vbCrLf}" &
                              $"3. Peek value{vbCrLf}" &
                              $"4. Display {vbCrLf}" &
                              $"0. Exit {vbCrLf}")

            Dim choice As Integer
            If Not Integer.TryParse(Console.ReadLine(), choice) Then
                Deffault()
                Continue Do
            End If

            Select Case choice
                Case 1
                    If operationCircularQueue Then
                        Console.WriteLine("What type of enqueue do you want to perform?" &
                                          $"{vbCrLf}1. Enqueue simple" &
                                          $"{vbCrLf}2. Enqueue rear")
                        Dim opt_ As Integer
                        If Not Integer.TryParse(Console.ReadLine(), opt_) Then
                            Deffault()
                            Continue Do
                        End If

                        If opt_ = 2 Then
                            Try
                                Console.WriteLine("Enter a value to enqueue at the rear:")
                                Dim convertedValue As T = DirectCast(Convert.ChangeType(Console.ReadLine(), GetType(T)), T)
                                queue.EnqueueRear(convertedValue)
                            Catch ex As InvalidCastException
                                Deffault()
                            End Try
                            Continue Do
                        End If

                        If opt_ <> 1 Then
                            Deffault()
                            Continue Do
                        End If
                    End If

                    Try
                        Console.WriteLine("Enter a value to enqueue:")
                        Dim convertedValue As T = DirectCast(Convert.ChangeType(Console.ReadLine(), GetType(T)), T)
                        queue.Enqueue(convertedValue)
                    Catch ex As InvalidCastException
                        Deffault()
                    End Try
                Case 2
                    If operationCircularQueue Then
                        Console.WriteLine("What type of 'Dequeue' do you want to perform?" &
                                          $"{vbCrLf}1. Dequeue simple" &
                                          $"{vbCrLf}2. Dequeue rear")

                        Dim opti
                        If Not Integer.TryParse(Console.ReadLine(), opti) Then
                            Deffault()
                            Continue Do
                        End If

                        If opti = 2 Then
                            queue.DequeueRear()
                            Continue Do
                        End If

                        If opti <> 1 Then
                            Deffault()
                            Continue Do
                        End If
                    End If

                    queue.Dequeue()
                    Continue Do
                Case 3
                    If operationCircularQueue Then
                        Console.WriteLine("What type of 'Peek' do you want to perform?" &
                                          $"{vbCrLf}1. Peek simple" &
                                          $"{vbCrLf}2. Peek rear")

                        Dim choice_ As Integer
                        If Not Integer.TryParse(Console.ReadLine(), choice_) Then
                            Deffault()
                            Continue Do
                        End If

                        If choice_ = 2 Then
                            queue.PeekRear()
                            Continue Do
                        End If

                        If choice_ <> 1 Then
                            Deffault()
                            Continue Do
                        End If
                    End If

                    queue.Peek()
                    Exit Select
                Case 4
                    queue.Display()
                    Exit Select
                Case 0
                    Return
                Case Else
                    Deffault()
            End Select

            Console.ReadKey()
        Loop While True
    End Sub

    Public Shared Sub MenuQueue()
        Do
            Console.Clear()
            Console.WriteLine($"Types of queues: {vbCrLf}" &
                              $"1. Regular queue {vbCrLf}" &
                              $"2. Doubly queue {vbCrLf}" &
                              $"3. Priority queue {vbCrLf}" &
                              $"4. Circular queue {vbCrLf}" &
                              $"0. Exit {vbCrLf}")

            Dim opt As Integer
            If Not Integer.TryParse(Console.ReadLine(), opt) Then
                Deffault()
                Continue Do
            End If

            Select Case opt
                Case 1
                    ALQueueOperation(New RegularQueue(Of Object)())
                    Exit Select
                Case 2
                    ALQueueOperation(New DoubleQueue(Of Object)())
                    Exit Select
                Case 3
                    ALQueueOperation(New PriorityQueue(Of Object)())
                    Exit Select
                Case 4
                    Console.WriteLine("How large do you want your Queue to be?")
                    Dim lenght As Integer
                    If Not Integer.TryParse(Console.ReadLine(), lenght) Then
                        Deffault()
                        Continue Do
                    End If

                    ALQueueOperation(New CircularQueue(Of Object)(lenght))
                    Exit Select
                Case 0
                    Return
                Case Else
                    Deffault()
            End Select
        Loop While True
    End Sub

    Public Shared Sub Deffault()
        Console.WriteLine("Invalid input. Please enter a valid number.")
        Console.ReadKey()
    End Sub
End Class

