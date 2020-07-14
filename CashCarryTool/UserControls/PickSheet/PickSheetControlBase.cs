using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eden_Farm_Cash___Carry_Tool.UserControls.PickSheet
{
	public partial class PickSheetControlBase : UserControl
	{
		protected PickSheetControl _parent;

		public void SetParent(PickSheetControl parent)
		{
			_parent = parent;
		}

		public PickSheetControlBase()
		{
			InitializeComponent();
		}
	}
}
