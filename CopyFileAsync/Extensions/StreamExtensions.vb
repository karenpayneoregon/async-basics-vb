Imports System.IO
Imports System.Runtime.CompilerServices

Namespace Extensions
    Public Module StreamExtensions
        ''' <summary>
        ''' Copy a file async via open streams
        ''' </summary>
        ''' <param name="source">Current open stream for file to copy</param>
        ''' <param name="destination">Current open stream for destination file</param>
        ''' <param name="bufferSize">Buffer size for reading</param>
        ''' <param name="progress">Action to report progress</param>
        ''' <returns></returns>
        ''' <remarks>
        ''' Buffer size should be adjusted according to your needs and could be
        ''' a calculated number per file
        ''' </remarks>
        <Extension>
        Public Async Function CopyToWithProgressAsync(
            source As Stream,
            destination As Stream,
            bufferSize As Integer,
            Optional ByVal progress As Action(Of Integer) = Nothing) As Task

            Dim buffer = New Byte(bufferSize - 1) {}
            Dim total = 0
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