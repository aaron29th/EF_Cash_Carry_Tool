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
			this.PicksListBox = new System.Windows.Forms.ListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ReloadPicksBtn = new System.Windows.Forms.Button();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// PicksListBox
			// 
			this.PicksListBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.PicksListBox.FormattingEnabled = true;
			this.PicksListBox.Location = new System.Drawing.Point(0, 0);
			this.PicksListBox.Name = "PicksListBox";
			this.PicksListBox.Size = new System.Drawing.Size(340, 134);
			this.PicksListBox.TabIndex = 0;
			this.PicksListBox.DoubleClick += new System.EventHandler(this.PicksListBox_DoubleClick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ReloadPicksBtn);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 505);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(340, 100);
			this.panel1.TabIndex = 1;
			// 
			// ReloadPicksBtn
			// 
			this.ReloadPicksBtn.Location = new System.Drawing.Point(99, 36);
			this.ReloadPicksBtn.Name = "ReloadPicksBtn";
			this.ReloadPicksBtn.Size = new System.Drawing.Size(75, 23);
			this.ReloadPicksBtn.TabIndex = 0;
			this.ReloadPicksBtn.Text = "Reload";
			this.ReloadPicksBtn.UseVisualStyleBackColor = true;
			this.ReloadPicksBtn.Click += new System.EventHandler(this.ReloadPicksBtn_Click);
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(30, 218);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(258, 94);
			this.checkedListBox1.TabIndex = 3;
			// 
			// PickSheetLoadControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.checkedListBox1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.PicksListBox);
			this.Name = "PickSheetLoadControl";
			this.Size = new System.Drawing.Size(340, 605);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox PicksListBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button ReloadPicksBtn;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
	}
}
