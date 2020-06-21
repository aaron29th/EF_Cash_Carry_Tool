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
			this.button1 = new System.Windows.Forms.Button();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.DocumentPreview = new MigraDoc.Rendering.Forms.DocumentPreview();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.button1);
			this.groupBox4.Controls.Add(this.checkBox2);
			this.groupBox4.Controls.Add(this.checkBox1);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox4.Location = new System.Drawing.Point(0, 738);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(1059, 50);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Preview";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(222, 15);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(98, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Reload";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Location = new System.Drawing.Point(138, 19);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(78, 17);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "Live reload";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(6, 19);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(126, 17);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Hide duplicate pages";
			this.checkBox1.UseVisualStyleBackColor = true;
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
			this.DocumentPreview.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.DocumentPreview.PageSize = new System.Drawing.Size(842, 595);
			this.DocumentPreview.Size = new System.Drawing.Size(1059, 738);
			this.DocumentPreview.TabIndex = 4;
			this.DocumentPreview.ZoomPercent = 89;
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
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox1;
		private MigraDoc.Rendering.Forms.DocumentPreview DocumentPreview;
	}
}
