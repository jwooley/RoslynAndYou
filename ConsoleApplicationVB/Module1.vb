Module Module1

    Sub Main()

        Dim MultiLineString = "Hello
World"                                  ' Multi Line String

        Dim nums = From num In Enumerable.Range(1, 10)
                   Where num Mod 2 = 0      ' Comments used to break the next line
                   Select num

    End Sub

End Module

Structure S
    Sub New()       ' Structure Constructor

    End Sub
End Structure