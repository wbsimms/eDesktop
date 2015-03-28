using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicEngine.Lib;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Nest;


namespace DocumentIndexer.Lib.DocTypes
{
	public interface IWord : IIndexableDoc, IRule<IndexModel>
	{
		
	}

	public class Word : IndexableDoc, IWord 
	{
		public Word(IElasticClient client) : base(client)
		{
			this.Type = DocType.Word;
			this.SupportedExtensions = new List<string>()
			{
				".docx",
			};
		}


		public IEngineResult Execute(IndexModel model)
		{
			var retval = new EngineResult() {TimeStart = DateTime.UtcNow};
			this.model = model;
			string extension = Path.GetExtension(model.FileName);
			if (!this.IsExtensionSupported(extension))
			{
				retval.TimeEnd = DateTime.UtcNow;
				return retval;
			}
			this.Extension = extension;

			StringBuilder sb = new StringBuilder();
			using (WordprocessingDocument doc = WordprocessingDocument.Open(model.FileName, false))
			{
				var allParagraphs = doc.MainDocumentPart.Document.Body.Elements<Paragraph>();
				foreach (var p in allParagraphs)
				{
					sb.AppendLine(p.InnerText);
				}
			}
			retval.Message = sb.ToString();

			retval.TimeEnd = DateTime.UtcNow;
			return retval;
		}
	}
}
