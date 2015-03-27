using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentIndexer.Lib
{
	public interface ISearchFoldersValidator
	{
		void Validate(ISearchFolders folders);
	}

	public class SearchFoldersValidator : ISearchFoldersValidator
	{
		public SearchFoldersValidator()
		{
		}

		public void Validate(ISearchFolders folders)
		{
			foreach (var dir in folders.Folders)
			{
				if (!Directory.Exists(dir))
				{
					folders.Errors.Add(new SearchFolderErrors()
					{
						Error = "Folder not found",
						FolderPath = dir
					});
				}
			}
		}
	}
}
