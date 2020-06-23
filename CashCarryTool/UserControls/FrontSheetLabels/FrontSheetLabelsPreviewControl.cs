using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel;

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
			if (doc == null) return;
			
			string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(doc);
			DocumentPreview.Ddl = ddl;
		}

		private void ReloadBtn_Click(object sender, EventArgs e)
		{
			_parent?.Reload();
		}

		public void SetPreviewPageNumber(int pageNumber)
		{
			DocumentPreview.Page = pageNumber;
		}
	}
}
