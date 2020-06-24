namespace Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels
{
	partial class LabelDetailsControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.PalletsGridView = new System.Windows.Forms.DataGridView();
			this.PalletsGridViewSelectedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.PalletsGridViewTypeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.palletBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.panel2 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.SecondRunVehicleTxt = new System.Windows.Forms.TextBox();
			this.SecondRunCheck = new System.Windows.Forms.CheckBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.PalletsUncheckAll = new System.Windows.Forms.Button();
			this.PalletsCheckAll = new System.Windows.Forms.Button();
			this.MixedPalletsUncheckAll = new System.Windows.Forms.Button();
			this.MixedPalletsCheckAll = new System.Windows.Forms.Button();
			this.BulkPalletsUncheckAll = new System.Windows.Forms.Button();
			this.BulkPalletsCheckAll = new System.Windows.Forms.Button();
			this.IcePalletsUncheckAll = new System.Windows.Forms.Button();
			this.IcePalletsCheckAll = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.NumLabelsPerPalletSpin = new System.Windows.Forms.NumericUpDown();
			this.TotalPalletsLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.NumBulkPalletsSpin = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.NumIcePalletsSpin = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.NumMixedPalletsSpin = new System.Windows.Forms.NumericUpDown();
			this.groupBox3.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PalletsGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.palletBindingSource)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumLabelsPerPalletSpin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumBulkPalletsSpin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumIcePalletsSpin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumMixedPalletsSpin)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.panel3);
			this.groupBox3.Controls.Add(this.panel2);
			this.groupBox3.Controls.Add(this.panel1);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(284, 572);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Labels";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.PalletsGridView);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 206);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(278, 286);
			this.panel3.TabIndex = 2;
			// 
			// PalletsGridView
			// 
			this.PalletsGridView.AllowUserToAddRows = false;
			this.PalletsGridView.AllowUserToDeleteRows = false;
			this.PalletsGridView.AutoGenerateColumns = false;
			this.PalletsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.PalletsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PalletsGridViewSelectedColumn,
            this.PalletsGridViewTypeColumn});
			this.PalletsGridView.DataSource = this.palletBindingSource;
			this.PalletsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PalletsGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.PalletsGridView.Location = new System.Drawing.Point(0, 0);
			this.PalletsGridView.Name = "PalletsGridView";
			this.PalletsGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.PalletsGridView.Size = new System.Drawing.Size(278, 286);
			this.PalletsGridView.TabIndex = 0;
			this.PalletsGridView.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.PalletsGridView_CellMouseUp);
			this.PalletsGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.PalletsGridView_CellValueChanged);
			this.PalletsGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.PalletsGridView_CurrentCellDirtyStateChanged);
			this.PalletsGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.PalletsGridView_DataBindingComplete);
			this.PalletsGridView.DoubleClick += new System.EventHandler(this.PalletsGridView_DoubleClick);
			// 
			// PalletsGridViewSelectedColumn
			// 
			this.PalletsGridViewSelectedColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.PalletsGridViewSelectedColumn.DataPropertyName = "Selected";
			this.PalletsGridViewSelectedColumn.HeaderText = "Selected";
			this.PalletsGridViewSelectedColumn.Name = "PalletsGridViewSelectedColumn";
			// 
			// PalletsGridViewTypeColumn
			// 
			this.PalletsGridViewTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.PalletsGridViewTypeColumn.DataPropertyName = "Type";
			this.PalletsGridViewTypeColumn.HeaderText = "Type";
			this.PalletsGridViewTypeColumn.Name = "PalletsGridViewTypeColumn";
			this.PalletsGridViewTypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.PalletsGridViewTypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// palletBindingSource
			// 
			this.palletBindingSource.DataSource = typeof(Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels.Pallet);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label7);
			this.panel2.Controls.Add(this.SecondRunVehicleTxt);
			this.panel2.Controls.Add(this.SecondRunCheck);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(3, 492);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(278, 77);
			this.panel2.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(2, 26);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(42, 13);
			this.label7.TabIndex = 9;
			this.label7.Text = "Vehicle";
			// 
			// SecondRunVehicleTxt
			// 
			this.SecondRunVehicleTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SecondRunVehicleTxt.Enabled = false;
			this.SecondRunVehicleTxt.Location = new System.Drawing.Point(5, 41);
			this.SecondRunVehicleTxt.Margin = new System.Windows.Forms.Padding(2);
			this.SecondRunVehicleTxt.Name = "SecondRunVehicleTxt";
			this.SecondRunVehicleTxt.Size = new System.Drawing.Size(271, 20);
			this.SecondRunVehicleTxt.TabIndex = 8;
			this.SecondRunVehicleTxt.TextChanged += new System.EventHandler(this.SecondRunVehicleTxt_TextChanged);
			// 
			// SecondRunCheck
			// 
			this.SecondRunCheck.AutoSize = true;
			this.SecondRunCheck.Location = new System.Drawing.Point(5, 6);
			this.SecondRunCheck.Name = "SecondRunCheck";
			this.SecondRunCheck.Size = new System.Drawing.Size(86, 17);
			this.SecondRunCheck.TabIndex = 7;
			this.SecondRunCheck.Text = "Second Run";
			this.SecondRunCheck.UseVisualStyleBackColor = true;
			this.SecondRunCheck.CheckedChanged += new System.EventHandler(this.SecondRunCheck_CheckedChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.PalletsUncheckAll);
			this.panel1.Controls.Add(this.PalletsCheckAll);
			this.panel1.Controls.Add(this.MixedPalletsUncheckAll);
			this.panel1.Controls.Add(this.MixedPalletsCheckAll);
			this.panel1.Controls.Add(this.BulkPalletsUncheckAll);
			this.panel1.Controls.Add(this.BulkPalletsCheckAll);
			this.panel1.Controls.Add(this.IcePalletsUncheckAll);
			this.panel1.Controls.Add(this.IcePalletsCheckAll);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.NumLabelsPerPalletSpin);
			this.panel1.Controls.Add(this.TotalPalletsLabel);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.NumBulkPalletsSpin);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.NumIcePalletsSpin);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.NumMixedPalletsSpin);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(3, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(278, 190);
			this.panel1.TabIndex = 0;
			// 
			// PalletsUncheckAll
			// 
			this.PalletsUncheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.PalletsUncheckAll.Location = new System.Drawing.Point(202, 0);
			this.PalletsUncheckAll.Name = "PalletsUncheckAll";
			this.PalletsUncheckAll.Size = new System.Drawing.Size(73, 23);
			this.PalletsUncheckAll.TabIndex = 31;
			this.PalletsUncheckAll.Text = "Uncheck All";
			this.PalletsUncheckAll.UseVisualStyleBackColor = true;
			this.PalletsUncheckAll.Click += new System.EventHandler(this.PalletsUncheckAll_Click);
			// 
			// PalletsCheckAll
			// 
			this.PalletsCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.PalletsCheckAll.Location = new System.Drawing.Point(123, 0);
			this.PalletsCheckAll.Name = "PalletsCheckAll";
			this.PalletsCheckAll.Size = new System.Drawing.Size(73, 23);
			this.PalletsCheckAll.TabIndex = 30;
			this.PalletsCheckAll.Text = "Check All";
			this.PalletsCheckAll.UseVisualStyleBackColor = true;
			this.PalletsCheckAll.Click += new System.EventHandler(this.PalletsCheckAll_Click);
			// 
			// MixedPalletsUncheckAll
			// 
			this.MixedPalletsUncheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.MixedPalletsUncheckAll.Location = new System.Drawing.Point(202, 106);
			this.MixedPalletsUncheckAll.Name = "MixedPalletsUncheckAll";
			this.MixedPalletsUncheckAll.Size = new System.Drawing.Size(73, 23);
			this.MixedPalletsUncheckAll.TabIndex = 29;
			this.MixedPalletsUncheckAll.Text = "Uncheck All";
			this.MixedPalletsUncheckAll.UseVisualStyleBackColor = true;
			this.MixedPalletsUncheckAll.Click += new System.EventHandler(this.MixedPalletsUncheckAll_Click);
			// 
			// MixedPalletsCheckAll
			// 
			this.MixedPalletsCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.MixedPalletsCheckAll.Location = new System.Drawing.Point(123, 106);
			this.MixedPalletsCheckAll.Name = "MixedPalletsCheckAll";
			this.MixedPalletsCheckAll.Size = new System.Drawing.Size(73, 23);
			this.MixedPalletsCheckAll.TabIndex = 28;
			this.MixedPalletsCheckAll.Text = "Check All";
			this.MixedPalletsCheckAll.UseVisualStyleBackColor = true;
			this.MixedPalletsCheckAll.Click += new System.EventHandler(this.MixedPalletsCheckAll_Click);
			// 
			// BulkPalletsUncheckAll
			// 
			this.BulkPalletsUncheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BulkPalletsUncheckAll.Location = new System.Drawing.Point(202, 69);
			this.BulkPalletsUncheckAll.Name = "BulkPalletsUncheckAll";
			this.BulkPalletsUncheckAll.Size = new System.Drawing.Size(73, 23);
			this.BulkPalletsUncheckAll.TabIndex = 27;
			this.BulkPalletsUncheckAll.Text = "Uncheck All";
			this.BulkPalletsUncheckAll.UseVisualStyleBackColor = true;
			this.BulkPalletsUncheckAll.Click += new System.EventHandler(this.BulkPalletsUncheckAll_Click);
			// 
			// BulkPalletsCheckAll
			// 
			this.BulkPalletsCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BulkPalletsCheckAll.Location = new System.Drawing.Point(123, 69);
			this.BulkPalletsCheckAll.Name = "BulkPalletsCheckAll";
			this.BulkPalletsCheckAll.Size = new System.Drawing.Size(73, 23);
			this.BulkPalletsCheckAll.TabIndex = 26;
			this.BulkPalletsCheckAll.Text = "Check All";
			this.BulkPalletsCheckAll.UseVisualStyleBackColor = true;
			this.BulkPalletsCheckAll.Click += new System.EventHandler(this.BulkPalletsCheckAll_Click);
			// 
			// IcePalletsUncheckAll
			// 
			this.IcePalletsUncheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.IcePalletsUncheckAll.Location = new System.Drawing.Point(202, 32);
			this.IcePalletsUncheckAll.Name = "IcePalletsUncheckAll";
			this.IcePalletsUncheckAll.Size = new System.Drawing.Size(73, 23);
			this.IcePalletsUncheckAll.TabIndex = 25;
			this.IcePalletsUncheckAll.Text = "Uncheck All";
			this.IcePalletsUncheckAll.UseVisualStyleBackColor = true;
			this.IcePalletsUncheckAll.Click += new System.EventHandler(this.IcePalletsUncheckAll_Click);
			// 
			// IcePalletsCheckAll
			// 
			this.IcePalletsCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.IcePalletsCheckAll.Location = new System.Drawing.Point(123, 32);
			this.IcePalletsCheckAll.Name = "IcePalletsCheckAll";
			this.IcePalletsCheckAll.Size = new System.Drawing.Size(73, 23);
			this.IcePalletsCheckAll.TabIndex = 24;
			this.IcePalletsCheckAll.Text = "Check All";
			this.IcePalletsCheckAll.UseVisualStyleBackColor = true;
			this.IcePalletsCheckAll.Click += new System.EventHandler(this.IcePalletsCheckAll_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(2, 141);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 13);
			this.label3.TabIndex = 23;
			this.label3.Text = "Labels Per Pallet";
			// 
			// NumLabelsPerPalletSpin
			// 
			this.NumLabelsPerPalletSpin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NumLabelsPerPalletSpin.Location = new System.Drawing.Point(5, 156);
			this.NumLabelsPerPalletSpin.Margin = new System.Windows.Forms.Padding(2);
			this.NumLabelsPerPalletSpin.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.NumLabelsPerPalletSpin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumLabelsPerPalletSpin.Name = "NumLabelsPerPalletSpin";
			this.NumLabelsPerPalletSpin.Size = new System.Drawing.Size(271, 20);
			this.NumLabelsPerPalletSpin.TabIndex = 22;
			this.NumLabelsPerPalletSpin.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.NumLabelsPerPalletSpin.ValueChanged += new System.EventHandler(this.NumLabelsPerPalletSpin_ValueChanged);
			// 
			// TotalPalletsLabel
			// 
			this.TotalPalletsLabel.AutoSize = true;
			this.TotalPalletsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TotalPalletsLabel.Location = new System.Drawing.Point(1, 0);
			this.TotalPalletsLabel.Name = "TotalPalletsLabel";
			this.TotalPalletsLabel.Size = new System.Drawing.Size(112, 20);
			this.TotalPalletsLabel.TabIndex = 21;
			this.TotalPalletsLabel.Text = "Total Pallets: 0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 57);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 20;
			this.label1.Text = "Bulk Pallets";
			// 
			// NumBulkPalletsSpin
			// 
			this.NumBulkPalletsSpin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NumBulkPalletsSpin.Location = new System.Drawing.Point(5, 72);
			this.NumBulkPalletsSpin.Margin = new System.Windows.Forms.Padding(2);
			this.NumBulkPalletsSpin.Name = "NumBulkPalletsSpin";
			this.NumBulkPalletsSpin.Size = new System.Drawing.Size(113, 20);
			this.NumBulkPalletsSpin.TabIndex = 19;
			this.NumBulkPalletsSpin.ValueChanged += new System.EventHandler(this.NumBulkPalletsSpin_ValueChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(2, 20);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 13);
			this.label8.TabIndex = 18;
			this.label8.Text = "Ice Pallets";
			// 
			// NumIcePalletsSpin
			// 
			this.NumIcePalletsSpin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NumIcePalletsSpin.Location = new System.Drawing.Point(5, 35);
			this.NumIcePalletsSpin.Margin = new System.Windows.Forms.Padding(2);
			this.NumIcePalletsSpin.Name = "NumIcePalletsSpin";
			this.NumIcePalletsSpin.Size = new System.Drawing.Size(113, 20);
			this.NumIcePalletsSpin.TabIndex = 17;
			this.NumIcePalletsSpin.ValueChanged += new System.EventHandler(this.NumIcePalletsSpin_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(2, 94);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 13);
			this.label4.TabIndex = 16;
			this.label4.Text = "Mixed Pallets";
			// 
			// NumMixedPalletsSpin
			// 
			this.NumMixedPalletsSpin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NumMixedPalletsSpin.Location = new System.Drawing.Point(5, 109);
			this.NumMixedPalletsSpin.Margin = new System.Windows.Forms.Padding(2);
			this.NumMixedPalletsSpin.Name = "NumMixedPalletsSpin";
			this.NumMixedPalletsSpin.Size = new System.Drawing.Size(113, 20);
			this.NumMixedPalletsSpin.TabIndex = 15;
			this.NumMixedPalletsSpin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumMixedPalletsSpin.ValueChanged += new System.EventHandler(this.NumMixedPalletsSpin_ValueChanged);
			// 
			// LabelDetailsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox3);
			this.Name = "LabelDetailsControl";
			this.Size = new System.Drawing.Size(284, 572);
			this.groupBox3.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PalletsGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.palletBindingSource)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumLabelsPerPalletSpin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumBulkPalletsSpin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumIcePalletsSpin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumMixedPalletsSpin)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label TotalPalletsLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown NumBulkPalletsSpin;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown NumIcePalletsSpin;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown NumMixedPalletsSpin;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox SecondRunVehicleTxt;
		private System.Windows.Forms.CheckBox SecondRunCheck;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown NumLabelsPerPalletSpin;
		private System.Windows.Forms.DataGridView PalletsGridView;
		private System.Windows.Forms.BindingSource palletBindingSource;
		private System.Windows.Forms.Button PalletsUncheckAll;
		private System.Windows.Forms.Button PalletsCheckAll;
		private System.Windows.Forms.Button MixedPalletsUncheckAll;
		private System.Windows.Forms.Button MixedPalletsCheckAll;
		private System.Windows.Forms.Button BulkPalletsUncheckAll;
		private System.Windows.Forms.Button BulkPalletsCheckAll;
		private System.Windows.Forms.Button IcePalletsUncheckAll;
		private System.Windows.Forms.Button IcePalletsCheckAll;
		private System.Windows.Forms.DataGridViewCheckBoxColumn PalletsGridViewSelectedColumn;
		private System.Windows.Forms.DataGridViewComboBoxColumn PalletsGridViewTypeColumn;
	}
}
