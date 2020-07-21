using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eden_Farm_Cash___Carry_Tool.UserControls
{
	public partial class PickSheetControl : UserControl
	{
		public PickSheetControl()
		{
			InitializeComponent();

			PickSheetLoadControl.SetParent(this);
			PickSheetPreviewControl.SetParent(this);
		}

		private void LoadPreview()
		{
			if (PickSheetLoadControl.SelectedFilePaths.Count == 0) return;
			
			var pickSheet = new Models.PickSheet()
			{
				FilePaths = PickSheetLoadControl.SelectedFilePaths,
				SelectedLines = PickSheetLoadControl.Lines
				
			};

			pickSheet.ImportPdfs();

			pickSheet.OverLayPdf(true);

			PickSheetPreviewControl.LoadPdfPreview(pickSheet);
			PickSheetLoadControl.Lines = pickSheet.SelectedLines;
		}

		public void ConfigUpdated()
		{
			LoadPreview();
		}

		public void LineClicked(float clickYLocation, int pageIndex)
		{
			var result = Models.PickSheet.ProcessLineClick(PickSheetLoadControl.Lines, clickYLocation, pageIndex);
			if (result == null)
				return;

			PickSheetLoadControl.Lines = result;
			ConfigUpdated();
		}
	}
}
