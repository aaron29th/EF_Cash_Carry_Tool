using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Eden_Farm_Cash___Carry_Tool.Models
{
	public class PickSheet
	{
		private const double _linesOffset = 60;
		private const double _lineHeight = 20;
		private const int _maxLinesPerPage = 5;
		private readonly PdfDocument _doc;

		public List<string> FilePaths { get; set; }
		public List<List<bool>> SelectedLines { get; set; }

		public PickSheet()
		{
			_doc = new PdfDocument();
		}

		public void ImportPdfs()
		{
			foreach (var path in FilePaths)
			{
				if (!File.Exists(path)) return;

				try
				{
					// Open the document to import pages from it.
					PdfDocument inputDocument = PdfReader.Open(path, PdfDocumentOpenMode.Import);

					// Iterate pages
					int count = inputDocument.PageCount;
					for (int i = 0; i < count; i++)
					{
						// Get the page from the external document...
						PdfPage page = inputDocument.Pages[i];
						// ...and add it to the output document.
						_doc.AddPage(page);
					}
				}
				catch
				{

				}
			}
		}

		public void OverLayPdf()
		{
			if (_doc == null || SelectedLines == null || SelectedLines.Count < _doc.PageCount) return;

			for (int pageNumber = 0; pageNumber < _doc.PageCount; pageNumber++)
			{
				var page = _doc.Pages[pageNumber];
				using (XGraphics gfx = XGraphics.FromPdfPage(page))
				{
					// Draw lines
					for (int lineNumber = 0; lineNumber < _maxLinesPerPage; lineNumber++)
					{
						double lineY = lineNumber * _lineHeight + _linesOffset;

						// Draw line ever 3
						if (lineNumber % 3 == 0)
						{
							XPen dashedBlackLine = new XPen(XColors.Blue, 1)
							{
								DashStyle = XDashStyle.Dash,
								DashPattern = new[] { 4.0, 4.0 }
							};
							gfx.DrawLine(dashedBlackLine, 0, lineY, page.Width, lineY);
						}

						// Draw selected lines
						if (!SelectedLines[pageNumber][lineNumber]) continue;

						XPen lineRed = new XPen(XColors.Red, 3);
						gfx.DrawLine(lineRed, 0, lineY, page.Width, lineY);
					}
				}
			}
		}

		public Stream GetStream()
		{
			var stream = new MemoryStream();
			_doc.Save(stream);

			return stream;
		}
	}
}
