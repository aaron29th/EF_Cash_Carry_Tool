namespace Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels
{
	partial class GeneralDetailsControl
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.PickDateTomorrow = new System.Windows.Forms.Button();
			this.PickDateToday = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.PickDateSel = new System.Windows.Forms.DateTimePicker();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.DeliveryDateTomorrow = new System.Windows.Forms.Button();
			this.DeliveryDateToday = new System.Windows.Forms.Button();
			this.DeliveryDateMonday = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.DeliveryDateSel = new System.Windows.Forms.DateTimePicker();
			this.panel1 = new System.Windows.Forms.Panel();
			this.LabelTitleSizeAutoCheck = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.LabelTitleSizeNumEdit = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.DetailsQuickSelect = new System.Windows.Forms.ComboBox();
			this.CustomerCodeTxt = new System.Windows.Forms.TextBox();
			this.TitleTxt = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LabelTitleSizeNumEdit)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(260, 329);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "General Details";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel2.Controls.Add(this.tableLayoutPanel2);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.PickDateSel);
			this.panel2.Controls.Add(this.tableLayoutPanel1);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.DeliveryDateSel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 174);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(254, 152);
			this.panel2.TabIndex = 1;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.Controls.Add(this.PickDateTomorrow, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.PickDateToday, 0, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 115);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(235, 30);
			this.tableLayoutPanel2.TabIndex = 27;
			// 
			// PickDateTomorrow
			// 
			this.PickDateTomorrow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PickDateTomorrow.Location = new System.Drawing.Point(120, 3);
			this.PickDateTomorrow.Name = "PickDateTomorrow";
			this.PickDateTomorrow.Size = new System.Drawing.Size(112, 24);
			this.PickDateTomorrow.TabIndex = 22;
			this.PickDateTomorrow.Text = "Tomorrow";
			this.PickDateTomorrow.UseVisualStyleBackColor = true;
			this.PickDateTomorrow.Click += new System.EventHandler(this.PickDateTomorrow_Click);
			// 
			// PickDateToday
			// 
			this.PickDateToday.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PickDateToday.Location = new System.Drawing.Point(3, 3);
			this.PickDateToday.Name = "PickDateToday";
			this.PickDateToday.Size = new System.Drawing.Size(111, 24);
			this.PickDateToday.TabIndex = 21;
			this.PickDateToday.Text = "Today";
			this.PickDateToday.UseVisualStyleBackColor = true;
			this.PickDateToday.Click += new System.EventHandler(this.PickDateToday_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(2, 74);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 13);
			this.label4.TabIndex = 26;
			this.label4.Text = "Date Picked";
			// 
			// PickDateSel
			// 
			this.PickDateSel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PickDateSel.Location = new System.Drawing.Point(5, 90);
			this.PickDateSel.Margin = new System.Windows.Forms.Padding(2);
			this.PickDateSel.Name = "PickDateSel";
			this.PickDateSel.Size = new System.Drawing.Size(235, 20);
			this.PickDateSel.TabIndex = 25;
			this.PickDateSel.Value = new System.DateTime(2020, 5, 26, 23, 9, 58, 0);
			this.PickDateSel.ValueChanged += new System.EventHandler(this.PickDateSel_ValueChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Controls.Add(this.DeliveryDateTomorrow, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.DeliveryDateToday, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.DeliveryDateMonday, 2, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 41);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(235, 30);
			this.tableLayoutPanel1.TabIndex = 24;
			// 
			// DeliveryDateTomorrow
			// 
			this.DeliveryDateTomorrow.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DeliveryDateTomorrow.Location = new System.Drawing.Point(81, 3);
			this.DeliveryDateTomorrow.Name = "DeliveryDateTomorrow";
			this.DeliveryDateTomorrow.Size = new System.Drawing.Size(72, 24);
			this.DeliveryDateTomorrow.TabIndex = 22;
			this.DeliveryDateTomorrow.Text = "Tomorrow";
			this.DeliveryDateTomorrow.UseVisualStyleBackColor = true;
			this.DeliveryDateTomorrow.Click += new System.EventHandler(this.DeliveryDateTomorrow_Click);
			// 
			// DeliveryDateToday
			// 
			this.DeliveryDateToday.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DeliveryDateToday.Location = new System.Drawing.Point(3, 3);
			this.DeliveryDateToday.Name = "DeliveryDateToday";
			this.DeliveryDateToday.Size = new System.Drawing.Size(72, 24);
			this.DeliveryDateToday.TabIndex = 21;
			this.DeliveryDateToday.Text = "Today";
			this.DeliveryDateToday.UseVisualStyleBackColor = true;
			this.DeliveryDateToday.Click += new System.EventHandler(this.DeliveryDateToday_Click);
			// 
			// DeliveryDateMonday
			// 
			this.DeliveryDateMonday.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DeliveryDateMonday.Location = new System.Drawing.Point(159, 3);
			this.DeliveryDateMonday.Name = "DeliveryDateMonday";
			this.DeliveryDateMonday.Size = new System.Drawing.Size(73, 24);
			this.DeliveryDateMonday.TabIndex = 23;
			this.DeliveryDateMonday.Text = "Monday";
			this.DeliveryDateMonday.UseVisualStyleBackColor = true;
			this.DeliveryDateMonday.Click += new System.EventHandler(this.DeliveryDateMonday_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(2, 0);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 13);
			this.label3.TabIndex = 20;
			this.label3.Text = "Delivery Date";
			// 
			// DeliveryDateSel
			// 
			this.DeliveryDateSel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DeliveryDateSel.Location = new System.Drawing.Point(5, 16);
			this.DeliveryDateSel.Margin = new System.Windows.Forms.Padding(2);
			this.DeliveryDateSel.Name = "DeliveryDateSel";
			this.DeliveryDateSel.Size = new System.Drawing.Size(235, 20);
			this.DeliveryDateSel.TabIndex = 19;
			this.DeliveryDateSel.Value = new System.DateTime(2020, 5, 26, 23, 9, 58, 0);
			this.DeliveryDateSel.ValueChanged += new System.EventHandler(this.DeliveryDateSel_ValueChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.LabelTitleSizeAutoCheck);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.LabelTitleSizeNumEdit);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.DetailsQuickSelect);
			this.panel1.Controls.Add(this.CustomerCodeTxt);
			this.panel1.Controls.Add(this.TitleTxt);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(3, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(254, 158);
			this.panel1.TabIndex = 0;
			// 
			// LabelTitleSizeAutoCheck
			// 
			this.LabelTitleSizeAutoCheck.AutoSize = true;
			this.LabelTitleSizeAutoCheck.Checked = true;
			this.LabelTitleSizeAutoCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.LabelTitleSizeAutoCheck.Location = new System.Drawing.Point(192, 55);
			this.LabelTitleSizeAutoCheck.Name = "LabelTitleSizeAutoCheck";
			this.LabelTitleSizeAutoCheck.Size = new System.Drawing.Size(48, 17);
			this.LabelTitleSizeAutoCheck.TabIndex = 29;
			this.LabelTitleSizeAutoCheck.Text = "Auto";
			this.LabelTitleSizeAutoCheck.UseVisualStyleBackColor = true;
			this.LabelTitleSizeAutoCheck.CheckedChanged += new System.EventHandler(this.LabelTitleSizeAutoCheck_CheckedChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(2, 38);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(79, 13);
			this.label5.TabIndex = 28;
			this.label5.Text = "Label Title Size";
			// 
			// LabelTitleSizeNumEdit
			// 
			this.LabelTitleSizeNumEdit.Enabled = false;
			this.LabelTitleSizeNumEdit.Location = new System.Drawing.Point(5, 54);
			this.LabelTitleSizeNumEdit.Name = "LabelTitleSizeNumEdit";
			this.LabelTitleSizeNumEdit.Size = new System.Drawing.Size(181, 20);
			this.LabelTitleSizeNumEdit.TabIndex = 27;
			this.LabelTitleSizeNumEdit.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
			this.LabelTitleSizeNumEdit.ValueChanged += new System.EventHandler(this.LabelTitleSizeNumEdit_ValueChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(2, 115);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(68, 13);
			this.label6.TabIndex = 26;
			this.label6.Text = "Quick Select";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Title";
			// 
			// DetailsQuickSelect
			// 
			this.DetailsQuickSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DetailsQuickSelect.DisplayMember = "SelectionText";
			this.DetailsQuickSelect.FormattingEnabled = true;
			this.DetailsQuickSelect.Location = new System.Drawing.Point(5, 131);
			this.DetailsQuickSelect.Name = "DetailsQuickSelect";
			this.DetailsQuickSelect.Size = new System.Drawing.Size(235, 21);
			this.DetailsQuickSelect.TabIndex = 25;
			this.DetailsQuickSelect.SelectedIndexChanged += new System.EventHandler(this.DetailsQuickSelect_SelectedIndexChanged);
			// 
			// CustomerCodeTxt
			// 
			this.CustomerCodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CustomerCodeTxt.Location = new System.Drawing.Point(5, 93);
			this.CustomerCodeTxt.Margin = new System.Windows.Forms.Padding(2);
			this.CustomerCodeTxt.Name = "CustomerCodeTxt";
			this.CustomerCodeTxt.Size = new System.Drawing.Size(235, 20);
			this.CustomerCodeTxt.TabIndex = 22;
			this.CustomerCodeTxt.TextChanged += new System.EventHandler(this.CustomerCodeTxt_TextChanged);
			// 
			// TitleTxt
			// 
			this.TitleTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TitleTxt.Location = new System.Drawing.Point(5, 16);
			this.TitleTxt.Margin = new System.Windows.Forms.Padding(2);
			this.TitleTxt.Name = "TitleTxt";
			this.TitleTxt.Size = new System.Drawing.Size(235, 20);
			this.TitleTxt.TabIndex = 21;
			this.TitleTxt.TextChanged += new System.EventHandler(this.TitleTxt_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(2, 77);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 13);
			this.label2.TabIndex = 24;
			this.label2.Text = "Customer Code";
			// 
			// GeneralDetailsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Name = "GeneralDetailsControl";
			this.Size = new System.Drawing.Size(260, 329);
			this.groupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LabelTitleSizeNumEdit)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox DetailsQuickSelect;
		private System.Windows.Forms.TextBox CustomerCodeTxt;
		private System.Windows.Forms.TextBox TitleTxt;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker DeliveryDateSel;
		private System.Windows.Forms.Button DeliveryDateMonday;
		private System.Windows.Forms.Button DeliveryDateToday;
		private System.Windows.Forms.Button DeliveryDateTomorrow;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button PickDateTomorrow;
		private System.Windows.Forms.Button PickDateToday;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker PickDateSel;
		private System.Windows.Forms.CheckBox LabelTitleSizeAutoCheck;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown LabelTitleSizeNumEdit;
	}
}
