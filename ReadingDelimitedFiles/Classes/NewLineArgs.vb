Namespace Classes
    Public Class NewLineArgs
        Inherits EventArgs

        Public Sub New(personDataArray As String(), currentLineIndex As Integer)

            PersonArray = personDataArray
            CurrentIndex = currentLineIndex

        End Sub
        ''' <summary>
        ''' Simple string array for values which make up a <see cref="Person"/> object
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property PersonArray() As String()
        ''' <summary>
        ''' Current line index in file being read
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property CurrentIndex() As Integer

    End Class
End Namespace