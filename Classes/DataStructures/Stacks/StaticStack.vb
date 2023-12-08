Imports System

Public Class StaticStack(Of T)
    Implements ImethodStacks(Of T)

    Private elements As T()
    Private capacity As Integer
    Private count_ As Integer

    Public Sub New(capacity As Integer)
        Me.capacity = capacity
        elements = New T(capacity - 1) {}
        count_ = 0
    End Sub

    Public Sub Push(element As T) Implements ImethodStacks(Of T).Push
        If count_ < capacity Then
            elements(count_) = element
            count_ += 1
        Else
            Console.WriteLine("The stack is full. Cannot add more elements.")
        End If
    End Sub

    Public Function Pop() As T Implements ImethodStacks(Of T).Pop
        If count_ > 0 Then
            count_ -= 1
            Dim element As T = elements(count_)
            elements(count_) = Nothing
            Return element
        Else
            Console.WriteLine("The stack is empty. Cannot pop more elements.")
            Return Nothing
        End If
    End Function

    Public Function Peek() As T Implements ImethodStacks(Of T).Peek
        If count_ > 0 Then
            Return elements(count_ - 1)
        Else
            Console.WriteLine("The stack is empty. No elements to peek.")
            Return Nothing
        End If
    End Function

    Public Function Count() As Integer Implements ImethodStacks(Of T).Count
        Return count_
    End Function

    Public Sub Show() Implements ImethodStacks(Of T).Show
        Console.WriteLine(vbLf & "Elements in the stack:")
        For i As Integer = count_ - 1 To 0 Step -1
            Console.WriteLine(elements(i))
        Next
    End Sub
End Class
