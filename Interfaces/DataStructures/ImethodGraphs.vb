Public Interface ImethodGraphs(Of T)
    Sub AddVertex(vertex As T)
    Sub RemoveVertex(vertex As T)
    Sub AddEdge(vertexStart As T, vertexEnd As T)
    Sub RemoveEdge(vertexStart As T, vertexEnd As T)
    Function VertexExists(vertex As T) As Boolean
    Function EdgeExists(vertexStart As T, vertexEnd As T) As Boolean
    Function GetAllVertices() As List(Of T)
    Function GetAllEdges() As List(Of (T, T))
    Function TraverseBFS(startVertex As T) As List(Of T)
    Function CalculateDegree(vertex As T) As Integer
    Function CalculateBFSLevels(startVertex As T) As Dictionary(Of T, Integer)
End Interface