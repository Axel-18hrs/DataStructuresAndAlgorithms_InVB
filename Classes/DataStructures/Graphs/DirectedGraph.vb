Public Class DirectedGraph(Of T)
    Implements ImethodGraphs(Of T)

    Private adjacencyList As New Dictionary(Of T, List(Of T))()

    Public Sub New()
    End Sub

    ' Add a vertex to the directed graph
    Public Sub AddVertex(vertex As T) Implements ImethodGraphs(Of T).AddVertex
        If Not adjacencyList.ContainsKey(vertex) Then
            adjacencyList(vertex) = New List(Of T)()
            Console.WriteLine($"Vertex {vertex} added to the graph.")
            Return
        End If

        Console.WriteLine($"Vertex {vertex} already exists in the graph.")
    End Sub

    ' Remove a vertex and all outgoing edges associated with it
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

    ' Add a directed edge from vertexStart to vertexEnd
    Public Sub AddEdge(vertexStart As T, vertexEnd As T) Implements ImethodGraphs(Of T).AddEdge
        If adjacencyList.ContainsKey(vertexStart) AndAlso adjacencyList.ContainsKey(vertexEnd) Then
            adjacencyList(vertexStart).Add(vertexEnd)
            Console.WriteLine($"Directed edge added from {vertexStart} to {vertexEnd}.")
            Return
        End If
        Console.WriteLine($"Vertices {vertexStart} or {vertexEnd} do not exist in the graph.")
    End Sub

    ' Remove a directed edge from vertexStart to vertexEnd
    Public Sub RemoveEdge(vertexStart As T, vertexEnd As T) Implements ImethodGraphs(Of T).RemoveEdge
        If adjacencyList.ContainsKey(vertexStart) AndAlso adjacencyList.ContainsKey(vertexEnd) Then
            adjacencyList(vertexStart).Remove(vertexEnd)
            Console.WriteLine($"Directed edge removed from {vertexStart} to {vertexEnd}.")
            Return
        End If
        Console.WriteLine($"Vertices {vertexStart} or {vertexEnd} do not exist in the graph.")
    End Sub

    ' Check the existence of a vertex in the directed graph
    Public Function VertexExists(vertex As T) As Boolean Implements ImethodGraphs(Of T).VertexExists
        Dim exists As Boolean = adjacencyList.ContainsKey(vertex)
        Console.WriteLine($"Vertex {vertex} exists in the graph: {exists}.")
        Return exists
    End Function

    ' Check the existence of a directed edge from vertexStart to vertexEnd
    Public Function EdgeExists(vertexStart As T, vertexEnd As T) As Boolean Implements ImethodGraphs(Of T).EdgeExists
        Dim exists As Boolean = adjacencyList.ContainsKey(vertexStart) AndAlso adjacencyList(vertexStart).Contains(vertexEnd)
        Console.WriteLine($"Directed edge from {vertexStart} to {vertexEnd} exists: {exists}.")
        Return exists
    End Function

    ' Get all vertices in the directed graph
    Public Function GetAllVertices() As List(Of T) Implements ImethodGraphs(Of T).GetAllVertices
        Dim vertices As New List(Of T)(adjacencyList.Keys)
        Console.WriteLine("All vertices in the graph: " + String.Join(", ", vertices))
        Return vertices
    End Function

    ' Get all directed edges in the graph
    Public Function GetAllEdges() As List(Of (T, T)) Implements ImethodGraphs(Of T).GetAllEdges
        Dim edges As New List(Of (T, T))()

        For Each vertex In adjacencyList.Keys
            For Each neighbor In adjacencyList(vertex)
                edges.Add((vertex, neighbor))
            Next
        Next

        Console.WriteLine("All directed edges in the graph: " + String.Join(", ", edges))
        Return edges
    End Function

    ' Traverse the directed graph using BFS
    Public Function TraverseBFS(startVertex As T) As List(Of T) Implements ImethodGraphs(Of T).TraverseBFS
        Dim visited As New List(Of T)()
        Dim queue As New Queue(Of T)()

        If Not adjacencyList.ContainsKey(startVertex) Then
            Console.WriteLine($"Vertex {startVertex} does not exist in the graph.")
            Return visited
        End If

        visited.Add(startVertex)
        queue.Enqueue(startVertex)

        While queue.Count > 0
            Dim currentVertex As T = queue.Dequeue()

            For Each neighbor In adjacencyList(currentVertex)
                If Not visited.Contains(neighbor) Then
                    visited.Add(neighbor)
                    queue.Enqueue(neighbor)
                End If
            Next
        End While

        Console.WriteLine("BFS traversal result: " + String.Join(", ", visited))
        Return visited
    End Function

    ' Calculate the out-degree of a vertex in the directed graph
    Public Function CalculateDegree(vertex As T) As Integer Implements ImethodGraphs(Of T).CalculateDegree
        Dim outDegree As Integer = If(adjacencyList.ContainsKey(vertex), adjacencyList(vertex).Count, -1)
        Console.WriteLine($"Out-degree of vertex {vertex}: {outDegree}.")
        Return outDegree
    End Function

    ' Calculate the breadth of the directed graph and the level at which a node is located
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

            For Each neighbor In adjacencyList(currentVertex)
                If Not levels.ContainsKey(neighbor) Then
                    levels(neighbor) = levels(currentVertex) + 1
                    queue.Enqueue(neighbor)
                End If
            Next
        End While

        Console.WriteLine("BFS levels: " + String.Join(", ", levels.Select(Function(pair) $"{pair.Key}:{pair.Value}")))
        Return levels
    End Function
End Class
