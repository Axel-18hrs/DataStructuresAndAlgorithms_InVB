Friend Interface ImethodStacks(Of T)
    Sub Push(element As T)
    Function Pop() As T
    Function Peek() As T
    Sub Show()
    Function Count() As Integer
End Interface
