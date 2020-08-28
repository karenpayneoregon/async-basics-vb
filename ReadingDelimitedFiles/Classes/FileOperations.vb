Imports System.IO
Imports System.Threading

Namespace Classes
    Public Class FileOperations
        ''' <summary>
        ''' Text file to work with
        ''' </summary>
        Private ReadOnly _fileName As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data.txt")

        Public Event OnReadLine As DelegatesSignatures.OnReadLine
        ''' <summary>
        ''' Read file with the ability to cancel the operation
        ''' </summary>
        ''' <param name="token">CancellationToken created in the calling form</param>
        ''' <returns>Nothing</returns>
        Public Async Function ReadFile(token As CancellationToken) As Task
            Dim lineIndex = 1

            Dim currentLine As String

            Using reader As StreamReader = File.OpenText(_fileName)

                While Not reader.EndOfStream

                    currentLine = Await reader.ReadLineAsync()

                    Dim parts = currentLine.Split(","c)

                    Dim person = New Person With {
                            .FirstName = parts(0),
                            .MiddleName = parts(1),
                            .LastName = parts(2),
                            .Street = parts(3),
                            .City = parts(4),
                            .State = parts(5),
                            .PostalCode = parts(6),
                            .EmailAddress = parts(7)
                            }

                    OnReadLineEvent?.Invoke(New NewLineArgs(person.FieldArray(), lineIndex))

                    lineIndex += 1

                    Await Task.Delay(1, token)

                    If token.IsCancellationRequested Then
                        token.ThrowIfCancellationRequested()
                    End If

                End While
            End Using
        End Function
    End Class
End Namespace