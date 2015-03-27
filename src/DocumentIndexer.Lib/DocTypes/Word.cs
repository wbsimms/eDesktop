using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentIndexer.Lib.DocTypes
{
	public interface IWord : IIndexableDoc
	{
		
	}

	public class Word : IndexableDoc, IWord
	{
		public Word(string file)
		{
			this.Type = DocType.Word;
			string extension = Path.GetExtension(file);
			this.Extension = extension;
		}

		public override void GetContent()
		{
		}

		public override void IndexContent()
		{
		}

		public new IList<string> SupportedExtensions()
		{
			return new List<string>()
			{
				"docx",
			};
		}
	}
}
