using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eden_Farm_Cash___Carry_Tool.UserControls
{
	public partial class PickSheetControl : UserControl
	{
		public PickSheetControl()
		{
			InitializeComponent();

			PickSheetLoadControl.SetParent(this);
		}

		public void SetPickPdfPath(string filePath)
		{
			PickSheetPreviewControl.SetPickPdfPath(filePath);
		}
	}
}
