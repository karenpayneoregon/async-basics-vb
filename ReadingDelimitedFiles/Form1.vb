Imports System.Threading
Imports ReadingDelimitedFiles.Classes

Public Class Form1

    Private _cancellationTokenSource As New CancellationTokenSource()
    Private Async Sub ReadFileButton_Click(sender As Object, e As EventArgs) Handles ReadFileButton.Click

        ReadFileButton.Enabled = False
        StatusLabel.Text = ""

        If DataGridView1.Rows.Count > 0 Then
            DataGridView1.Rows.Clear()
        End If

        If _cancellationTokenSource.IsCancellationRequested Then
            _cancellationTokenSource.Dispose()
            _cancellationTokenSource = New CancellationTokenSource()
        End If

        Try
            Dim operation = New FileOperations
            AddHandler operation.OnReadLine, AddressOf OnReadLine
            Await operation.ReadFile(_cancellationTokenSource.Token)
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
            ReadFileButton.Enabled = True

        End Try
    End Sub

    Private Sub OnReadLine(args As NewLineArgs)
        DataGridView1.Rows.Add(args.PersonArray)
        StatusLabel.Text = $"Reading line {args.CurrentIndex}"
    End Sub


    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        If Not ReadFileButton.Enabled Then
            _cancellationTokenSource.Cancel()
            ReadFileButton.Enabled = True
        End If
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        StatusLabel.Text = ""
    End Sub
End Class
