Public Class SimpleList(Of T)
    Implements ImethodLists(Of T)

    Private Shared Property Head As Node(Of T)
    Private Shared r As Random

    Public Sub New()
        Clear()
        r = New Random()
    End Sub

    Public Sub Add(data As T) Implements ImethodLists(Of T).Add
        ' Case 0: Create a new node
        Dim NewNode As New Node(Of T)(data)

        ' Case 1: Insert at the beginning
        If IsEmpty() Then
            Head = NewNode
            Return
        End If

        ' Case 2: Prevent duplicate data
        If Exist(NewNode.Data) Then
            Return
        End If

        ' Case 3: Insert the data at the beginning of the list
        If NewNode.CompareTo(Head) <= 0 Then
            NewNode.Next = Head
            Head = NewNode
            Return
        End If

        ' Case 4: Traverse the list
        Dim CurrentNode As Node(Of T) = Head
        While CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.CompareTo(NewNode) <= 0
            CurrentNode = CurrentNode.Next
        End While

        ' Case 5: Insert at X position or at the end of the list
        NewNode.Next = CurrentNode.Next
        CurrentNode.Next = NewNode
    End Sub

    Public Sub Delete(data As T) Implements ImethodLists(Of T).Delete
        ' Case 1: If the list is empty
        If IsEmpty() Then
            Console.WriteLine("Empty list.")
            Return
        End If

        ' Case 2: If the data is at the beginning
        If Head.CompareTo(data) = 0 Then
            Head = Head.Next
            Console.WriteLine($"- Data[{data}] deleted from the list")
            Return
        End If

        ' Case 3: Traverse the list
        Dim CurrentNode As Node(Of T) = Head
        While CurrentNode.Next IsNot Nothing AndAlso Not Equals(CurrentNode.Next.Data, data)
            CurrentNode = CurrentNode.Next
        End While

        ' Case 4: If the data is at X position
        If CurrentNode.Next IsNot Nothing AndAlso Equals(CurrentNode.Next.Data, data) Then
            CurrentNode.Next = CurrentNode.Next.Next
            Console.WriteLine($"- Data[{data}] deleted from the list")
            Return
        End If

        ' Case 5: The data was not found
        Console.WriteLine($"- Data[{data}] not found/deleted from the list")
    End Sub

    Public Sub Search(data As T) Implements ImethodLists(Of T).Search
        ' Case 1: If the list is empty
        If IsEmpty() Then
            Console.WriteLine("Empty list.")
            Return
        End If

        ' Case 2: If the data is at the beginning
        If Head.CompareTo(data) = 0 Then
            Console.WriteLine($"- Data[{data}] exists in the list")
            Return
        End If

        ' Case 3: Traverse the list
        Dim CurrentNode As Node(Of T) = Head
        While CurrentNode.Next IsNot Nothing AndAlso CurrentNode.Next.CompareTo(data) <= 0
            CurrentNode = CurrentNode.Next
        End While

        ' Case 4: If the data is at X position
        If CurrentNode.CompareTo(data) = 0 Then
            Console.WriteLine($"- Data[{data}] exists in the list")
            Return
        End If

        ' Case 5: The data does not exist
        Console.WriteLine($"- Data[{data}] does not exist in the list ")
    End Sub

    Public Sub Show() Implements ImethodLists(Of T).Show
        ' Case 1: If the list is empty
        If IsEmpty() Then
            Console.WriteLine("Empty list.")
            Return
        End If

        ' Case 2: Traverse the list
        Dim i As Integer = 0
        Dim CurrentNode As Node(Of T) = Head
        Console.WriteLine("=== My simple list ===")
        While CurrentNode IsNot Nothing
            Console.WriteLine($"- Node[{i}] and data: " & CurrentNode.Data.ToString())
            CurrentNode = CurrentNode.Next
            i += 1
        End While
    End Sub

    Public Sub ShowRevers() Implements ImethodLists(Of T).ShowRevers
        ' Case 1: If the list is empty
        If IsEmpty() Then
            Console.WriteLine("Empty list.")
            Return
        End If

        Dim stack As New Stack(Of T)()
        Dim CurrentNode As Node(Of T) = Head
        Dim i As Integer = 0
        While CurrentNode IsNot Nothing
            i += 1
            stack.Push(CurrentNode.Data)
            CurrentNode = CurrentNode.Next
        End While

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

        ' Case 2: If the first node contains the data
        If Head.CompareTo(data) = 0 Then
            Return True
        End If

        ' Case 3: Start traversing the list
        Dim CurrentNode As Node(Of T) = Head
        While CurrentNode.Next IsNot Nothing AndAlso CurrentNode.CompareTo(data) < 0
            CurrentNode = CurrentNode.Next
        End While

        ' Case 4: The data exists in the last element
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
    End Sub
End Class
