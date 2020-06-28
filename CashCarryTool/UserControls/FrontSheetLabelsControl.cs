using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels;

namespace Eden_Farm_Cash___Carry_Tool.UserControls
{
	public partial class FrontSheetLabelsControl : UserControl
	{
		private void LoadFrontSheet()
		{
			var frontSheet = new FrontSheet()
			{
				Title = GeneralDetailsControl.Title,
				CustomerCode = GeneralDetailsControl.CustomerCode,
				DeliveryDate = GeneralDetailsControl.DeliveryDate,

				Pallets = LabelDetailsControl.Pallets,
				NumCopiesPerPallet = FrontSheetLabelsPreviewControl.HideDuplicatePages
					? 1
					: LabelDetailsControl.NumLabelsPerPallet,

				SecondRun = LabelDetailsControl.SecondRun,
				VehicleRegistration = LabelDetailsControl.VehicleRegistration,

				InvoiceNumbers = FrontSheetDetailsControl.InvoiceNumbers
			};

			frontSheet.AddFrontSheet();

			FrontSheetLabelsPreviewControl.LoadFrontSheetPreview(frontSheet.Document);
		}

		private void LoadLabel()
		{
			var label = new Models.FrontSheetLabels.Label
			{
				Title = GeneralDetailsControl.Title,
				CustomerCode = GeneralDetailsControl.CustomerCode,
				DeliveryDate = GeneralDetailsControl.DeliveryDate,

				Pallets = LabelDetailsControl.Pallets,
				NumCopiesPerPallet = FrontSheetLabelsPreviewControl.HideDuplicatePages
					? 1
					: LabelDetailsControl.NumLabelsPerPallet,

				SecondRun = LabelDetailsControl.SecondRun,
				VehicleRegistration = LabelDetailsControl.VehicleRegistration
			};

			label.AddLabel();

			FrontSheetLabelsPreviewControl.LoadLabelPreview(label.Document);

		}

		public void Reload()
		{
			LoadFrontSheet();
			LoadLabel();
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
	}
}
