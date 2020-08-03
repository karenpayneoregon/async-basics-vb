Namespace Classes
    Public Class Operations
        Public Event OnMonitor As DelegatesModule.MonitorHandler
        ''' <summary>
        ''' Do nothing method to show how to cancel a Task via
        ''' CancellationTokenSource
        ''' </summary>
        ''' <param name="value">int value greater than 0</param>
        ''' <param name="token">Initialized cancellation token</param>
        ''' <returns></returns>
        Public Async Function Run(value As Integer, token As Threading.CancellationToken) As Task(Of Integer)

            Dim currentIndex = 0

            Do While currentIndex <= value - 1

                OnMonitorEvent?.Invoke(New MonitorArgs(Nothing, currentIndex))

                currentIndex += 1

                Await Task.Delay(1, token)

                If token.IsCancellationRequested Then
                    token.ThrowIfCancellationRequested()
                End If
            Loop

            OnMonitorEvent?.Invoke(New MonitorArgs("Done", currentIndex))

            Return currentIndex

        End Function
    End Class
End NameSpace