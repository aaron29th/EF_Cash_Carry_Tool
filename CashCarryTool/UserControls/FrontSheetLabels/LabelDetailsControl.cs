using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden_Farm_Cash___Carry_Tool.Models;
using Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels;

namespace Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels
{
	public partial class LabelDetailsControl : UserControl
	{
		private BindingList<Pallet> _pallets = new BindingList<Pallet>();
		private int _totalIce = 0;
		private int _totalBulk = 0;
		private int _totalMixed = 0;

		private void UpdatePalletTotals()
		{
			_totalIce = _pallets.Count(x => x.Type == PalletType.Ice);
			NumIcePalletsSpin.Value = _totalIce;

			_totalBulk = _pallets.Count(x => x.Type == PalletType.Bulk);
			NumBulkPalletsSpin.Value = _totalBulk;
			
			_totalMixed = _pallets.Count(x => x.Type == PalletType.Mixed);
			NumMixedPalletsSpin.Value = _totalMixed;
		}

		private void UpdatePallets()
		{
			int newTotalIce = (int) NumIcePalletsSpin.Value;
			int newTotalBulk = (int) NumBulkPalletsSpin.Value;
			int newTotalMixed = (int) NumMixedPalletsSpin.Value;

			// Add pallets
			while (newTotalIce > _totalIce)
			{
				_pallets.Insert(0, new Pallet() {Type = PalletType.Ice});
				_totalIce++;
			}

			while (newTotalBulk > _totalBulk)
			{
				// Add bulk pallets after last ice pallet
				int index = 0;
				var lastIce = _pallets.LastOrDefault(x => x.Type == PalletType.Ice);
				if (lastIce != null) index = _pallets.IndexOf(lastIce) + 1;

				_pallets.Insert(index, new Pallet() { Type = PalletType.Bulk });
				_totalBulk++;
			}

			while (newTotalMixed > _totalMixed)
			{
				// Add mixed pallets to end
				_pallets.Add(new Pallet() { Type = PalletType.Mixed });
				_totalMixed++;
			}

			// Remove pallets
			while (newTotalIce < _totalIce)
			{
				_pallets.Remove(_pallets.Last(x => x.Type == PalletType.Ice));
				_totalIce--;
			}

			while (newTotalBulk < _totalBulk)
			{
				_pallets.Remove(_pallets.Last(x => x.Type == PalletType.Bulk));
				_totalBulk--;
			}

			while (newTotalMixed < _totalMixed)
			{
				_pallets.Remove(_pallets.Last(x => x.Type == PalletType.Mixed));
				_totalMixed--;
			}


			int totalPallets = newTotalIce + newTotalBulk + newTotalMixed;
			TotalPalletsLabel.Text = $"Total Pallets: {totalPallets}";
		}

		private void DetailsUpdated()
		{

		}

		public LabelDetailsControl()
		{
			InitializeComponent();

			// Init pallet type column
			List<ComboboxItem> palletTypeItems = new List<ComboboxItem>()
			{
				new ComboboxItem() { Text = "Ice", Value = PalletType.Ice },
				new ComboboxItem() { Text = "Bulk", Value = PalletType.Bulk },
				new ComboboxItem() { Text = "Mixed", Value = PalletType.Mixed}
			};
			PalletsGridViewTypeColumn.DataSource = palletTypeItems;
			PalletsGridViewTypeColumn.DisplayMember = "Text";
			PalletsGridViewTypeColumn.ValueMember = "Value";

			// Init pallets grid view
			PalletsGridView.DataSource = _pallets;
		}

		private void NumIcePalletsSpin_ValueChanged(object sender, EventArgs e)
		{
			UpdatePallets();
		}

		private void NumBulkPalletsSpin_ValueChanged(object sender, EventArgs e)
		{
			UpdatePallets();
		}

		private void NumMixedPalletsSpin_ValueChanged(object sender, EventArgs e)
		{
			UpdatePallets();
		}

		private void PalletsGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			// Add row numbers
			if (sender is DataGridView gridView)
			{
				foreach (DataGridViewRow r in gridView.Rows)
				{
					gridView.Rows[r.Index].HeaderCell.Value =
						(r.Index + 1).ToString();
				}
			}
		}

		private void PalletsGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
		{
			// End of edition on each click on column of checkbox
			if (e.RowIndex == -1) return;
			if (e.ColumnIndex != PalletsGridViewSelectedColumn.Index &&
			    e.ColumnIndex != PalletsGridViewTypeColumn.Index) return;

			//PalletsGridView.EndEdit();
		}

		private void PalletsGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
			UpdatePalletTotals();
		}

		private void PalletsGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			// Commit comboxbox change straight away
			PalletsGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}

		private void PalletsCheckAll_Click(object sender, EventArgs e)
		{
			_pallets.ToList().ForEach(x => x.Selected = true);
			PalletsGridView.InvalidateColumn(PalletsGridViewSelectedColumn.Index);
		}

		private void IcePalletsCheckAll_Click(object sender, EventArgs e)
		{
			var pallets = _pallets.Where(x => x.Type == PalletType.Ice);
			foreach (var pallet in pallets)
			{
				pallet.Selected = true;
			}
			PalletsGridView.InvalidateColumn(PalletsGridViewSelectedColumn.Index);
		}

		private void BulkPalletsCheckAll_Click(object sender, EventArgs e)
		{
			var pallets = _pallets.Where(x => x.Type == PalletType.Bulk);
			foreach (var pallet in pallets)
			{
				pallet.Selected = true;
			}
			PalletsGridView.InvalidateColumn(PalletsGridViewSelectedColumn.Index);
		}

		private void MixedPalletsCheckAll_Click(object sender, EventArgs e)
		{
			var pallets = _pallets.Where(x => x.Type == PalletType.Mixed);
			foreach (var pallet in pallets)
			{
				pallet.Selected = true;
			}
			PalletsGridView.InvalidateColumn(PalletsGridViewSelectedColumn.Index);
		}

		private void PalletsUncheckAll_Click(object sender, EventArgs e)
		{
			_pallets.ToList().ForEach(x => x.Selected = false);
			PalletsGridView.InvalidateColumn(PalletsGridViewSelectedColumn.Index);
		}

		private void IcePalletsUncheckAll_Click(object sender, EventArgs e)
		{
			var pallets = _pallets.Where(x => x.Type == PalletType.Ice);
			foreach (var pallet in pallets)
			{
				pallet.Selected = false;
			}
			PalletsGridView.InvalidateColumn(PalletsGridViewSelectedColumn.Index);
		}

		private void BulkPalletsUncheckAll_Click(object sender, EventArgs e)
		{
			var pallets = _pallets.Where(x => x.Type == PalletType.Bulk);
			foreach (var pallet in pallets)
			{
				pallet.Selected = false;
			}
			PalletsGridView.InvalidateColumn(PalletsGridViewSelectedColumn.Index);
		}

		private void MixedPalletsUncheckAll_Click(object sender, EventArgs e)
		{
			var pallets = _pallets.Where(x => x.Type == PalletType.Mixed);
			foreach (var pallet in pallets)
			{
				pallet.Selected = false;
			}
			PalletsGridView.InvalidateColumn(PalletsGridViewSelectedColumn.Index);
		}
	}
}
