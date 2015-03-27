using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentIndexer.Lib
{
	public interface ISearchFolders
	{
		IList<SearchFolderErrors> Errors { get; }
		IList<string> Folders { get; }
	}

	public class SearchFolders : ISearchFolders
	{
		public SearchFolders()
		{
			this.Errors = new List<SearchFolderErrors>();
			this.Folders = new List<string>();
		}

		public IList<SearchFolderErrors> Errors { get; private set; }
		public IList<string> Folders { get; private set; }

	}

	public class SearchFolderErrors
	{
		public string Error { get; set; }
		public string FolderPath { get; set; }
	}
}
