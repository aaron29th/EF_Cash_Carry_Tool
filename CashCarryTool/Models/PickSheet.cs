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
		private const int _linesPerPage = 60;
		private const int _dashedLineEvery = 3;
		private const float _clickGuideLineLength = 50;
		private readonly PdfDocument _doc;

		private readonly XPen solidBlackLine = new XPen(XColors.Red, 3);
		private readonly XPen solidRedLine = new XPen(XColors.Red, 3);
		private readonly XPen solidBlueLine = new XPen(XColors.Blue, 3);
		private readonly XPen solidGreenLine = new XPen(XColors.Green, 3);
		private readonly XPen dashedBlackLine = new XPen(XColors.Blue, 1)
		{
			DashStyle = XDashStyle.Dash,
			DashPattern = new[] { 4.0, 4.0 }
		};

		public List<string> FilePaths { get; set; }
		public List<List<bool>> SelectedLines { get; set; }

		public static void ProcessLineClicks(ref List<List<bool>> selectedLines, List<float> clickYLocations)
		{

		}

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

		private void OverlayGuideLine(XGraphics gfx, int lineIndex, double lineY)
		{
			if (lineIndex % 3 == 0)
				gfx.DrawLine(solidRedLine, 0, lineY, _clickGuideLineLength, lineY);
			else if (lineIndex % 3 == 1)
				gfx.DrawLine(solidBlueLine, 0, lineY, _clickGuideLineLength, lineY);
			else
				gfx.DrawLine(solidGreenLine, 0, lineY, _clickGuideLineLength, lineY);
		}

		private void OverlaySelected(XGraphics gfx, int lineIndex, double lineY)
		{
			gfx.DrawLine(solidBlackLine, 0, lineY, page.Width, lineY);
		}

		private void OverlayFixedLines(bool lineClickGuides)
		{
			if (_doc == null) return;

			for (int pageIndex = 0; pageIndex < _doc.PageCount; pageIndex++)
			{
				var page = _doc.Pages[pageIndex];
				using (XGraphics gfx = XGraphics.FromPdfPage(page))
				{
					

					// Draw lines
					for (int lineIndex = 0; lineIndex < _linesPerPage; lineIndex++)
					{
						double lineY = lineIndex * _lineHeight + _linesOffset;

						// Draw dashed line every ...
						if (lineIndex % _dashedLineEvery == 0)
							gfx.DrawLine(dashedBlackLine, 0, lineY, page.Width, lineY);

						// Draw click guides
						if (lineClickGuides) 
							OverlayGuideLine(gfx, lineIndex, lineY);

						OverlaySelected(gfx, lineIndex, lineY);
						
					}
				}
			}
		}

		private void InitSelectedLines()
		{
			SelectedLines = new List<List<bool>>();

			if (_doc == null) return;

			for (int pageIndex = 0; pageIndex < _doc.PageCount; pageIndex++)
			{
				SelectedLines.Add(new List<bool>());
				for (int lineIndex = 0; lineIndex < _linesPerPage; lineIndex++)
				{
					SelectedLines[pageIndex].Add(false);
				}
			}
		}

		private void OverlaySelectedLines()
		{
			if (_doc == null || SelectedLines == null) return;

			for (int pageIndex = 0; pageIndex < _doc.PageCount && pageIndex < SelectedLines.Count; pageIndex++)
			{
				var page = _doc.Pages[pageIndex];
				using (XGraphics gfx = XGraphics.FromPdfPage(page))
				{
					

					// Draw lines
					for (int lineIndex = 0; lineIndex < _linesPerPage && lineIndex < SelectedLines[pageIndex].Count; lineIndex++)
					{
						double lineY = lineIndex * _lineHeight + _linesOffset;

						if (!SelectedLines[pageIndex][lineIndex])
							continue;

						
					}
				}
			}
		}

		public void OverLayPdf(bool lineClickGuides)
		{
			OverlayFixedLines(lineClickGuides);

			if (SelectedLines == null || SelectedLines.Count == 0)
				InitSelectedLines();
			OverlaySelectedLines();
		}

		public Stream GetStream()
		{
			var stream = new MemoryStream();
			_doc.Save(stream);

			return stream;
		}
	}
}
