using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Eden_Farm_Cash___Carry_Tool.Models
{
	public class PickSheet
	{
		private const double _linesOffsetPage1 = 199;
		private const int _linesPerPagePage1 = 42;

		private const double _linesOffset = _linesOffsetPage1 - _lineHeight * 7;
		private const int _linesPerPage = 49;

		private const double _lineHeight = 432D / 35D;
		private const int _dashedLineEvery = 3;
		private const float _clickGuideLineLength = 50;
		private const float _LineLeftMargin = 10;
		private readonly PdfDocument _doc;
		private readonly List<int> _pageNumbers = new List<int>();

		private readonly XFont _lineNumberFont = new XFont(FontFamily.GenericSerif, 8, XFontStyle.Regular);

		private readonly XPen solidBlackLine = new XPen(XColors.Black, 1);
		private readonly XPen solidRedLine = new XPen(XColors.Red, 1);
		private readonly XPen solidBlueLine = new XPen(XColors.Blue, 1);
		private readonly XPen solidGreenLine = new XPen(XColors.Green, 1);
		private readonly XPen dashedBlackLine = new XPen(XColors.Black, 1)
		{
			DashStyle = XDashStyle.Dash,
			DashPattern = new[] { 4.0, 4.0 }
		};

		public List<string> FilePaths { get; set; }
		public List<List<bool>> SelectedLines { get; set; }
		
		public  List<List<bool>> ProcessLineClick(float clickYLocation, int pageIndex)
		{
			if (pageIndex >= SelectedLines.Count || pageIndex < 0)
				return null;

			// Adjust page offset for page 1
			var offset = _linesOffset;
			if (_pageNumbers[pageIndex] == 1)
				offset = _linesOffsetPage1;

			var lineNumberRuff = (clickYLocation - offset) / _lineHeight;
			int lineNumber = (int) Math.Round(lineNumberRuff, MidpointRounding.AwayFromZero);

			if (lineNumber >= SelectedLines[pageIndex].Count || lineNumber < 0)
				return null;

			SelectedLines[pageIndex][lineNumber] = !SelectedLines[pageIndex][lineNumber];

			return SelectedLines;
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

		private void DetectPageNumbers()
		{
			if (_doc == null || _doc.PageCount == 0) 
				return;

			var s = new MemoryStream();
			_doc.Save(s);

			var doc = PdfiumViewer.PdfDocument.Load(s);
			for (int pageIndex = 0; pageIndex < doc.PageCount; pageIndex++)
			{
				var pageText = doc.GetPdfText(pageIndex);

				// Match page number
				Regex pageNumberRegex = new Regex(@"(Page: )([0-9]+)");
				var pageNumberMatch = pageNumberRegex.Match(pageText);
				if (pageNumberMatch.Groups.Count < 3)
				{
					_pageNumbers.Add(-1);
					continue;
				}

				_pageNumbers.Add(Convert.ToInt32(pageNumberMatch.Groups[2].Value));
			}
		}

		private void OverlayGuideLine(XGraphics gfx, int lineIndex, double lineY)
		{
			if (lineIndex % 3 == 0)
				gfx.DrawLine(solidRedLine, _LineLeftMargin, lineY, _clickGuideLineLength, lineY);
			else if (lineIndex % 3 == 1)
				gfx.DrawLine(solidBlueLine, _LineLeftMargin, lineY, _clickGuideLineLength, lineY);
			else
				gfx.DrawLine(solidGreenLine, _LineLeftMargin, lineY, _clickGuideLineLength, lineY);

			// Add line number
			gfx.DrawString(lineIndex.ToString(), _lineNumberFont, new XSolidBrush(), new PointF(0, (float)lineY + 3));
		}

		private void InitSelectedLines()
		{
			SelectedLines = new List<List<bool>>();
			
			if (_doc == null) 
				return;

			for (int pageIndex = 0; pageIndex < _doc.PageCount; pageIndex++)
			{
				SelectedLines.Add(new List<bool>());

				// Reduce number of lines on first page
				var numLines = _linesPerPage;
				if (_pageNumbers[pageIndex] == 1)
					numLines = _linesPerPagePage1;

				for (int lineIndex = 0; lineIndex < numLines; lineIndex++)
				{
					SelectedLines[pageIndex].Add(false);
				}
			}
		}

		public void OverLayPdf(bool lineClickGuides)
		{
			if (_doc == null) 
				return;

			DetectPageNumbers();
			if (SelectedLines == null || SelectedLines.Count == 0)
				InitSelectedLines();

			for (int pageIndex = 0; pageIndex < _doc.PageCount; pageIndex++)
			{
				// Reduce number of lines on first page
				var numLines = _linesPerPage;
				if (_pageNumbers[pageIndex] == 1)
					numLines = _linesPerPagePage1;

				var page = _doc.Pages[pageIndex];
				using (XGraphics gfx = XGraphics.FromPdfPage(page))
				{
					// Draw lines
					for (int lineIndex = 0; lineIndex < numLines; lineIndex++)
					{
						double lineY = lineIndex * _lineHeight + _linesOffset;
						if (_pageNumbers[pageIndex] == 1)
							lineY = lineIndex * _lineHeight + _linesOffsetPage1;

						// Draw dashed line every ...
						if (lineIndex % _dashedLineEvery == 0)
							gfx.DrawLine(dashedBlackLine, _LineLeftMargin, lineY, page.Width, lineY);

						// Draw click guides
						if (lineClickGuides)
							OverlayGuideLine(gfx, lineIndex, lineY);

						if (pageIndex < SelectedLines.Count && SelectedLines[pageIndex][lineIndex])
							gfx.DrawLine(solidBlackLine, _LineLeftMargin, lineY, page.Width, lineY);

					}
				}
			}
		}

		public Stream GetStream()
		{
			if (_doc.PageCount == 0)
				return null;
			var stream = new MemoryStream();
			_doc.Save(stream);

			return stream;
		}

		public void Save(string filePath)
		{
			if (_doc.PageCount == 0)
				return;
			_doc.Save(filePath);
		}
	}
}
