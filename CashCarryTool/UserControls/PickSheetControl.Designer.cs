namespace Eden_Farm_Cash___Carry_Tool.UserControls
{
	partial class PickSheetControl
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
			this.pickSheetPreviewControl1 = new Eden_Farm_Cash___Carry_Tool.UserControls.PickSheet.PickSheetPreviewControl();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(276, 792);
			this.panel1.TabIndex = 0;
			// 
			// pickSheetPreviewControl1
			// 
			this.pickSheetPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pickSheetPreviewControl1.Location = new System.Drawing.Point(276, 0);
			this.pickSheetPreviewControl1.Name = "pickSheetPreviewControl1";
			this.pickSheetPreviewControl1.Size = new System.Drawing.Size(978, 792);
			this.pickSheetPreviewControl1.TabIndex = 1;
			// 
			// PickSheetControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pickSheetPreviewControl1);
			this.Controls.Add(this.panel1);
			this.Name = "PickSheetControl";
			this.Size = new System.Drawing.Size(1254, 792);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private PickSheet.PickSheetPreviewControl pickSheetPreviewControl1;
	}
}
