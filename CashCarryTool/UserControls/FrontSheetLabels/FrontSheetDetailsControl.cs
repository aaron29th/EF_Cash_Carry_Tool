﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden_Farm_Cash___Carry_Tool.Models;
using Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels;
using Eden_Farm_Cash___Carry_Tool.Models.Pick;
using InvoiceTools.InvoiceModels;

namespace Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels
{
	public partial class FrontSheetDetailsControl : FrontSheetLabelsBase
	{
		private BindingList<Invoice> _invoices = new BindingList<Invoice>();
		public List<Invoice> Invoices => _invoices.ToList();
		public bool FullPalletBreakdown { get; set; }

		public bool PartiallyFillIn { get; set; }
		public bool FullyFillIn { get; set; }

		public FrontSheetDetailsControl()
		{
			InitializeComponent();
			_invoices.AllowNew = true;
			InvoiceNumbersGridView.DataSource = _invoices;

			PartiallyFillIn = PartiallyFillInCheck.Checked;
			FullyFillIn = FillInCheck.Checked;
		}

		public void LoadInvoicesData(List<Invoice> invoices)
		{
			_invoices = new BindingList<Invoice>(invoices);
			InvoiceNumbersGridView.DataSource = _invoices;
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
