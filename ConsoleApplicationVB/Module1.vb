Imports System.Console

Module Module1


    Sub Main()

        Dim MultiLineString = "Hello
World"                                  ' Multi Line String

        Dim nums = From num In Enumerable.Range(1, 10)
                   Where num Mod 2 = 0      ' Comments used to break the next line
                   Select num

        Dim FirstName = "Jim"
        Dim LastName = "Wooley"

        WriteLine($"{FirstName} {LastName}")    'Interpolated string
    End Sub

End Module

' For full list of new features see https://github.com/dotnet/roslyn/wiki/Languages-features-in-C%23-6-and-VB-14
