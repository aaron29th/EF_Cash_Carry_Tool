using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels;
using Eden_Farm_Cash___Carry_Tool.StaticClasses;

namespace Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels
{
	public partial class GeneralDetailsControl : FrontSheetLabelsBase
	{
		private BindingList<GeneralDetailsQuickSelect> _quickSelects;

		public string Title { get; private set; }
		public float TitleSize { get; private set; }
		public string CustomerCode { get; private set; }
		public string DeliveryDate { get; private set; }
		public string PickDate { get; private set; }

		private void InitQuickSelects()
		{
			try
			{
				using (var reader = new StreamReader(ResourcesDirectory.FrontSheetLabel.GeneralDetailsQuickSelectPath))
				using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
				{
					var quickSelectsList = csv.GetRecords<GeneralDetailsQuickSelect>().ToList();
					_quickSelects = new BindingList<GeneralDetailsQuickSelect>(quickSelectsList);
					DetailsQuickSelect.DataSource = _quickSelects;
					DetailsQuickSelect.SelectedItem = null;
				}
			}
			catch (IOException ex)
			{

			}
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

			// Init delivery date to tomorrow
			DeliveryDateSel.Value = DateTime.Now.AddDays(1);

			// Init pick date to today
			PickDateSel.Value = DateTime.Now;
		}

		private void TitleTxt_TextChanged(object sender, EventArgs e)
		{
			Title = TitleTxt.Text;

			if (!LabelTitleSizeAutoCheck.Checked)
			{
				DetailsUpdated();
				return;
			}

			if (TitleTxt.Text.Length < 18)
				LabelTitleSizeNumEdit.Value = 70;
			else if (TitleTxt.Text.Length < 25)
				LabelTitleSizeNumEdit.Value = 45;
			else
				LabelTitleSizeNumEdit.Value = 40;
		}

		private void CustomerCodeTxt_TextChanged(object sender, EventArgs e)
		{
			CustomerCode = CustomerCodeTxt.Text;
			DetailsUpdated();
		}

		private void DetailsQuickSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			GeneralDetailsQuickSelect selected = (GeneralDetailsQuickSelect)DetailsQuickSelect.SelectedItem;
			if (selected == null || selected.SelectionText == "Custom") return;

			TitleTxt.Text = selected.Title;
			CustomerCodeTxt.Text = selected.CustomerCode;
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
