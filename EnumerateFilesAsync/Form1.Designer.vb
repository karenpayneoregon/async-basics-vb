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
        Me.ConventionalButton = New System.Windows.Forms.Button()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.CurrentFileLabel = New System.Windows.Forms.Label()
        Me.CancelButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.FolderNameListBox = New System.Windows.Forms.ListBox()
        Me.ErrorListBox = New System.Windows.Forms.ListBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ConventionalButton
        '
        Me.ConventionalButton.Location = New System.Drawing.Point(15, 19)
        Me.ConventionalButton.Name = "ConventionalButton"
        Me.ConventionalButton.Size = New System.Drawing.Size(207, 23)
        Me.ConventionalButton.TabIndex = 0
        Me.ConventionalButton.Text = "Conventional attempt"
        Me.ConventionalButton.UseVisualStyleBackColor = True
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(19, 19)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 1
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'CurrentFileLabel
        '
        Me.CurrentFileLabel.AutoSize = True
        Me.CurrentFileLabel.Location = New System.Drawing.Point(28, 107)
        Me.CurrentFileLabel.Name = "CurrentFileLabel"
        Me.CurrentFileLabel.Size = New System.Drawing.Size(57, 13)
        Me.CurrentFileLabel.TabIndex = 2
        Me.CurrentFileLabel.Text = "Current file"
        '
        'CancelButton
        '
        Me.CancelButton.Location = New System.Drawing.Point(109, 19)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton.TabIndex = 3
        Me.CancelButton.Text = "Cancel"
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CancelButton)
        Me.GroupBox1.Controls.Add(Me.StartButton)
        Me.GroupBox1.Location = New System.Drawing.Point(287, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(206, 56)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Right way"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ConventionalButton)
        Me.GroupBox2.Location = New System.Drawing.Point(32, 22)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(249, 56)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Unavisable"
        '
        'FolderNameListBox
        '
        Me.FolderNameListBox.FormattingEnabled = True
        Me.FolderNameListBox.Location = New System.Drawing.Point(31, 137)
        Me.FolderNameListBox.Name = "FolderNameListBox"
        Me.FolderNameListBox.Size = New System.Drawing.Size(819, 82)
        Me.FolderNameListBox.TabIndex = 6
        '
        'ErrorListBox
        '
        Me.ErrorListBox.FormattingEnabled = True
        Me.ErrorListBox.Location = New System.Drawing.Point(31, 245)
        Me.ErrorListBox.Name = "ErrorListBox"
        Me.ErrorListBox.Size = New System.Drawing.Size(819, 82)
        Me.ErrorListBox.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 339)
        Me.Controls.Add(Me.ErrorListBox)
        Me.Controls.Add(Me.FolderNameListBox)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CurrentFileLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Iterate folders"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ConventionalButton As Button
    Friend WithEvents StartButton As Button
    Friend WithEvents CurrentFileLabel As Label
    Friend WithEvents CancelButton As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents FolderNameListBox As ListBox
    Friend WithEvents ErrorListBox As ListBox
End Class
