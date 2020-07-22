using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eden_Farm_Cash___Carry_Tool.Models.FrontSheetLabels;

namespace Eden_Farm_Cash___Carry_Tool.StaticClasses
{
	public static class TempDirectory
	{
		private static string _path;

		public static string Path
		{
			get
			{
				var exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
				var exeDirectory = System.IO.Path.GetDirectoryName(exePath);
				_path = $"{exeDirectory}\\temp";

				Directory.CreateDirectory(_path);

				return _path;
			}
		}

		public class PickSheet
		{
			public static string OpenPickSheetPath
			{
				get
				{
					long unixTimeMilliseconds = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
					string path = $"{Path}\\{unixTimeMilliseconds}.pdf";

					return path;
				}
			}
		}
		
	}
}
