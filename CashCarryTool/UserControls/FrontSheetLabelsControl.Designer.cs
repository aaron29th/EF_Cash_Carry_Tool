namespace Eden_Farm_Cash___Carry_Tool.UserControls
{
	partial class FrontSheetLabelsControl
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.LabelDetailsControl = new Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels.LabelDetailsControl();
			this.FrontSheetDetailsControl = new Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels.FrontSheetDetailsControl();
			this.GeneralDetailsControl = new Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels.GeneralDetailsControl();
			this.FrontSheetLabelsPreviewControl = new Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels.FrontSheetLabelsPreviewControl();
			this.panel2 = new System.Windows.Forms.Panel();
			this.CopyExcelLineBtn = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.LabelDetailsControl);
			this.panel1.Controls.Add(this.FrontSheetDetailsControl);
			this.panel1.Controls.Add(this.GeneralDetailsControl);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(345, 919);
			this.panel1.TabIndex = 4;
			// 
			// LabelDetailsControl
			// 
			this.LabelDetailsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LabelDetailsControl.Location = new System.Drawing.Point(3, 433);
			this.LabelDetailsControl.Name = "LabelDetailsControl";
			this.LabelDetailsControl.NumLabelsPerPallet = 4;
			this.LabelDetailsControl.ShowPalletNumber = true;
			this.LabelDetailsControl.ShowPalletNumberOf = true;
			this.LabelDetailsControl.ShowTotalPalletNumber = true;
			this.LabelDetailsControl.Size = new System.Drawing.Size(345, 441);
			this.LabelDetailsControl.TabIndex = 2;
			// 
			// FrontSheetDetailsControl
			// 
			this.FrontSheetDetailsControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.FrontSheetDetailsControl.FullPalletBreakdown = false;
			this.FrontSheetDetailsControl.FullyFillIn = false;
			this.FrontSheetDetailsControl.Location = new System.Drawing.Point(0, 294);
			this.FrontSheetDetailsControl.Name = "FrontSheetDetailsControl";
			this.FrontSheetDetailsControl.PartiallyFillIn = true;
			this.FrontSheetDetailsControl.Size = new System.Drawing.Size(345, 133);
			this.FrontSheetDetailsControl.TabIndex = 1;
			// 
			// GeneralDetailsControl
			// 
			this.GeneralDetailsControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.GeneralDetailsControl.Location = new System.Drawing.Point(0, 0);
			this.GeneralDetailsControl.Name = "GeneralDetailsControl";
			this.GeneralDetailsControl.Size = new System.Drawing.Size(345, 294);
			this.GeneralDetailsControl.TabIndex = 0;
			// 
			// FrontSheetLabelsPreviewControl
			// 
			this.FrontSheetLabelsPreviewControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FrontSheetLabelsPreviewControl.HideDuplicatePages = true;
			this.FrontSheetLabelsPreviewControl.LiveReload = true;
			this.FrontSheetLabelsPreviewControl.Location = new System.Drawing.Point(345, 0);
			this.FrontSheetLabelsPreviewControl.Name = "FrontSheetLabelsPreviewControl";
			this.FrontSheetLabelsPreviewControl.Size = new System.Drawing.Size(1043, 919);
			this.FrontSheetLabelsPreviewControl.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.CopyExcelLineBtn);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 880);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(345, 39);
			this.panel2.TabIndex = 5;
			// 
			// CopyExcelLineBtn
			// 
			this.CopyExcelLineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CopyExcelLineBtn.Location = new System.Drawing.Point(3, 3);
			this.CopyExcelLineBtn.Name = "CopyExcelLineBtn";
			this.CopyExcelLineBtn.Size = new System.Drawing.Size(336, 33);
			this.CopyExcelLineBtn.TabIndex = 0;
			this.CopyExcelLineBtn.Text = "Copy Excel Line";
			this.CopyExcelLineBtn.UseVisualStyleBackColor = true;
			this.CopyExcelLineBtn.Click += new System.EventHandler(this.CopyExcelLineBtn_Click);
			// 
			// FrontSheetLabelsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.FrontSheetLabelsPreviewControl);
			this.Controls.Add(this.panel1);
			this.Name = "FrontSheetLabelsControl";
			this.Size = new System.Drawing.Size(1388, 919);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private FrontSheetLabels.GeneralDetailsControl GeneralDetailsControl;
		private FrontSheetLabels.FrontSheetDetailsControl FrontSheetDetailsControl;
		private FrontSheetLabels.LabelDetailsControl LabelDetailsControl;
		private FrontSheetLabels.FrontSheetLabelsPreviewControl FrontSheetLabelsPreviewControl;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button CopyExcelLineBtn;
	}
}
