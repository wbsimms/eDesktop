using System;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentIndexer.Lib.Test
{
	[TestClass]
	public class ResolverTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			var resolver = Resolver.Instance;
			Assert.IsNotNull(resolver);
		}

		[TestMethod]
		public void ContainerTest()
		{
			var container = Resolver.Instance.Container;
			var searcher = container.Resolve<ISearcher>();
			var searchFolders = container.Resolve<ISearchFolders>();

			Assert.IsNotNull(searcher);
			Assert.IsNotNull(searchFolders);
		}


		[TestMethod]
		public void ResetTest()
		{
			Resolver.Instance.Reset();
		}
	}
}
