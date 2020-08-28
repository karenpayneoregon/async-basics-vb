using System;

namespace EnumerateFilesAsync.Classes
{
	namespace Classes
	{
		public class MonitorProgressArgs : EventArgs
		{
			public MonitorProgressArgs(string fileName)
			{
				CurrentFileName = fileName;
			}

			public string CurrentFileName {get;}
        }
	}
}