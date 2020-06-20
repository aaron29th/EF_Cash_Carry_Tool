using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels;

namespace Eden_Farm_Cash___Carry_Tool.Models
{
	class ComboboxItem
	{
		public string Text { get; set; }
		public PalletType Value { get; set; }

		public override string ToString()
		{
			return Text;
		}
    }
}
