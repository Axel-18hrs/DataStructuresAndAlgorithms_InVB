Public Enum OptionLists
    Add = 1
    Delete = 2
    Search = 3
    Show = 4
    ShowRevers = 5
    Clear = 6
End Enum

Public Module OperationsList
    Private r As Random

    Sub New()
        r = New Random()
    End Sub

    Public Sub AddElements(elementsToAdd As IEnumerable(Of Object), list As ImethodLists(Of Object))
        For Each element In elementsToAdd
            list.Add(element)
        Next
    End Sub

    Public Iterator Function DataNumeric() As IEnumerable(Of Object)
        Console.Write("How many data do you want to add: ")
        Dim cant As Integer = Integer.Parse(Console.ReadLine())

        Console.Write("Enter the minimum value for selecting data (default is 0): ")
        Dim minonResult As Integer
        Dim minon As Integer = If(Integer.TryParse(Console.ReadLine(), minonResult), minonResult, 0)
        Console.WriteLine($"Selected value: {minon}")

        Console.Write("Enter the maximum value for selecting data (default is 100): ")
        Dim lengthResult As Integer
        Dim length As Integer = If(Integer.TryParse(Console.ReadLine(), lengthResult), lengthResult, 100)
        Console.WriteLine($"Selected value: {length}")

        If minon > length Then
            Console.WriteLine("Error: The minimum value cannot be greater than the maximum value. Using default values.")
            minon = 0
            length = 100
        End If

        If cant > length - minon + 1 Then
            Console.WriteLine("Error: The number of data requested exceeds the available range. Using the available range.")
            cant = length - minon + 1
        End If

        Dim data(cant - 1) As Integer
        For i As Integer = 0 To cant - 1
            If i < cant Then
                Dim newValue As Integer = r.Next(minon, length + 1)
                If data.Contains(newValue) Then
                    i -= 1
                    Continue For
                End If
                data(i) = newValue
            Else
                Exit For
            End If
        Next

        For i As Integer = 0 To cant - 1
            Yield data(i)
        Next
    End Function

    Public Sub AListOperation(Of T)(list As ImethodLists(Of Object))
        Dim listTypeMessage As String = If(TypeOf list Is SimpleList(Of T), "Simple", If(TypeOf list Is CircularList(Of T), "Circular", If(TypeOf list Is DoublyListLinked(Of T), "Doubly", "Doubly circle")))

        Do
            Console.Clear()
            Console.WriteLine($"{listTypeMessage} list {Environment.NewLine}1. Add value {Environment.NewLine}2. Delete value {Environment.NewLine}3. Search value {Environment.NewLine}4. Show list {Environment.NewLine}5. Show reverse {Environment.NewLine}6. Clear {Environment.NewLine}0. Exit {Environment.NewLine}")
            Dim opti As Integer
            If Not Integer.TryParse(Console.ReadLine(), opti) Then
                Deffault()
                Continue Do
            End If


            Select Case opti
                Case CType(OptionLists.Add, Integer)
                    Console.Clear()
                    Console.WriteLine($"Do you want to add data randomly? {Environment.NewLine}1. Yes {Environment.NewLine}2. No {Environment.NewLine}")
                    Dim optio_ As Integer
                    If Not Integer.TryParse(Console.ReadLine(), optio_) Then
                        Deffault()
                        Continue Do
                    End If

                    Select Case optio_
                        Case 1
                            AddElements(DataNumeric(), list)
                            Continue Do
                        Case 2
                            Console.WriteLine("Enter a value: ")
                            list.Add(Console.ReadLine())
                            Continue Do
                        Case Else
                            Deffault()
                            Continue Do
                    End Select

                Case CType(OptionLists.Delete, Integer)
                    Console.Clear()
                    Console.WriteLine($"Do you want to delete data randomly (only numbers)? {Environment.NewLine}1. Yes {Environment.NewLine}2. No {Environment.NewLine}")
                    Dim optio As Integer
                    If Not Integer.TryParse(Console.ReadLine(), optio) Then
                        Deffault()
                        Continue Do
                    End If

                    Select Case optio
                        Case 1
                            list.Delete(DataNumeric())
                            Continue Do
                        Case 2
                            Console.WriteLine("Enter a value to delete: ")
                            list.Delete(Console.ReadLine())
                            Continue Do
                        Case Else
                            Deffault()
                            Continue Do
                    End Select

                Case CType(OptionLists.Search, Integer)
                    Console.WriteLine("Enter a value to search: ")
                    list.Search(Console.ReadLine())
                    Continue Do

                Case CType(OptionLists.Show, Integer)
                    list.Show()
                    Exit Select

                Case CType(OptionLists.ShowRevers, Integer)
                    list.ShowRevers()
                    Exit Select

                Case CType(OptionLists.Clear, Integer)
                    list.Clear()
                    Continue Do

                Case 0
                    Return

                Case Else
                    Deffault()
                    Continue Do
            End Select
            Console.ReadKey()
        Loop While True
    End Sub

    Public Sub MenuList()
        Do
            Console.Clear()
            Console.WriteLine($"Types of lists: {Environment.NewLine}1. Simple {Environment.NewLine}2. Circular {Environment.NewLine}3. Doubly linked {Environment.NewLine}4. Circular Doubly linked {Environment.NewLine}0. Exit {Environment.NewLine}")

            Dim opt As Integer
            If Not Integer.TryParse(Console.ReadLine(), opt) Then
                Deffault()
                Continue Do
            End If

            Select Case opt
                Case 1
                    AListOperation(Of Object)(New SimpleList(Of Object)())
                    Exit Select

                Case 2
                    AListOperation(Of Object)(New CircularList(Of Object)())
                    Exit Select

                Case 3
                    AListOperation(Of Object)(New DoublyListLinked(Of Object)())
                    Exit Select

                Case 4
                    AListOperation(Of Object)(New CircularDoublyLinkedList(Of Object)())
                    Exit Select

                Case 0
                    Return

                Case Else
                    Deffault()
                    Continue Do
            End Select
        Loop While True
    End Sub

    Public Sub Deffault()
        Console.WriteLine("Invalid input. Please enter a valid number.")
        Console.ReadKey()
    End Sub
End Module
