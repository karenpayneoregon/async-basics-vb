Namespace Classes
    Public Class MonitorArgs
        Inherits EventArgs
        ''' <summary>
        ''' Create an new instance of this class
        ''' </summary>
        ''' <param name="message">Message to display when finished operation</param>
        ''' <param name="percentCompleted">Percentage done</param>
        Public Sub New(message As String, percentCompleted As Integer)

            Me.Message = message
            Me.PercentDone = percentCompleted

        End Sub
        ''' <summary>
        ''' Text for operation completed
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Message() As String

        ''' <summary>
        ''' Current progress of operation
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property PercentDone() As Integer

    End Class
End Namespace