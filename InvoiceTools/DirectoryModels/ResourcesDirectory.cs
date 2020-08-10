using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using CsvHelper;
using InvoiceTools.Models;

namespace InvoiceTools.DirectoryModels
{
	public static class ResourcesDirectory
	{

		#region Paths

		private static string _path;
		public static string Path
		{
			get
			{
				var exePath = Assembly.GetExecutingAssembly().Location;
				var exeDirectory = System.IO.Path.GetDirectoryName(exePath);
				_path = $"{exeDirectory}\\..\\Resources";

				Directory.CreateDirectory(_path);

				return _path;
			}
		}

		public static string CustomersListPath
		{
			get
			{
				string path = $"{Path}\\Customers.csv";
				if (File.Exists(path)) 
					return path;

				InitCustomerList(path);

				return path;
			}
		}

		public static string LogoPath
		{
			get
			{
				string path = $"{Path}\\labelLogo.png";

				return path;
			}
		}

		#endregion

		private static void InitCustomerList(string path)
		{
			var records = new List<Customer>()
			{
				new Customer()
				{
					Code = "BES730",
					PreferredName = "Batleys Hadfield Road",
					QuickSelectText = "Batleys - Hadfield",
					Name = "Batleys Hadfield Road 730",
					Address = new[]
					{
						"Leckwith Industrial Estate",
						"24 Hadfield Road",
						"Cardiff",
						""
					},
					PostCode = "CF11 8AQ"
				}
			};

			using (var writer = new StreamWriter(path))
			using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
			{
				csv.WriteRecords(records);
			}
		}

		public static List<Customer> GetCustomers()
		{
			try
			{
				using (var reader = new StreamReader(CustomersListPath))
				using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
				{
					return csv.GetRecords<Customer>().ToList();
				}
			}
			catch (IOException ex)
			{
				return null;
			}
		}
	}
}
