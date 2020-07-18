namespace Eden_Farm_Cash___Carry_Tool.UserControls.PickSheet
{
	partial class PickSheetLoadControl
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.FilesGridView = new System.Windows.Forms.DataGridView();
			this.textDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.checkedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.checkedDataViewItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.RefreshPicksBtn = new System.Windows.Forms.Button();
			this.LinesCheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.PageListBox = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.FilesGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkedDataViewItemBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.FilesGridView);
			this.panel1.Controls.Add(this.RefreshPicksBtn);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(340, 171);
			this.panel1.TabIndex = 1;
			// 
			// FilesGridView
			// 
			this.FilesGridView.AutoGenerateColumns = false;
			this.FilesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.FilesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.FilesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.textDataGridViewTextBoxColumn,
            this.checkedDataGridViewCheckBoxColumn});
			this.FilesGridView.DataSource = this.checkedDataViewItemBindingSource;
			this.FilesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FilesGridView.Location = new System.Drawing.Point(0, 0);
			this.FilesGridView.Name = "FilesGridView";
			this.FilesGridView.RowHeadersVisible = false;
			this.FilesGridView.Size = new System.Drawing.Size(340, 148);
			this.FilesGridView.TabIndex = 1;
			this.FilesGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.FilesGridView_CellValueChanged);
			this.FilesGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.FilesGridView_CurrentCellDirtyStateChanged);
			// 
			// textDataGridViewTextBoxColumn
			// 
			this.textDataGridViewTextBoxColumn.DataPropertyName = "Text";
			this.textDataGridViewTextBoxColumn.HeaderText = "File Name";
			this.textDataGridViewTextBoxColumn.Name = "textDataGridViewTextBoxColumn";
			// 
			// checkedDataGridViewCheckBoxColumn
			// 
			this.checkedDataGridViewCheckBoxColumn.DataPropertyName = "Checked";
			this.checkedDataGridViewCheckBoxColumn.HeaderText = "Selected";
			this.checkedDataGridViewCheckBoxColumn.Name = "checkedDataGridViewCheckBoxColumn";
			// 
			// checkedDataViewItemBindingSource
			// 
			this.checkedDataViewItemBindingSource.DataSource = typeof(Eden_Farm_Cash___Carry_Tool.Models.CheckedDataViewItem);
			// 
			// RefreshPicksBtn
			// 
			this.RefreshPicksBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.RefreshPicksBtn.Location = new System.Drawing.Point(0, 148);
			this.RefreshPicksBtn.Name = "RefreshPicksBtn";
			this.RefreshPicksBtn.Size = new System.Drawing.Size(340, 23);
			this.RefreshPicksBtn.TabIndex = 0;
			this.RefreshPicksBtn.Text = "Reload";
			this.RefreshPicksBtn.UseVisualStyleBackColor = true;
			this.RefreshPicksBtn.Click += new System.EventHandler(this.RefreshPicksBtn_Click);
			// 
			// LinesCheckedListBox
			// 
			this.LinesCheckedListBox.FormattingEnabled = true;
			this.LinesCheckedListBox.Location = new System.Drawing.Point(3, 405);
			this.LinesCheckedListBox.Name = "LinesCheckedListBox";
			this.LinesCheckedListBox.Size = new System.Drawing.Size(258, 94);
			this.LinesCheckedListBox.TabIndex = 4;
			// 
			// PageListBox
			// 
			this.PageListBox.FormattingEnabled = true;
			this.PageListBox.Location = new System.Drawing.Point(3, 177);
			this.PageListBox.Name = "PageListBox";
			this.PageListBox.Size = new System.Drawing.Size(334, 95);
			this.PageListBox.TabIndex = 5;
			// 
			// PickSheetLoadControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.PageListBox);
			this.Controls.Add(this.LinesCheckedListBox);
			this.Controls.Add(this.panel1);
			this.Name = "PickSheetLoadControl";
			this.Size = new System.Drawing.Size(340, 605);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.FilesGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkedDataViewItemBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button RefreshPicksBtn;
		private System.Windows.Forms.CheckedListBox LinesCheckedListBox;
		private System.Windows.Forms.ListBox PageListBox;
		private System.Windows.Forms.DataGridView FilesGridView;
		private System.Windows.Forms.BindingSource checkedDataViewItemBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn checkedDataGridViewCheckBoxColumn;
	}
}
