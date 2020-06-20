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
	class ResourcesDirectory
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
			private static string _generalDetailsQuickSelectPath;

			public static string GeneralDetailsQuickSelectPath
			{
				get
				{
					_generalDetailsQuickSelectPath = $"{Path}\\bulkLabelQuickSelects.csv";

					if (File.Exists(_generalDetailsQuickSelectPath)) return _generalDetailsQuickSelectPath;

					var records = new List<GeneralDetailsQuickSelect>
					{
						new GeneralDetailsQuickSelect {SelectionText = "Custom", Title = "", CustomerCode = ""},
						new GeneralDetailsQuickSelect {SelectionText = "Hadfield - Batleys", Title = "Batleys Hadfield", CustomerCode = "BES970"},
					};

					using (var writer = new StreamWriter(_generalDetailsQuickSelectPath))
					using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
					{
						csv.WriteRecords(records);
					}

					return _generalDetailsQuickSelectPath;
				}
			}
		}
		
	}
}
