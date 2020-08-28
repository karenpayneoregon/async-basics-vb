using System;
using System.Windows.Forms;
using System.Threading;
using EnumerateFilesAsync.Classes.Classes;

namespace EnumerateFilesAsync
{
    public partial class Form1
    {
        public Form1()
        {
            InitializeComponent();
        }

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        private string folderName = "C:\\Program Files (x86)";
        private string searchFor = "THE SOFTWARE IS PROVIDED";

        private async void StartButton_Click(object sender, EventArgs e)
        {

            FolderNameListBox.DataSource = null;

            ErrorListBox.Items.Clear();

            if (_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = new CancellationTokenSource();
            }

            var operations = new Operations();

            operations.OnIterate += IterateFolders;

            try
            {

                var foundFiles = await operations.IterateFolders(folderName, searchFor, _cancellationTokenSource.Token);

                if (!operations.FolderExists)
                {
                    MessageBox.Show($"{folderName}{Environment.NewLine} does not exists");
                }
                else if (foundFiles.Count == 0)
                {
                    MessageBox.Show("No matches");
                }

                FolderNameListBox.DataSource = foundFiles;
                CurrentFileLabel.Text = "";

            }
            catch (OperationCanceledException oce)
            {
                //
                // Land here from token.ThrowIfCancellationRequested()
                // thrown in Run method from a cancel request in this
                // form's Cancel button
                //
                MessageBox.Show("Operation cancelled");
            }
            catch (Exception ex)
            {
                //
                // Handle any unhandled exceptions
                //
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //
                // Success or failure reenable the Run button
                //
                StartButton.Enabled = true;
            }

        }
        /// <summary>
        /// Show current file on each iteration along
        /// with if there were permission issues reading.
        /// </summary>
        /// <param name="args"></param>
        private void IterateFolders(MonitorProgressArgs args)
        {

            if (args.CurrentFileName.Contains("Access denied"))
            {
                ErrorListBox.Items.Add(args.CurrentFileName);
            }
            else
            {
                CurrentFileLabel.Text = args.CurrentFileName;
            }

        }
        /// <summary>
        /// Cancel operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        private static Form1 _DefaultInstance;
        public static Form1 DefaultInstance
        {
            get
            {
                if (_DefaultInstance == null || _DefaultInstance.IsDisposed)
                    _DefaultInstance = new Form1();

                return _DefaultInstance;
            }
        }
    }

}