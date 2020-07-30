using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eden_Farm_Cash___Carry_Tool.Models.Pick
{
	public class Section
	{
		public List<int> ProcessedPages { get; }

		public Section()
		{
			ProcessedPages = new List<int>();
		}

		public void ProcessPage(int pageNumber, string pageText)
		{

		}
	}
}
