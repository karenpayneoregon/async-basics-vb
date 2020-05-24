Imports System.IO
Imports System.Runtime.CompilerServices

Namespace Extensions
    Public Module StreamExtensions
        ''' <summary>
        ''' Copy a file async via open streams
        ''' </summary>
        ''' <param name="source"></param>
        ''' <param name="destination"></param>
        ''' <param name="bufferSize"></param>
        ''' <param name="progress"></param>
        ''' <returns></returns>
        <Extension>
        Public Async Function CopyToWithProgressAsync(
            source As Stream,
            destination As Stream,
            bufferSize As Integer,
            Optional ByVal progress As Action(Of Integer) = Nothing) As Task

            Dim buffer = New Byte(bufferSize - 1) {}
            Dim total = 0 '0L
            Dim amountRead As Integer

            Do

                amountRead = 0

                Do While amountRead < bufferSize

                    Dim numBytes = Await source.ReadAsync(buffer, amountRead, bufferSize - amountRead)

                    If numBytes = 0 Then
                        Exit Do
                    End If

                    amountRead += numBytes

                    '
                    ' Only for demonstrating, remove for your code
                    '
                    Await Task.Delay(200)

                Loop

                total += amountRead

                Await destination.WriteAsync(buffer, 0, amountRead)

                If progress IsNot Nothing Then
                    progress(total)
                End If

            Loop While amountRead = bufferSize

        End Function

    End Module
End Namespace