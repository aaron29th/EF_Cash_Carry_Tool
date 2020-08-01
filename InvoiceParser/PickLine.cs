using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InvoiceParser
{
	public class PickLine
	{
		public string Location { get; set; }
		public int Code { get; set; }
		public string Description { get; set; }
		public int Ordered { get; set; }

		public int Pack { get; set; }
		public string Size { get; set; }
		
		public bool Free { get; set; }
		public int LineNumber { get; set; }
		public long Barcode { get; set; }

		public PickLine()
		{
			
		}

		public PickLine(string lineText)
		{
			// Extract all elements of line
			var pattern = @"(^[a-zA-Z 0-9]+\/[a-zA-z0-9]+) " +	// Location
			              @"([0-9]{4,}) " +						// Code
			              @"((1 )|([0-9]+ ))" +                 // Pack
						  @"((.{50})|(.{1,49} ))" +				// Description
			              @"([a-zA-Z.0-9]+) " +					// Size
			              @"(?(4)Single |)" +					// If pack == 1 then single
			              @"((\*FREE\* )|)" +					// Free?
			              @"([0-9]+)" +							// Quantity
			              @"( _____ )" +						// Del
			              @"([0-9]+)" +							// Line
			              @"( [0-9]+|)";						// Barcode

			var lineRegex = new Regex(pattern);
			var lineMatches = lineRegex.Match(lineText);

			Location = lineMatches.Groups[1].Value;
			Code = Convert.ToInt32(lineMatches.Groups[2].Value);
			Pack = Convert.ToInt32(lineMatches.Groups[3].Value.Trim());
			Description = lineMatches.Groups[6].Value.Trim();
			Size = lineMatches.Groups[9].Value;
			Ordered = Convert.ToInt32(lineMatches.Groups[12].Value);
			LineNumber = Convert.ToInt32(lineMatches.Groups[14].Value);
			Barcode = lineMatches.Groups[15].Value.Trim() == ""
				? -1
				: Convert.ToInt64(lineMatches.Groups[15].Value.Trim());
		}
	}
}
