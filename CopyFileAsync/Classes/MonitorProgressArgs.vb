Namespace Classes
    Public Class MonitorProgressArgs
        Inherits EventArgs

        Public Sub New(amount As Integer)

            Current = amount

        End Sub

        Public ReadOnly Property Current() As Integer

    End Class
End Namespace