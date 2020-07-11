using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden_Farm_Cash___Carry_Tool.Models;

namespace Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels
{
	public partial class FrontSheetDetailsControl : FrontSheetLabelsBase
	{
		private readonly BindingList<StringValue> _invoiceNumbers = new BindingList<StringValue>();
		public List<string> InvoiceNumbers => _invoiceNumbers.Select(x => x.Value).ToList();
		public bool FullPalletBreakdown { get; set; }

		public bool PartiallyFillIn { get; set; }
		public bool FullyFillIn { get; set; }

		public FrontSheetDetailsControl()
		{
			InitializeComponent();
			_invoiceNumbers.AllowNew = true;
			InvoiceNumbersGridView.DataSource = _invoiceNumbers;

			PartiallyFillIn = PartiallyFillInCheck.Checked;
			FullyFillIn = FillInCheck.Checked;
		}

		private void InvoiceNumbersGridView_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
		{
			DetailsUpdated();
		}

		private void InvoiceNumbersGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			DetailsUpdated();
		}

		private void FullPalletBreakDownCheck_CheckedChanged(object sender, EventArgs e)
		{
			FullPalletBreakdown = FullPalletBreakDownCheck.Checked;
			DetailsUpdated();
		}

		private void FillInPalletsCheck_CheckedChanged(object sender, EventArgs e)
		{
			PartiallyFillIn = PartiallyFillInCheck.Checked;
			FillInCheck.Enabled = PartiallyFillInCheck.Checked;
			DetailsUpdated();
		}

		private void FillInCheck_CheckedChanged(object sender, EventArgs e)
		{
			FullyFillIn = FillInCheck.Checked;
			DetailsUpdated();
		}
	}
}
