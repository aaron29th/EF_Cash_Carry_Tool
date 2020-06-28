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
			this.PrintBothButton = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.NextPageBtn = new System.Windows.Forms.Button();
			this.PreviousPageBtn = new System.Windows.Forms.Button();
			this.PageNumberLabel = new System.Windows.Forms.Label();
			this.ReloadBtn = new System.Windows.Forms.Button();
			this.LiveReloadCheck = new System.Windows.Forms.CheckBox();
			this.HideDuplicatePagesCheck = new System.Windows.Forms.CheckBox();
			this.LabelsPreview = new MigraDoc.Rendering.Forms.DocumentPreview();
			this.PreviewTabControl = new System.Windows.Forms.TabControl();
			this.FrontSheetTab = new System.Windows.Forms.TabPage();
			this.FrontSheetPreview = new MigraDoc.Rendering.Forms.DocumentPreview();
			this.LabelsTab = new System.Windows.Forms.TabPage();
			this.groupBox4.SuspendLayout();
			this.PreviewTabControl.SuspendLayout();
			this.FrontSheetTab.SuspendLayout();
			this.LabelsTab.SuspendLayout();
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
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(470, 15);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(118, 23);
			this.button2.TabIndex = 7;
			this.button2.Text = "Print Labels";
			this.button2.UseVisualStyleBackColor = true;
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
			// LabelsPreview
			// 
			this.LabelsPreview.Ddl = null;
			this.LabelsPreview.DesktopColor = System.Drawing.SystemColors.ControlDark;
			this.LabelsPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LabelsPreview.Document = null;
			this.LabelsPreview.Location = new System.Drawing.Point(3, 3);
			this.LabelsPreview.Name = "LabelsPreview";
			this.LabelsPreview.Page = 0;
			this.LabelsPreview.PageColor = System.Drawing.Color.White;
			this.LabelsPreview.PageSize = new System.Drawing.Size(842, 595);
			this.LabelsPreview.Size = new System.Drawing.Size(1045, 706);
			this.LabelsPreview.TabIndex = 4;
			this.LabelsPreview.ZoomPercent = 85;
			this.LabelsPreview.PageChanged += new MigraDoc.Rendering.Forms.PagePreviewEventHandler(this.DocumentPreview_PageChanged);
			// 
			// PreviewTabControl
			// 
			this.PreviewTabControl.Controls.Add(this.FrontSheetTab);
			this.PreviewTabControl.Controls.Add(this.LabelsTab);
			this.PreviewTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PreviewTabControl.Location = new System.Drawing.Point(0, 0);
			this.PreviewTabControl.Name = "PreviewTabControl";
			this.PreviewTabControl.SelectedIndex = 0;
			this.PreviewTabControl.Size = new System.Drawing.Size(1059, 738);
			this.PreviewTabControl.TabIndex = 5;
			this.PreviewTabControl.SelectedIndexChanged += new System.EventHandler(this.PreviewTabControl_SelectedIndexChanged);
			// 
			// FrontSheetTab
			// 
			this.FrontSheetTab.Controls.Add(this.FrontSheetPreview);
			this.FrontSheetTab.Location = new System.Drawing.Point(4, 22);
			this.FrontSheetTab.Name = "FrontSheetTab";
			this.FrontSheetTab.Padding = new System.Windows.Forms.Padding(3);
			this.FrontSheetTab.Size = new System.Drawing.Size(1051, 712);
			this.FrontSheetTab.TabIndex = 1;
			this.FrontSheetTab.Text = "Front Sheet";
			this.FrontSheetTab.UseVisualStyleBackColor = true;
			// 
			// FrontSheetPreview
			// 
			this.FrontSheetPreview.Ddl = null;
			this.FrontSheetPreview.DesktopColor = System.Drawing.SystemColors.ControlDark;
			this.FrontSheetPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FrontSheetPreview.Document = null;
			this.FrontSheetPreview.Location = new System.Drawing.Point(3, 3);
			this.FrontSheetPreview.Name = "FrontSheetPreview";
			this.FrontSheetPreview.Page = 0;
			this.FrontSheetPreview.PageColor = System.Drawing.Color.GhostWhite;
			this.FrontSheetPreview.PageSize = new System.Drawing.Size(595, 842);
			this.FrontSheetPreview.Size = new System.Drawing.Size(1045, 706);
			this.FrontSheetPreview.TabIndex = 0;
			this.FrontSheetPreview.ZoomPercent = 60;
			// 
			// LabelsTab
			// 
			this.LabelsTab.Controls.Add(this.LabelsPreview);
			this.LabelsTab.Location = new System.Drawing.Point(4, 22);
			this.LabelsTab.Name = "LabelsTab";
			this.LabelsTab.Padding = new System.Windows.Forms.Padding(3);
			this.LabelsTab.Size = new System.Drawing.Size(1051, 712);
			this.LabelsTab.TabIndex = 0;
			this.LabelsTab.Text = "Labels";
			this.LabelsTab.UseVisualStyleBackColor = true;
			// 
			// FrontSheetLabelsPreviewControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.PreviewTabControl);
			this.Controls.Add(this.groupBox4);
			this.Name = "FrontSheetLabelsPreviewControl";
			this.Size = new System.Drawing.Size(1059, 788);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.PreviewTabControl.ResumeLayout(false);
			this.FrontSheetTab.ResumeLayout(false);
			this.LabelsTab.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button ReloadBtn;
		private System.Windows.Forms.CheckBox LiveReloadCheck;
		private System.Windows.Forms.CheckBox HideDuplicatePagesCheck;
		private MigraDoc.Rendering.Forms.DocumentPreview LabelsPreview;
		private System.Windows.Forms.Button NextPageBtn;
		private System.Windows.Forms.Button PreviousPageBtn;
		private System.Windows.Forms.Label PageNumberLabel;
		private System.Windows.Forms.Button PrintBothButton;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TabControl PreviewTabControl;
		private System.Windows.Forms.TabPage LabelsTab;
		private System.Windows.Forms.TabPage FrontSheetTab;
		private MigraDoc.Rendering.Forms.DocumentPreview FrontSheetPreview;
	}
}
