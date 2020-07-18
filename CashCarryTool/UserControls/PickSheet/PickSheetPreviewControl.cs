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
		public PickSheetPreviewControl()
		{
			InitializeComponent();
		}

		public void LoadPdfPreview(Models.PickSheet pickSheet)
		{
			var s = pickSheet.GetStream();
			var pdfDocument = PdfiumViewer.PdfDocument.Load(s);
			PdfRenderer.Load(pdfDocument);
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
