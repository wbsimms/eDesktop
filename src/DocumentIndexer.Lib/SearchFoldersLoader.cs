using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentIndexer.Lib
{
	public interface ISearchFoldersLoader
	{
		ISearchFolders LoadFolders();
	}

	public class SearchFoldersesLoader : ISearchFoldersLoader
	{
		private ISearchFolders folders;

		public SearchFoldersesLoader(ISearchFolders searchFolders)
		{
			folders = searchFolders;
		}

		public ISearchFolders LoadFolders()
		{
			this.folders.Folders.Add(@"C:\Users\Wm.Barrett\Documents");
			return folders;
		}
	}
}
