using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden_Farm_Cash___Carry_Tool.Models;
using Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels;
using MigraDoc.DocumentObjectModel;

namespace Eden_Farm_Cash___Carry_Tool.UserControls
{
	public partial class FrontSheetLabelsControl : UserControl
	{
		private PrinterSettings PrinterSettingsDialog()
		{
			PrinterSettings printerSettings = new PrinterSettings();

			using (PrintDialog dialog = new PrintDialog())
			{
				dialog.PrinterSettings = printerSettings;
				dialog.AllowSelection = true;
				dialog.AllowSomePages = true;
				var result = dialog.ShowDialog();

				if (result == DialogResult.OK)
				{
					return printerSettings;
				}
			}

			return null;
		}

		private FrontSheet InitFrontSheet()
		{
			return new FrontSheet()
			{
				Title = GeneralDetailsControl.Title,
				CustomerCode = GeneralDetailsControl.CustomerCode,
				DeliveryDate = GeneralDetailsControl.DeliveryDate,
				PickDate = GeneralDetailsControl.PickDate,

				Pallets = LabelDetailsControl.Pallets,
				NumCopiesPerPallet = LabelDetailsControl.NumLabelsPerPallet,

				SecondRun = LabelDetailsControl.SecondRun,
				VehicleRegistration = LabelDetailsControl.VehicleRegistration,

				FullPalletBreakDown = FrontSheetDetailsControl.FullPalletBreakdown,
				InvoiceNumbers = FrontSheetDetailsControl.InvoiceNumbers
			};
		}

		private Models.FrontSheetLabels.Label InitLabel(bool hideDuplicates, Document doc = null)
		{
			return new Models.FrontSheetLabels.Label
			{
				Document = doc,

				Title = GeneralDetailsControl.Title,
				CustomerCode = GeneralDetailsControl.CustomerCode,
				DeliveryDate = GeneralDetailsControl.DeliveryDate,

				Pallets = LabelDetailsControl.Pallets,
				NumCopiesPerPallet = hideDuplicates
					? 1
					: LabelDetailsControl.NumLabelsPerPallet,

				ShowPalletNumber = LabelDetailsControl.ShowPalletNumber,
				ShowPalletNumberOf = LabelDetailsControl.ShowPalletNumberOf,
				ShowTotalPalletNumber = LabelDetailsControl.ShowTotalPalletNumber,

				SecondRun = LabelDetailsControl.SecondRun,
				VehicleRegistration = LabelDetailsControl.VehicleRegistration
			};
		}

		private void LoadFrontSheet()
		{
			var frontSheet = InitFrontSheet();

			frontSheet.AddFrontSheet();

			FrontSheetLabelsPreviewControl.LoadFrontSheetPreview(frontSheet.Document);
		}

		private void LoadLabel()
		{
			var label = InitLabel(FrontSheetLabelsPreviewControl.HideDuplicatePages);

			label.AddLabel();

			FrontSheetLabelsPreviewControl.LoadLabelPreview(label.Document);

		}

		public void Reload()
		{
			LoadFrontSheet();
			LoadLabel();
		}

		public void DetailsUpdate()
		{
			if (FrontSheetLabelsPreviewControl.LiveReload) Reload();
		}

		public void SetPreviewPageNumber(int pageNumber)
		{
			FrontSheetLabelsPreviewControl.SetPreviewPageNumber(pageNumber);
		}

		public void PrintFrontSheet()
		{
			var printerSettings = PrinterSettingsDialog();
			if (printerSettings == null) return;

			var frontSheet = InitFrontSheet();
			frontSheet.AddFrontSheet();
			var doc = frontSheet.Document;

			MigraDocPrintDocument printDocument = new MigraDocPrintDocument(doc) {PrinterSettings = printerSettings};

			// Attach the current printer settings
			if (printerSettings.PrintRange == PrintRange.Selection)
				throw new NotImplementedException();

			// Print the document
			printDocument.Print();
		}

		public void PrintLabels()
		{
			var printerSettings = PrinterSettingsDialog();
			if (printerSettings == null) return;

			var label = InitLabel(false);
			label.AddLabel();
			var doc = label.Document;

			MigraDocPrintDocument printDocument = new MigraDocPrintDocument(doc) { PrinterSettings = printerSettings };

			// Attach the current printer settings
			if (printerSettings.PrintRange == PrintRange.Selection)
				throw new NotImplementedException();

			// Print the document
			printDocument.Print();
		}

		public void PrintBoth()
		{
			var printerSettings = PrinterSettingsDialog();
			if (printerSettings == null) return;

			var frontSheet = InitFrontSheet();
			frontSheet.AddFrontSheet();
			var doc = frontSheet.Document;

			var label = InitLabel(false, doc);
			label.AddLabel();

			MigraDocPrintDocument printDocument = new MigraDocPrintDocument(doc) { PrinterSettings = printerSettings };

			// Attach the current printer settings
			if (printerSettings.PrintRange == PrintRange.Selection)
				throw new NotImplementedException();

			// Print the document
			printDocument.Print();
		}

		public FrontSheetLabelsControl()
		{
			InitializeComponent();

			GeneralDetailsControl.SetParent(this);
			FrontSheetDetailsControl.SetParent(this);
			LabelDetailsControl.SetParent(this);
			FrontSheetLabelsPreviewControl.SetParent(this);

			Reload();
		}
	}
}
