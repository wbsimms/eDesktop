using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DocumentIndexer.Lib.Test
{
	[TestClass]
	public class SearchFoldersValidatorsTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			ISearchFoldersValidator validator = Resolver.Instance.Container.Resolve<ISearchFoldersValidator>();
			Assert.IsNotNull(validator);
		}

		[TestMethod]
		public void ValidateTest()
		{
			ISearchFoldersValidator validator = Resolver.Instance.Container.Resolve<ISearchFoldersValidator>();

			ISearchFolders folders = new SearchFolders();
			folders.Folders.Add("blah");
			folders.Folders.Add(@"C:\Windows");

			validator.Validate(folders);
			Assert.IsNotNull(folders.Errors);
			Assert.IsNotNull(folders.Errors.Count == 1);
		}
	}
}
