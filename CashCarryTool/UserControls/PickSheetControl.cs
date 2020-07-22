using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden_Farm_Cash___Carry_Tool.StaticClasses;
using PdfiumViewer;

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
			if (PickSheetLoadControl.SelectedFilePaths.Count == 0)
			{
				PickSheetPreviewControl.ClearPreview();
				PickSheetLoadControl.Lines = new List<List<bool>>();
				return;
			};
			
			var pickSheet = new Models.PickSheet()
			{
				FilePaths = PickSheetLoadControl.SelectedFilePaths,
				SelectedLines = PickSheetLoadControl.Lines
				
			};

			pickSheet.ImportPdfs();

			pickSheet.OverLayPdf(PickSheetPreviewControl.ShowGuideLines);

			PickSheetPreviewControl.LoadPdfPreview(pickSheet);
			PickSheetLoadControl.Lines = pickSheet.SelectedLines;
		}

		private Models.PickSheet GeneratePickSheet()
		{
			var pickSheet = new Models.PickSheet()
			{
				FilePaths = PickSheetLoadControl.SelectedFilePaths,
				SelectedLines = PickSheetLoadControl.Lines

			};

			pickSheet.ImportPdfs();

			pickSheet.OverLayPdf(false);

			return pickSheet;
		}

		public void PrintDocument()
		{
			var pickSheet = GeneratePickSheet();


		}

		public void OpenDocument()
		{
			var pickSheet = GeneratePickSheet();

			string filePath = TempDirectory.PickSheet.OpenPickSheetPath;
			pickSheet.Save(filePath);

			if (!File.Exists(filePath))
				return;

			Process.Start(filePath);
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
