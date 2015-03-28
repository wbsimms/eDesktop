using System.Collections.Generic;
using Nest;

namespace DocumentIndexer.Lib.DocTypes
{
	public interface IIndexableDoc
	{
		DocType Type { get; }
		string Extension { get; }
		IList<string> SupportedExtensions { get; }
	}

	public class IndexableDoc : IIndexableDoc
	{
		public DocType Type { get; protected set; }
		public string Extension { get; protected set; }
		public IList<string> SupportedExtensions { get; protected set; } 
		protected IElasticClient ElasticClient;
		protected IndexModel model;

		public IndexableDoc(IElasticClient client)
		{
			this.ElasticClient = client;
		}

		protected bool IsExtensionSupported(string extension)
		{
			return this.SupportedExtensions.Contains(extension);
		}
	}
}