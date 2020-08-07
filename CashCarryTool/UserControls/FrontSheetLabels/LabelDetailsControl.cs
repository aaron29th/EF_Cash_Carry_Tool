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
using Eden_Farm_Cash___Carry_Tool.Models.Pick;

namespace Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels
{
	public partial class LabelDetailsControl : FrontSheetLabelsBase
	{
		private readonly BindingList<Pallet> _pallets = new BindingList<Pallet>() { new Pallet() {Selected = true, Type = PalletType.Frozen }};
		public List<Pallet> Pallets => _pallets.ToList();

		private int _totalIce;
		private int _totalBulkFrozen;
		private int _totalFrozen;
		private int _totalAmbient;
		private int _totalBulkAmbient;

		public int NumLabelsPerPallet { get; set; }

		public bool SecondRun { get; private set; }
		public string VehicleRegistration { get; private set; }

		public bool ShowPalletNumber { get; set; }
		public bool ShowPalletNumberOf { get; set; }
		public bool ShowTotalPalletNumber { get; set; }

		#region Pallet Totals

		private void UpdatePalletTotals()
		{
			_totalIce = _pallets.Count(x => x.Type == PalletType.Ice);
			NumIcePalletsSpin.Value = _totalIce;

			_totalBulkFrozen = _pallets.Count(x => x.Type == PalletType.BulkFrozen);
			NumBulkPalletsSpin.Value = _totalBulkFrozen;
			
			_totalFrozen = _pallets.Count(x => x.Type == PalletType.Frozen);
			NumMixedPalletsSpin.Value = _totalFrozen;

			_totalAmbient = _pallets.Count(x => x.Type == PalletType.Ambient);
			NumAmbientPalletsSpin.Value = _totalAmbient;

			_totalBulkAmbient = _pallets.Count(x => x.Type == PalletType.BulkAmbient);
			NumBulkAmbientPalletsSpin.Value = _totalBulkAmbient;
		}

		private void UpdatePallets()
		{
			int newTotalIce = (int) NumIcePalletsSpin.Value;
			int newTotalBulkFrozen = (int) NumBulkPalletsSpin.Value;
			int newTotalFrozen = (int) NumMixedPalletsSpin.Value;
			int newTotalAmbient = (int) NumAmbientPalletsSpin.Value;
			int newTotalBulkAmbient = (int)NumBulkAmbientPalletsSpin.Value;

			// Add pallets
			while (newTotalBulkAmbient > _totalBulkAmbient)
			{
				_pallets.Insert(0, new Pallet() { Type = PalletType.BulkAmbient });
				_totalBulkAmbient++;
			}

			while (newTotalAmbient > _totalAmbient)
			{
				// Add ice pallets after last ambient pallet
				int index = 0;
				var lastBulkAmbient = _pallets.LastOrDefault(x => x.Type == PalletType.BulkAmbient);
				if (lastBulkAmbient != null) index = _pallets.IndexOf(lastBulkAmbient) + 1;

				_pallets.Insert(index, new Pallet() {Type = PalletType.Ambient});
				_totalAmbient++;
			}

			while (newTotalIce > _totalIce)
			{
				// Add ice pallets after last ambient pallet
				int index = 0;
				var lastAmbient = _pallets.LastOrDefault(x => x.Type == PalletType.Ambient);
				if (lastAmbient != null) index = _pallets.IndexOf(lastAmbient) + 1;

				_pallets.Insert(index, new Pallet() { Type = PalletType.Ice, Selected = false });
				_totalIce++;
			}

			while (newTotalBulkFrozen > _totalBulkFrozen)
			{
				// Add bulk pallets after last ice pallet
				int index = 0;
				var lastIce = _pallets.LastOrDefault(x => x.Type == PalletType.Ice);
				if (lastIce != null) index = _pallets.IndexOf(lastIce) + 1;

				_pallets.Insert(index, new Pallet() { Type = PalletType.BulkFrozen });
				_totalBulkFrozen++;
			}

			while (newTotalFrozen > _totalFrozen)
			{
				// Add mixed pallets to end
				_pallets.Add(new Pallet() { Type = PalletType.Frozen });
				_totalFrozen++;
			}

			// Remove pallets
			while (newTotalBulkAmbient < _totalBulkAmbient)
			{
				_pallets.Remove(_pallets.Last(x => x.Type == PalletType.BulkAmbient));
				_totalBulkAmbient--;
			}

			while (newTotalAmbient < _totalAmbient)
			{
				_pallets.Remove(_pallets.Last(x => x.Type == PalletType.Ambient));
				_totalAmbient--;
			}

			while (newTotalIce < _totalIce)
			{
				_pallets.Remove(_pallets.Last(x => x.Type == PalletType.Ice));
				_totalIce--;
			}

			while (newTotalBulkFrozen < _totalBulkFrozen)
			{
				_pallets.Remove(_pallets.Last(x => x.Type == PalletType.BulkFrozen));
				_totalBulkFrozen--;
			}

			while (newTotalFrozen < _totalFrozen)
			{
				_pallets.Remove(_pallets.Last(x => x.Type == PalletType.Frozen));
				_totalFrozen--;
			}

			int totalFrozenPallets = newTotalIce + newTotalBulkFrozen + newTotalFrozen;
			TotalFrozenPalletsLabel.Text = $"Total Pallets: {totalFrozenPallets}";

			int totalAmbientPallets = newTotalAmbient + newTotalBulkAmbient;
			TotalAmbientPalletsLabel.Text = $"Total Pallets: {totalAmbientPallets}";

			UpdateHeaderColumn(PalletsGridView);
			DetailsUpdated();
		}

