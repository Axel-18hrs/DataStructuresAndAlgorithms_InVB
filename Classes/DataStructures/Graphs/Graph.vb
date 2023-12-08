Public Class Graph(Of T)
    Implements ImethodGraphs(Of T)

    Private adjacencyList As New Dictionary(Of T, List(Of T))()

    Public Sub New()
    End Sub

    ' Add a vertex to the graph
    Public Sub AddVertex(vertex As T) Implements ImethodGraphs(Of T).AddVertex
        If Not adjacencyList.ContainsKey(vertex) Then
            adjacencyList(vertex) = New List(Of T)()
            Console.WriteLine($"Vertex {vertex} added to the graph.")
            Return
        End If

        Console.WriteLine($"Vertex {vertex} already exists in the graph.")
    End Sub

    ' Remove a vertex and all associated edges
    Public Sub RemoveVertex(vertex As T) Implements ImethodGraphs(Of T).RemoveVertex
        If adjacencyList.ContainsKey(vertex) Then
            adjacencyList.Remove(vertex)
            Console.WriteLine($"Vertex {vertex} removed from the graph.")

            For Each otherVertex In adjacencyList.Keys
                adjacencyList(otherVertex).Remove(vertex)
            Next
            Return
        End If

        Console.WriteLine($"Vertex {vertex} does not exist in the graph.")
    End Sub

    ' Add an edge between two existing vertices
    Public Sub AddEdge(vertexStart As T, vertexEnd As T) Implements ImethodGraphs(Of T).AddEdge
        If adjacencyList.ContainsKey(vertexStart) AndAlso adjacencyList.ContainsKey(vertexEnd) Then
            adjacencyList(vertexStart).Add(vertexEnd)
            adjacencyList(vertexEnd).Add(vertexStart) ' If the graph is undirected
            Console.WriteLine($"Edge added between {vertexStart} and {vertexEnd}.")
            Return
        End If
        Console.WriteLine($"Vertices {vertexStart} or {vertexEnd} do not exist in the graph.")
    End Sub

    ' Remove an edge between two existing vertices
    Public Sub RemoveEdge(vertexStart As T, vertexEnd As T) Implements ImethodGraphs(Of T).RemoveEdge
        If adjacencyList.ContainsKey(vertexStart) AndAlso adjacencyList.ContainsKey(vertexEnd) Then
            adjacencyList(vertexStart).Remove(vertexEnd)
            adjacencyList(vertexEnd).Remove(vertexStart) ' If the graph is undirected
            Console.WriteLine($"Edge removed between {vertexStart} and {vertexEnd}.")
            Return
        End If
        Console.WriteLine($"Vertices {vertexStart} or {vertexEnd} do not exist in the graph.")
    End Sub

    ' Check the existence of a vertex
    Public Function VertexExists(vertex As T) As Boolean Implements ImethodGraphs(Of T).VertexExists
        Dim exists As Boolean = adjacencyList.ContainsKey(vertex)
        Console.WriteLine($"Vertex {vertex} exists in the graph: {exists}.")
        Return exists
    End Function

    ' Check the existence of an edge
    Public Function EdgeExists(vertexStart As T, vertexEnd As T) As Boolean Implements ImethodGraphs(Of T).EdgeExists
        Dim exists As Boolean = adjacencyList.ContainsKey(vertexStart) AndAlso adjacencyList(vertexStart).Contains(vertexEnd)
        Console.WriteLine($"Edge between {vertexStart} and {vertexEnd} exists: {exists}.")
        Return exists
    End Function

    ' Get all vertices
    Public Function GetAllVertices() As List(Of T) Implements ImethodGraphs(Of T).GetAllVertices
        Dim vertices As New List(Of T)(adjacencyList.Keys)
        Console.WriteLine("All vertices in the graph: " + String.Join(", ", vertices))
        Return vertices
    End Function

    ' Get all edges
    Public Function GetAllEdges() As List(Of (T, T)) Implements ImethodGraphs(Of T).GetAllEdges
        Dim edges As New List(Of (T, T))()

        For Each vertex In adjacencyList.Keys
            For Each neighbor In adjacencyList(vertex)
                edges.Add((vertex, neighbor))
            Next
        Next

        Console.WriteLine("All edges in the graph: " + String.Join(", ", edges))
        Return edges
    End Function

    ' Traverse the graph using BFS
    Public Function TraverseBFS(startVertex As T) As List(Of T) Implements ImethodGraphs(Of T).TraverseBFS
        Dim visited As New List(Of T)()
        Dim queue As New Queue(Of T)()

        ' Check if startVertex is in adjacencyList
        If Not adjacencyList.ContainsKey(startVertex) Then
            Console.WriteLine($"Vertex {startVertex} does not exist in the graph.")
            Return visited
        End If

        visited.Add(startVertex)
        queue.Enqueue(startVertex)

        While queue.Count > 0
            Dim currentVertex As T = queue.Dequeue()

            ' Check if currentVertex is in adjacencyList
            If adjacencyList.ContainsKey(currentVertex) Then
                For Each neighbor In adjacencyList(currentVertex)
                    If Not visited.Contains(neighbor) Then
                        visited.Add(neighbor)
                        queue.Enqueue(neighbor)
                    End If
                Next
            End If
        End While

        Console.WriteLine("BFS traversal result: " + String.Join(", ", visited))
        Return visited
    End Function

    ' Calculate the degree of a vertex
    Public Function CalculateDegree(vertex As T) As Integer Implements ImethodGraphs(Of T).CalculateDegree
        Dim degree As Integer = If(adjacencyList.ContainsKey(vertex), adjacencyList(vertex).Count, -1)
        Console.WriteLine($"Degree of vertex {vertex}: {degree}.")
        Return degree
    End Function

    ' Calculate the breadth of the graph and the level of a node
    Public Function CalculateBFSLevels(startVertex As T) As Dictionary(Of T, Integer) Implements ImethodGraphs(Of T).CalculateBFSLevels
        Dim levels As New Dictionary(Of T, Integer)()
        Dim queue As New Queue(Of T)()

        If Not adjacencyList.ContainsKey(startVertex) Then
            Console.WriteLine($"Vertex {startVertex} does not exist in the graph.")
            Return levels
        End If

        levels(startVertex) = 0
        queue.Enqueue(startVertex)

        While queue.Count > 0
            Dim currentVertex As T = queue.Dequeue()

            ' Verificar si currentVertex está en adjacencyList
            If adjacencyList.ContainsKey(currentVertex) Then
                For Each neighbor In adjacencyList(currentVertex)
                    If Not levels.ContainsKey(neighbor) Then
                        levels(neighbor) = levels(currentVertex) + 1
                        queue.Enqueue(neighbor)
                    End If
                Next
            End If
        End While

        Console.WriteLine("BFS levels: " + String.Join(", ", levels.Select(Function(pair) $"{pair.Key}:{pair.Value}")))
        Return levels
    End Function
End Class
