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
			this.panel1 = new System.Windows.Forms.Panel();
			this.PdfRenderer = new PdfiumViewer.PdfRenderer();
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
			// PdfRenderer
			// 
			this.PdfRenderer.Cursor = System.Windows.Forms.Cursors.Cross;
			this.PdfRenderer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PdfRenderer.Location = new System.Drawing.Point(0, 0);
			this.PdfRenderer.Name = "PdfRenderer";
			this.PdfRenderer.Page = 0;
			this.PdfRenderer.Rotation = PdfiumViewer.PdfRotation.Rotate0;
			this.PdfRenderer.Size = new System.Drawing.Size(931, 699);
			this.PdfRenderer.TabIndex = 1;
			this.PdfRenderer.Text = "pdfRenderer1";
			this.PdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitHeight;
			this.PdfRenderer.Click += new System.EventHandler(this.PdfRenderer_Click);
			// 
			// PickSheetPreviewControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.PdfRenderer);
			this.Controls.Add(this.panel1);
			this.Name = "PickSheetPreviewControl";
			this.Size = new System.Drawing.Size(931, 799);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private PdfiumViewer.PdfRenderer PdfRenderer;
	}
}
