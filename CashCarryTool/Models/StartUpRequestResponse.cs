using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eden_Farm_Cash___Carry_Tool.Models
{
	public class StartUpRequestResponse
	{
		public bool StartUp { get; set; }
		public bool ShowDialog { get; set; }

		public int DialogCode { get; set; }
		public string DialogTitle { get; set; }
		public string DialogText { get; set; }
	}
}
