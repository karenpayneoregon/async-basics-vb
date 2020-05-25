Imports System.ComponentModel
Imports System.Threading
Imports WinFormsControlHelpers

Public Class Form1
    Private waitFor As Integer = 2000
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim bgw = New BackgroundWorker()

        AddHandler bgw.DoWork,
            Sub()

                Thread.Sleep(waitFor)
                'Label1.Text = "1"
                Label1.InvokeIfRequired(Sub(lb) lb.Text = "Success from background worker")

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
    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Await Task.Run(
            Sub()

                Thread.Sleep(waitFor)
                Label1.Text = "Oh this is not going to work :-("

            End Sub)

        MessageBox.Show("Hi from the UI thread from Button2!")

    End Sub
    ''' <summary>
    ''' Prevent Cross-thread operation not valid
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Await Task.Run(
            Sub()

                Thread.Sleep(waitFor)

                Label1.InvokeIfRequired(Sub(label) label.Text = "Success from Button3 first")
                TextBox1.InvokeIfRequired(Sub(textBox) textBox.Text = "Success from Button3 first")

            End Sub)

        MessageBox.Show("Hi from the UI thread in Button3!")


        Await Task.Run(
            Sub()

                Thread.Sleep(waitFor)

                If Label1.InvokeRequired Then
                    Label1.Invoke(Sub() Label1.Text = "Success from Button3 second")
                Else
                    Label1.Text = "Success from Button3 second"
                End If

                '
                ' We can do better, see below commented code
                '
                'If TextBox1.InvokeRequired Then
                '    TextBox1.Invoke(Sub() TextBox1.Text = "Success from Button3 second")
                'Else
                '    TextBox1.Text = "Success from Button3 second"
                'End If

                TextBox1.Invoke(New MethodInvoker(Sub() TextBox1.Text = "Success from Button3 second"))

            End Sub)


    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Label1.Text = ""
    End Sub
End Class
