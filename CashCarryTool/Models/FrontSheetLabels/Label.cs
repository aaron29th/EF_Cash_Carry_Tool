using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eden_Farm_Cash___Carry_Tool.StaticClasses;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels
{
	class Label
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

		private void AddSpace(float space)
		{
			LayoutHelper.AddSpaceAfter(_currentSection, space);
		}

		private static float GetTitleSize(int length)
		{
			if (length < 18) return 70;
			return 45;
		}

		private void AddTitle()
		{
			Table table = LayoutHelper.AddEqualWidthTable(
				1, 1, _currentSection, 5);
			table.Format.Font.Size = GetTitleSize(Title.Length);
			table.Format.Font.Bold = true;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], Title);
		}

		private void AddCustomerCode()
		{
			Table table = LayoutHelper.AddTableFillLastColumn(
				new List<float>() { 320 }, 1, _currentSection, 4);
			table.Format.Font.Size = 40;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "Customer Code", 1, 20);
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], CustomerCode);
		}

		private void AddDeliveryDate()
		{
			Table table = LayoutHelper.AddTableFillLastColumn(
				new List<float>() { 320 }, 1, _currentSection, 4);
			table.Format.Font.Size = 40;

			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[0], "Delivery Date", 1, 20);
			LayoutHelper.CellAddParagraphWithSpace(table.Rows[0].Cells[1], DeliveryDate);
		}

		private void AddSecondRunWarning()
		{
			Table table = LayoutHelper.AddEqualWidthTable(
				1, 1, _currentSection, 5);
			table.Format.Font.Size = 40;
			table.Format.Alignment = ParagraphAlignment.Center;

			var cellParagraph = table.Rows[0].Cells[0].AddParagraph();
			cellParagraph.Add(FormattedTextHelper.WarningSign());
			cellParagraph.AddText(" Second Run ");
			cellParagraph.Add(FormattedTextHelper.WarningSign());
		}

		private void AddPalletNumberAndLogo(int palletNumber)
		{
			Table table = LayoutHelper.AddTable(
				new List<float>() { 320, 100, 280 }, 1, _currentSection, 5);
			table.Format.Font.Size = 50;
			//table.Format.Font.Name = "Impact";

			var row = table.Rows[0];

			row.Cells[0].Format.Font.Size = table.Format.Font.Size + 3;
			LayoutHelper.CellAddParagraphWithSpace(row.Cells[0], "Pallet Number", 1, 20);

			row.Cells[1].AddParagraph(palletNumber.ToString()).Format.Font.Name = "Impact";
			row.Cells[1].Format.Alignment = ParagraphAlignment.Center;

			row.Cells[2].Format.Alignment = ParagraphAlignment.Right;
			row.Cells[2].Format.Borders.Width = 0;

			var logo = row.Cells[2].AddParagraph().AddImage(ResourcesDirectory.FrontSheetLabel.LogoPath);
			logo.ScaleHeight = 5;
			logo.ScaleWidth = 5;
		}

		private void AddAdditionalText(Pallet pallet)
		{
			if (pallet.Type == PalletType.Mixed) return;

			Table table = LayoutHelper.AddTableFillLastColumn(new List<float>() { 420 }, 1, _currentSection, 3);
			table.Format.Font.Size = 40;
			// Offset logo overrun
			table.TopPadding = -50;

			var cell = table.Rows[0].Cells[0];
			var paragraph = LayoutHelper.CellAddParagraphWithSpace(cell, "");

			if (pallet.Type == PalletType.Ice)
			{
				paragraph.Add(FormattedTextHelper.Snowflake());
				paragraph.AddText(" ICE ");
				paragraph.Add(FormattedTextHelper.Snowflake());
			} else if (pallet.Type == PalletType.Bulk)
			{
				paragraph.AddText("BULK");
			}
			
		}

		private void AddFooter()
		{
			string footerText = "";
			_currentSection.Footers.Primary.AddParagraph(footerText);
		}

		private void InitDocument()
		{
			if (Document != null) return;

			// Create a new MigraDoc document
			Document = new Document();

			// set orientation
			Document.DefaultPageSetup.Orientation = Orientation.Landscape;

			Document.UseCmykColor = true;
		}

		private void GenFile(string fileName)
		{
			try
			{
				const bool unicode = true;
				// Create a renderer for the MigraDoc document.
				PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode)
				{
					Document = Document
				};

				// Layout and render document to PDF
				pdfRenderer.RenderDocument();

				pdfRenderer.PdfDocument.Save(fileName);
			}
			catch (IOException ex)
			{
				return;
			}
		}

		public void AddLabel()
		{
			if (Pallets == null || Pallets.Count == 0)
			{
				return;
			}

			InitDocument();

			for (int i = 0; i < Pallets.Count; i++)
			{
				// SKip unselected pallets
				if (!Pallets[i].Selected) continue;

				for (int j = 0; j < NumCopiesPerPallet; j++)
				{
					_currentSection = Document.AddSection();
					_currentSection.PageSetup.PageFormat = PageFormat.A4;
					_currentSection.PageSetup.Orientation = Orientation.Landscape;
					_currentSection.PageSetup.TopMargin = 40;
					_currentSection.PageSetup.LeftMargin = Document.DefaultPageSetup.LeftMargin;
					_currentSection.PageSetup.RightMargin = Document.DefaultPageSetup.RightMargin;

					AddTitle();
					AddSpace(20);

					AddCustomerCode();
					AddSpace(10);

					AddDeliveryDate();
					AddSpace(20);

					if (SecondRun)
					{
						AddSecondRunWarning();
						AddSpace(20);
					}
					else
					{
						AddSpace(80);
					}
					

					AddPalletNumberAndLogo(i + 1);

					AddAdditionalText(Pallets[i]);

					AddFooter();
				}
			}
		}
	}
}
