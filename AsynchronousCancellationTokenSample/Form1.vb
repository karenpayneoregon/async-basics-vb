Imports System.Threading
Imports AsynchronousCancellationTokenSample.Classes

Public Class Form1

    Private _totalIterations As Integer = 500
    Private _cancellationTokenSource As New CancellationTokenSource()

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        progressBar1.Maximum = _totalIterations
    End Sub
    ''' <summary>
    ''' Start a do nothing process, pass the CancellationTokenSource Token
    ''' to the operation which permits the method Run to recognize cancellation
    ''' when invoking _cancellationTokenSource.Cancel() in the Cancel button.
    '''
    ''' Note the do nothing operation runs asynchronously which means the user
    ''' interface remains responsive.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub RunButton_Click(sender As Object, e As EventArgs) Handles RunButton.Click

        RunButton.Enabled = False

        If _cancellationTokenSource.IsCancellationRequested Then
            _cancellationTokenSource.Dispose()
            _cancellationTokenSource = New CancellationTokenSource()
        End If

        Dim ops = New Operations()

        '
        ' Subscribe to OnMonitor which uses a custom EventArg to return
        ' text when the operation is done and percent done during the
        ' operation
        '
        AddHandler ops.OnMonitor, AddressOf MonitorDoNothingOperation

        Try

            Dim resultValue = Await ops.Run(_totalIterations, _cancellationTokenSource.Token)

        Catch oce As OperationCanceledException
            '
            ' Land here from token.ThrowIfCancellationRequested()
            ' thrown in Run method from a cancel request in this
            ' form's Cancel button
            '
            MessageBox.Show("Operation cancelled")
        Catch ex As Exception
            '
            ' Handle any unhandled exceptions
            '
            MessageBox.Show(ex.Message)
        Finally
            '
            ' Success or failure reenable the Run button
            '
            RunButton.Enabled = True
        End Try

    End Sub
    ''' <summary>
    ''' Call back for OnMonitor event
    ''' </summary>
    ''' <param name="args"></param>
    Private Sub MonitorDoNothingOperation(args As MonitorArgs)
        '
        ' Set current progress for ProgressBar
        '
        progressBar1.Value = args.PercentDone

        '
        ' Use text to indicate we are done
        '
        If args.PercentDone = _totalIterations Then
            MessageBox.Show(args.Message)
        End If
    End Sub
    '
    ' Request cancellation of current operation
    '
    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click

        If Not RunButton.Enabled Then
            _cancellationTokenSource.Cancel()
            RunButton.Enabled = True
        End If

    End Sub

End Class
