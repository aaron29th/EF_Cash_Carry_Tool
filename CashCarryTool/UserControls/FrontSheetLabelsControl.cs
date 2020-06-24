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
	public partial class FrontSheetLabelsControl : UserControl
	{
		private void InitLabel()
		{
			var label = new Models.FrontSheetLabels.Label
			{
				Title = GeneralDetailsControl.Title,
				CustomerCode = GeneralDetailsControl.CustomerCode,
				DeliveryDate = GeneralDetailsControl.DeliveryDate,

				Pallets = LabelDetailsControl.Pallets,
				NumCopiesPerPallet = FrontSheetLabelsPreviewControl.HideDuplicatePages ? 1 : LabelDetailsControl.NumLabelsPerPallet,

				SecondRun = LabelDetailsControl.SecondRun,
				VehicleRegistration = LabelDetailsControl.VehicleRegistration
			};

			label.AddLabel("testPdf.pdf");

			FrontSheetLabelsPreviewControl.LoadPreview(label.Document);

		}

		public void Reload()
		{
			InitLabel();
		}

		public void DetailsUpdate()
		{
			if (FrontSheetLabelsPreviewControl.LiveReload) Reload();
		}

		public void SetPreviewPageNumber(int pageNumber)
		{
			FrontSheetLabelsPreviewControl.SetPreviewPageNumber(pageNumber);
		}

		public FrontSheetLabelsControl()
		{
			InitializeComponent();

			GeneralDetailsControl.SetParent(this);
			FrontSheetDetailsControl.SetParent(this);
			LabelDetailsControl.SetParent(this);
			FrontSheetLabelsPreviewControl.SetParent(this);

			Reload();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			InitLabel();
		}
	}
}
