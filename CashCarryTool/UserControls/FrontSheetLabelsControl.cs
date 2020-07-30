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
using Eden_Farm_Cash___Carry_Tool.Models.Pick;
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
				Invoices = FrontSheetDetailsControl.Invoices,

				PartiallyFillIn = FrontSheetDetailsControl.PartiallyFillIn,
				FullyFillIn = FrontSheetDetailsControl.FullyFillIn
			};
		}

		private Models.FrontSheetLabels.Label InitLabel(bool hideDuplicates, Document doc = null)
		{
			return new Models.FrontSheetLabels.Label
			{
				Document = doc,

				Title = GeneralDetailsControl.Title,
				TitleSize = GeneralDetailsControl.TitleSize,
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

		public void LoadInvoicesData(List<Invoice> invoices)
		{
			FrontSheetDetailsControl.LoadInvoicesData(invoices);
			GeneralDetailsControl.LoadInvoicesData(invoices);
			LabelDetailsControl.LoadInvoicesData(invoices);
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

		public void JumpToPalletLabel(int pageNumber)
		{
			if (!FrontSheetLabelsPreviewControl.HideDuplicatePages)
				pageNumber *= LabelDetailsControl.NumLabelsPerPallet;
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

		private void CopyExcelLineBtn_Click(object sender, EventArgs e)
		{
			string totalPallets = FrontSheetDetailsControl.FullyFillIn ? LabelDetailsControl.Pallets.Count.ToString() : "";

			string totalAmbientPallets = LabelDetailsControl.Pallets.Count(x => x.Type == PalletType.Ambient).ToString();
			string totalBulkAmbientPallets = LabelDetailsControl.Pallets.Count(x => x.Type == PalletType.BulkAmbient).ToString();

			string totalIcePallets = LabelDetailsControl.Pallets.Count(x => x.Type == PalletType.Ice).ToString();
			string totalBulkFrozenPallets = LabelDetailsControl.Pallets.Count(x => x.Type == PalletType.BulkFrozen).ToString();
			string totalFrozenPallets = FrontSheetDetailsControl.FullyFillIn ? LabelDetailsControl.Pallets.Count(x => x.Type == PalletType.Frozen).ToString() : "";
			
			int totalUnits = FrontSheetDetailsControl.Invoices.Sum(x => x.AmbientUnits + x.BulkAmbientUnits + x.BulkFrozenUnits + x.FrozenUnits);

			int totalAmbientUnits = FrontSheetDetailsControl.Invoices.Sum(x => x.AmbientUnits);
			int totalBulkAmbientUnits = FrontSheetDetailsControl.Invoices.Sum(x => x.BulkAmbientUnits);

			int totalBulkFrozenUnits = FrontSheetDetailsControl.Invoices.Sum(x => x.BulkFrozenUnits);
			int totalFrozenUnits = FrontSheetDetailsControl.Invoices.Sum(x => x.FrozenUnits);

			Clipboard.SetText($"{GeneralDetailsControl.CustomerCode}|{GeneralDetailsControl.Title}|" +
							  // Pallets
			                  $"=OFFSET(INDIRECT(ADDRESS(ROW(),COLUMN())),0,1,1,1) + OFFSET(INDIRECT(ADDRESS(ROW(),COLUMN())),0,5,1,1)|=SUM(OFFSET(INDIRECT(ADDRESS(ROW(),COLUMN())),0,1,1,3))|{totalIcePallets}|{totalBulkFrozenPallets}|{totalFrozenPallets}|" + // Frozen
			                  $"=SUM(OFFSET(INDIRECT(ADDRESS(ROW(),COLUMN())),0,1,1,2))|{totalBulkAmbientPallets}|{totalAmbientPallets}|" + // Ambient
							  // Units
			                  $"=OFFSET(INDIRECT(ADDRESS(ROW(),COLUMN())),0,1,1,1) + OFFSET(INDIRECT(ADDRESS(ROW(),COLUMN())),0,4,1,1)|=SUM(OFFSET(INDIRECT(ADDRESS(ROW(),COLUMN())),0,1,1,2))|{totalBulkFrozenUnits}|{totalFrozenUnits}|" + // Frozen
							  $"=SUM(OFFSET(INDIRECT(ADDRESS(ROW(),COLUMN())),0,1,1,2))|{totalBulkAmbientUnits}|{totalAmbientUnits}|" + // Ambient
							  // Pick Date
			                  $"{GeneralDetailsControl.PickDate}");
		}
	}
}
