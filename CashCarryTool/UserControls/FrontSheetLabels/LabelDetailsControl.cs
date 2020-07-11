using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden_Farm_Cash___Carry_Tool.Models;
using Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels;

namespace Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels
{
	public partial class LabelDetailsControl : FrontSheetLabelsBase
	{
		private readonly BindingList<Pallet> _pallets = new BindingList<Pallet>() { new Pallet() {Selected = true, Type = PalletType.Mixed }};
		public List<Pallet> Pallets => _pallets.ToList();

		public int TotalIce { get; private set; }
		public int TotalBulk { get; private set; }
		public int TotalMixed { get; private set; }

		public int NumLabelsPerPallet { get; set; }

		public bool SecondRun { get; private set; }
		public string VehicleRegistration { get; private set; }

		public bool ShowPalletNumber { get; set; }
		public bool ShowPalletNumberOf { get; set; }
		public bool ShowTotalPalletNumber { get; set; }

		private void UpdatePalletTotals()
		{
			TotalIce = _pallets.Count(x => x.Type == PalletType.Ice);
			NumIcePalletsSpin.Value = TotalIce;

			TotalBulk = _pallets.Count(x => x.Type == PalletType.Bulk);
			NumBulkPalletsSpin.Value = TotalBulk;
			
			TotalMixed = _pallets.Count(x => x.Type == PalletType.Mixed);
			NumMixedPalletsSpin.Value = TotalMixed;
		}

		private void UpdatePallets()
		{
			int newTotalIce = (int) NumIcePalletsSpin.Value;
			int newTotalBulk = (int) NumBulkPalletsSpin.Value;
			int newTotalMixed = (int) NumMixedPalletsSpin.Value;

			// Add pallets
			while (newTotalIce > TotalIce)
			{
				_pallets.Insert(0, new Pallet() {Type = PalletType.Ice});
				TotalIce++;
			}

			while (newTotalBulk > TotalBulk)
			{
				// Add bulk pallets after last ice pallet
				int index = 0;
				var lastIce = _pallets.LastOrDefault(x => x.Type == PalletType.Ice);
				if (lastIce != null) index = _pallets.IndexOf(lastIce) + 1;

				_pallets.Insert(index, new Pallet() { Type = PalletType.Bulk });
				TotalBulk++;
			}

			while (newTotalMixed > TotalMixed)
			{
				// Add mixed pallets to end
				_pallets.Add(new Pallet() { Type = PalletType.Mixed });
				TotalMixed++;
			}

			// Remove pallets
			while (newTotalIce < TotalIce)
			{
				_pallets.Remove(_pallets.Last(x => x.Type == PalletType.Ice));
				TotalIce--;
			}

			while (newTotalBulk < TotalBulk)
			{
				_pallets.Remove(_pallets.Last(x => x.Type == PalletType.Bulk));
				TotalBulk--;
			}

			while (newTotalMixed < TotalMixed)
			{
				_pallets.Remove(_pallets.Last(x => x.Type == PalletType.Mixed));
				TotalMixed--;
			}

			int totalPallets = newTotalIce + newTotalBulk + newTotalMixed;
			TotalPalletsLabel.Text = $"Total Pallets: {totalPallets}";
			DetailsUpdated();
		}

		public LabelDetailsControl()
		{
			InitializeComponent();

			// Init properties
			TotalMixed = 1;
			NumLabelsPerPallet = 4;
			SecondRun = false;
			VehicleRegistration = "";

			ShowPalletNumber = true;
			ShowPalletNumberOf = true;
			ShowTotalPalletNumber = true;

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

		#region Spin edits

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

		private void NumLabelsPerPalletSpin_ValueChanged(object sender, EventArgs e)
		{
			NumLabelsPerPallet = (int)NumLabelsPerPalletSpin.Value;
			DetailsUpdated();
		}

		#endregion

		#region Pallets GridView

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
			DetailsUpdated();
		}

		private void PalletsGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			// Commit comboxbox change straight away
			PalletsGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}

		#endregion

		#region Check / uncheck all

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

		#endregion

		#region Second run

		private void SecondRunCheck_CheckedChanged(object sender, EventArgs e)
		{
			SecondRunVehicleTxt.Enabled = SecondRun = SecondRunCheck.Checked;
			DetailsUpdated();
		}

		private void SecondRunVehicleTxt_TextChanged(object sender, EventArgs e)
		{
			VehicleRegistration = SecondRunVehicleTxt.Text;
			DetailsUpdated();
		}

		#endregion

		private void PalletsGridView_DoubleClick(object sender, EventArgs e)
		{
			if (PalletsGridView.SelectedRows.Count == 0) return;

			int palletIndex = PalletsGridView.SelectedRows[0].Index;
			if (!_pallets[palletIndex].Selected) return;

			int pageNumber = _pallets.Take(palletIndex + 1).Count(x => x.Selected = true);
			_parent?.SetPreviewPageNumber(pageNumber);
		}

		private void PalletNumberCheck_CheckedChanged(object sender, EventArgs e)
		{
			ShowPalletNumber = PalletNumberCheck.Checked;
			DetailsUpdated();
		}

		private void OfCheck_CheckedChanged(object sender, EventArgs e)
		{
			ShowPalletNumberOf = OfCheck.Checked;
			TotalPalletNumberCheck.Enabled = OfCheck.Checked;
			DetailsUpdated();
		}

		private void TotalPalletNumberCheck_CheckedChanged(object sender, EventArgs e)
		{
			ShowTotalPalletNumber = TotalPalletNumberCheck.Checked;
			DetailsUpdated();
		}
	}
}
