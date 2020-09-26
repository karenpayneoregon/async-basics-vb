Imports WinFormsControlHelpers

Public Class SplashForm
    ''' <summary>
    ''' Load gif using InvokeIfRequired in project
    ''' WinFormsControlHelpers.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub SplashForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Await Task.Run(Async Function()

                           PictureBox1.InvokeIfRequired(
                               Sub(pictureBox)
                                   pictureBox.Image = My.Resources.Kitty
                               End Sub)

                           Await Task.Delay(500)

                       End Function)
    End Sub
End Class