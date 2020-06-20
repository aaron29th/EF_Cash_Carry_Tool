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

namespace Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels
{
	public partial class LabelDetailsControl : UserControl
	{
		private BindingList<Pallet> _pallets = new BindingList<Pallet>();
		private int _totalIce = 0;
		private int _totalBulk = 0;
		private int _totalMixed = 0;


		private void UpdateTotalPallets()
		{
			int totalPallets = (int)NumIcePalletsSpin.Value + (int)NumBulkPalletsSpin.Value + (int)NumMixedPalletsSpin.Value;
			TotalPalletsLabel.Text = $"Total Pallets: {totalPallets}";
		}

		private void GeneratePalletsList()
		{
			int newTotalIce = (int) NumIcePalletsSpin.Value;
			int newTotalBulk = (int) NumBulkPalletsSpin.Value;
			int newTotalMixed = (int) NumMixedPalletsSpin.Value;

			int firstIceIndex = _totalIce > 0 ? 0 : -1;
			int lastIceIndex = _totalIce > 0 ? _totalIce - 1 : -1;

			int firstBulkIndex = _totalBulk > 0 ? _totalIce : -1;
			int lastBulkIndex = _totalBulk > 0 ? _totalIce + _totalBulk - 1 : -1;

			int firstMixedIndex = _totalMixed > 0 ? _totalIce + _totalBulk : -1;
			int lastMixedIndex = _totalMixed > 0 ? _totalIce + _totalBulk + _totalMixed - 1 : -1;
			//_pallets.Remove()

		}

		public LabelDetailsControl()
		{
			InitializeComponent();
		}

		private void NumIcePalletsSpin_ValueChanged(object sender, EventArgs e)
		{

		}

		private void NumBulkPalletsSpin_ValueChanged(object sender, EventArgs e)
		{

		}

		private void NumMixedPalletsSpin_ValueChanged(object sender, EventArgs e)
		{

		}
	}
}
