Public Class DoubleNode(Of T)
    Implements IComparable(Of DoubleNode(Of T))

    Public Property Back As DoubleNode(Of T)
    Public Property Next_ As DoubleNode(Of T)
    Public Property Data As T

    Public Sub New(data As T)
        Me.Data = data
        Next_ = Nothing
        Back = Nothing
    End Sub

    Public Function CompareTo(otroData As DoubleNode(Of T)) As Integer Implements IComparable(Of DoubleNode(Of T)).CompareTo
        ' Caso 1: Ambos tipos son numéricos
        If EsNumero(Data) AndAlso EsNumero(otroData.Data) Then
            Dim valor1 As Long = Convert.ToInt64(Data)
            Dim valor2 As Long = Convert.ToInt64(otroData.Data)
            Return valor1.CompareTo(valor2)
        End If

        ' Caso 2: Solo el dato del nodo que está comparando es numérico
        If EsNumero(Data) AndAlso TypeOf otroData.Data Is String OrElse TypeOf otroData.Data Is Char Then
            Dim valor1 As Long = Convert.ToInt64(Data)
            Dim valor2 As Long = Convert.ToInt64(otroData.Data.ToString().Length)
            Return valor1.CompareTo(valor2)
        End If

        ' Caso 3: Solo el dato del nodo a comparar es numérico
        If EsNumero(otroData.Data) AndAlso (TypeOf Data Is String OrElse TypeOf Data Is Char) Then
            Dim valor1 As Long = Convert.ToInt64(Data.ToString().Length)
            Dim valor2 As Long = Convert.ToInt64(otroData.Data)
            Return valor1.CompareTo(valor2)
        End If

        ' Caso 4: Son diferentes tipos que se pueden comparar
        If TypeOf Data Is IComparable AndAlso TypeOf otroData.Data Is IComparable Then
            Return DirectCast(Data, IComparable).ToString().Length.CompareTo(DirectCast(otroData.Data, IComparable).ToString().Length)
        End If

        Return 0
    End Function

    Public Function CompareTo(otroData As T) As Integer
        ' Caso 1: Ambos tipos son numéricos
        If EsNumero(Data) AndAlso EsNumero(otroData) Then
            Dim valor1 As Long = Convert.ToInt64(Data)
            Dim valor2 As Long = Convert.ToInt64(otroData)
            Return valor1.CompareTo(valor2)
        End If

        ' Caso 2: Solo el dato del nodo que está comparando es numérico
        If EsNumero(Data) AndAlso (TypeOf otroData Is String OrElse TypeOf otroData Is Char) Then
            Dim valor1 As Long = Convert.ToInt64(Data)
            Dim valor2 As Long = Convert.ToInt64(otroData.ToString().Length)
            Return valor1.CompareTo(valor2)
        End If

        ' Caso 3: Solo el dato del nodo a comparar es numérico
        If EsNumero(otroData) AndAlso (TypeOf Data Is String OrElse TypeOf Data Is Char) Then
            Dim valor1 As Long = Convert.ToInt64(Data.ToString().Length)
            Dim valor2 As Long = Convert.ToInt64(otroData)
            Return valor1.CompareTo(valor2)
        End If

        ' Caso 4: Son diferentes tipos que se pueden comparar
        If TypeOf Data Is IComparable AndAlso TypeOf otroData Is IComparable Then
            Return DirectCast(Data, IComparable).ToString().Length.CompareTo(DirectCast(otroData, IComparable).ToString().Length)
        End If

        Return 0
    End Function

    Private Function EsNumero(value As Object) As Boolean
        Return TypeOf value Is SByte OrElse
               TypeOf value Is Byte OrElse
               TypeOf value Is Short OrElse
               TypeOf value Is UShort OrElse
               TypeOf value Is Integer OrElse
               TypeOf value Is UInteger OrElse
               TypeOf value Is Long OrElse
               TypeOf value Is ULong OrElse
               TypeOf value Is Single OrElse
               TypeOf value Is Double OrElse
               TypeOf value Is Decimal
    End Function
End Class

