'*******************************************************************************************'
'                                                                                           '
' Download Free Evaluation Version From:     https://bytescout.com/download/web-installer   '
'                                                                                           '
' Also available as Web API! Get free API Key https://app.pdf.co/signup                     '
'                                                                                           '
' Copyright © 2017-2020 ByteScout, Inc. All rights reserved.                                '
' https://www.bytescout.com                                                                 '
' https://www.pdf.co                                                                        '
'*******************************************************************************************'


Imports Bytescout.PDFExtractor

Class Program

    Friend Shared Sub Main(args As String())

        Dim extractor As TextExtractor = New TextExtractor("demo", "demo")

        ' Load the document
        extractor.LoadDocumentFromFile("sample2.pdf")

        ' Smart match the search string like Adobe Reader
        extractor.WordMatchingMode = WordMatchingMode.SmartMatch

        Dim searchString As String = "land"

        ' Get page count
        Dim pageCount As Integer = extractor.GetPageCount()

        ' Iterate through pages
        For i As Integer = 0 To pageCount - 1

            ' Search through page
            If extractor.Find(i, searchString, False) Then

                Do
                    ' Output search results
                    Console.WriteLine("Found on page " + i.ToString() + " at location " + extractor.FoundText.Bounds.ToString())

                    ' Now we are getting the found text
                    Dim extractedString As String = extractor.FoundText.Text
                    Console.WriteLine("Found text: " + extractedString)

                Loop While extractor.FindNext() ' Search next occurrence of the search string

            End If

        Next

        ' Cleanup
		extractor.Dispose()


        Console.WriteLine()
        Console.WriteLine("Press any key to exit...")
        Console.ReadKey()

    End Sub

End Class
