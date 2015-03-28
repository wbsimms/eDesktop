using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicEngine.Lib;
using Microsoft.Practices.ObjectBuilder2;

namespace DocumentIndexer.Lib
{
	public interface IIndexer
	{
		void Execute();
	}

	public class Indexer : IIndexer
	{
		private IRuleCollection<IndexModel> rules;
		private Engine<IndexModel> engine;
		private ISearchFolders folders;

		public Indexer(IRuleCollection<IndexModel> rules, ISearchFolders folders)
		{
			engine = new LogicEngine.Lib.Engine<IndexModel>(rules);
			this.rules = rules;
			this.folders = folders;
		}

		public void Execute()
		{
			foreach (var folder in folders.Folders)
			{
				IndexFolder(folder);
			}
		}

		public void IndexFolder(string folder)
		{
			var files = Directory.EnumerateFiles(folder);
			foreach (string file in files)
			{
				engine.Execute(new IndexModel() {FileName = file});

			}
			var directories = Directory.EnumerateDirectories(folder);
			directories.ForEach(IndexFolder);

		}
	}
}
