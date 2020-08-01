namespace InvoiceParser.Forms
{
	partial class SplitCustomerNameAddressForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplitCustomerNameAddressForm));
			this.SplitTextSlider = new System.Windows.Forms.TrackBar();
			this.CustomerNameTextbox = new System.Windows.Forms.TextBox();
			this.CustomerAddressLineTextbox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SplitLinesLabel = new System.Windows.Forms.Label();
			this.AcceptBtn = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.SplitTextSlider)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// SplitTextSlider
			// 
			this.SplitTextSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.SplitTextSlider.LargeChange = 1;
			this.SplitTextSlider.Location = new System.Drawing.Point(0, -3);
			this.SplitTextSlider.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.SplitTextSlider.Name = "SplitTextSlider";
			this.SplitTextSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.SplitTextSlider.Size = new System.Drawing.Size(45, 248);
			this.SplitTextSlider.TabIndex = 0;
			this.SplitTextSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.SplitTextSlider.ValueChanged += new System.EventHandler(this.SplitTextSlider_ValueChanged);
			this.SplitTextSlider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SplitTextSlider_MouseDown);
			// 
			// CustomerNameTextbox
			// 
			this.CustomerNameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CustomerNameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CustomerNameTextbox.Location = new System.Drawing.Point(15, 30);
			this.CustomerNameTextbox.Name = "CustomerNameTextbox";
			this.CustomerNameTextbox.Size = new System.Drawing.Size(482, 29);
			this.CustomerNameTextbox.TabIndex = 2;
			this.CustomerNameTextbox.TextChanged += new System.EventHandler(this.CustomerNameTextbox_TextChanged);
			// 
			// CustomerAddressLineTextbox
			// 
			this.CustomerAddressLineTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CustomerAddressLineTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CustomerAddressLineTextbox.Location = new System.Drawing.Point(15, 90);
			this.CustomerAddressLineTextbox.Name = "CustomerAddressLineTextbox";
			this.CustomerAddressLineTextbox.Size = new System.Drawing.Size(482, 29);
			this.CustomerAddressLineTextbox.TabIndex = 3;
			this.CustomerAddressLineTextbox.TextChanged += new System.EventHandler(this.CustomerAddressLineTextbox_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Customer Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Customer Address Line 2";
			// 
			// SplitLinesLabel
			// 
			this.SplitLinesLabel.AutoSize = true;
			this.SplitLinesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SplitLinesLabel.Location = new System.Drawing.Point(57, 8);
			this.SplitLinesLabel.Name = "SplitLinesLabel";
			this.SplitLinesLabel.Size = new System.Drawing.Size(259, 225);
			this.SplitLinesLabel.TabIndex = 7;
			this.SplitLinesLabel.Text = "ExampleReallyLongName\r\nLine 2\r\nLine 3\r\nLine 4\r\nLine 5\r\nLine 6\r\nLine 7\r\nLine 8 &\r\n" +
    "Line 9";
			this.SplitLinesLabel.UseMnemonic = false;
			// 
			// AcceptBtn
			// 
			this.AcceptBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.AcceptBtn.Location = new System.Drawing.Point(15, 218);
			this.AcceptBtn.Name = "AcceptBtn";
			this.AcceptBtn.Size = new System.Drawing.Size(482, 40);
			this.AcceptBtn.TabIndex = 8;
			this.AcceptBtn.Text = "Accept";
			this.AcceptBtn.UseVisualStyleBackColor = true;
			this.AcceptBtn.Click += new System.EventHandler(this.AcceptBtn_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(837, 273);
			this.tableLayoutPanel1.TabIndex = 9;
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.Controls.Add(this.SplitTextSlider);
			this.panel1.Controls.Add(this.SplitLinesLabel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(319, 267);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.CustomerNameTextbox);
			this.panel2.Controls.Add(this.AcceptBtn);
			this.panel2.Controls.Add(this.CustomerAddressLineTextbox);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(328, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(506, 267);
			this.panel2.TabIndex = 1;
			// 
			// SplitCustomerNameAddressForm
			// 
			this.AcceptButton = this.AcceptBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(837, 273);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(853, 312);
			this.Name = "SplitCustomerNameAddressForm";
			this.Text = "Please Split the Customer Name and Address Line";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SplitCustomerNameAddressForm_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.SplitTextSlider)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TrackBar SplitTextSlider;
		private System.Windows.Forms.TextBox CustomerNameTextbox;
		private System.Windows.Forms.TextBox CustomerAddressLineTextbox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label SplitLinesLabel;
		private System.Windows.Forms.Button AcceptBtn;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
	}
}