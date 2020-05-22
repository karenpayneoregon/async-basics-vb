Namespace Classes
    Public Class Person
        Public Property FirstName As String
        Public Property MiddleName As String
        Public Property LastName As String
        Public Property Street() As String
        Public Property City As String
        Public Property State As String
        Public Property PostalCode As String
        Public Property EmailAddress As String
        Public Function FieldArray() As String()
            Return New String() {FirstName, MiddleName, LastName, Street, City, State, PostalCode, EmailAddress}
        End Function
    End Class
End Namespace