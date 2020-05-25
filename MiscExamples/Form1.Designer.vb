<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BackGroundWorkerButton = New System.Windows.Forms.Button()
        Me.CrossThreadButton = New System.Windows.Forms.Button()
        Me.GeneralResultsLabel = New System.Windows.Forms.Label()
        Me.TaskRunInvokeButton = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.WebExampleButton = New System.Windows.Forms.Button()
        Me.WebResultLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BackGroundWorkerButton
        '
        Me.BackGroundWorkerButton.Location = New System.Drawing.Point(15, 12)
        Me.BackGroundWorkerButton.Name = "BackGroundWorkerButton"
        Me.BackGroundWorkerButton.Size = New System.Drawing.Size(134, 23)
        Me.BackGroundWorkerButton.TabIndex = 0
        Me.BackGroundWorkerButton.Text = "backgroundWorker"
        Me.BackGroundWorkerButton.UseVisualStyleBackColor = True
        '
        'CrossThreadButton
        '
        Me.CrossThreadButton.Location = New System.Drawing.Point(15, 41)
        Me.CrossThreadButton.Name = "CrossThreadButton"
        Me.CrossThreadButton.Size = New System.Drawing.Size(131, 23)
        Me.CrossThreadButton.TabIndex = 1
        Me.CrossThreadButton.Text = "Cross thread"
        Me.CrossThreadButton.UseVisualStyleBackColor = True
        '
        'GeneralResultsLabel
        '
        Me.GeneralResultsLabel.AutoSize = True
        Me.GeneralResultsLabel.Location = New System.Drawing.Point(176, 17)
        Me.GeneralResultsLabel.Name = "GeneralResultsLabel"
        Me.GeneralResultsLabel.Size = New System.Drawing.Size(39, 13)
        Me.GeneralResultsLabel.TabIndex = 2
        Me.GeneralResultsLabel.Text = "Label1"
        '
        'TaskRunInvokeButton
        '
        Me.TaskRunInvokeButton.Location = New System.Drawing.Point(15, 70)
        Me.TaskRunInvokeButton.Name = "TaskRunInvokeButton"
        Me.TaskRunInvokeButton.Size = New System.Drawing.Size(131, 23)
        Me.TaskRunInvokeButton.TabIndex = 3
        Me.TaskRunInvokeButton.Text = "Invoke"
        Me.TaskRunInvokeButton.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(179, 44)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(177, 20)
        Me.TextBox1.TabIndex = 4
        '
        'WebExampleButton
        '
        Me.WebExampleButton.Location = New System.Drawing.Point(15, 99)
        Me.WebExampleButton.Name = "WebExampleButton"
        Me.WebExampleButton.Size = New System.Drawing.Size(131, 23)
        Me.WebExampleButton.TabIndex = 5
        Me.WebExampleButton.Text = "Web"
        Me.WebExampleButton.UseVisualStyleBackColor = True
        '
        'WebResultLabel
        '
        Me.WebResultLabel.AutoSize = True
        Me.WebResultLabel.Location = New System.Drawing.Point(176, 99)
        Me.WebResultLabel.Name = "WebResultLabel"
        Me.WebResultLabel.Size = New System.Drawing.Size(39, 13)
        Me.WebResultLabel.TabIndex = 6
        Me.WebResultLabel.Text = "Label2"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 152)
        Me.Controls.Add(Me.WebResultLabel)
        Me.Controls.Add(Me.WebExampleButton)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TaskRunInvokeButton)
        Me.Controls.Add(Me.GeneralResultsLabel)
        Me.Controls.Add(Me.CrossThreadButton)
        Me.Controls.Add(Me.BackGroundWorkerButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Misc"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BackGroundWorkerButton As Button
    Friend WithEvents CrossThreadButton As Button
    Friend WithEvents GeneralResultsLabel As Label
    Friend WithEvents TaskRunInvokeButton As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents WebExampleButton As Button
    Friend WithEvents WebResultLabel As Label
End Class
