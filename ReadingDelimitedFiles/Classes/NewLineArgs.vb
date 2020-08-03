Namespace Classes
    Public Class NewLineArgs
        Inherits EventArgs

        Public Sub New(personDataArray As String(), currentLineIndex As Integer)

            PersonArray = personDataArray
            CurrentIndex = currentLineIndex

        End Sub
        Public ReadOnly Property PersonArray() As String()
        Public ReadOnly Property CurrentIndex() As Integer

    End Class
End Namespace