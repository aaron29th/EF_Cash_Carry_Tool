using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Eden_Farm_Cash___Carry_Tool.UserControls.PickSheet
{
	public partial class PickSheetPreviewControl : UserControl
	{
		public PickSheetPreviewControl()
		{
			InitializeComponent();

			PdfDocument PDFDoc = PdfReader.Open("res/example.pdf", PdfDocumentOpenMode.Import);
			PdfDocument PDFNewDoc = new PdfDocument();
			for (int Pg = 0; Pg < PDFDoc.Pages.Count; Pg++)
			{
				PDFNewDoc.AddPage(PDFDoc.Pages[Pg]);
			}

			//PdfPage pdfPage = yourPDFdoc.AddPage();
			PdfPage pdfPage = PDFNewDoc.Pages[0];
			pdfPage.Width = XUnit.FromMillimeter(210);
			pdfPage.Height = XUnit.FromMillimeter(297);

			using (XGraphics gfx = XGraphics.FromPdfPage(pdfPage))
			{
				XPen lineRed = new XPen(XColors.Red, 5);

				gfx.DrawLine(lineRed, 0, pdfPage.Height / 2, pdfPage.Width, pdfPage.Height / 2);
			}

			PDFNewDoc.Save("res/new.pdf");
			//PDFNewDoc.

			//PickSheetPreview.
		}
	}
}
