Imports System.IO

Namespace Classes
    Public Class Operations
        Public Event OnIterate As DelegatesModule.OnIterate
        Private folderFound As Boolean
        Public ReadOnly Property FolderExists() As Boolean
            Get
                Return folderFound
            End Get
        End Property
        Public Async Function IterateFolders(folderName As String, searchString As String, token As Threading.CancellationToken) As Task(Of List(Of String))

            Dim foundList = New List(Of String)()

            If Not Directory.Exists(folderName) Then
                OnIterateEvent?.Invoke(New MonitorProgressArgs("Folder does not exists!"))
                folderFound = False
                Return foundList
            End If

            folderFound = True
            Dim currentFileName = ""
            Try
                For Each fileName In Directory.EnumerateFiles(folderName, "*.txt", SearchOption.AllDirectories)
                    currentFileName = fileName
                    OnIterateEvent?.Invoke(New MonitorProgressArgs(fileName))

                    Dim contents = File.ReadAllText(fileName)

                    Await Task.Delay(1)

                    If contents.Contains(searchString) Then
                        foundList.Add(fileName)
                    End If

                    If token.IsCancellationRequested Then
                        token.ThrowIfCancellationRequested()
                    End If

                Next
            Catch ex As Exception
                OnIterateEvent?.Invoke(New MonitorProgressArgs($"Access denied {currentFileName}"))
            End Try

            Return foundList

        End Function
    End Class
End Namespace
