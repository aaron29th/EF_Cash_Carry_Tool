namespace Eden_Farm_Cash___Carry_Tool.UserControls.PickSheet
{
	partial class PickSheetPreviewControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickSheetPreviewControl));
			this.panel1 = new System.Windows.Forms.Panel();
			this.PickSheetPreview = new PdfSharp.Forms.PagePreview();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 699);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(931, 100);
			this.panel1.TabIndex = 0;
			// 
			// PickSheetPreview
			// 
			this.PickSheetPreview.DesktopColor = System.Drawing.SystemColors.ControlDark;
			this.PickSheetPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PickSheetPreview.Location = new System.Drawing.Point(0, 0);
			this.PickSheetPreview.Name = "PickSheetPreview";
			this.PickSheetPreview.PageColor = System.Drawing.Color.GhostWhite;
			this.PickSheetPreview.PageGraphicsUnit = PdfSharp.Drawing.XGraphicsUnit.Point;
			this.PickSheetPreview.PageSize = ((PdfSharp.Drawing.XSize)(resources.GetObject("PickSheetPreview.PageSize")));
			this.PickSheetPreview.PageSizeF = new System.Drawing.Size(595, 842);
			this.PickSheetPreview.PageUnit = PdfSharp.Drawing.XGraphicsUnit.Point;
			this.PickSheetPreview.Size = new System.Drawing.Size(931, 699);
			this.PickSheetPreview.TabIndex = 1;
			this.PickSheetPreview.ZoomPercent = 59;
			// 
			// PickSheetPreviewControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.PickSheetPreview);
			this.Controls.Add(this.panel1);
			this.Name = "PickSheetPreviewControl";
			this.Size = new System.Drawing.Size(931, 799);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private PdfSharp.Forms.PagePreview PickSheetPreview;
	}
}
