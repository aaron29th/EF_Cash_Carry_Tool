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
				NumCopiesPerPallet = LabelDetailsControl.NumLabelsPerPallet,

				SecondRun = LabelDetailsControl.SecondRun,
				VehicleRegistration = LabelDetailsControl.VehicleRegistration
			};

			label.AddLabel("testPdf.pdf");

			FrontSheetLabelsPreviewControl.LoadPreview(label.Document);

		}

		public FrontSheetLabelsControl()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			InitLabel();
		}
	}
}
