using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden_Farm_Cash___Carry_Tool.Models.Pick;
using Eden_Farm_Cash___Carry_Tool.StaticClasses;
using Eden_Farm_Cash___Carry_Tool.UserControls.PickSheet;
using InvoiceTools.InvoiceModels;

namespace Eden_Farm_Cash___Carry_Tool
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			PickSheetControl.SetParent(this);
		}

		public void LoadInvoices(List<Invoice> invoices)
		{
			FrontSheetLabelsControl.LoadInvoicesData(invoices);
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				var files = Directory.GetFiles(TempDirectory.Path);

				foreach (var filePath in files)
				{
					File.Delete(filePath);
				}
			}
			catch
			{

			}
		}

		private void RestartBtn_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you wish to restart?", "Restart Program", MessageBoxButtons.YesNo) ==
			    DialogResult.No)
				return;

			Application.Restart();
			Environment.Exit(0);
		}
	}
}
