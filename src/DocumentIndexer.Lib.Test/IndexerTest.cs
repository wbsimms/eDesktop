using System;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentIndexer.Lib.Test
{
	[TestClass]
	public class IndexerTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			var indexer = Resolver.Instance.Container.Resolve<IIndexer>();
			Assert.IsNotNull(indexer);
		}

		[TestMethod]
		public void ExecuteTest()
		{
			var searchFolders = new SearchFolders();
			searchFolders.Folders.Add(@"C:\Users\Wm.Barrett\OneDrive\Documents\CaseStudies\");

			Resolver.Instance.Container.RegisterInstance(searchFolders);

			var indexer = Resolver.Instance.Container.Resolve<IIndexer>();
			indexer.Execute();

		}

	}
}
