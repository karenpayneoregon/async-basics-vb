Imports System.IO
Imports System.Windows.Forms.VisualStyles
Imports CopyFileAsync.Extensions

Namespace Classes

    Public Class FileOperations
        Inherits BaseConnectionLibrary.BaseExceptionProperties

        Public Event OnIterate As DelegatesModule.OnIterate
        Public Function GetFileBytes(fileName As String) As Long
            Dim fi As New FileInfo(fileName)
            Return fi.Length
        End Function
        Public Async Function CopyFile(sourceFileName As String, destinationFileName As String) As Task(Of Boolean)

            Try

                Using writer As StreamWriter = File.CreateText(destinationFileName)
                End Using

                Using sourceFileSteam As Stream = File.Open(sourceFileName, FileMode.Open)
                    Using destinationFileSteam As FileStream = File.Open(destinationFileName, FileMode.Open)
                        Await sourceFileSteam.CopyToWithProgressAsync(destinationFileSteam, 32768, Sub(percent)
                                                                                                       Progress(percent)
                                                                                                   End Sub)
                    End Using
                End Using

                Return True

            Catch ex As Exception

                mHasException = True
                mLastException = ex

                Return False

            End Try

        End Function
        Private Sub Progress(bytes As Integer)
            OnIterateEvent?.Invoke(New MonitorProgressArgs(bytes))
        End Sub
    End Class
End Namespace