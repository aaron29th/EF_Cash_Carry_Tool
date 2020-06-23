using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eden_Farm_Cash___Carry_Tool.UserControls.FrontSheetLabels
{
	public class FrontSheetLabelsBase : UserControl
	{
		protected FrontSheetLabelsControl _parent;

		public void SetParent(FrontSheetLabelsControl parent)
		{
			_parent = parent;
		}

		public void DetailsUpdated()
		{
			_parent?.DetailsUpdate();
		}
	}
}
