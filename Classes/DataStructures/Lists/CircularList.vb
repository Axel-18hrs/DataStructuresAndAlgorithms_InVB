Public Class CircularList(Of T)
    Implements ImethodLists(Of T)

    Private Property Head As Node(Of T)
    Private Property LastNode As Node(Of T)

    Public Sub New()
        Clear()
    End Sub

    Public Sub Add(data As T) Implements ImethodLists(Of T).Add
        ' Case 0: Create a new node
        Dim NewNode As New Node(Of T)(data)

        ' Case 1: Insert at the beginning
        If IsEmpty() Then
            Head = NewNode
            Head.Next = Head
            LastNode = NewNode
            Return
        End If

        ' Case 2: Prevent duplicate data
        If Exist(NewNode.Data) Then
            Return
        End If

        ' Case 3: Place the data after the first node
        If NewNode.CompareTo(Head) <= 0 Then
            NewNode.Next = Head
            Head = NewNode
            LastNode.Next = Head
            Return
        End If

        ' Case 4: Insert at the end if the data is greater
        If NewNode.CompareTo(LastNode) >= 0 Then
            LastNode.Next = NewNode
            NewNode.Next = Head
            LastNode = NewNode
            Return
        End If

        ' Case 5: Traverse the list
        Dim CurrentNode As Node(Of T) = Head
        While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.CompareTo(NewNode) <= 0
            CurrentNode = CurrentNode.Next
        End While

        NewNode.Next = CurrentNode.Next
        CurrentNode.Next = NewNode
    End Sub

    Public Sub Delete(data As T) Implements ImethodLists(Of T).Delete
        ' Case 1: If the list is empty
        If IsEmpty() Then
            Console.WriteLine("Empty list")
            Return
        End If

        ' Case 2: The data is at the beginning of the list
        If Head.CompareTo(data) = 0 Then
            Head = Head.Next
            LastNode.Next = Head
            Console.WriteLine($"- Data[{data}] deleted from the list")
            Return
        End If

        ' Case 3: Traverse the list
        Dim CurrentNode As Node(Of T) = Head
        While CurrentNode.Next IsNot Head AndAlso CurrentNode.Next.CompareTo(data) < 0
            CurrentNode = CurrentNode.Next
        End While

        ' Case 4: The data is at the end of the list
        If CurrentNode.Next Is LastNode AndAlso LastNode.CompareTo(data) = 0 Then
            CurrentNode.Next = CurrentNode.Next.Next
            LastNode = CurrentNode
            LastNode.Next = Head
            Console.WriteLine($"- Data[{data}] deleted from the list")
            Return
        End If

        ' Case 5: The data is at X position in the list
        If CurrentNode.Next.CompareTo(data) = 0 Then
            CurrentNode.Next = CurrentNode.Next.Next
            Console.WriteLine($"- Data[{data}] deleted from the list")
            Return
        End If

        ' Case 6: The data was not found
        Console.WriteLine($"- Data[{data}] not found/deleted from the list")
    End Sub

    Public Sub Search(data As T) Implements ImethodLists(Of T).Search
        ' Case 1: If the list is empty
        If IsEmpty() Then
            Console.WriteLine("Empty list")
            Return
        End If

        ' Case 2: If the data is at the beginning of the list
        If Head.CompareTo(data) = 0 Then
            Console.WriteLine($"- Data[{data}] exists in the list")
            Return
        End If

        ' Case 3: Traverse the list
        Dim CurrentNode As Node(Of T) = Head
        While CurrentNode.Next IsNot Head AndAlso CurrentNode.CompareTo(data) < 0
            CurrentNode = CurrentNode.Next
        End While

        ' Case 4: The entered data exists at X position
        If CurrentNode.CompareTo(data) = 0 Then
            Console.WriteLine($"- Data[{data}] exists in the list")
            Return
        End If

        ' Case 5: The data does not exist
        Console.WriteLine($"- Data[{data}] does not exist in the list ")
    End Sub

    Public Sub Show() Implements ImethodLists(Of T).Show
        ' Case 1: Check if the list is empty
        If IsEmpty() Then
            Console.WriteLine("Empty list")
            Return
        End If

        ' Case 2: Traverse the list
        Dim CurrentNode As Node(Of T) = Head
        Dim i As Integer = 0
        Console.WriteLine("=== My Circular List ===")
        Do
            Console.WriteLine($"- Node[{i}] and data: " & CurrentNode.Data.ToString())
            CurrentNode = CurrentNode.Next
            i += 1
        Loop While CurrentNode IsNot Head
    End Sub

    Public Sub ShowRevers() Implements ImethodLists(Of T).ShowRevers
        Dim stack As New Stack(Of T)()
        Dim CurrentNode As Node(Of T) = Head
        Dim i As Integer = 0
        Do
            i += 1
            stack.Push(CurrentNode.Data)
            CurrentNode = CurrentNode.Next
        Loop While CurrentNode IsNot Head

        ' Create a copy of the stack before iterating
        Dim stackArray As T() = stack.ToArray()

        For Each node As T In stackArray
            i -= 1
            Console.WriteLine($"- Node[{i}] and data: " & node.ToString())
        Next
    End Sub

    Public Function Exist(data As T) As Boolean Implements ImethodLists(Of T).Exist
        ' Case 1: If the list is empty
        If IsEmpty() Then
            Return False
        End If

        ' Case 2: If the data already exists at the beginning
        If Head.CompareTo(data) = 0 Then
            Return True
        End If

        ' Case 3: Traverse the list
        Dim CurrentNode As Node(Of T) = Head
        While CurrentNode.Next IsNot Head AndAlso CurrentNode.CompareTo(data) < 0
            CurrentNode = CurrentNode.Next
        End While

        ' Case 4: If the data already exists at X position / or at the end
        If CurrentNode.CompareTo(data) = 0 Then
            Return True
        End If
        ' Case 5: The data does not exist in the list
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
