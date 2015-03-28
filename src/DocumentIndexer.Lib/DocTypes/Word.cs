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

			var toSave = new LocalDocument()
			{
				Content = sb.ToString(),
				Extension = this.Extension,
				Path = model.FileName
			};

			using (WordprocessingDocument doc = WordprocessingDocument.Open(model.FileName, false))
			{
				var allParagraphs = doc.MainDocumentPart.Document.Body.Elements<Paragraph>();
				toSave.Title = doc.CoreFilePropertiesPart.OpenXmlPackage.PackageProperties.Title;
				toSave.Creator = doc.CoreFilePropertiesPart.OpenXmlPackage.PackageProperties.Creator;
				toSave.DateCreated = doc.CoreFilePropertiesPart.OpenXmlPackage.PackageProperties.Created.Value;
				toSave.DateModified = doc.CoreFilePropertiesPart.OpenXmlPackage.PackageProperties.Modified.Value;
				toSave.Tags = doc.CoreFilePropertiesPart.OpenXmlPackage.PackageProperties.Keywords;

				foreach (var p in allParagraphs)
				{
					sb.AppendLine(p.InnerText);
				}
			}
			retval.Message = sb.ToString();
			retval.TimeEnd = DateTime.UtcNow;
			
 			var indexResult = this.ElasticClient.Index<LocalDocument>(toSave);
			model.Id = indexResult.Id;
			return retval;
		}
	}

	public class LocalDocument
	{
		public LocalDocument()
		{
		}

		public string Title { get; set; }

		public string Content { get; set; }
		public string Creator { get; set; }
		public string Extension { get; set; }
		public string Path { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
		public string Tags { get; set; }
 
	}
}
