Imports System.IO
Imports System.Threading
Imports EnumerateFilesAsync.Classes

Public Class Form1
    Private _cancellationTokenSource As New CancellationTokenSource()

    Private folderName As String = "C:\Program Files (x86)"
    Private searchFor As String = "THE SOFTWARE IS PROVIDED"

    ''' <summary>
    ''' Iterate folders synchronously in button click which should never be done, see
    ''' examples in Operations class.
    '''
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ConventionalButton_Click(sender As Object, e As EventArgs) Handles ConventionalButton.Click
        ErrorListBox.Items.Clear()
        Dim foundList = New List(Of String)()

        Try
            For Each fileName In Directory.EnumerateFiles(folderName, "*.txt", SearchOption.AllDirectories)
                Dim contents = File.ReadAllText(fileName)
                If contents.Contains(searchFor) Then
                    foundList.Add(fileName)
                End If
            Next
        Catch ex As Exception
            ErrorListBox.Items.Add(ex.Message)
        End Try

        If foundList.Count > 0 Then
            FolderNameListBox.DataSource = foundList
        Else
            MessageBox.Show("No matches")
        End If
    End Sub

    Private Async Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click

        FolderNameListBox.DataSource = Nothing

        ErrorListBox.Items.Clear()

        If _cancellationTokenSource.IsCancellationRequested Then
            _cancellationTokenSource.Dispose()
            _cancellationTokenSource = New CancellationTokenSource()
        End If

        Dim operations As New Operations

        AddHandler operations.OnIterate, AddressOf IterateFolders

        Try

            Dim foundFiles = Await operations.IterateFolders(
                folderName,
                searchFor,
                _cancellationTokenSource.Token)

            If Not operations.FolderExists Then
                MessageBox.Show($"{folderName}{Environment.NewLine} does not exists")
            ElseIf foundFiles.Count = 0 Then
                MessageBox.Show("No matches")
            End If

            FolderNameListBox.DataSource = foundFiles
            CurrentFileLabel.Text = ""

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
            StartButton.Enabled = True
        End Try

    End Sub
    ''' <summary>
    ''' Show current file on each iteration along
    ''' with if there were permission issues reading.
    ''' </summary>
    ''' <param name="args"></param>
    Private Sub IterateFolders(args As MonitorProgressArgs)

        If args.CurrentFileName.Contains("Access denied") Then
            ErrorListBox.Items.Add(args.CurrentFileName)
        Else
            CurrentFileLabel.Text = args.CurrentFileName
        End If

    End Sub
    ''' <summary>
    ''' Cancel operation
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        _cancellationTokenSource.Cancel()
    End Sub
End Class
