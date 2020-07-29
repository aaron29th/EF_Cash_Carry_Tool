using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eden_Farm_Cash___Carry_Tool.Models.Pick
{
	class PickSheetException : Exception
	{
		public PickSheetException()
		{
		}

		public PickSheetException(string message)
			: base(message)
		{
		}

		public PickSheetException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
