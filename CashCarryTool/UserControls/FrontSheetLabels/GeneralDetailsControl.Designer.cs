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
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.DetailsQuickSelect = new System.Windows.Forms.ComboBox();
			this.CustomerCodeTxt = new System.Windows.Forms.TextBox();
			this.TitleTxt = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.DeliveryDateSel = new System.Windows.Forms.DateTimePicker();
			this.DeliveryDateMonday = new System.Windows.Forms.Button();
			this.DeliveryDateToday = new System.Windows.Forms.Button();
			this.DeliveryDateTomorrow = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(260, 218);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "General Details";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.DetailsQuickSelect);
			this.panel1.Controls.Add(this.CustomerCodeTxt);
			this.panel1.Controls.Add(this.TitleTxt);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(3, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(254, 124);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.panel2.Controls.Add(this.tableLayoutPanel1);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.DeliveryDateSel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 140);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(254, 75);
			this.panel2.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(2, 74);
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
			this.DetailsQuickSelect.Location = new System.Drawing.Point(5, 90);
			this.DetailsQuickSelect.Name = "DetailsQuickSelect";
			this.DetailsQuickSelect.Size = new System.Drawing.Size(235, 21);
			this.DetailsQuickSelect.TabIndex = 25;
			this.DetailsQuickSelect.SelectedIndexChanged += new System.EventHandler(this.DetailsQuickSelect_SelectedIndexChanged);
			// 
			// CustomerCodeTxt
			// 
			this.CustomerCodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CustomerCodeTxt.Location = new System.Drawing.Point(5, 52);
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
			this.label2.Location = new System.Drawing.Point(2, 36);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 13);
			this.label2.TabIndex = 24;
			this.label2.Text = "Customer Code";
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
			this.tableLayoutPanel1.Size = new System.Drawing.Size(235, 30);
			this.tableLayoutPanel1.TabIndex = 24;
			// 
			// GeneralDetailsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Name = "GeneralDetailsControl";
			this.Size = new System.Drawing.Size(260, 218);
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
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
	}
}
