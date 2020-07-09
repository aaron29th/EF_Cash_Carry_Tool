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
		private const float _borderWidth = 3;

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
			var table = LayoutHelper.AddEqualWidthTable(6, 22, _currentSection, _borderWidth);
			table.Format.Font.Size = 12;

			const float headerTextSize = 8;
			table.Rows[0].Format.Font.Size = headerTextSize;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "Pallet Number");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "Description");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[2], "Blue (CHEP)");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[3], "Red (LPR)");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[4], "Brown (PP)");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[5], "White (EPAL)");

			for (int rowIndex = 1; rowIndex < 21; rowIndex++)
			{
				LayoutHelper.CellAddParagraphWithSpace(table.Rows[rowIndex].Cells[0], rowIndex.ToString(),1 , headerTextSize);
				for (int columnIndex = 1; columnIndex < 6; columnIndex++)
				{
					LayoutHelper.CellAddParagraphWithSpace(table.Rows[rowIndex].Cells[columnIndex], "");
				}
			}

			table.Rows[21].Format.Font.Bold = true;
			table.Rows[21].Cells[1].Shading.Color = Colors.Gray;
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[21].Cells[0], "Total");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[21].Cells[1], "");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[21].Cells[2], "");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[21].Cells[3], "");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[21].Cells[4], "");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[21].Cells[5], "");
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

			// Add empty spaces
			for (int rowIndex = 1; rowIndex < 5; rowIndex++)
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
			table.Rows[0].Format.Font.Size = 8;
			table.Rows[1].Format.Font.Size = 20;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "Total Pallets");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[0], "");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "Total 6 x 12kg Ice Pallets");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[1], "");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[2], "Total Bulk Pallets");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[2], "");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[3], "Total Mixed Pallets");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[3], "");
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
			var table = LayoutHelper.AddEqualWidthTable(7, 20, _currentSection, _borderWidth);
			table.Columns[3].Format.Borders.Width = 0;
			table.Format.Font.Size = 15;

			const float headerTextSize = 8;
			table.Rows[0].Format.Font.Size = headerTextSize;


			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "Code");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "QTY");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[2], "Description");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[3], "");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[4], "Code");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[5], "QTY");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[6], "Description");

			for (int rowIndex = 1; rowIndex < 20; rowIndex++)
			{
				for (int columnIndex = 0; columnIndex < 7; columnIndex++)
				{
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
			_currentSection.PageSetup.BottomMargin = 10;
			_currentSection.PageSetup.LeftMargin = 30;
			_currentSection.PageSetup.RightMargin = 20;

			AddCustomer();
			AddDates();
			AddSpace(10);

			AddInvoiceNumbers();
			AddSpace(10);

			if (FullPalletBreakDown) AddPalletBreakdown();
			else AddPalletColourTotal();
			AddSpace(10);

			AddPalletTotals();
			AddSpace(10);

			AddPickerAndTimes();
			AddSpace(10);
			AddMissings();
		}
	}
}
