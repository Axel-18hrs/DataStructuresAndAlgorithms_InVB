Friend Class BinaryTreeNode
    Public Value As Integer
    Public Left, Right As BinaryTreeNode

    Public Sub New(value As Integer)
        Me.Value = value
        Left = Nothing
        Right = Nothing
    End Sub
End Class

Public Class BinaryTreeSort
    Implements ImethodAlgorithms
    Private root As BinaryTreeNode
    Private swaps As Integer = 0
    Private recursions As Integer = 0

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        For Each value In arr
            root = Insert(root, value)
        Next
        Dim index As Integer = 0
        InOrderTraversal(root, arr, index)
        Console.WriteLine($"Number of swaps: {swaps}")
        Console.WriteLine($"Number of recursions: {recursions}")
    End Sub

    Private Function Insert(node As BinaryTreeNode, value As Integer) As BinaryTreeNode
        If node Is Nothing Then
            Return New BinaryTreeNode(value)
        End If

        If value < node.Value Then
            swaps += 1 ' Incrementa el número de intercambios
            node.Left = Insert(node.Left, value)
        ElseIf value > node.Value Then
            swaps += 1 ' Incrementa el número de intercambios
            node.Right = Insert(node.Right, value)
        End If

        Return node
    End Function

    Private Sub InOrderTraversal(node As BinaryTreeNode, arr As Integer(), ByRef index As Integer)
        recursions += 1 ' Incrementa el número de recursiones
        If node IsNot Nothing Then
            InOrderTraversal(node.Left, arr, index)
            arr(index) = node.Value
            index += 1
            PrintTree(node)
            InOrderTraversal(node.Right, arr, index)
        End If
    End Sub

    Private Sub PrintTree(node As BinaryTreeNode, Optional indent As String = "", Optional last As Boolean = True)
        If node IsNot Nothing Then
            Console.WriteLine($"{indent}|- {node.Value}")
            indent += If(last, "   ", "|  ")
            PrintTree(node.Left, indent, False)
            PrintTree(node.Right, indent, True)
        End If
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementación para ordenar un array de doubles
    End Sub
End Class
