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
			this.InvoiceNumbersGridView = new System.Windows.Forms.DataGridView();
			this.InvoiceNumbersGridViewNumbersColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.stringValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.InvoiceNumbersGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stringValueBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(260, 269);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Front Sheet";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.InvoiceNumbersGridView);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(254, 250);
			this.panel1.TabIndex = 1;
			// 
			// InvoiceNumbersGridView
			// 
			this.InvoiceNumbersGridView.AutoGenerateColumns = false;
			this.InvoiceNumbersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.InvoiceNumbersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.InvoiceNumbersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceNumbersGridViewNumbersColumn});
			this.InvoiceNumbersGridView.DataSource = this.stringValueBindingSource;
			this.InvoiceNumbersGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.InvoiceNumbersGridView.Location = new System.Drawing.Point(0, 0);
			this.InvoiceNumbersGridView.Name = "InvoiceNumbersGridView";
			this.InvoiceNumbersGridView.RowHeadersVisible = false;
			this.InvoiceNumbersGridView.Size = new System.Drawing.Size(254, 250);
			this.InvoiceNumbersGridView.TabIndex = 0;
			this.InvoiceNumbersGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.InvoiceNumbersGridView_CellEndEdit);
			this.InvoiceNumbersGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.InvoiceNumbersGridView_CellValuePushed);
			// 
			// InvoiceNumbersGridViewNumbersColumn
			// 
			this.InvoiceNumbersGridViewNumbersColumn.DataPropertyName = "Value";
			this.InvoiceNumbersGridViewNumbersColumn.HeaderText = "Invoice Number";
			this.InvoiceNumbersGridViewNumbersColumn.Name = "InvoiceNumbersGridViewNumbersColumn";
			// 
			// stringValueBindingSource
			// 
			this.stringValueBindingSource.DataSource = typeof(Eden_Farm_Cash___Carry_Tool.Models.StringValue);
			// 
			// FrontSheetDetailsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox2);
			this.Name = "FrontSheetDetailsControl";
			this.Size = new System.Drawing.Size(260, 269);
			this.groupBox2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.InvoiceNumbersGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stringValueBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGridView InvoiceNumbersGridView;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNumbersGridViewNumbersColumn;
		private System.Windows.Forms.BindingSource stringValueBindingSource;
	}
}
