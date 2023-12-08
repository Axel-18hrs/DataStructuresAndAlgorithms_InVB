Public Class CircularDoublyLinkedList(Of T)
    Implements ImethodLists(Of T)

    Private Property Head As DoubleNode(Of T)
    Private Property LastNode As DoubleNode(Of T)

    Public Sub New()
        Clear()
    End Sub

    Public Sub Add(data As T) Implements ImethodLists(Of T).Add
        ' Case 0: Create a new node
        Dim NewNode As New DoubleNode(Of T)(data)

        ' Case 1: Insert at the beginning
        If IsEmpty() Then
            Head = NewNode
            LastNode = NewNode
            Head.Back = LastNode
            LastNode.Next_ = Head
            Return
        End If

        ' Case 2: Prevent duplicate data
        If Exist(NewNode.Data) Then
            Console.WriteLine("// Already exists: " & data.ToString())
            Return
        End If

        ' Case 3: Insert at the beginning if the data is smaller
        If NewNode.CompareTo(Head) <= 0 Then
            NewNode.Next_ = Head
            NewNode.Back = LastNode
            Head.Back = NewNode
            Head = NewNode
            LastNode.Next_ = Head
            Return
        End If

        ' Case 4: Insert at the end if the data is larger
        If NewNode.CompareTo(LastNode) >= 0 Then
            LastNode.Next_ = NewNode
            NewNode.Back = LastNode
            NewNode.Next_ = Head
            LastNode = NewNode
            Head.Back = LastNode
            Return
        End If

        ' Case 5: Traverse the list
        Dim CurrentNode As DoubleNode(Of T) = Head
        While CurrentNode.Next_ IsNot Head AndAlso CurrentNode.Next_.CompareTo(NewNode) <= 0
            CurrentNode = CurrentNode.Next_
        End While

        ' Case 6: Insert at X position
        NewNode.Next_ = CurrentNode.Next_
        NewNode.Back = CurrentNode
        CurrentNode.Next_.Back = NewNode
        CurrentNode.Next_ = NewNode
    End Sub

    Public Sub Delete(data As T) Implements ImethodLists(Of T).Delete
        ' Case 1: If the list is empty
        If IsEmpty() Then
            Console.WriteLine("Empty list")
            Return
        End If

        ' Case 2: Delete and check if there is only one element
        If Head.CompareTo(LastNode) = 0 Then
            Clear()
            Console.WriteLine($"- Data[{data}] deleted from the list")
            Return
        End If

        ' Case 3: The data is at the beginning of the list
        If Head.CompareTo(data) = 0 Then
            Head = Head.Next_
            Head.Back = LastNode
            LastNode.Next_ = Head
            Console.WriteLine($"- Data[{data}] deleted from the list")
            Return
        End If

        ' Case 4: The data is at the end of the list
        If LastNode.CompareTo(data) = 0 Then
            LastNode = LastNode.Back
            LastNode.Next_ = Head
            Head.Back = LastNode
            Console.WriteLine($"- Data[{data}] deleted from the list")
            Return
        End If

        ' Case 5: Traverse the list
        Dim CurrentNode As DoubleNode(Of T) = Head
        While CurrentNode.Next_ IsNot Head AndAlso CurrentNode.Next_.CompareTo(data) < 0
            CurrentNode = CurrentNode.Next_
        End While

        ' Case 6: The data is at X position in the list
        If CurrentNode.Next_.CompareTo(data) = 0 Then
            CurrentNode.Next_.Next_.Back = CurrentNode
            CurrentNode.Next_ = CurrentNode.Next_.Next_
            Console.WriteLine($"- Data[{data}] deleted from the list")
            Return
        End If

        ' Case 7: The data to delete was not found
        Console.WriteLine($"- Data[{data}] Not found/deleted from the list")
    End Sub

    Public Sub Search(data As T) Implements ImethodLists(Of T).Search
        ' Case 1: If the list is empty
        If IsEmpty() Then
            Console.WriteLine("Empty list")
            Return
        End If

        ' Case 2: If the data is at the beginning
        If Head.CompareTo(data) = 0 Then
            Console.WriteLine($"- Data[{data}] exists in the list")
            Return
        End If

        ' Case 3: If the data is at the end
        If LastNode.CompareTo(data) = 0 Then
            Console.WriteLine($"- Data[{data}] exists in the list")
            Return
        End If

        ' Case 4: Traverse the list
        Dim CurrentNode As DoubleNode(Of T) = Head
        While CurrentNode.Next_ IsNot Head AndAlso CurrentNode.Next_.CompareTo(data) < 0
            CurrentNode = CurrentNode.Next_
        End While

        ' Case 5: If the data exists in the list
        If CurrentNode.CompareTo(data) = 0 Then
            Console.WriteLine($"- Data[{data}] exists in the list")
            Return
        End If

        ' Case 6: The data does not exist in the list
        Console.WriteLine($"- Data[{data}] Does not exist in the list ")
    End Sub

    Public Sub Show() Implements ImethodLists(Of T).Show
        ' Case 1: If the list is empty
        If IsEmpty() Then
            Console.WriteLine("Empty list")
            Return
        End If

        ' Case 2: Traverse the list
        Dim CurrentNode As DoubleNode(Of T) = Head
        Dim i As Integer = 0
        Console.WriteLine("=== My Circular Doubly Linked List ===")
        Do
            Console.WriteLine($"- Node[{i}] and data: " & CurrentNode.Data.ToString())
            CurrentNode = CurrentNode.Next_
            i += 1
        Loop While CurrentNode IsNot Head
    End Sub

    Public Sub ShowRevers() Implements ImethodLists(Of T).ShowRevers
        ' Case 1: If the list is empty
        If IsEmpty() Then
            Console.WriteLine("Empty list")
            Return
        End If

        ' Case 2: Traverse the list
        Dim CurrentNode As DoubleNode(Of T) = LastNode
        Dim i As Integer = 0
        Console.WriteLine("=== My Reversed Circular Doubly Linked List ===")
        Do
            Console.WriteLine($"- Node[{i}] and data: " & CurrentNode.Data.ToString())
            CurrentNode = CurrentNode.Back
            i += 1
        Loop While CurrentNode IsNot LastNode
    End Sub

    Public Function Exist(data As T) As Boolean Implements ImethodLists(Of T).Exist
        ' Case 1: If the list is empty
        If IsEmpty() Then
            Return False
        End If

        ' Case 2: If the first element already exists
        If Head.CompareTo(data) = 0 Then
            Return True
        End If

        ' Case 3: If the data is at the end
        If LastNode.CompareTo(data) = 0 Then
            Return True
        End If

        ' Case 4: Traverse the list
        Dim CurrentNode As DoubleNode(Of T) = Head
        While CurrentNode.Next_ IsNot Head AndAlso CurrentNode.CompareTo(data) < 0
            CurrentNode = CurrentNode.Next_
        End While

        ' Case 5: The entered data exists at X position
        If CurrentNode.CompareTo(data) = 0 Then
            Return True
        End If

        ' Case 6: The data does not exist in the list
        Return False
    End Function

    Public Function IsEmpty() As Boolean Implements ImethodLists(Of T).IsEmpty
        Return Head Is Nothing
    End Function

    Public Sub Clear() Implements ImethodLists(Of T).Clear
        Head = Nothing
        LastNode = Nothing
    End Sub
End Class
