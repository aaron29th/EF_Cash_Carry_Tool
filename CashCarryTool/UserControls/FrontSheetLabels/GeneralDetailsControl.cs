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
	public partial class GeneralDetailsControl : UserControl
	{
		private BindingList<GeneralDetailsQuickSelect> _quickSelects;

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

		private void DetailsUpdated()
		{

		}

		public GeneralDetailsControl()
		{
			InitializeComponent();

			// Init quick selects
			InitQuickSelects();

			// Init delivery date to tomorrow
			DeliveryDateSel.Value = DateTime.Now.AddDays(1);
		}

		private void TitleTxt_TextChanged(object sender, EventArgs e)
		{
			DetailsUpdated();
		}

		private void CustomerCodeTxt_TextChanged(object sender, EventArgs e)
		{
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
	}
}
