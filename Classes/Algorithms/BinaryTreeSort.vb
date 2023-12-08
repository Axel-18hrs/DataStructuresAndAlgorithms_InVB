Friend Class BinaryTreeNode
    Public Value As Integer
    Public Left, Right As BinaryTreeNode

    Public Sub New(value As Integer)
        Me.Value = value
        Left = Nothing
        Right = Nothing
    End Sub
End Class

Friend Class BinaryTreeSort
    Implements ImethodAlgorithms

    Private root As BinaryTreeNode

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        ' Construir el árbol binario
        For Each value In arr
            root = Insert(root, value)
        Next

        ' Recorrer el árbol en orden para obtener los elementos ordenados
        Dim index As Integer = 0
        InOrderTraversal(root, arr, index)
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        ' Implementación para arrays de tipo double (pendiente)
    End Sub

    Private Function Insert(node As BinaryTreeNode, value As Integer) As BinaryTreeNode
        If node Is Nothing Then
            Return New BinaryTreeNode(value)
        End If

        If value < node.Value Then
            node.Left = Insert(node.Left, value)
        ElseIf value > node.Value Then
            node.Right = Insert(node.Right, value)
        End If

        Return node
    End Function

    Private Sub InOrderTraversal(node As BinaryTreeNode, arr As Integer(), ByRef index As Integer)
        If node IsNot Nothing Then
            InOrderTraversal(node.Left, arr, index)
            arr(index) = node.Value
            index += 1
            InOrderTraversal(node.Right, arr, index)
        End If
    End Sub
End Class
