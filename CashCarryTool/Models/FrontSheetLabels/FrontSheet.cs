using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Eden_Farm_Cash___Carry_Tool.StaticClasses;
using MigraDoc.DocumentObjectModel;

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
		public List<string> InvoiceNumbers { get; set; }
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

		private void AddInvoiceNumbers()
		{
			var table = LayoutHelper.AddEqualWidthTable(3, 3, _currentSection, _borderWidth);
			table.Format.Font.Size = 15;

			table.Rows[0].Format.Font.Size = 8;
			table.Rows[0].Format.Alignment = ParagraphAlignment.Center;
			table.Rows[0].Cells[1].AddParagraph("Invoice numbers");

			for (int i = 0; i < 6; i++)
			{
				int rowIndex = i / 3 + 1;
				int columnIndex = i % 3;
				string invoiceNumber = "";
				if (i < InvoiceNumbers.Count) invoiceNumber = InvoiceNumbers[i];
				LayoutHelper.CellAddParagraphWithSpace(table.Rows[rowIndex].Cells[columnIndex], invoiceNumber);
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
							

						if (FullyFillIn && Pallets[palletNumber - 1].Type == PalletType.Mixed)
							description = "Mixed";
						else if (PartiallyFillIn && Pallets[palletNumber - 1].Type == PalletType.Ice)
							description = "Ice";
						else if (PartiallyFillIn && Pallets[palletNumber - 1].Type == PalletType.Bulk)
							description = "Bulk";
					}

					LayoutHelper.CellAddParagraphWithSpace(table.Rows[rowIndex].Cells[palletNumberColumnIndex + 1],
						description);

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
			var table = LayoutHelper.AddEqualWidthTable(5, 5, _currentSection, _borderWidth);
			table.Format.Font.Size = 15;

			const float headerTextSize = 8;
			table.Rows[0].Format.Font.Size = headerTextSize;

			// Add header row
			var headerRow = table.Rows[0];
			//LayoutHelper.CellAddParagraphWithSpace(headerRow.Cells[0], "");
			LayoutHelper.CellAddParagraphWithSpace(headerRow.Cells[1], "Blue (CHEP)");
			LayoutHelper.CellAddParagraphWithSpace(headerRow.Cells[2], "Red (LPR)");
			LayoutHelper.CellAddParagraphWithSpace(headerRow.Cells[3], "Brown (PP)");
			LayoutHelper.CellAddParagraphWithSpace(headerRow.Cells[4], "White (EPAL)");

			// Add header column
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[0], "6 x 12kg Ice", 1, headerTextSize);
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[2].Cells[0], "Bulk", 1, headerTextSize);
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[3].Cells[0], "Mixed", 1, headerTextSize);
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[4].Cells[0], "Total", 1, headerTextSize);

			// FIll in ice row
			if (PartiallyFillIn && Pallets.Count(x => x.Type == PalletType.Ice) > 0)
			{
				LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[1], Pallets.Count(x => x.Type == PalletType.Ice).ToString());
			}
			else
			{
				LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[1], "");
			}
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[2], "");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[3], "");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[4], "");


			// Add empty spaces
			for (int rowIndex = 2; rowIndex < 5; rowIndex++)
			{
				for (int columnIndex = 1; columnIndex < 5; columnIndex++)
				{
					LayoutHelper.CellAddParagraphWithSpace(table.Rows[rowIndex].Cells[columnIndex], "");
				}
			}
		}

		private void AddPalletTotals()
		{
			var table = LayoutHelper.AddEqualWidthTable(4, 2, _currentSection, _borderWidth, true);
			table.Format.Font.Size = 8;
			table.Rows[1].Format.Font.Size = 20;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "Total Pallets");
			table.Rows[1].Cells[0].Format.Font.Size = 40;
			if (FullyFillIn && Pallets.Any()) LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[0], Pallets.Count().ToString());
			else LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[0], "");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "Total 6 x 12kg Ice Pallets");
			if (PartiallyFillIn && Pallets.Count(x => x.Type == PalletType.Ice) > 0) LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[1], Pallets.Count(x => x.Type == PalletType.Ice).ToString());
			else LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[1], "");


			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[2], "Total Bulk Pallets");
			if (PartiallyFillIn && Pallets.Count(x => x.Type == PalletType.Bulk) > 0) LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[2], Pallets.Count(x => x.Type == PalletType.Bulk).ToString());
			else LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[2], "");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[3], "Total Mixed Pallets");
			if (FullyFillIn && Pallets.Count(x => x.Type == PalletType.Mixed) > 0) LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[3], Pallets.Count(x => x.Type == PalletType.Mixed).ToString());
			else LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[3], "");
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

			AddInvoiceNumbers();
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

			AddPalletTotals();
			AddSpace(10);

			AddPickerAndTimes();
			AddSpace(10);
			AddMissings();
		}
	}
}
