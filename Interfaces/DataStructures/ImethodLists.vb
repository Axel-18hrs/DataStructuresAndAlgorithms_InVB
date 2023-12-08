Public Interface ImethodLists(Of T)
    Sub Add(data As T)
    Sub Delete(data As T)
    Sub Search(data As T)
    Function Exist(data As T) As Boolean
    Sub Show()
    Sub ShowRevers()
    Function IsEmpty() As Boolean
    Sub Clear()
End Interface
