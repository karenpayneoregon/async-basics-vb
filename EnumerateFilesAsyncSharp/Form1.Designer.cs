using System.IO;
using System.Threading;
using EnumerateFilesAsync.Classes;

//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace EnumerateFilesAsync
{
	public partial class Form1 : System.Windows.Forms.Form
	{
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            this.StartButton = new System.Windows.Forms.Button();
            this.CurrentFileLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.FolderNameListBox = new System.Windows.Forms.ListBox();
            this.ErrorListBox = new System.Windows.Forms.ListBox();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(19, 19);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // CurrentFileLabel
            // 
            this.CurrentFileLabel.AutoSize = true;
            this.CurrentFileLabel.Location = new System.Drawing.Point(28, 107);
            this.CurrentFileLabel.Name = "CurrentFileLabel";
            this.CurrentFileLabel.Size = new System.Drawing.Size(57, 13);
            this.CurrentFileLabel.TabIndex = 2;
            this.CurrentFileLabel.Text = "Current file";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(109, 19);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.CancelButton);
            this.GroupBox1.Controls.Add(this.StartButton);
            this.GroupBox1.Location = new System.Drawing.Point(31, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(206, 56);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            // 
            // FolderNameListBox
            // 
            this.FolderNameListBox.FormattingEnabled = true;
            this.FolderNameListBox.Location = new System.Drawing.Point(31, 137);
            this.FolderNameListBox.Name = "FolderNameListBox";
            this.FolderNameListBox.Size = new System.Drawing.Size(819, 82);
            this.FolderNameListBox.TabIndex = 6;
            // 
            // ErrorListBox
            // 
            this.ErrorListBox.FormattingEnabled = true;
            this.ErrorListBox.Location = new System.Drawing.Point(31, 245);
            this.ErrorListBox.Name = "ErrorListBox";
            this.ErrorListBox.Size = new System.Drawing.Size(819, 82);
            this.ErrorListBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 339);
            this.Controls.Add(this.ErrorListBox);
            this.Controls.Add(this.FolderNameListBox);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.CurrentFileLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iterate folders";
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal Button StartButton;
		internal Label CurrentFileLabel;
		internal Button CancelButton;
		internal GroupBox GroupBox1;
		internal ListBox FolderNameListBox;
		internal ListBox ErrorListBox;
	}

}