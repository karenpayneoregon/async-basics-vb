Imports SqlServerSimpleAsync.Classes

Public Class Form1
    Private customersBindingSource As New BindingSource
    Private Async Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try

            Dim customersTable = Await DataOperations.ReadCustomers()

            customersBindingSource.DataSource = customersTable
            DataGridView1.DataSource = customersBindingSource

        Catch ex As Exception
            '
            ' Handle any unhandled exceptions
            '
            MessageBox.Show(ex.Message)

        End Try
    End Sub
End Class