		#endregion
		
		public LabelDetailsControl()
		{
			InitializeComponent();

			// Init properties
			_totalFrozen = (int)NumMixedPalletsSpin.Value;
			NumLabelsPerPallet = (int)NumLabelsPerPalletSpin.Value;
			SecondRun = SecondRunCheck.Checked;
			VehicleRegistration = SecondRunVehicleTxt.Text;

			ShowPalletNumber = PalletNumberCheck.Checked;
			ShowPalletNumberOf = OfCheck.Checked;
			ShowTotalPalletNumber = TotalPalletNumberCheck.Checked;

			// Init pallet type column
			List<ComboboxItem> palletTypeItems = new List<ComboboxItem>()
			{
				new ComboboxItem() { Text = "Frozen", Value = PalletType.Frozen },
				new ComboboxItem() { Text = "Bulk Frozen - Ice", Value = PalletType.Ice },
				new ComboboxItem() { Text = "Bulk Frozen - Other", Value = PalletType.BulkFrozen },
				new ComboboxItem() { Text = "Ambient", Value = PalletType.Ambient },
				new ComboboxItem() { Text = "Bulk Ambient", Value = PalletType.BulkAmbient }
			};
			PalletsGridViewTypeColumn.DataSource = palletTypeItems;
			PalletsGridViewTypeColumn.DisplayMember = "Text";
			PalletsGridViewTypeColumn.ValueMember = "Value";

			// Init pallets grid view
			PalletsGridView.DataSource = _pallets;
		}

