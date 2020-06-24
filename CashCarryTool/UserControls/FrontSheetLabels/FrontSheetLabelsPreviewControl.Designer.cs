namespace Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels
{
	partial class FrontSheetLabelsPreviewControl
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
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.ReloadBtn = new System.Windows.Forms.Button();
			this.LiveReloadCheck = new System.Windows.Forms.CheckBox();
			this.HideDuplicatePagesCheck = new System.Windows.Forms.CheckBox();
			this.DocumentPreview = new MigraDoc.Rendering.Forms.DocumentPreview();
			this.PageNumberLabel = new System.Windows.Forms.Label();
			this.PreviousPageBtn = new System.Windows.Forms.Button();
			this.NextPageBtn = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.PrintBothButton = new System.Windows.Forms.Button();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.PrintBothButton);
			this.groupBox4.Controls.Add(this.button2);
			this.groupBox4.Controls.Add(this.button1);
			this.groupBox4.Controls.Add(this.NextPageBtn);
			this.groupBox4.Controls.Add(this.PreviousPageBtn);
			this.groupBox4.Controls.Add(this.PageNumberLabel);
			this.groupBox4.Controls.Add(this.ReloadBtn);
			this.groupBox4.Controls.Add(this.LiveReloadCheck);
			this.groupBox4.Controls.Add(this.HideDuplicatePagesCheck);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox4.Location = new System.Drawing.Point(0, 738);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(1059, 50);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Preview";
			// 
			// ReloadBtn
			// 
			this.ReloadBtn.Location = new System.Drawing.Point(222, 15);
			this.ReloadBtn.Name = "ReloadBtn";
			this.ReloadBtn.Size = new System.Drawing.Size(98, 23);
			this.ReloadBtn.TabIndex = 2;
			this.ReloadBtn.Text = "Reload";
			this.ReloadBtn.UseVisualStyleBackColor = true;
			this.ReloadBtn.Click += new System.EventHandler(this.ReloadBtn_Click);
			// 
			// LiveReloadCheck
			// 
			this.LiveReloadCheck.AutoSize = true;
			this.LiveReloadCheck.Checked = true;
			this.LiveReloadCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.LiveReloadCheck.Location = new System.Drawing.Point(138, 19);
			this.LiveReloadCheck.Name = "LiveReloadCheck";
			this.LiveReloadCheck.Size = new System.Drawing.Size(78, 17);
			this.LiveReloadCheck.TabIndex = 1;
			this.LiveReloadCheck.Text = "Live reload";
			this.LiveReloadCheck.UseVisualStyleBackColor = true;
			this.LiveReloadCheck.CheckedChanged += new System.EventHandler(this.LiveReloadCheck_CheckedChanged);
			// 
			// HideDuplicatePagesCheck
			// 
			this.HideDuplicatePagesCheck.AutoSize = true;
			this.HideDuplicatePagesCheck.Checked = true;
			this.HideDuplicatePagesCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.HideDuplicatePagesCheck.Location = new System.Drawing.Point(6, 19);
			this.HideDuplicatePagesCheck.Name = "HideDuplicatePagesCheck";
			this.HideDuplicatePagesCheck.Size = new System.Drawing.Size(126, 17);
			this.HideDuplicatePagesCheck.TabIndex = 0;
			this.HideDuplicatePagesCheck.Text = "Hide duplicate pages";
			this.HideDuplicatePagesCheck.UseVisualStyleBackColor = true;
			this.HideDuplicatePagesCheck.CheckedChanged += new System.EventHandler(this.HideDuplicatePagesCheck_CheckedChanged);
			// 
			// DocumentPreview
			// 
			this.DocumentPreview.Ddl = null;
			this.DocumentPreview.DesktopColor = System.Drawing.SystemColors.ControlDark;
			this.DocumentPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DocumentPreview.Document = null;
			this.DocumentPreview.Location = new System.Drawing.Point(0, 0);
			this.DocumentPreview.Name = "DocumentPreview";
			this.DocumentPreview.Page = 0;
			this.DocumentPreview.PageColor = System.Drawing.Color.White;
			this.DocumentPreview.PageSize = new System.Drawing.Size(842, 595);
			this.DocumentPreview.Size = new System.Drawing.Size(1059, 738);
			this.DocumentPreview.TabIndex = 4;
			this.DocumentPreview.ZoomPercent = 89;
			this.DocumentPreview.PageChanged += new MigraDoc.Rendering.Forms.PagePreviewEventHandler(this.DocumentPreview_PageChanged);
			// 
			// PageNumberLabel
			// 
			this.PageNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.PageNumberLabel.AutoSize = true;
			this.PageNumberLabel.Location = new System.Drawing.Point(892, 21);
			this.PageNumberLabel.Name = "PageNumberLabel";
			this.PageNumberLabel.Size = new System.Drawing.Size(65, 13);
			this.PageNumberLabel.TabIndex = 3;
			this.PageNumberLabel.Text = "Page: 0 of 0";
			// 
			// PreviousPageBtn
			// 
			this.PreviousPageBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.PreviousPageBtn.Location = new System.Drawing.Point(851, 15);
			this.PreviousPageBtn.Name = "PreviousPageBtn";
			this.PreviousPageBtn.Size = new System.Drawing.Size(26, 23);
			this.PreviousPageBtn.TabIndex = 4;
			this.PreviousPageBtn.Text = "<";
			this.PreviousPageBtn.UseVisualStyleBackColor = true;
			this.PreviousPageBtn.Click += new System.EventHandler(this.PreviousPageBtn_Click);
			// 
			// NextPageBtn
			// 
			this.NextPageBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NextPageBtn.Location = new System.Drawing.Point(975, 15);
			this.NextPageBtn.Name = "NextPageBtn";
			this.NextPageBtn.Size = new System.Drawing.Size(26, 23);
			this.NextPageBtn.TabIndex = 5;
			this.NextPageBtn.Text = ">";
			this.NextPageBtn.UseVisualStyleBackColor = true;
			this.NextPageBtn.Click += new System.EventHandler(this.NextPageBtn_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(346, 15);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(118, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "Print Front Sheet";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(470, 15);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(118, 23);
			this.button2.TabIndex = 7;
			this.button2.Text = "Print Labels";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// PrintBothButton
			// 
			this.PrintBothButton.Location = new System.Drawing.Point(594, 15);
			this.PrintBothButton.Name = "PrintBothButton";
			this.PrintBothButton.Size = new System.Drawing.Size(118, 23);
			this.PrintBothButton.TabIndex = 8;
			this.PrintBothButton.Text = "Print Both";
			this.PrintBothButton.UseVisualStyleBackColor = true;
			this.PrintBothButton.Click += new System.EventHandler(this.PrintBothButton_Click);
			// 
			// FrontSheetLabelsPreviewControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.DocumentPreview);
			this.Controls.Add(this.groupBox4);
			this.Name = "FrontSheetLabelsPreviewControl";
			this.Size = new System.Drawing.Size(1059, 788);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button ReloadBtn;
		private System.Windows.Forms.CheckBox LiveReloadCheck;
		private System.Windows.Forms.CheckBox HideDuplicatePagesCheck;
		private MigraDoc.Rendering.Forms.DocumentPreview DocumentPreview;
		private System.Windows.Forms.Button NextPageBtn;
		private System.Windows.Forms.Button PreviousPageBtn;
		private System.Windows.Forms.Label PageNumberLabel;
		private System.Windows.Forms.Button PrintBothButton;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
	}
}
