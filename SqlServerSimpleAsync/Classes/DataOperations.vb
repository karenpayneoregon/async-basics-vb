Imports System.Data.SqlClient

Namespace Classes

    Public Class DataOperations
        Private Shared ConnectionStringWorks As String =
                           "Data Source=.\SQLEXPRESS;" &
                           "Initial Catalog=NorthWindAzureForInserts;" &
                           "Integrated Security=True"
        Private Shared ConnectionStringFails As String =
                           "Data Source=.\SQLEXPRESS_BAD;" &
                           "Initial Catalog=NorthWindAzureForInserts;" &
                           "Integrated Security=True"

        Public Shared Async Function ReadCustomers() As Task(Of DataTable)

            Return Await Task.Run(Async Function()

                                      Dim customersTable = New DataTable()

                                      Using cn = New SqlConnection(ConnectionStringFails)

                                          Using cmd = New SqlCommand() With {.Connection = cn}

                                              cmd.CommandText = SelectStatement()
                                              Await cn.OpenAsync()

                                              customersTable.Load(Await cmd.ExecuteReaderAsync())

                                          End Using

                                      End Using

                                      customersTable.Columns.Cast(Of DataColumn).
                                        Where(Function(column) column.ColumnName.Contains("Id")).
                                        ToList().
                                        ForEach(Sub(column)
                                                    column.ColumnMapping = MappingType.Hidden
                                                End Sub)
                                      Return customersTable

                                  End Function)

        End Function
        Private Shared Function SelectStatement() As String
            Return <SQL>
SELECT Cust.CustomerIdentifier,
       Cust.CompanyName,
       Cust.ContactId,
       Contacts.FirstName,
       Contacts.LastName,
       Cust.ContactTypeIdentifier,
       CT.ContactTitle,
       Cust.Address AS Street,
       Cust.City,
       Cust.PostalCode,
       Cust.CountryIdentifier,
       Countries.Name AS CountryName,
       Cust.ModifiedDate
FROM Customers AS Cust
     INNER JOIN ContactType AS CT ON Cust.ContactTypeIdentifier = CT.ContactTypeIdentifier
     INNER JOIN Contacts ON Cust.ContactId = Contacts.ContactId
     INNER JOIN Countries ON Cust.CountryIdentifier = Countries.CountryIdentifier
               </SQL>.Value
        End Function




    End Class
End Namespace