		public void LoadInvoicesData(List<Invoice> invoices)
		{
			
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
		
		private void NumAmbientPalletsSpin_ValueChanged(object sender, EventArgs e)
		{
			UpdatePallets();
		}

		private void NumBulkAmbientPalletsSpin_ValueChanged(object sender, EventArgs e)
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
		private void UpdateHeaderColumn(DataGridView gridView)
		{
			foreach (DataGridViewRow r in gridView.Rows)
			{
				int palletIndex = r.Index;
				int palletNumber;

				bool isFrozenType = _pallets[palletIndex].Type == PalletType.Frozen ||
				                    _pallets[palletIndex].Type == PalletType.Ice ||
				                    _pallets[palletIndex].Type == PalletType.BulkFrozen;

				if (isFrozenType)
					palletNumber = _pallets.Take(palletIndex + 1).Count(x =>
						x.Type == PalletType.Frozen || x.Type == PalletType.Ice || x.Type == PalletType.BulkFrozen);
				else
					palletNumber = _pallets.Take(palletIndex + 1)
						.Count(x => x.Type == PalletType.Ambient || x.Type == PalletType.BulkAmbient);

				string typeStr = isFrozenType ? "F" : "A";

				gridView.Rows[r.Index].HeaderCell.Value = $"{typeStr}-{palletNumber.ToString()}";
			}
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
		private void CheckPalletType(PalletType type)
		{
			var pallets = _pallets.Where(x => x.Type == type);
			foreach (var pallet in pallets)
			{
				pallet.Selected = true;
			}
			PalletsGridView.InvalidateColumn(PalletsGridViewSelectedColumn.Index);
			DetailsUpdated();
		}

		private void TotalFrozenPalletsCheckAll_Click(object sender, EventArgs e)
		{
			CheckPalletType(PalletType.Frozen);
			CheckPalletType(PalletType.Ice);
			CheckPalletType(PalletType.BulkFrozen);
		}

		private void IcePalletsCheckAll_Click(object sender, EventArgs e)
		{
			CheckPalletType(PalletType.Ice);
		}

		private void BulkPalletsCheckAll_Click(object sender, EventArgs e)
		{
			CheckPalletType(PalletType.BulkFrozen);
		}

		private void MixedPalletsCheckAll_Click(object sender, EventArgs e)
		{
			CheckPalletType(PalletType.Frozen);
		}

		private void TotalAmbientPalletsCheckAll_Click(object sender, EventArgs e)
		{
			CheckPalletType(PalletType.Ambient);
			CheckPalletType(PalletType.BulkAmbient);
		}

		private void AmbientPalletsCheckAll_Click(object sender, EventArgs e)
		{
			CheckPalletType(PalletType.Ambient);
		}

		private void BulkAmbientPalletsCheckAll_Click(object sender, EventArgs e)
		{
			CheckPalletType(PalletType.BulkAmbient);
		}

		// Uncheck
		private void UncheckPalletType(PalletType type)
		{
			var pallets = _pallets.Where(x => x.Type == type);
			foreach (var pallet in pallets)
			{
				pallet.Selected = false;
			}
			PalletsGridView.InvalidateColumn(PalletsGridViewSelectedColumn.Index);
			DetailsUpdated();
		}

		private void TotalFrozenPalletsUncheckAll_Click(object sender, EventArgs e)
		{
			UncheckPalletType(PalletType.Frozen);
			UncheckPalletType(PalletType.Ice);
			UncheckPalletType(PalletType.BulkFrozen);
		}

		private void IcePalletsUncheckAll_Click(object sender, EventArgs e)
		{
			UncheckPalletType(PalletType.Ice);
		}

		private void BulkPalletsUncheckAll_Click(object sender, EventArgs e)
		{
			UncheckPalletType(PalletType.BulkFrozen);
		}

		private void MixedPalletsUncheckAll_Click(object sender, EventArgs e)
		{
			UncheckPalletType(PalletType.Frozen);
		}

		private void TotalAmbientPalletsUncheckAll_Click(object sender, EventArgs e)
		{
			UncheckPalletType(PalletType.Ambient);
			UncheckPalletType(PalletType.BulkAmbient);
		}

		private void AmbientPalletsUncheckAll_Click(object sender, EventArgs e)
		{
			UncheckPalletType(PalletType.Ambient);
		}

		private void BulkAmbientPalletsUncheckAll_Click(object sender, EventArgs e)
		{
			UncheckPalletType(PalletType.BulkAmbient);
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

		#region Label Numbers

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

		#endregion

		private void PalletsGridView_DoubleClick(object sender, EventArgs e)
		{
			if (PalletsGridView.SelectedRows.Count == 0) return;

			int palletIndex = PalletsGridView.SelectedRows[0].Index;
			if (!_pallets[palletIndex].Selected) return;

			int pageNumber = _pallets.Take(palletIndex + 1).Count(x => x.Selected = true);

			_parent?.JumpToPalletLabel(pageNumber);
		}
	}
}
