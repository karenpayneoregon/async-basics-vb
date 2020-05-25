Imports System.ComponentModel
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports System.Threading
Imports WinFormsControlHelpers

Public Class Form1
    Private waitFor As Integer = 2000
    Private Sub BackGroundWorkerButton_Click(sender As Object, e As EventArgs) _
        Handles BackGroundWorkerButton.Click

        Dim bgw = New BackgroundWorker()

        AddHandler bgw.DoWork,
            Sub()

                Thread.Sleep(waitFor)
                GeneralResultsLabel.Invoke(New MethodInvoker(Sub() GeneralResultsLabel.Text = "Success from background worker"))
            End Sub

        AddHandler bgw.RunWorkerCompleted,
            Sub()
                MessageBox.Show("Hi from the UI thread for backgrounder worker!")
            End Sub

        bgw.RunWorkerAsync()

    End Sub
    ''' <summary>
    ''' Cross-thread operation not valid: Control 'Label1' accessed from a thread other than the thread it was created on.'
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub CrossThreadButton_Click(sender As Object, e As EventArgs) Handles CrossThreadButton.Click

        Await Task.Run(
            Sub()

                Thread.Sleep(waitFor)
                GeneralResultsLabel.Text = "Oh this is not going to work :-("

            End Sub)

        MessageBox.Show("Hi from the UI thread from Button2!")

    End Sub
    ''' <summary>
    ''' Prevent Cross-thread operation not valid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub TaskRunInvokeButton_Click(sender As Object, e As EventArgs) Handles TaskRunInvokeButton.Click
        Await Task.Run(
            Sub()

                Thread.Sleep(waitFor)

                GeneralResultsLabel.InvokeIfRequired(Sub(label) label.Text = "Success from TaskRunInvokeButton first")
                TextBox1.InvokeIfRequired(Sub(textBox) textBox.Text = "Success from TaskRunInvokeButton first")

            End Sub)

        MessageBox.Show("Hi from the UI thread in Button3!")


        Await Task.Run(
            Sub()

                Thread.Sleep(waitFor)

                GeneralResultsLabel.Invoke(New MethodInvoker(Sub() GeneralResultsLabel.Text = "Success from TaskRunInvokeButton second"))

                '
                ' We can do better, see below commented code
                '
                'If TextBox1.InvokeRequired Then
                '    TextBox1.Invoke(Sub() TextBox1.Text = "Success from Button3 second")
                'Else
                '    TextBox1.Text = "Success from Button3 second"
                'End If

                TextBox1.Invoke(New MethodInvoker(Sub() TextBox1.Text = "Success from TaskRunInvokeButton second"))

            End Sub)


    End Sub

    Private ReadOnly _httpClient As New HttpClient()
    ''' <summary>
    ''' Adapted from Microsoft code sample
    ''' https://docs.microsoft.com/en-us/dotnet/csharp/async
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub WebExampleButton_Click(sender As Object, e As EventArgs) Handles WebExampleButton.Click
        WebResultLabel.Invoke(New MethodInvoker(Sub() WebResultLabel.Text = "Working..."))
        Await Task.Delay(500)
        Dim count = Await GetDotNetCount()
        WebResultLabel.Invoke(New MethodInvoker(Sub() WebResultLabel.Text = $"Count of time .NET appears {count}"))
    End Sub
    Public Async Function GetDotNetCount() As Task(Of Integer)
        ' Suspends GetDotNetCount() to allow the caller (the web server)
        ' to accept another request, rather than blocking on this one.
        Dim html = Await _httpClient.GetStringAsync("https://dotnetfoundation.org")

        Return Regex.Matches(html, "\.NET").Count
    End Function

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        GeneralResultsLabel.Text = ""
        WebResultLabel.Text = ""
    End Sub
End Class

