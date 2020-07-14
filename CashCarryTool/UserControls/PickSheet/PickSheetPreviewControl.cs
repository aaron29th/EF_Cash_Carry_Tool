using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumViewer;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfDocument = PdfSharp.Pdf.PdfDocument;

namespace Eden_Farm_Cash___Carry_Tool.UserControls.PickSheet
{
	public partial class PickSheetPreviewControl : UserControl
	{
		private const double _linesOffset = 60;
		private const double _lineHeight = 20;
		private const int _maxLinesPerPage = 5;

		private List<List<bool>> _selectedLines;
		private string _pickPdfPath;

		public PickSheetPreviewControl()
		{
			InitializeComponent();
		}

		public void SetPickPdfPath(string filePath)
		{
			if (!File.Exists(filePath)) return;

			_pickPdfPath = filePath;

			var doc = OverlayPdf();
			if (doc == null) return;
			LoadPdfPreview(doc);
		}

		private void LoadPdfPreview(PdfDocument doc)
		{
			var stream = new MemoryStream();
			doc.Save(stream);

			var pdfDocument = PdfiumViewer.PdfDocument.Load(stream);
			PdfRenderer.Load(pdfDocument);
		}

		private PdfDocument LoadPdf()
		{
			if (!File.Exists(_pickPdfPath)) return null;

			try
			{
				var doc = PdfReader.Open(_pickPdfPath, PdfDocumentOpenMode.Modify);
				
				_selectedLines = new List<List<bool>>();
				for (int pageNumber = 0; pageNumber < doc.PageCount; pageNumber++)
				{
					_selectedLines.Add(new List<bool>());
					for (int lineNumber = 0; lineNumber < _maxLinesPerPage; lineNumber++)
					{
						_selectedLines[pageNumber].Add(false);
					}
				}

				return doc;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		private PdfDocument OverlayPdf()
		{
			var doc = LoadPdf();
			if (doc == null) return null;

			for (int pageNumber = 0; pageNumber < doc.PageCount; pageNumber++)
			{
				var page = doc.Pages[pageNumber];
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
								DashPattern = new []{ 4.0, 4.0 }
							};
							gfx.DrawLine(dashedBlackLine, 0, lineY, page.Width, lineY);
						}

						// Draw selected lines
						if (!_selectedLines[pageNumber][lineNumber]) continue;

						XPen lineRed = new XPen(XColors.Red, 3);
						gfx.DrawLine(lineRed, 0, lineY, page.Width, lineY);
					}
				}
			}

			return doc;
		}

		private void PdfRenderer_Click(object sender, EventArgs e)
		{
			if (e is MouseEventArgs args && sender is PdfRenderer renderer)
			{
				var point = renderer.PointToPdf(args.Location);
				var pageHeight = 300;
				var pageY = pageHeight - point.Location.Y;

			}
		}
	}
}
