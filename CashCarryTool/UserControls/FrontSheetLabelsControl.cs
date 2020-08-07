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
			string totalAmbientPallets = LabelDetailsControl.Pallets.Count(x => x.Type == PalletType.Ambient).ToString();
			if (totalAmbientPallets == "0")
				totalAmbientPallets = "";

			string totalBulkAmbientPallets = LabelDetailsControl.Pallets.Count(x => x.Type == PalletType.BulkAmbient).ToString();
			if (totalBulkAmbientPallets == "0")
				totalBulkAmbientPallets = "";

			string totalIcePallets = LabelDetailsControl.Pallets.Count(x => x.Type == PalletType.Ice).ToString();
			if (totalIcePallets == "0")
				totalIcePallets = "";

			string totalBulkFrozenPallets = LabelDetailsControl.Pallets.Count(x => x.Type == PalletType.BulkFrozen).ToString();
			if (totalBulkFrozenPallets == "0")
				totalBulkFrozenPallets = "";
			
			string totalFrozenPallets = FrontSheetDetailsControl.FullyFillIn ? LabelDetailsControl.Pallets.Count(x => x.Type == PalletType.Frozen).ToString() : "";
			if (totalFrozenPallets == "0")
				totalFrozenPallets = "";

			int totalAmbientUnits = FrontSheetDetailsControl.Invoices.Sum(x => x.AmbientUnits);
			int totalBulkAmbientUnits = FrontSheetDetailsControl.Invoices.Sum(x => x.BulkAmbientUnits);

			int totalBulkFrozenUnits = FrontSheetDetailsControl.Invoices.Sum(x => x.BulkFrozenUnits);
			int totalFrozenUnits = FrontSheetDetailsControl.Invoices.Sum(x => x.FrozenUnits);

			int route = -1;
			if (FrontSheetDetailsControl.Invoices.Count > 0)
				route = FrontSheetDetailsControl.Invoices.First().Route;

			Clipboard.SetText($"{GeneralDetailsControl.CustomerCode}|{GeneralDetailsControl.Title}|" +
							  // Pallets
			                  "=[@[Total PF]]+[@[Total PA]]|" + 
							  $"=[@[Ice PF]] +[@[Bulk PF]] +[@[Normal PF]]|{totalIcePallets}|{totalBulkFrozenPallets}|{totalFrozenPallets}|" + // Frozen
			                  $"=[@[Bulk PA]] +[@[Normal PA]]|{totalBulkAmbientPallets}|{totalAmbientPallets}|" + // Ambient
							  // Units
			                  "=[@[Total UF]]+[@[Total UA]]|" + 
							  $"=[@[Bulk UF]]+[@[Normal UF]]|{totalBulkFrozenUnits}|{totalFrozenUnits}|" + // Frozen
							  $"=[@[Bulk UA]]+[@[Normal UA]]|{totalBulkAmbientUnits}|{totalAmbientUnits}|" + // Ambient
							  // Empty cells
			                  "||" + // Picker, Missings,
							  "||||" + // Pallet colours * 4
							  "|||=[@[End Time]]-[@[Start Time]]-[@Break]|=[@[Normal UF]]/(HOUR([@[Time Picking]])+MINUTE([@[Time Picking]])/60)|" + // Start Time, End time, Break, Time picking, Pick Rate
							  "|" + // 1-Frozen Lines 
							  "|||" + // Median, Mean, Mode
							  $"{route}"); // Route
		}
	}
}
