using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceParser.Forms
{
	public partial class SplitCustomerNameAddressForm : Form
	{
		private const int _sliderMargin = 13;
		private readonly string[] words;

		public bool Confirmed { get; set; }
		public string CustomerName { get; set; }
		public string CustomerAddressLine { get; set; }

		public SplitCustomerNameAddressForm()
		{
			InitializeComponent();
		}

		public SplitCustomerNameAddressForm(string line)
		{
			InitializeComponent();

			words = line.Split(
				new[] {' '}
			);

			SplitLinesLabel.Text = String.Join(Environment.NewLine, words);

			
			SplitTextSlider.Maximum = words.Length;
			SplitTextSlider.Height = SplitLinesLabel.Height + _sliderMargin * 2;
			SplitTextSlider.Value = words.Length / 2;

		}

		private void SplitTextSlider_MouseDown(object sender, MouseEventArgs e)
		{
			if (sender is TrackBar slider)
			{
				var yOffset = e.Location.Y - _sliderMargin;
				if (yOffset < 0)
					yOffset = 0;

				double sliderHeight = slider.Height - _sliderMargin * 2;

				var ratio = yOffset / sliderHeight;
				int range = slider.Maximum - slider.Minimum;
				var newValue = range * ratio;
				slider.Value = slider.Maximum - (int) Math.Round(newValue);
			}
		}

		private void SplitTextSlider_ValueChanged(object sender, EventArgs e)
		{
			int sliderPos = SplitTextSlider.Maximum - SplitTextSlider.Value;
			var customerName = String.Join(" ", words.Take(sliderPos));
			CustomerNameTextbox.Text = customerName.Trim();

			var customerAddressLine = String.Join(" ", words.Skip(sliderPos));
			CustomerAddressLineTextbox.Text = customerAddressLine.Trim();
		}

		private void AcceptBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void SplitCustomerNameAddressForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Confirmed = true;
		}

		private void CustomerNameTextbox_TextChanged(object sender, EventArgs e)
		{
			CustomerName = CustomerNameTextbox.Text;
		}

		private void CustomerAddressLineTextbox_TextChanged(object sender, EventArgs e)
		{
			CustomerAddressLine = CustomerAddressLineTextbox.Text;
		}
	}
}
