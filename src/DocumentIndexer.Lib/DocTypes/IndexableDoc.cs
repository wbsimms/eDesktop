using System.Collections.Generic;

namespace DocumentIndexer.Lib.DocTypes
{
	public interface IIndexableDoc
	{
		DocType Type { get; }
		string Extension { get; }
		void GetContent();
		void IndexContent();
		IList<string> SupportedExtensions();
	}

	public abstract class IndexableDoc : IIndexableDoc
	{
		public DocType Type { get; protected set; }
		public string Extension { get; protected set; }
		public abstract void GetContent();
		public abstract void IndexContent();

		public IList<string> SupportedExtensions()
		{
			return new List<string>();
		}

		protected bool IsExtensionSupported(string extension)
		{
			return SupportedExtensions().Contains(extension);
		}
	}
}