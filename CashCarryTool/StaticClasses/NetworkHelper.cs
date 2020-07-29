using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Eden_Farm_Cash___Carry_Tool.StaticClasses
{
	public class NetworkHelper
	{
		public static bool GetStartPermission()
		{
			string urlAddress = "https://aaronrosser.xyz/ef/ef";

			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();

				if (response.StatusCode != HttpStatusCode.OK)
					return false;

				Stream receiveStream = response.GetResponseStream();
				StreamReader readStream = null;

				if (String.IsNullOrWhiteSpace(response.CharacterSet))
					readStream = new StreamReader(receiveStream);
				else
					readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

				string data = readStream.ReadToEnd();

				response.Close();
				readStream.Close();

				return data.Contains("ok");
			}
			catch
			{
				return false;
			}
		}
	}
}
