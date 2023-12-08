Friend Interface ImethodQueues(Of T)
    Sub Enqueue(value As T)
    Sub EnqueueRear(value As T)
    Sub Dequeue()
    Sub DequeueRear()
    Sub Peek()
    Sub PeekRear()
    Sub Display()
    Function Count() As Integer
    Function IsEmpty() As Boolean
End Interface

