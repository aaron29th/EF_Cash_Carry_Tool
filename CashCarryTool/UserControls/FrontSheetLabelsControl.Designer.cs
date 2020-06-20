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
			this.generalDetailsControl1 = new Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels.GeneralDetailsControl();
			this.frontSheetLabelsPreviewControl1 = new Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels.FrontSheetLabelsPreviewControl();
			this.frontSheetDetailsControl1 = new Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels.FrontSheetDetailsControl();
			this.labelDetailsControl1 = new Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels.LabelDetailsControl();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// generalDetailsControl1
			// 
			this.generalDetailsControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.generalDetailsControl1.Location = new System.Drawing.Point(0, 0);
			this.generalDetailsControl1.Name = "generalDetailsControl1";
			this.generalDetailsControl1.Size = new System.Drawing.Size(345, 212);
			this.generalDetailsControl1.TabIndex = 0;
			// 
			// frontSheetLabelsPreviewControl1
			// 
			this.frontSheetLabelsPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.frontSheetLabelsPreviewControl1.Location = new System.Drawing.Point(345, 0);
			this.frontSheetLabelsPreviewControl1.Name = "frontSheetLabelsPreviewControl1";
			this.frontSheetLabelsPreviewControl1.Size = new System.Drawing.Size(1043, 737);
			this.frontSheetLabelsPreviewControl1.TabIndex = 2;
			// 
			// frontSheetDetailsControl1
			// 
			this.frontSheetDetailsControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.frontSheetDetailsControl1.Location = new System.Drawing.Point(0, 212);
			this.frontSheetDetailsControl1.Name = "frontSheetDetailsControl1";
			this.frontSheetDetailsControl1.Size = new System.Drawing.Size(345, 133);
			this.frontSheetDetailsControl1.TabIndex = 1;
			// 
			// labelDetailsControl1
			// 
			this.labelDetailsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelDetailsControl1.Location = new System.Drawing.Point(0, 345);
			this.labelDetailsControl1.Name = "labelDetailsControl1";
			this.labelDetailsControl1.Size = new System.Drawing.Size(345, 392);
			this.labelDetailsControl1.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.labelDetailsControl1);
			this.panel1.Controls.Add(this.frontSheetDetailsControl1);
			this.panel1.Controls.Add(this.generalDetailsControl1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(345, 737);
			this.panel1.TabIndex = 4;
			// 
			// FrontSheetLabelsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.frontSheetLabelsPreviewControl1);
			this.Controls.Add(this.panel1);
			this.Name = "FrontSheetLabelsControl";
			this.Size = new System.Drawing.Size(1388, 737);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private FrontSheetLabels.GeneralDetailsControl generalDetailsControl1;
		private FrontSheetLabels.FrontSheetDetailsControl frontSheetDetailsControl1;
		private FrontSheetLabels.LabelDetailsControl labelDetailsControl1;
		private FrontSheetLabels.FrontSheetLabelsPreviewControl frontSheetLabelsPreviewControl1;
		private System.Windows.Forms.Panel panel1;
	}
}
