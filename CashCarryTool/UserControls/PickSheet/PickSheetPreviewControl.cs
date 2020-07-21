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
	public partial class PickSheetPreviewControl : PickSheetControlBase
	{
		private Rectangle _currentDisplayRectangle;

		public PickSheetPreviewControl()
		{
			InitializeComponent();
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

		}

		private void PrintBtn_Click(object sender, EventArgs e)
		{
			_parent?.PrintDocument();
		}

		private void ImportDataBtn_Click(object sender, EventArgs e)
		{

		}
	}
}
