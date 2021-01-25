Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Public Module ControlExtensions
    <System.Runtime.CompilerServices.Extension>
    Public Sub InvokeIfRequired(Of T As ISynchronizeInvoke)(ByVal control As T, ByVal action As Action(Of T))
        If control.InvokeRequired Then
            control.Invoke(New Action(Sub() action(control)), Nothing)
        Else
            action(control)
        End If
    End Sub

End Module

