using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden_Farm_Cash___Carry_Tool.Models.Pick;
using Eden_Farm_Cash___Carry_Tool.UserControls.PickSheet;

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

		}
	}
}
