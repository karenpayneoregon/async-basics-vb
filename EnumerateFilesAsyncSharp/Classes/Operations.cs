using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EnumerateFilesAsync.Classes
{
	namespace Classes
	{
		public class Operations
		{
			public event DelegatesModule.OnIterate OnIterate;
			private bool _folderFound;
			public bool FolderExists => _folderFound;

            public async Task<List<string>> IterateFolders(string folderName, string searchString, CancellationToken token)
			{

				var foundList = new List<string>();

				if (!Directory.Exists(folderName))
				{
					OnIterate?.Invoke(new MonitorProgressArgs("Folder does not exists!"));
					_folderFound = false;
					return foundList;
				}

				_folderFound = true;
				var currentFileName = "";

				try
				{
					foreach (var fileName in Directory.EnumerateFiles(folderName, "*.txt", SearchOption.AllDirectories))
					{
						currentFileName = fileName;
						OnIterate?.Invoke(new MonitorProgressArgs(fileName));

						var contents = File.ReadAllText(fileName);

						await Task.Delay(1, token);

						if (contents.Contains(searchString))
						{
							foundList.Add(fileName);
						}

						if (token.IsCancellationRequested)
						{
							token.ThrowIfCancellationRequested();
						}

					}
				}
				catch (Exception ex)
				{
					OnIterate?.Invoke(new MonitorProgressArgs($"Access denied {currentFileName}"));
				}

				return foundList;

			}
		}
	}

}