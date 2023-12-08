Friend Class BucketSort
    Implements ImethodAlgorithms

    Public Sub New()
    End Sub

    Public Sub Sort(arr As Integer()) Implements ImethodAlgorithms.Sort
        ' Implementation for integer arrays (pending)
    End Sub

    Public Sub Sort(arr As Double()) Implements ImethodAlgorithms.Sort
        BucketSort_Double(arr)
    End Sub

    Private Shared Sub PrintBucketState(buckets As List(Of Double)())
        Console.WriteLine("Current state of buckets:")
        For i As Integer = 0 To buckets.Length - 1
            Console.Write($"Bucket {i}: ")
            For Each item In buckets(i)
                Console.Write($"{item} ")
            Next
            Console.WriteLine()
        Next
        Console.WriteLine()
    End Sub

    Private Shared Function BucketSort_Double(array As Double()) As Double()
        ' Create empty buckets
        Dim buckets(array.Length - 1) As List(Of Double)
        For i As Integer = 0 To buckets.Length - 1
            buckets(i) = New List(Of Double)()
        Next

        ' Insert elements into their respective buckets
        For Each element In array
            buckets(CInt(element * array.Length)).Add(element)
        Next

        ' Print the state of buckets after insertion
        PrintBucketState(buckets)

        ' Sort the elements of each bucket
        For i As Integer = 0 To array.Length - 1
            buckets(i).Sort()
        Next

        ' Print the state of buckets after sorting
        PrintBucketState(buckets)

        ' Get the sorted elements
        Dim k As Integer = 0
        For i As Integer = 0 To array.Length - 1
            For Each item In buckets(i)
                array(k) = item
                k += 1
            Next
        Next

        Return array
    End Function
End Class
