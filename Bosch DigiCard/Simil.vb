'http://accessmvp.com/TomVanStiphout/Simil.htm
Public Class Simil
    Private Structure structSubString
        Public o1 As Integer
        Public o2 As Integer
        Public len As Integer
    End Structure

    Public Shared Function Simil(ByVal s1 As String, ByVal s2 As String) As Double
        Dim returnValue As Double = 0.0
        Dim tlen As Integer                      'sum of lengths of the two strings.
        Dim s1len As Integer = s1.Length
        Dim s2len As Integer = s2.Length

        If s1len = 0 OrElse s2len = 0 Then
            returnValue = 0.0
        Else
            Dim tcnt As Integer = 0
            tlen = s1len + s2len
            rsimil(s1, s1len, s2, s2len, tcnt)
            returnValue = tcnt / tlen
        End If
        Return returnValue
    End Function

    Private Shared Sub rsimil(ByVal s1 As String, ByVal s1len As Integer, ByVal s2 As String, ByVal s2len As Integer, ByRef tcnt As Integer)
        Dim ss As structSubString

        If s1len = 0 OrElse s2len = 0 Then Exit Sub

        find_biggest_substring(s1, s1len, s2, s2len, ss)
        If ss.len <> 0 Then
            tcnt += (ss.len * 2)

            'Check left half...
            rsimil(s1, ss.o1, s2, ss.o2, tcnt)

            'Check right half...
            Dim delta1 As Integer = ss.o1 + ss.len
            Dim delta2 As Integer = ss.o2 + ss.len
            If delta1 < s1len AndAlso delta2 < s2len Then
                rsimil(s1.Substring(delta1), s1len - delta1, s2.Substring(delta2), s2len - delta2, tcnt)
            End If
        End If
    End Sub

    Private Shared Sub find_biggest_substring(ByVal s1 As String, ByVal s1len As Integer, ByVal s2 As String, ByVal s2len As Integer, ByRef ss As structSubString)
        Dim i As Integer
        Dim j As Integer
        Dim size As Integer = 1

        ss.o2 = -1
        i = 0
        While i <= (s1len - size)
            j = 0
            While j <= (s2len - size)
                Dim test_size As Integer = size
                While (1)
                    If ((test_size <= (s1len - i)) AndAlso (test_size <= (s2len - j))) Then
                        'While things match, keep trying...
                        'Note: String.Equals performs an ordinal (case-sensitive and culture-insensitive) comparison. 
                        If s1.Substring(i, test_size).Equals(s2.Substring(j, test_size)) Then
                            If ((test_size > size) OrElse (ss.o2 < 0)) Then
                                ss.o1 = i
                                ss.o2 = j
                                size = test_size
                            End If
                            test_size += 1
                        Else
                            'Not equal
                            Exit While
                        End If
                    Else
                        'Gone past the end of a string - we're done.
                        Exit While
                    End If
                End While

                j += 1
            End While
            i += 1
        End While
        If ss.o2 < 0 Then
            ss.len = 0
        Else
            ss.len = size
        End If
    End Sub
End Class