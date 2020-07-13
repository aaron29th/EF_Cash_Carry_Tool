namespace Eden_Farm_Cash___Carry_Tool
{
	partial class mainForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.frontSheetLabels1 = new Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabelsControl();
			this.pickSheetControl1 = new Eden_Farm_Cash___Carry_Tool.UserControls.PickSheetControl();
			this.tabControl1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1335, 953);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.pickSheetControl1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(1327, 927);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Pick Sheet";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.frontSheetLabels1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1327, 927);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Front Sheet / Labels";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// frontSheetLabels1
			// 
			this.frontSheetLabels1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.frontSheetLabels1.Location = new System.Drawing.Point(3, 3);
			this.frontSheetLabels1.Name = "frontSheetLabels1";
			this.frontSheetLabels1.Size = new System.Drawing.Size(1321, 921);
			this.frontSheetLabels1.TabIndex = 0;
			// 
			// pickSheetControl1
			// 
			this.pickSheetControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pickSheetControl1.Location = new System.Drawing.Point(0, 0);
			this.pickSheetControl1.Name = "pickSheetControl1";
			this.pickSheetControl1.Size = new System.Drawing.Size(1327, 927);
			this.pickSheetControl1.TabIndex = 0;
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1335, 953);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "mainForm";
			this.Text = "Eden Farm Cash + Carry Tool";
			this.tabControl1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private UserControls.FrontSheetLabelsControl frontSheetLabels1;
		private System.Windows.Forms.TabPage tabPage2;
		private UserControls.PickSheetControl pickSheetControl1;
	}
}

