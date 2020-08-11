using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Eden_Farm_Cash___Carry_Tool.Models.Pick;
using Eden_Farm_Cash___Carry_Tool.StaticClasses;
using InvoiceTools.InvoiceModels;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using Section = MigraDoc.DocumentObjectModel.Section;

namespace Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels
{
	class FrontSheet
	{
		private const float _borderWidth = 2;

		public Document Document;
		private Section _currentSection;

		public string Title { get; set; }
		public string CustomerCode { get; set; }
		public string DeliveryDate { get; set; }
		public string PickDate { get; set; }

		public List<Pallet> Pallets { get; set; }
		public int NumCopiesPerPallet { get; set; }
		public bool SecondRun { get; set; }
		public string VehicleRegistration { get; set; }

		public bool FullPalletBreakDown { get; set; }
		public List<Invoice> Invoices { get; set; }
		public bool PartiallyFillIn { get; set; }
		public bool FullyFillIn { get; set; }

		private void AddSpace(float space)
		{
			LayoutHelper.AddSpaceAfter(_currentSection, space);
		}

		private void AddCustomer()
		{
			var table = LayoutHelper.AddEqualWidthTable(2, 2, _currentSection, _borderWidth, true);

			// Customer
			table.Rows[0].Format.Font.Size = 8;
			table.Rows[1].Format.Font.Size = 20;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "Customer");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[0], Title);

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "Account");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[1], CustomerCode);
		}

		private void AddDates()
		{
			var table = LayoutHelper.AddEqualWidthTable(2, 3, _currentSection, _borderWidth, true);
			table.Rows[0].Format.Font.Size = 8;
			table.Rows[1].Format.Font.Size = 4;
			table.Rows[2].Format.Font.Size = 12;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "Date Picked");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[0], "");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[0], PickDate);

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "Delivery Date");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[1], "");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[1], DeliveryDate);
		}

		private void AddInvoices()
		{
			var table = LayoutHelper.AddEqualWidthTable(3, 3, _currentSection, _borderWidth);
			table.Format.Font.Size = 15;

			table.Rows[0].Format.Font.Size = 8;
			table.Rows[0].Format.Alignment = ParagraphAlignment.Center;
			table.Rows[0].Cells[1].AddParagraph("Invoices");

			for (int i = 0; i < 6; i++)
			{
				int rowIndex = i / 3 + 1;
				int columnIndex = i % 3;
				var invoicePara = LayoutHelper.CellAddParagraphWithSpace(table.Rows[rowIndex].Cells[columnIndex], "");
				
				if (i >= Invoices.Count) 
					continue;

				var invoiceNumberText = new FormattedTextHelper(Invoices[i].InvoiceNumber.ToString());
				invoiceNumberText.Size = 8;
				invoiceNumberText.Bold = true;
				invoicePara.Add(invoiceNumberText);

				// Unit totals
				int totalUnits = Invoices[i].BulkAmbientUnits + Invoices[i].AmbientUnits + Invoices[i].BulkFrozenUnits + Invoices[i].FrozenUnits;
				if (totalUnits <= 0)
					continue;

				invoicePara.AddSpace(1);

				var unitsText = new FormattedTextHelper($"| {totalUnits} T | {Invoices[i].FrozenUnits} F | {Invoices[i].BulkFrozenUnits} B/F | {Invoices[i].AmbientUnits} A | {Invoices[i].BulkAmbientUnits} B/A ");
				unitsText.Size = 7;
				invoicePara.Add(unitsText);

			}
		}

		private void AddPalletBreakdown()
		{
			//var table = LayoutHelper.AddEqualWidthTable(6, 22, _currentSection, _borderWidth);
			var table = LayoutHelper.AddWeightedWidthTable(new List<float>(){ 0.4f, 1, 1, 1, 1, 1, 0.2f, 0.4f, 1, 1, 1, 1, 1 }, 11, _currentSection, _borderWidth);
			table.Format.Font.Size = 15;

			const float headerTextSize = 7;
			table.Rows[0].Format.Font.Size = headerTextSize;

			for (int palletNumberColumnIndex = 0; palletNumberColumnIndex <= 7; palletNumberColumnIndex += 7)
			{
				LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[palletNumberColumnIndex], "#");
				LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[palletNumberColumnIndex + 1], "Des");
				LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[palletNumberColumnIndex + 2], "Blue (CHEP)");
				LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[palletNumberColumnIndex + 3], "Red (LPR)");
				LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[palletNumberColumnIndex + 4], "Brown (PP)");
				LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[palletNumberColumnIndex + 5], "White (EPAL)");

				for (int rowIndex = 1; rowIndex < 11; rowIndex++)
				{
					// Add pallet numbers
					int palletNumber = palletNumberColumnIndex == 0 ? rowIndex : rowIndex + 10;
					LayoutHelper.CellAddParagraphWithSpace(table.Rows[rowIndex].Cells[palletNumberColumnIndex],
						palletNumber.ToString(), 1, headerTextSize);

					// Underline selected / add description
					string description = "";
					if (Pallets.Count >= palletNumber)
					{
						if (Pallets[palletNumber - 1].Selected)
						{
							table.Rows[rowIndex].Cells[palletNumberColumnIndex].Format.Font.Italic = true;
							table.Rows[rowIndex].Cells[palletNumberColumnIndex].Format.Font.Bold = true;
						}
							

						if (FullyFillIn && PartiallyFillIn && Pallets[palletNumber - 1].Type == PalletType.Frozen)
							description = "F";
						else if (PartiallyFillIn && Pallets[palletNumber - 1].Type == PalletType.Ice)
							description = "Ice";
						else if (PartiallyFillIn && Pallets[palletNumber - 1].Type == PalletType.BulkFrozen)
							description = "B/F";
						else if (PartiallyFillIn && Pallets[palletNumber - 1].Type == PalletType.Ambient)
							description = "A";
						else if (PartiallyFillIn && Pallets[palletNumber - 1].Type == PalletType.BulkAmbient)
							description = "B/A";
					}

					LayoutHelper.CellAddParagraphWithSpace(table.Rows[rowIndex].Cells[palletNumberColumnIndex + 1],
						description, 1, 7);

					// Add blue pallets column, 1 if ice pallet empty otherwise
					string numBluePalletsText =
						PartiallyFillIn && Pallets.Count >= palletNumber &&
						Pallets[palletNumber - 1].Type == PalletType.Ice
							? "1"
							: "";
					LayoutHelper.CellAddParagraphWithSpace(table.Rows[rowIndex].Cells[palletNumberColumnIndex + 2],
						numBluePalletsText);

					// Add empty spaces
					for (int columnIndex = palletNumberColumnIndex + 3;
						columnIndex < palletNumberColumnIndex + 6;
						columnIndex++)
					{
						LayoutHelper.CellAddParagraphWithSpace(table.Rows[rowIndex].Cells[columnIndex], "");
					}


				}
			}
		}

		private void AddSimplePalletColourTotal()
		{
			var table = LayoutHelper.AddEqualWidthTable(4, 2, _currentSection, _borderWidth, true);
			table.Format.Font.Size = 8;
			table.Rows[1].Format.Font.Size = 20;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "Blue (CHEP)");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[0], "");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "Red (LPR)");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[1], "");


			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[2], "Brown (PP)");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[2], "");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[3], "White (EPAL)");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[3], "");
		}

		private void AddPalletColourTotal()
		{
			var table = LayoutHelper.AddEqualWidthTable(6, 7, _currentSection, _borderWidth);
			table.Format.Font.Size = 15;

			const float headerTextSize = 8;
			table.Rows[0].Format.Font.Size = headerTextSize;

			// Add header row
			var headerRow = table.Rows[0];

			LayoutHelper.CellAddParagraphWithSpace(headerRow.Cells[2], "Blue (CHEP)");
			LayoutHelper.CellAddParagraphWithSpace(headerRow.Cells[3], "Red (LPR)");
			LayoutHelper.CellAddParagraphWithSpace(headerRow.Cells[4], "Brown (PP)");
			LayoutHelper.CellAddParagraphWithSpace(headerRow.Cells[5], "White (EPAL)");

			// Add header column
			table.Rows[1].Cells[0].MergeRight = 1;
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[0], "1-Frozen", 1, headerTextSize);

			table.Rows[2].Cells[0].MergeDown = 1;
			var bulkFrozenHeader = LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[0], "2-Bulk Frozen", 1, headerTextSize);
			
			// Space with larger font to account for border width
			var space = new FormattedText();
			space.AddSpace(1);
			space.Font.Size = table.Format.Font.Size + _borderWidth;
			bulkFrozenHeader.AddLineBreak();
			bulkFrozenHeader.Add(space);

			bulkFrozenHeader.Format.Borders.Right.Width = 0;
			bulkFrozenHeader.Format.Borders.Bottom.Width = 0;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[1], "6 x 12kg Ice", 1, headerTextSize);
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[3].Cells[1], "Other", 1, headerTextSize);

			table.Rows[4].Cells[0].MergeRight = 1;
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[4].Cells[0], "5-Ambient", 1, headerTextSize);
			table.Rows[5].Cells[0].MergeRight = 1;
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[5].Cells[0], "6-Bulk Ambient", 1, headerTextSize);
			table.Rows[6].Cells[0].MergeRight = 1;
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[6].Cells[0], "Total", 1, headerTextSize);

			// FIll in ice row
			if (PartiallyFillIn && Pallets.Count(x => x.Type == PalletType.Ice) > 0)
			{
				LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[2], Pallets.Count(x => x.Type == PalletType.Ice).ToString());
			}
			else
			{
				LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[2], "");
			}
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[3], "");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[4], "");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[5], "");


			// Add empty spaces
			for (int rowIndex = 1; rowIndex < 7; rowIndex++)
			{
				if (rowIndex == 2) continue;
				for (int columnIndex = 2; columnIndex < 6; columnIndex++)
				{
					LayoutHelper.CellAddParagraphWithSpace(table.Rows[rowIndex].Cells[columnIndex], "");
				}
			}
		}

		private void AddIcePickedDoubleStacked()
		{
			var table = LayoutHelper.AddTableFillLastColumn(new List<float>() { 20, 200, 50, 20, 200 }, 1, _currentSection, _borderWidth);
			table.Format.Font.Size = 15;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "");
			table.Rows[0].Cells[1].Borders.Width = 0;
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "Number of 6 x 12kg ice pallets picked", 1, 10).Format.Borders.Width = 0;

			if (FullPalletBreakDown) return;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[3], "");
			table.Rows[0].Cells[4].Borders.Width = 0;
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[4], "Number of double stacked pallets", 1, 10)
				.Format.Borders.Width = 0;
		}

		private void AddPalletTotals()
		{
			var table = LayoutHelper.AddWeightedWidthTable(new List<float>(){ 1, 1, 1, 1, 0.2f, 1, 1} , 3, _currentSection, _borderWidth, true);
			table.Format.Font.Size = 7;

			table.Rows[2].Format.Font.Size = 20;

			// Total Pallets
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "Total Freezer Pallets");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[0], "");

			int totalPallets = Pallets.Count(x => x.Type == PalletType.Frozen ||
			                                      x.Type == PalletType.BulkFrozen ||
			                                      x.Type == PalletType.Ice);
			if (FullyFillIn && PartiallyFillIn && Pallets.Any()) LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[0], totalPallets.ToString());
			else LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[0], "");
			table.Rows[2].Cells[0].Format.Font.Size = 30;

			// 1-Frozen
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "1-Frozen Pallets");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[1], "");
			if (FullyFillIn && PartiallyFillIn && Pallets.Count(x => x.Type == PalletType.Frozen) > 0) LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[1], Pallets.Count(x => x.Type == PalletType.Frozen).ToString());
			else LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[1], "");

			// 2-Bulk Frozen
			var bulkFrozenPara = LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[2], "2-Bulk Frozen Pallets");
			bulkFrozenPara.Format.Borders.Bottom.Width = _borderWidth;
			//bulkFrozenPara.Format.Font.Bold = true;
			table.Rows[0].Cells[2].MergeRight = 1;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[2], "6 x 12kg Ice Pallets");
			if (PartiallyFillIn && Pallets.Count(x => x.Type == PalletType.Ice) > 0) LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[2], Pallets.Count(x => x.Type == PalletType.Ice).ToString());
			else LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[2], "");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[3], "Other");
			if (PartiallyFillIn && Pallets.Count(x => x.Type == PalletType.BulkFrozen) > 0) LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[3], Pallets.Count(x => x.Type == PalletType.BulkFrozen).ToString());
			else LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[3], "");

			

			// 5-Ambient
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[5], "5-Ambient Pallets");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[5], "");
			if (FullyFillIn && PartiallyFillIn && Pallets.Count(x => x.Type == PalletType.Ambient) > 0) LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[5], Pallets.Count(x => x.Type == PalletType.Ambient).ToString());
			else LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[5], "");

			// 6-Bulk Ambient
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[6], "6-Bulk Ambient Pallets");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[6], "");
			if (PartiallyFillIn && Pallets.Count(x => x.Type == PalletType.BulkAmbient) > 0) LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[6], Pallets.Count(x => x.Type == PalletType.BulkAmbient).ToString());
			else LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[6], "");
		}

		private void AddUnitTotals()
		{
			var table = LayoutHelper.AddEqualWidthTable(5, 2, _currentSection, _borderWidth, true);
			table.Format.Font.Size = 8;
			table.Rows[1].Format.Font.Size = 20;

			int totalUnits = Invoices.Sum(x => x.BulkAmbientUnits + x.AmbientUnits + x.BulkFrozenUnits + x.FrozenUnits);
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "Total Units");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[0], totalUnits > 0 ? totalUnits.ToString() : "", 1, 12);

			int totalMixedUnits = Invoices.Sum(x => x.FrozenUnits);
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "Total Frozen Units");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[1], totalMixedUnits > 0 ? totalMixedUnits.ToString() : "", 1, 12);

			int totalBulkFrozenUnits = Invoices.Sum(x => x.BulkFrozenUnits);
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[2], "Total Bulk Frozen Units");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[2], totalBulkFrozenUnits > 0 ? totalBulkFrozenUnits.ToString() : "", 1, 12);

			int totalAmbientUnits = Invoices.Sum(x => x.AmbientUnits);
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[3], "Total Ambient Units");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[3], totalAmbientUnits > 0 ? totalAmbientUnits.ToString() : "", 1, 12);

			int totalBulkAmbientUnits = Invoices.Sum(x => x.BulkAmbientUnits);
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[4], "Total Bulk Ambient Units");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[4], totalBulkAmbientUnits > 0 ? totalBulkAmbientUnits.ToString() : "", 1, 12);
		}

		private void AddPickerAndTimes()
		{
			var table = LayoutHelper.AddEqualWidthTable(4, 2, _currentSection, _borderWidth, true);
			table.Rows[0].Format.Font.Size = 8;
			table.Rows[1].Format.Font.Size = 15;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "Picker");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[0], "");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "Checker");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[1], "");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[2], "Start Time");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[2], "");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[3], "Finish Time");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[3], "");
		}

		private void AddMissings()
		{
			var table = LayoutHelper.AddWeightedWidthTable(new List<float>() { 1, 1, 2, 0.25f, 1, 1, 2, 0.25f, 1, 1, 2 }, 11, _currentSection, _borderWidth);

			table.Format.Font.Size = 15;

			const float headerTextSize = 8;
			table.Rows[0].Format.Font.Size = headerTextSize;


			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "Code");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "QTY");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[2], "Description");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[4], "Code");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[5], "QTY");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[6], "Description");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[8], "Code");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[9], "QTY");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[10], "Description");

			for (int rowIndex = 1; rowIndex < 11; rowIndex++)
			{
				for (int columnIndex = 0; columnIndex < 11; columnIndex++)
				{
					if (columnIndex == 3 || columnIndex == 7) continue;
					LayoutHelper.CellAddParagraphWithSpace(table.Rows[rowIndex].Cells[columnIndex], "");
				}
			}
		}

		private void AddNote(string note)
		{
			var table = LayoutHelper.AddEqualWidthTable(1, 1, _currentSection);

			table.Rows[0].Format.Font.Size = 10;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], note);
		}

		private void InitDocument()
		{
			if (Document != null) return;

			// Create a new MigraDoc document
			Document = new Document();
			Document.DefaultPageSetup.Orientation = Orientation.Portrait;

			Document.UseCmykColor = true;
		}

		public void AddFrontSheet()
		{
			InitDocument();

			_currentSection = Document.AddSection();
			_currentSection.PageSetup.PageFormat = PageFormat.A4;
			_currentSection.PageSetup.TopMargin = 20;
			_currentSection.PageSetup.BottomMargin = 20;
			_currentSection.PageSetup.LeftMargin = 30;
			_currentSection.PageSetup.RightMargin = 20;

			AddCustomer();
			AddDates();
			AddSpace(10);

			AddInvoices();
			AddSpace(10);

			if (FullPalletBreakDown)
			{
				AddPalletBreakdown();
				AddSpace(10);
				AddSimplePalletColourTotal();
			}
			else
			{
				AddPalletColourTotal();
			}
			AddSpace(10);

			AddIcePickedDoubleStacked();
			AddSpace(10);

			AddPalletTotals();
			AddSpace(10);

			AddUnitTotals();
			AddSpace(10);

			AddPickerAndTimes();
			AddSpace(10);
			AddMissings();
			
			AddSpace(20);
			//AddNote("Please note: Pallets of \"6 x 2kg ice\" are separated from \"bulk frozen\" for all but the unit totals");
		}
	}
}
