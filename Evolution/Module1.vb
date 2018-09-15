Imports System.Text
Module Module1

    Private rand = New Random
    Public ReadOnly Alphabet = "abcdefghijklmnopqrstuvwxyz "
    Public ReadOnly Target = "lientje leerde lotje lopen langs de lange lindenlaan" REM methinks it is a weasel"
    Public ReadOnly GenSize = 100

    Sub Main()
        Dim child = CreateRandomString(Target.Length)
        Dim count = 1
        Do While (child <> Target)
            child = Generation(child)
            Console.WriteLine("{0,2} {1}", count, child)
            count += 1
        Loop

        Console.ReadLine()

    End Sub

    Private Function CreateRandomString(length As Integer) As String
        Dim sb As New StringBuilder(length)
        For idx = 0 To length - 1
            sb.Append(Alphabet(rand.Next(0, Alphabet.length)))
        Next
        Return sb.ToString
    End Function

    Private Function Generation(parent As String)
        Dim bestDist = Distance(parent)
        Dim result = parent
        For idx = 1 To GenSize
            Dim child = Mutate(parent)
            Dim dist = Distance(child)
            If (dist < bestDist) Then
                result = child
                bestDist = dist
            End If
        Next
        Return result
    End Function

    Private Function Mutate(s As String) As String
        Dim sb As New StringBuilder(s)
        For idx = 0 To 1
            Dim randPos = rand.Next(0, s.Length)
            Dim randChar = Alphabet(rand.Next(0, Alphabet.Length))
            sb(randPos) = randChar
        Next
        Return sb.ToString
    End Function

    Private Function Distance(s As String) As Integer
        Dim count = 0
        For idx = 0 To s.Length - 1
            If (s(idx) <> Target(idx)) Then
                count += 1
            End If
        Next
        Return count
    End Function

End Module

