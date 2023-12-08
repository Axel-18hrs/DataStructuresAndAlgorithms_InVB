Imports System

Friend Class DoubleQueue(Of T)
    Implements ImethodQueues(Of T)

    Private myDeque As New LinkedList(Of T)()

    Public Sub Enqueue(value As T) Implements ImethodQueues(Of T).Enqueue
        myDeque.AddFirst(value)
        Console.WriteLine($"Enqueued at the front: {value}")
    End Sub

    Public Sub EnqueueRear(value As T) Implements ImethodQueues(Of T).EnqueueRear
        myDeque.AddLast(value)
        Console.WriteLine($"Enqueued at the rear: {value}")
    End Sub

    Public Sub Dequeue() Implements ImethodQueues(Of T).Dequeue
        If myDeque.Count > 0 Then
            Dim value As T = myDeque.First.Value
            myDeque.RemoveFirst()
            Console.WriteLine($"Dequeued from the front: {value}")
            Return
        End If

        Console.WriteLine("Deque is empty. Unable to dequeue from the front.")
    End Sub

    Public Sub DequeueRear() Implements ImethodQueues(Of T).DequeueRear
        If myDeque.Count > 0 Then
            Dim value As T = myDeque.Last.Value
            myDeque.RemoveLast()
            Console.WriteLine($"Dequeued from the rear: {value}")
            Return
        End If

        Console.WriteLine("Deque is empty. Unable to dequeue from the rear.")
    End Sub

    Public Sub Peek() Implements ImethodQueues(Of T).Peek
        If myDeque.Count > 0 Then
            Dim frontValue As T = myDeque.First.Value
            Console.WriteLine($"Front element: {frontValue}")
            Return
        End If

        Console.WriteLine("Deque is empty. No elements at the front to peek.")
    End Sub

    Public Sub PeekRear() Implements ImethodQueues(Of T).PeekRear
        If myDeque.Count > 0 Then
            Dim rearValue As T = myDeque.Last.Value
            Console.WriteLine($"Rear element: {rearValue}")
            Return
        End If

        Console.WriteLine("Deque is empty. No elements at the rear to peek.")
    End Sub

    Public Sub Display() Implements ImethodQueues(Of T).Display
        Console.Write("Deque elements: ")
        For Each item In myDeque
            Console.Write($"{item} ")
        Next
        Console.WriteLine()
    End Sub

    Public Function Count() As Integer Implements ImethodQueues(Of T).Count
        Return myDeque.Count
    End Function

    Public Function IsEmpty() As Boolean Implements ImethodQueues(Of T).IsEmpty
        Throw New NotImplementedException()
    End Function
End Class
