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
using Eden_Farm_Cash___Carry_Tool.StaticClasses;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfiumViewer;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Orientation = MigraDoc.DocumentObjectModel.Orientation;
using PdfDocument = PdfSharp.Pdf.PdfDocument;

namespace Eden_Farm_Cash___Carry_Tool.UserControls.PickSheet
{
	public partial class PickSheetPreviewControl : PickSheetControlBase
	{
		private Rectangle _currentDisplayRectangle;

		public bool ShowGuideLines { get; set; }

		private void ConfigUpdated()
		{
			_parent?.ConfigUpdated();
		}

		public PickSheetPreviewControl()
		{
			InitializeComponent();
			ShowGuideLines = ShowGuidesCheck.Checked;
		}

		public void ClearPreview()
		{
			// Create a new MigraDoc document
			var migraDoc = new Document();
			migraDoc.DefaultPageSetup.Orientation = Orientation.Portrait;
			var section = migraDoc.AddSection();
			section.PageSetup.LeftMargin = 12;
			var table = LayoutHelper.AddEqualWidthTable(1, 15, section);
			table.Format.Font.Size = 15;

			table.Rows[0].Cells[0].Format.Font.Size = 20;
			table.Rows[0].Cells[0].AddParagraph("Copyright 2020 Aaron Rosser");

			table.Rows[2].Cells[0].AddParagraph("Full licenses can be found in the license folder");

			table.Rows[4].Cells[0].AddParagraph("PdfSharp / MigraDoc");
			table.Rows[5].Cells[0].AddParagraph("MIT License - Copyright (c) 2005-2014 empira Software GmbH, Troisdorf (Germany)");

			table.Rows[7].Cells[0].AddParagraph("CsvHelper");
			table.Rows[8].Cells[0].AddParagraph("Apache 2.0 - Josh Close");

			table.Rows[10].Cells[0].AddParagraph("Pdfium Viewer");
			table.Rows[11].Cells[0].AddParagraph("Apache 2.0 - Pieter van Ginkel");

			table.Rows[13].Cells[0].AddParagraph("Pdfium");
			table.Rows[14].Cells[0].AddParagraph("Copyright 2014, the V8 project authors");

			// Render document
			const bool unicode = true;
			PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode)
			{
				Document = migraDoc
			};
			pdfRenderer.RenderDocument();

			var s = new MemoryStream();
			pdfRenderer.PdfDocument.Save(s);

			var doc = PdfiumViewer.PdfDocument.Load(s);
			PdfRenderer.Load(doc);
		}

		public void LoadPdfPreview(Models.PickSheet pickSheet)
		{
			var s = pickSheet.GetStream();
			var pdfDocument = PdfiumViewer.PdfDocument.Load(s);

			var firstPageYOffset = _currentDisplayRectangle.Height / 2 - (PdfRenderer.Bounds.Height / 2);

			Rectangle oldDisplayRectangle = _currentDisplayRectangle;
			oldDisplayRectangle.Y = (Math.Abs(oldDisplayRectangle.Y) - firstPageYOffset);

			PdfRenderer.Load(pdfDocument);

			PdfRenderer.ScrollIntoView(oldDisplayRectangle);
			
		}

		private void PdfRenderer_Click(object sender, EventArgs e)
		{
			if (e is MouseEventArgs args && sender is PdfRenderer renderer)
			{
				var point = renderer.PointToPdf(args.Location);
				var pageHeight = renderer.Bounds.Height;

				pageHeight = 841;
				
				var pageY = pageHeight - point.Location.Y;

				_parent?.LineClicked(pageY, point.Page);
			}
		}

		private void PdfRenderer_DisplayRectangleChanged(object sender, EventArgs e)
		{
			_currentDisplayRectangle = PdfRenderer.DisplayRectangle;
		}

		private void ShowGuidesCheck_CheckedChanged(object sender, EventArgs e)
		{
			ShowGuideLines = ShowGuidesCheck.Checked;
			ConfigUpdated();
		}

		private void PrintBtn_Click(object sender, EventArgs e)
		{
			_parent?.PrintDocument();
		}

		private void ImportDataBtn_Click(object sender, EventArgs e)
		{

		}

		private void OpenBtn_Click(object sender, EventArgs e)
		{
			_parent?.OpenDocument();
		}
	}
}
