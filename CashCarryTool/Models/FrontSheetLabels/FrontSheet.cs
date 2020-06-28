using System;
using System.Collections.Generic;
using System.Linq;
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

		public List<Pallet> Pallets { get; set; }
		public int NumCopiesPerPallet { get; set; }
		public bool SecondRun { get; set; }
		public string VehicleRegistration { get; set; }

		public List<string> InvoiceNumbers { get; set; }

		private void AddSpace(float space)
		{
			LayoutHelper.AddSpaceAfter(_currentSection, space);
		}

		private void AddCustomer()
		{
			var table = LayoutHelper.AddEqualWidthTable(2, 2, _currentSection, _borderWidth, true);
			table.Rows[0].Format.Font.Size = 12;
			table.Rows[1].Format.Font.Size = 20;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], $"Customer");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[0], Title);

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "Account");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[1], CustomerCode);
		}

		private void AddInvoiceNumbers()
		{
			var table = LayoutHelper.AddEqualWidthTable(3, 3, _currentSection, _borderWidth);
			table.Format.Font.Size = 15;

			table.Rows[0].Format.Font.Size = 12;
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

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "Pallet Number");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "Description");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[2], "Blue (CHEP)");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[3], "Red (LPR)");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[4], "Brown (PP)");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[5], "White (EPAL)");

			for (int rowIndex = 1; rowIndex < 21; rowIndex++)
			{
				LayoutHelper.CellAddParagraphWithSpace(table.Rows[rowIndex].Cells[0], rowIndex.ToString());
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

		private void AddPalletTotals()
		{
			var table = LayoutHelper.AddEqualWidthTable(3, 5, _currentSection, _borderWidth);
		}

		private void AddPickerAndTimes()
		{
			var table = LayoutHelper.AddEqualWidthTable(3, 2, _currentSection, _borderWidth, true);
			table.Rows[0].Format.Font.Size = 12;
			table.Rows[1].Format.Font.Size = 15;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], $"Picker");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[0], "");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "Start Time");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[1], "");

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[2], "Finish Time");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[2], "");
		}

		private void AddMissings()
		{
			var table = LayoutHelper.AddEqualWidthTable(7, 20, _currentSection, _borderWidth);
			table.Columns[3].Format.Borders.Width = 0;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "Code");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "QTY");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[2], "Des");

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
			_currentSection.PageSetup.TopMargin = 40;

			AddCustomer();
			AddSpace(20);

			AddInvoiceNumbers();
			AddSpace(20);

			AddPalletBreakdown();
			AddPalletTotals();

			AddPickerAndTimes();
			AddSpace(20);
			AddMissings();
		}
	}
}
