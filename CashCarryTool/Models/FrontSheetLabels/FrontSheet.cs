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

		private void AddCustomer()
		{
			var table = LayoutHelper.AddEqualWidthTable(2, 2, _currentSection, 3, true);
			table.Rows[0].Format.Font.Size = 12;
			table.Rows[1].Format.Font.Size = 20;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], $"Customer");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[0], Title);

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], "Account");
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[1].Cells[1], CustomerCode);
		}

		private void AddInvoiceNumbers()
		{
			var table = LayoutHelper.AddEqualWidthTable(3, 3, _currentSection);
		}

		private void AddPalletBreakdown()
		{
			var table = LayoutHelper.AddEqualWidthTable(5, 20, _currentSection);
		}

		private void AddPalletTotals()
		{
			var table = LayoutHelper.AddEqualWidthTable(3, 5, _currentSection);
		}

		private void AddPickerAndTimes()
		{
			var table = LayoutHelper.AddEqualWidthTable(3, 1, _currentSection);
		}

		private void AddMissings()
		{
			var table = LayoutHelper.AddEqualWidthTable(7, 20, _currentSection);
		}

		private void InitDocument()
		{
			if (Document != null) return;

			// Create a new MigraDoc document
			Document = new Document();

			Document.UseCmykColor = true;
		}

		public void AddFrontSheet()
		{
			InitDocument();

			_currentSection = Document.AddSection();
			_currentSection.PageSetup.PageFormat = PageFormat.A4;
			_currentSection.PageSetup.TopMargin = 40;

			AddCustomer();
			AddInvoiceNumbers();
			AddPalletBreakdown();
			AddPalletTotals();
			AddPickerAndTimes();
			AddMissings();
		}
	}
}
