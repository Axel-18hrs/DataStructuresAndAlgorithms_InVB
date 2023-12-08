Imports System

Friend Class RegularQueue(Of T)
    Implements ImethodQueues(Of T)

    Private myQueue As New Queue(Of T)()

    Public Sub Enqueue(value As T) Implements ImethodQueues(Of T).Enqueue
        myQueue.Enqueue(value)
        Console.WriteLine($"Enqueued: {value}")
    End Sub

    Public Sub EnqueueRear(value As T) Implements ImethodQueues(Of T).EnqueueRear
    End Sub

    Public Sub Dequeue() Implements ImethodQueues(Of T).Dequeue
        If myQueue.Count > 0 Then
            Dim value = myQueue.Dequeue()
            Console.WriteLine($"Dequeued: {value}")
            Return
        End If

        Console.WriteLine("Queue is empty. Unable to dequeue.")
    End Sub

    Public Sub DequeueRear() Implements ImethodQueues(Of T).DequeueRear
    End Sub

    Public Sub Peek() Implements ImethodQueues(Of T).Peek
        If myQueue.Count > 0 Then
            Dim frontValue = myQueue.Peek()
            Console.WriteLine($"Front element: {frontValue}")
            Return
        End If

        Console.WriteLine("Queue is empty. No elements to peek.")
    End Sub

    Public Sub PeekRear() Implements ImethodQueues(Of T).PeekRear
    End Sub

    Public Sub Display() Implements ImethodQueues(Of T).Display
        Console.Write("Queue elements: ")
        For Each item In myQueue
            Console.Write($"{item} ")
        Next
        Console.WriteLine()
    End Sub

    Public Function Count() As Integer Implements ImethodQueues(Of T).Count
        Return myQueue.Count
    End Function

    Public Function IsEmpty() As Boolean Implements ImethodQueues(Of T).IsEmpty
        Throw New NotImplementedException()
    End Function
End Class
