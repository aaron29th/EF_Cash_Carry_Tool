using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Eden_Farm_Cash___Carry_Tool.Models.Pick
{
	class Line
	{
		public string Location { get; set; }
		public int Code { get; set; }
		public string Description { get; set; }
		public int Ordered { get; set; }

		public string Pack { get; set; }
		public string Size { get; set; }
		
		public bool Free { get; set; }
		public int LineNumber { get; set; }
		public long Barcode { get; set; }

		public Line()
		{
			
		}

		public Line(string text)
		{
			//Regex rg = new Regex(pattern);
			var pattern = @"(^[a-zA-Z 0-9]+\/[a-zA-z0-9]+) " + // Location
			              @"([0-9]{4,}) " + // Code
			              @"((1 )|([0-9]+ ))" + // Pack
			              @"((.{1,49} )|(.{50}))" + // Description
			              @"([a-zA-Z.0-9]+) " +  // Size
			              @"(?(4)Single |)" + // If pack == 1 then single
			              @"((\*FREE\* )|)" + // Free?
			              @"([0-9]+)" + // Quantity
			              @"( _____ )" + // Del
			              @"([0-9]+)" + // Line
			              @"( [0-9]+|)"; // Barcode
		}
	}
}
