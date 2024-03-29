﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Eden_Farm_Cash___Carry_Tool.Models.Pick;
using InvoiceTools.DirectoryModels;
using InvoiceTools.InvoiceModels;
using InvoiceTools.Models;

namespace Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels
{
	public partial class GeneralDetailsControl : FrontSheetLabelsBase
	{
		private BindingList<Customer> _quickSelects;

		public string Title { get; private set; }
		public float TitleSize { get; private set; }
		public string CustomerCode { get; private set; }
		public string DeliveryDate { get; private set; }
		public string PickDate { get; private set; }

		private void InitQuickSelects()
		{
			var customers = ResourcesDirectory.GetCustomers();
			_quickSelects = new BindingList<Customer>(customers);
			DetailsQuickSelect.DataSource = _quickSelects;
			DetailsQuickSelect.SelectedItem = null;
		}

		public GeneralDetailsControl()
		{
			InitializeComponent();

			// Init properties
			Title = "";
			TitleSize = 70;
			CustomerCode = "";

			// Init quick selects
			InitQuickSelects();

			// Init delivery date to tomorrow or monday on fri / dat
			if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
				DeliveryDateSel.Value = DateTime.Now.AddDays(3);
			else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
				DeliveryDateSel.Value = DateTime.Now.AddDays(2);
			else
				DeliveryDateSel.Value = DateTime.Now.AddDays(1);

			// Init pick date to today
			PickDateSel.Value = DateTime.Now;
		}

		public void LoadInvoicesData(List<Invoice> invoices)
		{
			if (invoices.Count == 0)
				return;

			TitleTxt.Text = invoices[0].CustomerName;
			CustomerCodeTxt.Text = invoices[0].CustomerCode;
			DeliveryDateSel.Value = invoices[0].DeliveryBy;

			InitQuickSelects();
		}

		private void TitleTxt_TextChanged(object sender, EventArgs e)
		{
			Title = TitleTxt.Text;

			if (LabelTitleSizeAutoCheck.Checked)
			{
				float titleTextWidth = 99999;
				float textSize = 81;
				int magicWidthNumber = 890;
				while (titleTextWidth > magicWidthNumber)
				{
					Font font = new Font("Arial", textSize);

					// Measure width of title text
					using (Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
					{
						SizeF size = graphics.MeasureString(Title, font);
						titleTextWidth = size.Width;
					}

					textSize -= 1;
				}

				LabelTitleSizeNumEdit.Value = (decimal) textSize;
			}

			DetailsUpdated();
		}

		private void CustomerCodeTxt_TextChanged(object sender, EventArgs e)
		{
			CustomerCode = CustomerCodeTxt.Text;
			DetailsUpdated();
		}

		private void DetailsQuickSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			Customer selected = (Customer)DetailsQuickSelect.SelectedItem;
			if (selected == null || selected.QuickSelectText == "Custom") return;

			TitleTxt.Text = selected.PreferredName;
			CustomerCodeTxt.Text = selected.Code;
		}

		private void DeliveryDateSel_ValueChanged(object sender, EventArgs e)
		{
			DeliveryDate = DeliveryDateSel.Value.ToString("ddd dd MMM yyyy");
			DetailsUpdated();
		}

		private void DeliveryDateToday_Click(object sender, EventArgs e)
		{
			DeliveryDateSel.Value = DateTime.Now;
		}

		private void DeliveryDateTomorrow_Click(object sender, EventArgs e)
		{
			DeliveryDateSel.Value = DateTime.Now.AddDays(1);
		}

		private void DeliveryDateMonday_Click(object sender, EventArgs e)
		{
			var dateTime = DateTime.Now;
			while (dateTime.DayOfWeek != DayOfWeek.Monday)
			{
				dateTime = dateTime.AddDays(1);
			}

			DeliveryDateSel.Value = dateTime;
		}

		private void PickDateSel_ValueChanged(object sender, EventArgs e)
		{
			PickDate = PickDateSel.Value.ToString("ddd dd MMM yyyy");
			DetailsUpdated();
		}

		private void PickDateToday_Click(object sender, EventArgs e)
		{
			PickDateSel.Value = DateTime.Now;
		}

		private void PickDateTomorrow_Click(object sender, EventArgs e)
		{
			PickDateSel.Value = DateTime.Now.AddDays(1);
		}

		private void LabelTitleSizeNumEdit_ValueChanged(object sender, EventArgs e)
		{
			TitleSize = (float) LabelTitleSizeNumEdit.Value;
			DetailsUpdated();
		}

		private void LabelTitleSizeAutoCheck_CheckedChanged(object sender, EventArgs e)
		{
			LabelTitleSizeNumEdit.Enabled = !LabelTitleSizeAutoCheck.Checked;
		}
	}
}
