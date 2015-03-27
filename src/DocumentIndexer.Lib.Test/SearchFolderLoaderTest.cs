using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DocumentIndexer.Lib.Test
{
	[TestClass]
	public class SearchFolderLoaderTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			var loader = Resolver.Instance.Container.Resolve<ISearchFoldersLoader>();
			Assert.IsNotNull(loader);
		}

		[TestMethod]
		public void LoadFoldersTest()
		{
			Mock<ISearchFolders> mock = new Mock<ISearchFolders>();
			mock.Setup(x => x.Errors).Returns(() => new List<SearchFolderErrors>());
			mock.Setup(x => x.Folders).Returns(() => new List<string>());
			Resolver.Instance.Container.RegisterInstance(mock.Object);

			var loader = Resolver.Instance.Container.Resolve<ISearchFoldersLoader>();

			var folders = loader.LoadFolders();
			Assert.IsNotNull(folders);
		}
	}
}
