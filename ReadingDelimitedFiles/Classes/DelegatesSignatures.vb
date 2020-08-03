Namespace Classes
    Public Class DelegatesSignatures
        ''' <summary>
        ''' Callback in <see cref="FileOperations.ReadFile"/> to load a
        ''' DataGridView in the form.
        ''' </summary>
        ''' <param name="arguments"></param>
        Public Delegate Sub OnReadLine(arguments As NewLineArgs)
    End Class
End NameSpace