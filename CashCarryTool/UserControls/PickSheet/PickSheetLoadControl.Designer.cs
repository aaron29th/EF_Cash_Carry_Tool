namespace Eden_Farm_Cash___Carry_Tool.UserControls.PickSheet
{
	partial class PickSheetLoadControl
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
			this.RefreshPicksBtn = new System.Windows.Forms.Button();
			this.PicksCheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.LinesCheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.PageListBox = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.RefreshPicksBtn);
			this.panel1.Controls.Add(this.PicksCheckedListBox);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(340, 171);
			this.panel1.TabIndex = 1;
			// 
			// RefreshPicksBtn
			// 
			this.RefreshPicksBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.RefreshPicksBtn.Location = new System.Drawing.Point(0, 148);
			this.RefreshPicksBtn.Name = "RefreshPicksBtn";
			this.RefreshPicksBtn.Size = new System.Drawing.Size(340, 23);
			this.RefreshPicksBtn.TabIndex = 0;
			this.RefreshPicksBtn.Text = "Reload";
			this.RefreshPicksBtn.UseVisualStyleBackColor = true;
			this.RefreshPicksBtn.Click += new System.EventHandler(this.RefreshPicksBtn_Click);
			// 
			// PicksCheckedListBox
			// 
			this.PicksCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PicksCheckedListBox.FormattingEnabled = true;
			this.PicksCheckedListBox.Location = new System.Drawing.Point(0, 0);
			this.PicksCheckedListBox.Name = "PicksCheckedListBox";
			this.PicksCheckedListBox.Size = new System.Drawing.Size(340, 171);
			this.PicksCheckedListBox.TabIndex = 3;
			// 
			// LinesCheckedListBox
			// 
			this.LinesCheckedListBox.FormattingEnabled = true;
			this.LinesCheckedListBox.Location = new System.Drawing.Point(3, 405);
			this.LinesCheckedListBox.Name = "LinesCheckedListBox";
			this.LinesCheckedListBox.Size = new System.Drawing.Size(258, 94);
			this.LinesCheckedListBox.TabIndex = 4;
			// 
			// PageListBox
			// 
			this.PageListBox.FormattingEnabled = true;
			this.PageListBox.Location = new System.Drawing.Point(82, 231);
			this.PageListBox.Name = "PageListBox";
			this.PageListBox.Size = new System.Drawing.Size(120, 95);
			this.PageListBox.TabIndex = 5;
			// 
			// PickSheetLoadControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.PageListBox);
			this.Controls.Add(this.LinesCheckedListBox);
			this.Controls.Add(this.panel1);
			this.Name = "PickSheetLoadControl";
			this.Size = new System.Drawing.Size(340, 605);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button RefreshPicksBtn;
		private System.Windows.Forms.CheckedListBox PicksCheckedListBox;
		private System.Windows.Forms.CheckedListBox LinesCheckedListBox;
		private System.Windows.Forms.ListBox PageListBox;
	}
}
