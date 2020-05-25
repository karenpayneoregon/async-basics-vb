Imports System.IO
Imports CopyFileAsync.Classes

Public Class Form1
    Private Async Sub CopyFileButton_Click(sender As Object, e As EventArgs) _
        Handles CopyFileButton.Click

        Dim operations As New FileOperations

        Dim sourceFileName As String =
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Names1.txt")

        Dim destinationFileName As String =
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Names2.txt")

        ProgressBar1.Maximum = CType(operations.GetFileBytes(sourceFileName), Integer)

        AddHandler operations.OnIterate, AddressOf OnIterate

        Dim success = Await operations.CopyFile(sourceFileName, destinationFileName)
        If success Then
            MessageBox.Show("Done")
        Else
            MessageBox.Show(operations.LastExceptionMessage)
        End If
    End Sub
    ''' <summary>
    ''' Call back to set percent done in ProgressBae
    ''' </summary>
    ''' <param name="args"></param>
    Private Sub OnIterate(args As MonitorProgressArgs)
        ProgressBar1.Value = args.Current
    End Sub
End Class
