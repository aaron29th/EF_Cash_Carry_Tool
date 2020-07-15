using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eden_Farm_Cash___Carry_Tool.UserControls.PickSheet
{
	public partial class PickSheetLoadControl : PickSheetControlBase
	{
		private readonly string _picksFolderPath = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\\Pick PDFs";

		private void InitPicksFolder()
		{
			Directory.CreateDirectory(_picksFolderPath);
		}

		private void ReloadPicks()
		{
			if (!Directory.Exists(_picksFolderPath)) return;

			var filesPaths = Directory.GetFiles(_picksFolderPath);
			var fileNames = new List<string>();
			foreach (var fileName in filesPaths)
			{
				fileNames.Add(fileName.Replace($"{_picksFolderPath}\\", ""));
			}
			PicksCheckedListBox.DataSource = fileNames;
		}

		public PickSheetLoadControl()
		{
			InitializeComponent();

			InitPicksFolder();
			ReloadPicks();
		}

		private void PicksListBox_DoubleClick(object sender, EventArgs e)
		{
			if (PicksCheckedListBox.SelectedIndex == -1) return;

			string filePath = $"{_picksFolderPath}\\{PicksCheckedListBox.SelectedItem}";

			_parent?.SetPickPdfPath(filePath);
		}

		private void RefreshPicksBtn_Click(object sender, EventArgs e)
		{
			ReloadPicks();
		}
	}
}
