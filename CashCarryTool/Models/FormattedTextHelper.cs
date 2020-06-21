using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;

namespace Eden_Farm_Cash___Carry_Tool.Models
{
	class FormattedTextHelper : FormattedText
	{
		public FormattedTextHelper(string text)
		{
			AddText(text);
		}

		public FormattedTextHelper(string text, string fontName)
		{
			AddText(text);
			Font.Name = fontName;
		}

		public static FormattedTextHelper Snowflake()
		{
			return new FormattedTextHelper("T", "Wingdings");
		}

		public static FormattedTextHelper WarningSign()
		{
			return new FormattedTextHelper("\u26A0", "Segoe UI Emoji");
		}
	}
}
