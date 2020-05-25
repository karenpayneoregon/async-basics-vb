
Imports System.Text

Public Class Form1
    Private Shared MainCounter As Integer = 0

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

    Private Shared Function CreateSimple() As String
        Dim id As Integer = MainCounter
        MainCounter += 1
        Return "Task [" & id & "] delayed: NONE"
    End Function

    Private Shared Function CreateMessage() As Message
        Return New Message(CreateSimple())
    End Function

    Private Shared Async Function CreateTask(ByVal delay As Integer) As Task(Of String)
        Dim id As Integer = MainCounter
        MainCounter += 1
        Await Task.Delay(delay)
        Return "Task [" & id & "] delayed: " & delay
    End Function

    Private Shared Async Function CreateOtherTask(ByVal delay As Integer) As Task(Of Message)
        Dim id As Integer = MainCounter
        MainCounter += 1
        Await Task.Delay(delay)
        Return New Message("Task [" & id & "] delayed: " & delay)
    End Function

    Public Class Message
        Private _message As String

        Public Sub New(msg As String)
            _message = msg
        End Sub

        Public Overrides Function ToString() As String
            Return _message
        End Function
    End Class
    ''' <summary>
    ''' https://dotnetfiddle.net/JMLHxR
    ''' Original code C#, this version has been adapted to windows forms unlike
    ''' the original or console style project.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Async Sub RunButton2_Click(sender As Object, e As EventArgs) Handles RunButton2.Click
        TextBox1.Text = ""

        RunButton2.Enabled = False

        Dim sb As New StringBuilder

        Dim rnd As New Random()

        Dim tasks = New Task(Of Object)() {
            CreateTask(rnd.Next(500, 2000)).
                ContinueWith(Function(t) CObj(t.Result)),
            CreateOtherTask(rnd.Next(500, 2000)).
                ContinueWith(Function(t) CObj(t.Result)),
            CreateTask(rnd.Next(500, 2000)).
                ContinueWith(Function(t) CObj(t.Result)),
            CreateOtherTask(rnd.Next(500, 2000)).
                ContinueWith(Function(t) CObj(t.Result)),
            Task.Run(Function() CObj(CreateSimple())),
            Task.Run(Function() CObj(CreateMessage())),
            Task.Run(Function() CObj(CreateSimple())),
            Task.Run(Function() CObj(CreateMessage()))}

        Dim all As Object()

        ' They are already completed here, but just to show the syntax.
        ' .Result should obliviously be awaited instead.
        Try
            all = Await Task.WhenAll(tasks)
        Finally
            RunButton2.Enabled = True
        End Try

        For Each result In all

            If result Is GetType(Message) Then
                sb.AppendLine(CType(result, Message).ToString())
            Else
                sb.AppendLine(result.ToString())
            End If


        Next result

        TextBox1.Text = sb.ToString()
    End Sub
End Class
