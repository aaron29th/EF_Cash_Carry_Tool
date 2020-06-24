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
		}

		public void LoadPreview(Document doc)
		{
			if (doc == null)
			{
				doc = new Document();
			};
			
			string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(doc);
			DocumentPreview.Ddl = ddl;

			PageNumberLabel.Text = $"Page: {DocumentPreview.Page} of {DocumentPreview.PageCount}";
			PreviousPageBtn.Enabled = DocumentPreview.Page > 1;
			NextPageBtn.Enabled = DocumentPreview.Page < DocumentPreview.PageCount;
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
			if (pageNumber < 0 && pageNumber > DocumentPreview.PageCount) return;
			DocumentPreview.Page = pageNumber;
		}

		private void PreviousPageBtn_Click(object sender, EventArgs e)
		{
			SetPreviewPageNumber(DocumentPreview.Page - 1);
		}

		private void NextPageBtn_Click(object sender, EventArgs e)
		{
			SetPreviewPageNumber(DocumentPreview.Page + 1);
		}

		private void DocumentPreview_PageChanged(object sender, EventArgs e)
		{
			PageNumberLabel.Text = $"Page: {DocumentPreview.Page} of {DocumentPreview.PageCount}";
			PreviousPageBtn.Enabled = DocumentPreview.Page > 1;
			NextPageBtn.Enabled = DocumentPreview.Page < DocumentPreview.PageCount;
		}

		private void PrintBothButton_Click(object sender, EventArgs e)
		{
			
		}
	}
}
