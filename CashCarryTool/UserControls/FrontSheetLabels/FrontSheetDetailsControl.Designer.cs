namespace Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels
{
	partial class FrontSheetDetailsControl
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.FillInCheck = new System.Windows.Forms.CheckBox();
			this.PartiallyFillInCheck = new System.Windows.Forms.CheckBox();
			this.FullPalletBreakDownCheck = new System.Windows.Forms.CheckBox();
			this.InvoiceNumbersGridView = new System.Windows.Forms.DataGridView();
			this.invoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.stringValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.invoiceNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.mixedUnitsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bulkUnitsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ambientUnitsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceNumbersGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stringValueBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(361, 275);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Front Sheet";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.InvoiceNumbersGridView);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(355, 256);
			this.panel1.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.FillInCheck);
			this.panel2.Controls.Add(this.PartiallyFillInCheck);
			this.panel2.Controls.Add(this.FullPalletBreakDownCheck);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(355, 23);
			this.panel2.TabIndex = 2;
			// 
			// FillInCheck
			// 
			this.FillInCheck.AutoSize = true;
			this.FillInCheck.Location = new System.Drawing.Point(232, 3);
			this.FillInCheck.Name = "FillInCheck";
			this.FillInCheck.Size = new System.Drawing.Size(50, 17);
			this.FillInCheck.TabIndex = 3;
			this.FillInCheck.Text = "Fill In";
			this.FillInCheck.UseVisualStyleBackColor = true;
			this.FillInCheck.CheckedChanged += new System.EventHandler(this.FillInCheck_CheckedChanged);
			// 
			// PartiallyFillInCheck
			// 
			this.PartiallyFillInCheck.AutoSize = true;
			this.PartiallyFillInCheck.Checked = true;
			this.PartiallyFillInCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.PartiallyFillInCheck.Location = new System.Drawing.Point(137, 3);
			this.PartiallyFillInCheck.Name = "PartiallyFillInCheck";
			this.PartiallyFillInCheck.Size = new System.Drawing.Size(89, 17);
			this.PartiallyFillInCheck.TabIndex = 2;
			this.PartiallyFillInCheck.Text = "Partially Fill In";
			this.PartiallyFillInCheck.UseVisualStyleBackColor = true;
			this.PartiallyFillInCheck.CheckedChanged += new System.EventHandler(this.FillInPalletsCheck_CheckedChanged);
			// 
			// FullPalletBreakDownCheck
			// 
			this.FullPalletBreakDownCheck.AutoSize = true;
			this.FullPalletBreakDownCheck.Location = new System.Drawing.Point(3, 3);
			this.FullPalletBreakDownCheck.Name = "FullPalletBreakDownCheck";
			this.FullPalletBreakDownCheck.Size = new System.Drawing.Size(128, 17);
			this.FullPalletBreakDownCheck.TabIndex = 1;
			this.FullPalletBreakDownCheck.Text = "Full Pallet Breakdown";
			this.FullPalletBreakDownCheck.UseVisualStyleBackColor = true;
			this.FullPalletBreakDownCheck.CheckedChanged += new System.EventHandler(this.FullPalletBreakDownCheck_CheckedChanged);
			// 
			// InvoiceNumbersGridView
			// 
			this.InvoiceNumbersGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.InvoiceNumbersGridView.AutoGenerateColumns = false;
			this.InvoiceNumbersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.InvoiceNumbersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.InvoiceNumbersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invoiceNumberDataGridViewTextBoxColumn,
            this.mixedUnitsDataGridViewTextBoxColumn,
            this.bulkUnitsDataGridViewTextBoxColumn,
            this.ambientUnitsDataGridViewTextBoxColumn});
			this.InvoiceNumbersGridView.DataSource = this.invoiceBindingSource;
			this.InvoiceNumbersGridView.Location = new System.Drawing.Point(0, 29);
			this.InvoiceNumbersGridView.Name = "InvoiceNumbersGridView";
			this.InvoiceNumbersGridView.RowHeadersVisible = false;
			this.InvoiceNumbersGridView.Size = new System.Drawing.Size(355, 227);
			this.InvoiceNumbersGridView.TabIndex = 0;
			this.InvoiceNumbersGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.InvoiceNumbersGridView_CellEndEdit);
			this.InvoiceNumbersGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.InvoiceNumbersGridView_CellValuePushed);
			// 
			// invoiceBindingSource
			// 
			this.invoiceBindingSource.DataSource = typeof(Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels.Invoice);
			// 
			// stringValueBindingSource
			// 
			this.stringValueBindingSource.DataSource = typeof(Eden_Farm_Cash___Carry_Tool.Models.StringValue);
			// 
			// invoiceNumberDataGridViewTextBoxColumn
			// 
			this.invoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNumber";
			this.invoiceNumberDataGridViewTextBoxColumn.HeaderText = "InvoiceNumber";
			this.invoiceNumberDataGridViewTextBoxColumn.Name = "invoiceNumberDataGridViewTextBoxColumn";
			// 
			// mixedUnitsDataGridViewTextBoxColumn
			// 
			this.mixedUnitsDataGridViewTextBoxColumn.DataPropertyName = "MixedUnits";
			this.mixedUnitsDataGridViewTextBoxColumn.HeaderText = "MixedUnits";
			this.mixedUnitsDataGridViewTextBoxColumn.Name = "mixedUnitsDataGridViewTextBoxColumn";
			// 
			// bulkUnitsDataGridViewTextBoxColumn
			// 
			this.bulkUnitsDataGridViewTextBoxColumn.DataPropertyName = "BulkUnits";
			this.bulkUnitsDataGridViewTextBoxColumn.HeaderText = "BulkUnits";
			this.bulkUnitsDataGridViewTextBoxColumn.Name = "bulkUnitsDataGridViewTextBoxColumn";
			// 
			// ambientUnitsDataGridViewTextBoxColumn
			// 
			this.ambientUnitsDataGridViewTextBoxColumn.DataPropertyName = "AmbientUnits";
			this.ambientUnitsDataGridViewTextBoxColumn.HeaderText = "AmbientUnits";
			this.ambientUnitsDataGridViewTextBoxColumn.Name = "ambientUnitsDataGridViewTextBoxColumn";
			// 
			// FrontSheetDetailsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox2);
			this.Name = "FrontSheetDetailsControl";
			this.Size = new System.Drawing.Size(361, 275);
			this.groupBox2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceNumbersGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.invoiceBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stringValueBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGridView InvoiceNumbersGridView;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.BindingSource stringValueBindingSource;
		private System.Windows.Forms.CheckBox FullPalletBreakDownCheck;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.CheckBox PartiallyFillInCheck;
		private System.Windows.Forms.CheckBox FillInCheck;
		private System.Windows.Forms.BindingSource invoiceBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn invoiceNumberDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn mixedUnitsDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn bulkUnitsDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ambientUnitsDataGridViewTextBoxColumn;
	}
}
