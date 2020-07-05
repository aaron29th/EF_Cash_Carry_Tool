using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eden_Farm_Cash___Carry_Tool.Models;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;

namespace Eden_Farm_Cash___Carry_Tool.StaticClasses
{
	public static class LayoutHelper
	{
		public static void AddSpaceAfter(Section section, float spaceAfter)
		{
			Paragraph paragraph = section.AddParagraph();
			paragraph.Format.LineSpacingRule = LineSpacingRule.Exactly;
			paragraph.Format.LineSpacing = Unit.FromMillimeter(0.0);
			paragraph.Format.SpaceAfter = spaceAfter;
		}

		public static Paragraph CellAddParagraphWithSpace(Cell cell, string text, int numSpaces = 1)
		{
			return CellAddParagraphWithSpace(cell, new FormattedTextHelper(text), numSpaces);
		}

		public static Paragraph CellAddParagraphWithSpace(Cell cell, FormattedText text, int numSpaces = 1)
		{
			var paragraph = cell.AddParagraph();
			paragraph.AddSpace(numSpaces);
			paragraph.Add(text);

			return paragraph;
		}

		public static Table AddTableFillLastColumn(List<float> columnWidths, int numRows, Section section, float borderWidth = 0)
		{
			Document doc = section.Document;
			float totalWidth = columnWidths.Sum();
			float sectionWidth = doc.DefaultPageSetup.PageHeight - doc.DefaultPageSetup.LeftMargin - doc.DefaultPageSetup.RightMargin;

			if (sectionWidth > totalWidth) columnWidths.Add(sectionWidth - totalWidth);

			return AddTable(columnWidths, numRows, section, borderWidth);
		}

		public static Table AddEqualWidthTable(int numColumns, int numRows, Section section, float borderWidth = 0, bool noHorizontalInternalBorders = false)
		{
			Document doc = section.Document;
			
			float sectionWidth;
			if (section.PageSetup.Orientation == Orientation.Portrait) sectionWidth = doc.DefaultPageSetup.PageWidth - doc.DefaultPageSetup.LeftMargin - doc.DefaultPageSetup.RightMargin;
			else sectionWidth = doc.DefaultPageSetup.PageHeight - doc.DefaultPageSetup.LeftMargin - doc.DefaultPageSetup.RightMargin;

			float columnWidth = sectionWidth / numColumns;
			List<float> columnWidths = new List<float>();
			for (int i = 0; i < numColumns; i++)
			{
				columnWidths.Add(columnWidth);
			}

			return AddTable(columnWidths, numRows, section, borderWidth, noHorizontalInternalBorders);
		}

		public static Table AddTable(List<float> columnWidths, int numRows, Section section, float borderWidth = 0 , bool noHorizontalInternalBorders = false)
		{
			Table table = section.AddTable();
			table.Format.Borders.Color = Colors.Black;
			table.Format.Borders.Width = borderWidth;
			
			// Fix double border between columns and rows
			//table.Format.Borders.Left.Width = 0;
			table.Format.LeftIndent = -3;
			//table.LeftPadding = -borderWidth;
			//table.Format.RightIndent = -3;
			table.Format.SpaceBefore = -borderWidth;

			foreach (var width in columnWidths)
			{
				Column column = table.AddColumn();
				column.Width = width;
			}

			// Fix missing left border for first column
			//table.Columns[0].Format.Borders.Left.Width = borderWidth;

			for (int i = 0; i < numRows; i++)
			{
				table.AddRow();
			}

			if (noHorizontalInternalBorders && numRows > 0)
			{
				table.Format.Borders.Bottom.Width = 0;
				table.Format.Borders.Top.Width = 0;

				table.Rows[0].Format.Borders.Top.Width = borderWidth;
				table.Rows[numRows - 1].Format.Borders.Bottom.Width = borderWidth;
			}

			return table;
		}
	}
}
