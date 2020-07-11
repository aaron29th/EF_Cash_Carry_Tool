using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels
{
	public partial class FrontSheetLabelsPreviewControl : FrontSheetLabelsBase
	{
		public bool LiveReload { get; set; }
		public bool HideDuplicatePages { get; set; }

		public FrontSheetLabelsPreviewControl()
		{
			InitializeComponent();

			LiveReload = LiveReloadCheck.Checked;
			HideDuplicatePages = HideDuplicatePagesCheck.Checked;

			RefreshPageNumberControls();
		}

		public void LoadFrontSheetPreview(Document doc)
		{
			if (doc == null)
			{
				doc = new Document();
			};

			string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(doc);
			FrontSheetPreview.Ddl = ddl;
		}

		public void LoadLabelPreview(Document doc)
		{
			if (doc == null)
			{
				doc = new Document();
			};
			
			string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(doc);
			LabelsPreview.Ddl = ddl;

			RefreshPageNumberControls();
		}

		private void RefreshPageNumberControls()
		{
			if (PreviewTabControl.SelectedTab.Name == "LabelsTab") SetPageNumberControls(LabelsPreview.Page, LabelsPreview.PageCount);
			else SetPageNumberControls(1, 1);
		}

		private void SetPageNumberControls(int pageNumber, int totalPages)
		{
			PageNumberLabel.Text = $"Page: {pageNumber} of {totalPages}";
			PreviousPageBtn.Enabled = pageNumber > 1;
			NextPageBtn.Enabled = pageNumber < totalPages;
		}

		private void HideDuplicatePagesCheck_CheckedChanged(object sender, EventArgs e)
		{
			HideDuplicatePages = HideDuplicatePagesCheck.Checked;
			_parent?.Reload();
		}

		private void LiveReloadCheck_CheckedChanged(object sender, EventArgs e)
		{
			LiveReload = LiveReloadCheck.Checked;
		}

		private void ReloadBtn_Click(object sender, EventArgs e)
		{
			_parent?.Reload();
		}

		public void SetPreviewPageNumber(int pageNumber)
		{
			if (pageNumber < 0 && pageNumber > LabelsPreview.PageCount) return;
			LabelsPreview.Page = pageNumber;
		}

		private void PreviousPageBtn_Click(object sender, EventArgs e)
		{
			SetPreviewPageNumber(LabelsPreview.Page - 1);
		}

		private void NextPageBtn_Click(object sender, EventArgs e)
		{
			SetPreviewPageNumber(LabelsPreview.Page + 1);
		}

		private void DocumentPreview_PageChanged(object sender, EventArgs e)
		{
			RefreshPageNumberControls();
		}

		private void PreviewTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			RefreshPageNumberControls();
		}

		private void PrintFrontSheetBtn_Click(object sender, EventArgs e)
		{
			_parent?.PrintFrontSheet();
		}

		private void PrintLabelsBtn_Click(object sender, EventArgs e)
		{
			_parent?.PrintLabels();
		}

		private void PrintBothButton_Click(object sender, EventArgs e)
		{
			_parent?.PrintBoth();
		}
	}
}
