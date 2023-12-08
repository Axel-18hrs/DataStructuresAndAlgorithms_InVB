Friend Class OperationsGraph
    Public Shared Sub AllOperationGraph(Of T)(graph As ImethodGraphs(Of T))
        Dim graphMessage As String = If(TypeOf graph Is Graph(Of T), "Graph", "Directed graph")

        Do
            Console.Clear()
            Console.WriteLine($"{graphMessage} Menu: {vbCrLf}" & $"1. Add Vertex{vbCrLf}" & $"2. Remove Vertex{vbCrLf}")
            Console.WriteLine($"3. Add Edge{vbCrLf}" & $"4. Remove Edge{vbCrLf}" & $"5. Check Vertex Existence{vbCrLf}")
            Console.WriteLine($"6. Check Edge Existence{vbCrLf}" & $"7. Get All Vertices{vbCrLf}" & $"8. Get All Edges{vbCrLf}")
            Console.WriteLine($"9. Traverse BFS{vbCrLf}" & $"10. Calculate Vertex Degree{vbCrLf}" & $"11. Calculate BFS Levels{vbCrLf}" & $"0. Exit{vbCrLf}")

            Dim choice As Integer
            If Not Integer.TryParse(Console.ReadLine(), choice) Then
                OperationsList.Deffault()
                Continue Do
            End If

            Select Case choice
                Case 1
                    Console.Write("Enter vertex value: ")
                    graph.AddVertex(DirectCast(Convert.ChangeType(Console.ReadLine(), GetType(T)), T))
                    Console.WriteLine("Vertex added successfully.")
                Case 2
                    Console.Write("Enter vertex value to remove: ")
                    graph.RemoveVertex(DirectCast(Convert.ChangeType(Console.ReadLine(), GetType(T)), T))
                Case 3
                    Console.Write("Enter starting vertex: ")
                    Dim vertexStart_1 As T = DirectCast(Convert.ChangeType(Console.ReadLine(), GetType(T)), T)
                    Console.Write("Enter ending vertex: ")
                    Dim vertexEnd_1 As T = DirectCast(Convert.ChangeType(Console.ReadLine(), GetType(T)), T)
                    graph.AddEdge(vertexStart_1, vertexEnd_1)
                    Console.WriteLine("Edge added successfully.")
                Case 4
                    Console.Write("Enter starting vertex: ")
                    Dim vertexStart_2 As T = DirectCast(Convert.ChangeType(Console.ReadLine(), GetType(T)), T)
                    Console.Write("Enter ending vertex: ")
                    Dim vertexEnd_3 As T = DirectCast(Convert.ChangeType(Console.ReadLine(), GetType(T)), T)
                    graph.RemoveEdge(vertexStart_2, vertexEnd_3)
                Case 5
                    Console.Write("Enter vertex to check existence: ")
                    graph.VertexExists(DirectCast(Convert.ChangeType(Console.ReadLine(), GetType(T)), T))
                Case 6
                    Console.Write("Enter starting vertex: ")
                    Dim vertexStart As T = DirectCast(Convert.ChangeType(Console.ReadLine(), GetType(T)), T)
                    Console.Write("Enter ending vertex: ")
                    Dim vertexEnd As T = DirectCast(Convert.ChangeType(Console.ReadLine(), GetType(T)), T)
                    graph.EdgeExists(vertexStart, vertexEnd)
                Case 7
                    graph.GetAllVertices()
                Case 8
                    graph.GetAllEdges()
                Case 9
                    Console.Write("Enter starting vertex for BFS traversal: ")
                    graph.TraverseBFS(DirectCast(Convert.ChangeType(Console.ReadLine(), GetType(T)), T))
                Case 10
                    Console.Write("Enter vertex to calculate degree: ")
                    graph.CalculateDegree(DirectCast(Convert.ChangeType(Console.ReadLine(), GetType(T)), T))
                Case 11
                    Console.Write("Enter starting vertex for BFS levels: ")
                    graph.CalculateBFSLevels(DirectCast(Convert.ChangeType(Console.ReadLine(), GetType(T)), T))
                Case 0
                    Return
                Case Else
                    OperationsList.Deffault()
            End Select

            Console.ReadKey()
        Loop While True
    End Sub

    Public Shared Sub MenuGraphs()
        Do
            Console.Clear()
            Console.WriteLine($"Types of graphs: {vbCrLf}" & $"1. Graph{vbCrLf}" & $"2. Directed graph{vbCrLf}" & $"3. Exit{vbCrLf}")

            Dim opt As Integer
            If Not Integer.TryParse(Console.ReadLine(), opt) Then
                OperationsList.Deffault()
                Continue Do
            End If

            Select Case opt
                Case 1
                    AllOperationGraph(New Graph(Of Object)())
                Case 2
                    AllOperationGraph(New DirectedGraph(Of Object)())
                Case 3
                    Return
                Case Else
                    OperationsList.Deffault()
            End Select
        Loop While True
    End Sub
End Class
