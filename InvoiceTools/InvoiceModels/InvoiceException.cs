using System;

namespace InvoiceTools.InvoiceModels
{
	public class InvoiceException : Exception
	{
		public InvoiceException()
		{
		}

		public InvoiceException(string message)
			: base(message)
		{
		}

		public InvoiceException(string message, Exception inner)
			: base(message, inner)
		{
		}
    }
}
