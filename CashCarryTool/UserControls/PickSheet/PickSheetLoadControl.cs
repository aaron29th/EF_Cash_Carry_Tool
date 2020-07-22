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

		private readonly List<BindingList<CheckedDataViewItem>> _lines = new List<BindingList<CheckedDataViewItem>>();
		public List<List<bool>> Lines
		{
			get
			{
				var newLines = new List<List<bool>>();
				foreach (var page in _lines)
				{
					newLines.Add(page.Select(x => x.Checked).ToList());
				}

				return newLines;
			}
			set
			{
				_lines.Clear();
				PageListBox.Items.Clear();
				LinesGridView.DataSource = null;
				for (int pageIndex = 0; pageIndex < value.Count; pageIndex++)
				{
					PageListBox.Items.Add(pageIndex + 1);
					_lines.Add(new BindingList<CheckedDataViewItem>());
					for (int lineIndex = 0; lineIndex < value[pageIndex].Count; lineIndex++)
					{
						_lines[pageIndex].Add(new CheckedDataViewItem()
						{
							Checked = value[pageIndex][lineIndex],
							Text = lineIndex.ToString()
						});
					}
				}

				if (_selectedPageIndex < value.Count && _selectedPageIndex != -1)
					PageListBox.SelectedIndex = _selectedPageIndex;
			}
		}

		private int _selectedPageIndex = -1;

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
			ConfigUpdated();
		}

		private void FilesGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			FilesGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}

		private void FilesGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == -1 || e.RowIndex == -1) 
				return;

			_lines.Clear();
			ConfigUpdated();
		}

		private void PageListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (PageListBox.SelectedIndex == -1 || _lines.Count == 0)
				return;

			_selectedPageIndex = PageListBox.SelectedIndex;
			LinesGridView.DataSource = _lines[PageListBox.SelectedIndex];
		}

		private void LinesGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			LinesGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}

		private void LinesGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == -1 || e.RowIndex == -1) 
				return;

			ConfigUpdated();
		}

		private void ClearPicksFolderBtn_Click(object sender, EventArgs e)
		{

		}

		private void DeselectPagesLinesBtn_Click(object sender, EventArgs e)
		{
			if (PageListBox.SelectedIndex == -1 || _lines.Count == 0)
				return;

			for (int i = 0; i < _lines[PageListBox.SelectedIndex].Count; i++)
			{
				_lines[PageListBox.SelectedIndex][i].Checked = false;
			}

			ConfigUpdated();
		}
	}
}
