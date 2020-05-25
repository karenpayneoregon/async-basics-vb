
Imports System.Text

Public Class Form1

    Private Async Function SlowAndComplexWordAsync() As Task(Of String)

        Dim results = ""

        For Each counter In Enumerable.Range(65, 26)
            results = String.Concat(results, ChrW(counter))
            Await Task.Delay(150)
        Next

        Return results

    End Function
    Private Async Function SlowAndComplexSumAsync() As Task(Of Integer)

        Dim sum = 0

        For Each counter In Enumerable.Range(0, 25)
            sum += counter
            Await Task.Delay(100)
        Next

        Return sum

    End Function

    Private Async Sub RunButton_Click(sender As Object, e As EventArgs) Handles RunButton.Click

        RunButton.Enabled = False

        Dim sb As New StringBuilder

        TextBox1.Text = ""

        Dim stopwatch = New Stopwatch()
        stopwatch.Start()

        ' this task will take about 2.5s to complete
        Dim sumTask As Task(Of Integer) = SlowAndComplexSumAsync()

        ' this task will take about 4s to complete
        Dim wordTask As Task(Of String) = SlowAndComplexWordAsync()

        ' running them in parallel should take about 4s to complete
        Try
            Await Task.WhenAll(sumTask, wordTask)
        Finally
            RunButton.Enabled = True
        End Try

        ' The elapsed time at this point will only be about 4s
        sb.AppendLine($"Time elapsed when both complete... {stopwatch.Elapsed}")

        ' These lines are to prove the outputs are as expected,
        ' i.e. 300 for the complex sum and "ABC...XYZ" for the complex word
        sb.AppendLine("Result of complex sum = " & sumTask.Result)
        sb.AppendLine("Result of complex letter processing " & wordTask.Result)

        TextBox1.Text = sb.ToString()

    End Sub

End Class
