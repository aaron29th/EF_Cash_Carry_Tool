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
			this.FrontSheetLabelsPreviewControl = new Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels.FrontSheetLabelsPreviewControl();
			this.LabelDetailsControl = new Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels.LabelDetailsControl();
			this.FrontSheetDetailsControl = new Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels.FrontSheetDetailsControl();
			this.GeneralDetailsControl = new Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels.GeneralDetailsControl();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.LabelDetailsControl);
			this.panel1.Controls.Add(this.FrontSheetDetailsControl);
			this.panel1.Controls.Add(this.GeneralDetailsControl);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(345, 737);
			this.panel1.TabIndex = 4;
			// 
			// FrontSheetLabelsPreviewControl
			// 
			this.FrontSheetLabelsPreviewControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FrontSheetLabelsPreviewControl.Location = new System.Drawing.Point(345, 0);
			this.FrontSheetLabelsPreviewControl.Name = "FrontSheetLabelsPreviewControl";
			this.FrontSheetLabelsPreviewControl.Size = new System.Drawing.Size(1043, 737);
			this.FrontSheetLabelsPreviewControl.TabIndex = 2;
			// 
			// LabelDetailsControl
			// 
			this.LabelDetailsControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LabelDetailsControl.Location = new System.Drawing.Point(0, 345);
			this.LabelDetailsControl.Name = "LabelDetailsControl";
			this.LabelDetailsControl.Size = new System.Drawing.Size(345, 392);
			this.LabelDetailsControl.TabIndex = 2;
			// 
			// FrontSheetDetailsControl
			// 
			this.FrontSheetDetailsControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.FrontSheetDetailsControl.Location = new System.Drawing.Point(0, 212);
			this.FrontSheetDetailsControl.Name = "FrontSheetDetailsControl";
			this.FrontSheetDetailsControl.Size = new System.Drawing.Size(345, 133);
			this.FrontSheetDetailsControl.TabIndex = 1;
			// 
			// GeneralDetailsControl
			// 
			this.GeneralDetailsControl.Dock = System.Windows.Forms.DockStyle.Top;
			this.GeneralDetailsControl.Location = new System.Drawing.Point(0, 0);
			this.GeneralDetailsControl.Name = "GeneralDetailsControl";
			this.GeneralDetailsControl.Size = new System.Drawing.Size(345, 212);
			this.GeneralDetailsControl.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(1138, 687);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FrontSheetLabelsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.button1);
			this.Controls.Add(this.FrontSheetLabelsPreviewControl);
			this.Controls.Add(this.panel1);
			this.Name = "FrontSheetLabelsControl";
			this.Size = new System.Drawing.Size(1388, 737);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private FrontSheetLabels.GeneralDetailsControl GeneralDetailsControl;
		private FrontSheetLabels.FrontSheetDetailsControl FrontSheetDetailsControl;
		private FrontSheetLabels.LabelDetailsControl LabelDetailsControl;
		private FrontSheetLabels.FrontSheetLabelsPreviewControl FrontSheetLabelsPreviewControl;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
	}
}
