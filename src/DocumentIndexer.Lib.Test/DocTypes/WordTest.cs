using System;
using DocumentIndexer.Lib.DocTypes;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocumentIndexer.Lib.Test.DocTypes
{
	[TestClass]
	public class WordTest
	{
		[TestMethod]
		public void ConstructorTest()
		{
			var word = Resolver.Instance.Container.Resolve<IWord>();
			Assert.IsNotNull(word);
		}

		[TestMethod]
		public void ExecuteTest()
		{
			var word = Resolver.Instance.Container.Resolve<IWord>();
			IndexModel model = new IndexModel() { FileName = @"C:\Projects\eDesktop\TestData\TestWord.docx" };
			var result = word.Execute(model);
			Assert.IsNotNull(result);
			Assert.IsFalse(result.HasError);
		}
	}
}
