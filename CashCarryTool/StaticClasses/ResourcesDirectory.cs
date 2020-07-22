using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels;

namespace Eden_Farm_Cash___Carry_Tool.StaticClasses
{
	public static class ResourcesDirectory
	{
		private static string _path;

		public static string Path
		{
			get
			{
				var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
				var exeDirectory = System.IO.Path.GetDirectoryName(exePath);
				_path = $"{exeDirectory}\\res";

				Directory.CreateDirectory(_path);

				return _path;
			}
		}

		public class FrontSheetLabel
		{
			public static string GeneralDetailsQuickSelectPath
			{
				get
				{
					string path = $"{Path}\\quickSelects.csv";

					if (File.Exists(path)) return path;

					var records = new List<GeneralDetailsQuickSelect>
					{
						new GeneralDetailsQuickSelect {SelectionText = "Custom", Title = "", CustomerCode = ""},
						new GeneralDetailsQuickSelect {SelectionText = "McNabs Cash & Carry", Title = "McNabs Cash & Carry", CustomerCode = "MCN812"},
					};

					using (var writer = new StreamWriter(path))
					using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
					{
						csv.WriteRecords(records);
					}

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
		}
		
	}
}
