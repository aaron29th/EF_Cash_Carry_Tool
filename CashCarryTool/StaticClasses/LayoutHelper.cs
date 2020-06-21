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

		public static Table AddEqualWidthTable(int numColumns, int numRows, Section section, float borderWidth = 0)
		{
			Document doc = section.Document;
			float sectionWidth = doc.DefaultPageSetup.PageHeight - doc.DefaultPageSetup.LeftMargin - doc.DefaultPageSetup.RightMargin;
			float columnWidth = sectionWidth / numColumns;
			List<float> columnWidths = new List<float>();
			for (int i = 0; i < numColumns; i++)
			{
				columnWidths.Add(columnWidth);
			}

			return AddTable(columnWidths, numRows, section, borderWidth);
		}

		public static Table AddTable(List<float> columnWidths, int numRows, Section section, float borderWidth = 0)
		{
			Table table = section.AddTable();
			table.Format.Borders.Color = Colors.Black;
			table.Format.Borders.Width = borderWidth;
			// Fix double border between columns
			table.Format.LeftIndent = -borderWidth;

			foreach (var width in columnWidths)
			{
				Column column = table.AddColumn();
				column.Width = width;
			}

			for (int i = 0; i < numRows; i++)
			{
				table.AddRow();
			}

			return table;
		}
	}
}
