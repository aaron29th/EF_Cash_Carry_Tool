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
			this.FilesPanel = new System.Windows.Forms.Panel();
			this.FilesGridView = new System.Windows.Forms.DataGridView();
			this.textDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.checkedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.checkedDataViewItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.RefreshPicksBtn = new System.Windows.Forms.Button();
			this.PageListBox = new System.Windows.Forms.ListBox();
			this.LinesGridView = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.LinesPanel = new System.Windows.Forms.Panel();
			this.PagesPanel = new System.Windows.Forms.Panel();
			this.ClearPicksFolderBtn = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.DeselectPagesLinesBtn = new System.Windows.Forms.Button();
			this.FilesPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.FilesGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.checkedDataViewItemBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LinesGridView)).BeginInit();
			this.LinesPanel.SuspendLayout();
			this.PagesPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// FilesPanel
			// 
			this.FilesPanel.Controls.Add(this.panel1);
			this.FilesPanel.Controls.Add(this.FilesGridView);
			this.FilesPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.FilesPanel.Location = new System.Drawing.Point(0, 0);
			this.FilesPanel.Name = "FilesPanel";
			this.FilesPanel.Size = new System.Drawing.Size(340, 233);
			this.FilesPanel.TabIndex = 1;
			// 
			// FilesGridView
			// 
			this.FilesGridView.AllowUserToAddRows = false;
			this.FilesGridView.AllowUserToDeleteRows = false;
			this.FilesGridView.AllowUserToResizeColumns = false;
			this.FilesGridView.AllowUserToResizeRows = false;
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
			this.FilesGridView.Size = new System.Drawing.Size(340, 233);
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
			this.RefreshPicksBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RefreshPicksBtn.Location = new System.Drawing.Point(3, 3);
			this.RefreshPicksBtn.Name = "RefreshPicksBtn";
			this.RefreshPicksBtn.Size = new System.Drawing.Size(334, 28);
			this.RefreshPicksBtn.TabIndex = 0;
			this.RefreshPicksBtn.Text = "Reload";
			this.RefreshPicksBtn.UseVisualStyleBackColor = true;
			this.RefreshPicksBtn.Click += new System.EventHandler(this.RefreshPicksBtn_Click);
			// 
			// PageListBox
			// 
			this.PageListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PageListBox.FormattingEnabled = true;
			this.PageListBox.Location = new System.Drawing.Point(0, 20);
			this.PageListBox.Name = "PageListBox";
			this.PageListBox.Size = new System.Drawing.Size(340, 96);
			this.PageListBox.TabIndex = 5;
			this.PageListBox.SelectedIndexChanged += new System.EventHandler(this.PageListBox_SelectedIndexChanged);
			// 
			// LinesGridView
			// 
			this.LinesGridView.AllowUserToAddRows = false;
			this.LinesGridView.AllowUserToDeleteRows = false;
			this.LinesGridView.AllowUserToResizeColumns = false;
			this.LinesGridView.AllowUserToResizeRows = false;
			this.LinesGridView.AutoGenerateColumns = false;
			this.LinesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.LinesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.LinesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewCheckBoxColumn1});
			this.LinesGridView.DataSource = this.checkedDataViewItemBindingSource;
			this.LinesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LinesGridView.Location = new System.Drawing.Point(0, 0);
			this.LinesGridView.Name = "LinesGridView";
			this.LinesGridView.RowHeadersVisible = false;
			this.LinesGridView.Size = new System.Drawing.Size(340, 222);
			this.LinesGridView.TabIndex = 2;
			this.LinesGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.LinesGridView_CellValueChanged);
			this.LinesGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.LinesGridView_CurrentCellDirtyStateChanged);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Text";
			this.dataGridViewTextBoxColumn1.HeaderText = "Line Number";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			// 
			// dataGridViewCheckBoxColumn1
			// 
			this.dataGridViewCheckBoxColumn1.DataPropertyName = "Checked";
			this.dataGridViewCheckBoxColumn1.HeaderText = "Selected";
			this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			// 
			// LinesPanel
			// 
			this.LinesPanel.Controls.Add(this.LinesGridView);
			this.LinesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LinesPanel.Location = new System.Drawing.Point(0, 383);
			this.LinesPanel.Name = "LinesPanel";
			this.LinesPanel.Size = new System.Drawing.Size(340, 222);
			this.LinesPanel.TabIndex = 6;
			// 
			// PagesPanel
			// 
			this.PagesPanel.Controls.Add(this.PageListBox);
			this.PagesPanel.Controls.Add(this.panel3);
			this.PagesPanel.Controls.Add(this.panel2);
			this.PagesPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.PagesPanel.Location = new System.Drawing.Point(0, 233);
			this.PagesPanel.Name = "PagesPanel";
			this.PagesPanel.Size = new System.Drawing.Size(340, 150);
			this.PagesPanel.TabIndex = 7;
			// 
			// ClearPicksFolderBtn
			// 
			this.ClearPicksFolderBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ClearPicksFolderBtn.Location = new System.Drawing.Point(3, 37);
			this.ClearPicksFolderBtn.Name = "ClearPicksFolderBtn";
			this.ClearPicksFolderBtn.Size = new System.Drawing.Size(334, 31);
			this.ClearPicksFolderBtn.TabIndex = 2;
			this.ClearPicksFolderBtn.Text = "Clear Folder";
			this.ClearPicksFolderBtn.UseVisualStyleBackColor = true;
			this.ClearPicksFolderBtn.Click += new System.EventHandler(this.ClearPicksFolderBtn_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.RefreshPicksBtn);
			this.panel1.Controls.Add(this.ClearPicksFolderBtn);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 157);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(340, 76);
			this.panel1.TabIndex = 3;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(340, 20);
			this.panel2.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Page Number";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.DeselectPagesLinesBtn);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 116);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(340, 34);
			this.panel3.TabIndex = 7;
			// 
			// DeselectPagesLinesBtn
			// 
			this.DeselectPagesLinesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DeselectPagesLinesBtn.Location = new System.Drawing.Point(3, 3);
			this.DeselectPagesLinesBtn.Name = "DeselectPagesLinesBtn";
			this.DeselectPagesLinesBtn.Size = new System.Drawing.Size(334, 26);
			this.DeselectPagesLinesBtn.TabIndex = 0;
			this.DeselectPagesLinesBtn.Text = "Deselect Pages Lines";
			this.DeselectPagesLinesBtn.UseVisualStyleBackColor = true;
			this.DeselectPagesLinesBtn.Click += new System.EventHandler(this.DeselectPagesLinesBtn_Click);
			// 
			// PickSheetLoadControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.LinesPanel);
			this.Controls.Add(this.PagesPanel);
			this.Controls.Add(this.FilesPanel);
			this.Name = "PickSheetLoadControl";
			this.Size = new System.Drawing.Size(340, 605);
			this.FilesPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.FilesGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.checkedDataViewItemBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LinesGridView)).EndInit();
			this.LinesPanel.ResumeLayout(false);
			this.PagesPanel.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel FilesPanel;
		private System.Windows.Forms.Button RefreshPicksBtn;
		private System.Windows.Forms.ListBox PageListBox;
		private System.Windows.Forms.DataGridView FilesGridView;
		private System.Windows.Forms.BindingSource checkedDataViewItemBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn textDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn checkedDataGridViewCheckBoxColumn;
		private System.Windows.Forms.DataGridView LinesGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
		private System.Windows.Forms.Panel LinesPanel;
		private System.Windows.Forms.Panel PagesPanel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button ClearPicksFolderBtn;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button DeselectPagesLinesBtn;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
	}
}
