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
			this.OpenBtn = new System.Windows.Forms.Button();
			this.ImportDataBtn = new System.Windows.Forms.Button();
			this.PrintBtn = new System.Windows.Forms.Button();
			this.ShowGuidesCheck = new System.Windows.Forms.CheckBox();
			this.PdfRenderer = new PdfiumViewer.PdfRenderer();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.OpenBtn);
			this.panel1.Controls.Add(this.ImportDataBtn);
			this.panel1.Controls.Add(this.PrintBtn);
			this.panel1.Controls.Add(this.ShowGuidesCheck);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 759);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(931, 40);
			this.panel1.TabIndex = 0;
			// 
			// OpenBtn
			// 
			this.OpenBtn.Location = new System.Drawing.Point(121, 8);
			this.OpenBtn.Name = "OpenBtn";
			this.OpenBtn.Size = new System.Drawing.Size(131, 23);
			this.OpenBtn.TabIndex = 3;
			this.OpenBtn.Text = "Open for Printing";
			this.OpenBtn.UseVisualStyleBackColor = true;
			this.OpenBtn.Click += new System.EventHandler(this.OpenBtn_Click);
			// 
			// ImportDataBtn
			// 
			this.ImportDataBtn.Location = new System.Drawing.Point(395, 8);
			this.ImportDataBtn.Name = "ImportDataBtn";
			this.ImportDataBtn.Size = new System.Drawing.Size(131, 23);
			this.ImportDataBtn.TabIndex = 2;
			this.ImportDataBtn.Text = "Import Data";
			this.ImportDataBtn.UseVisualStyleBackColor = true;
			this.ImportDataBtn.Click += new System.EventHandler(this.ImportDataBtn_Click);
			// 
			// PrintBtn
			// 
			this.PrintBtn.Location = new System.Drawing.Point(258, 8);
			this.PrintBtn.Name = "PrintBtn";
			this.PrintBtn.Size = new System.Drawing.Size(131, 23);
			this.PrintBtn.TabIndex = 1;
			this.PrintBtn.Text = "Print with Adobe Acrobat";
			this.PrintBtn.UseVisualStyleBackColor = true;
			this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
			// 
			// ShowGuidesCheck
			// 
			this.ShowGuidesCheck.AutoSize = true;
			this.ShowGuidesCheck.Location = new System.Drawing.Point(15, 12);
			this.ShowGuidesCheck.Name = "ShowGuidesCheck";
			this.ShowGuidesCheck.Size = new System.Drawing.Size(89, 17);
			this.ShowGuidesCheck.TabIndex = 0;
			this.ShowGuidesCheck.Text = "Show Guides";
			this.ShowGuidesCheck.UseVisualStyleBackColor = true;
			this.ShowGuidesCheck.CheckedChanged += new System.EventHandler(this.ShowGuidesCheck_CheckedChanged);
			// 
			// PdfRenderer
			// 
			this.PdfRenderer.Cursor = System.Windows.Forms.Cursors.Cross;
			this.PdfRenderer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PdfRenderer.Location = new System.Drawing.Point(0, 0);
			this.PdfRenderer.Name = "PdfRenderer";
			this.PdfRenderer.Page = 0;
			this.PdfRenderer.Rotation = PdfiumViewer.PdfRotation.Rotate0;
			this.PdfRenderer.Size = new System.Drawing.Size(931, 759);
			this.PdfRenderer.TabIndex = 1;
			this.PdfRenderer.Text = "pdfRenderer1";
			this.PdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitHeight;
			this.PdfRenderer.DisplayRectangleChanged += new System.EventHandler(this.PdfRenderer_DisplayRectangleChanged);
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
			this.Load += new System.EventHandler(this.PickSheetPreviewControl_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private PdfiumViewer.PdfRenderer PdfRenderer;
		private System.Windows.Forms.Button ImportDataBtn;
		private System.Windows.Forms.Button PrintBtn;
		private System.Windows.Forms.CheckBox ShowGuidesCheck;
		private System.Windows.Forms.Button OpenBtn;
	}
}
