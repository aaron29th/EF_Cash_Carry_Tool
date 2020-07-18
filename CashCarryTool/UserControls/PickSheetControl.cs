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
		}

		private void LoadPreview()
		{
			if (PickSheetLoadControl.SelectedFilePaths.Count == 0) return;
			
			var pickSheet = new Models.PickSheet()
			{
				FilePaths = PickSheetLoadControl.SelectedFilePaths
				//SelectedLines = PickSheetLoadControl.Se
				
			};

			pickSheet.ImportPdfs();

			pickSheet.OverLayPdf();

			PickSheetPreviewControl.LoadPdfPreview(pickSheet);
		}

		public void ConfigUpdated()
		{
			LoadPreview();
		}
	}
}
