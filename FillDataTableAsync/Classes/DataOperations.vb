Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Classes
    Public Class DataOperations
        Private SqlServerConnectionString As String = "TODO"
        Private AcccessConnectionString As String = "TODO"
        Public Async Function FillForSqlServer() As Task(Of DataTable)

            Dim resultsDataTable = New DataTable()

            Try
                Using conn = New SqlConnection(SqlServerConnectionString)
                    Dim adapter = New SqlDataAdapter("TODO", conn)
                    Await Task.Run(Function() adapter.Fill(resultsDataTable))
                End Using
            Catch ex As Exception
                ' handle exception
            End Try

            Return resultsDataTable

        End Function
        Public Async Function FillForAccess() As Task(Of DataTable)

            Dim resultsDataTable = New DataTable()

            Try
                Using conn = New OleDbConnection(SqlServerConnectionString)
                    Dim adapter = New OleDbDataAdapter("TODO", conn)
                    Await Task.Run(Function() adapter.Fill(resultsDataTable))
                End Using
            Catch ex As Exception
                ' handle exception
            End Try

            Return resultsDataTable

        End Function

        Public Async Sub SubDemo()
            ' appease the compiler, better to use a function
            Await Task.Delay(1)
        End Sub
        Public Async Function FunDemo() As Task
            ' appease the compiler, better to use a function
            Await Task.Delay(1)
        End Function
    End Class
End Namespace