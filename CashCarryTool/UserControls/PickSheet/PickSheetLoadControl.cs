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
using Eden_Farm_Cash___Carry_Tool.Models;

namespace Eden_Farm_Cash___Carry_Tool.UserControls.PickSheet
{
	public partial class PickSheetLoadControl : PickSheetControlBase
	{
		private readonly string _picksFolderPath = $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\\Pick PDFs\\";
		private readonly BindingList<CheckedDataViewItem> _files = new BindingList<CheckedDataViewItem>();

		public List<string> SelectedFilePaths
		{
			get
			{
				var selected = _files.Where(x => x.Checked);
				var j = selected.Count();
				var filePaths = selected.Select(x => x.Text).ToList();
				for (int i = 0; i < filePaths.Count; i++)
					filePaths[i] = _picksFolderPath + filePaths[i];
				return filePaths;
			}
		}

		private void InitPicksFolder()
		{
			Directory.CreateDirectory(_picksFolderPath);
		}

		private void ReloadPicks()
		{
			if (!Directory.Exists(_picksFolderPath)) return;

			var filePaths = Directory.GetFiles(_picksFolderPath);
			_files.Clear();
			foreach (var path in filePaths)
			{
				_files.Add(new CheckedDataViewItem()
				{
					Checked = false,
					Text = path.Replace($"{_picksFolderPath}", "")
				});
			}
		}

		private void ConfigUpdated()
		{
			_parent?.ConfigUpdated();
		}

		public PickSheetLoadControl()
		{
			InitializeComponent();

			FilesGridView.DataSource = _files;

			InitPicksFolder();
			ReloadPicks();
		}

		private void RefreshPicksBtn_Click(object sender, EventArgs e)
		{
			ReloadPicks();
		}

		private void FilesGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == -1 || e.RowIndex == -1) return;

			ConfigUpdated();
		}

		private void FilesGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			FilesGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}
	}
}
