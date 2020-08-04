using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eden_Farm_Cash___Carry_Tool.Models;
using Newtonsoft.Json;

namespace Eden_Farm_Cash___Carry_Tool.StaticClasses
{
	public class NetworkHelper
	{
		public static bool GetStartPermission()
		{
			string urlAddress = "https://aaronrosser.xyz/ef/cc.json";

			try
			{
				HttpWebRequest request = (HttpWebRequest) WebRequest.Create(urlAddress);
				HttpWebResponse response = (HttpWebResponse) request.GetResponse();

				if (response.StatusCode != HttpStatusCode.OK)
					return false;

				Stream receiveStream = response.GetResponseStream();
				StreamReader readStream = null;

				if (String.IsNullOrWhiteSpace(response.CharacterSet))
					readStream = new StreamReader(receiveStream);
				else
					readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

				string jsonData = readStream.ReadToEnd();

				response.Close();
				readStream.Close();

				var res = JsonConvert.DeserializeObject<StartUpRequestResponse>(jsonData);

				if (res.ShowDialog)
				{
					MessageBox.Show(res.DialogText, res.DialogTitle, MessageBoxButtons.OK,
						(MessageBoxIcon) res.DialogCode);
				}

				return res.StartUp;
			}
			catch (WebException ex)
			{
				MessageBox.Show($"Network error occured. {Environment.NewLine}Please ensure the computer has a strong stable network connection.", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			catch (JsonReaderException ex)
			{
				return false;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
