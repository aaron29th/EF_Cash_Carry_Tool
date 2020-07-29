using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden_Farm_Cash___Carry_Tool.Models.Pick;
using Eden_Farm_Cash___Carry_Tool.StaticClasses;
using PdfiumViewer;
using PdfSharp.Pdf.IO;

namespace Eden_Farm_Cash___Carry_Tool.UserControls
{
	public partial class PickSheetControl : UserControl
	{
		private MainForm _parent;
		private Models.PickSheet _loadedPickSheet;

		public PickSheetControl()
		{
			InitializeComponent();

			PickSheetLoadControl.SetParent(this);
			PickSheetPreviewControl.SetParent(this);
		}

		public void SetParent(MainForm parent)
		{
			_parent = parent;
		}

		private Models.PickSheet GeneratePickSheet(bool guideLines)
		{
			var pickSheet = new Models.PickSheet()
			{
				FilePaths = PickSheetLoadControl.SelectedFilePaths,
				SelectedLines = PickSheetLoadControl.Lines
			};

			pickSheet.ImportPdfs();

			pickSheet.OverLayPdf(guideLines);

			return pickSheet;
		}

		private void LoadPreview()
		{
			if (PickSheetLoadControl.SelectedFilePaths.Count == 0)
			{
				PickSheetPreviewControl.ClearPreview();
				PickSheetLoadControl.Lines = new List<List<bool>>();
				return;
			};

			var pickSheet = GeneratePickSheet(PickSheetPreviewControl.ShowGuideLines);

			PickSheetPreviewControl.LoadPdfPreview(pickSheet);
			PickSheetLoadControl.Lines = pickSheet.SelectedLines;

			_loadedPickSheet = pickSheet;
		}

		public void PrintDocument()
		{
			var pickSheet = GeneratePickSheet(false);

		}

		public void OpenDocument()
		{
			var pickSheet = GeneratePickSheet(false);

			string filePath = TempDirectory.PickSheet.OpenPickSheetPath;
			pickSheet.Save(filePath);

			if (!File.Exists(filePath))
				return;

			Process.Start(filePath);
		}

		public void ConfigUpdated()
		{
			LoadPreview();
		}

		public void LineClicked(float clickYLocation, int pageIndex)
		{
			var result = _loadedPickSheet.ProcessLineClick(clickYLocation, pageIndex);
			if (result == null)
				return;

			PickSheetLoadControl.Lines = result;
			ConfigUpdated();
		}

		private Invoice ProcessInvoicePdf(string filePath, string customerName)
		{
			using (var doc = PdfDocument.Load(filePath))
			{
				var lines = new string[doc.PageCount];
				for (int pageIndex = 0; pageIndex < doc.PageCount; pageIndex++)
				{
					lines[pageIndex] = doc.GetPdfText(pageIndex);
				}

				var invoice = new Invoice();
				invoice.ProcessInvoice(lines, customerName);

				return invoice;
			}
		}

		private void CheckInvoiceConsistency(Invoice a, Invoice b)
		{
			if (a.CustomerCode != b.CustomerCode)
				throw new InvoiceException("Customer code is inconsistent");
			if (!a.DeliveryBy.Equals(b.DeliveryBy))
				throw new InvoiceException("Delivery date is inconsistent");
		}

		public void ImportData()
		{
			var loadedInvoices = new List<Invoice>();

			foreach (var filePath in PickSheetLoadControl.SelectedFilePaths)
			{
				try
				{
					if (loadedInvoices.Count == 0)
						loadedInvoices.Add(ProcessInvoicePdf(filePath, null));
					else
					{
						loadedInvoices.Add(ProcessInvoicePdf(filePath, loadedInvoices[0].CustomerName));
						CheckInvoiceConsistency(loadedInvoices[0], loadedInvoices.Last());
					}
				}
				catch (PdfiumViewer.PdfException ex)
				{

				}
				catch (InvoiceException ex)
				{
					MessageBox.Show("Error parsing invoice in file" + 
					                Environment.NewLine +
					                Environment.NewLine +
									filePath + 
					                Environment.NewLine + 
					                Environment.NewLine + 
					                ex.Message, "Error parsing invoice",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			_parent?.LoadInvoices(loadedInvoices);
		}
	}
}
