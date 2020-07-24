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
		
		public bool Single { get; set; }
		public bool Free { get; set; }
		public int LineNumber { get; set; }
		public long Barcode { get; set; }

		public Line()
		{
			
		}

		public Line(string text)
		{
			//Regex rg = new Regex(pattern);
		}
	}
}
