/// UfoCode - Copyright (C) Shallow
/// <summary>
/// The settings loader, to set up the game options.
/// </summary>

using Microsoft.Xna.Framework;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ufocode
{
	static class Settings
	{
		// Types
		static Type T_point = typeof(Point);
		static Type T_float = typeof(float);

		// Class to handle each setting individually
		public class Setting
		{
			public object VALUE { get; private set; }
			private object DEFAULT, MIN, MAX;
			private Type @typeof;

			public Setting(Type @typeof, object @default, object min, object max)
			{
				this.@typeof = @typeof;

				DEFAULT = @default;
				MIN = min;
				MAX = max;

				Set(DEFAULT);
			}

			public void Set(object value) 
			{
				if (@typeof == T_point)
					value = ((Point)value).Clamp((Point)MIN, (Point)MAX);
				else if (@typeof == T_float)
					value = MathHelper.Clamp((float)value, (float)MIN, (float)MAX);

				VALUE = value;
			}
		}

		// Battle field
		public static Setting BATTLEFIELD_DIMENSION = new Setting(T_point, new Point(800, 400), new Point(100, 100), UfoCode.ScreenDimension.ToPoint());

		// Life
		public static Setting UFO_LIFE = new Setting(T_float, 100f, 1f, 100f);

		public static void LoadSettings()
		{
			// Sets the battle settings
			Match match;
			string pattern = @"^(\S+) +(\S+)$";

			try
			{
				foreach (string line in File.ReadAllLines("settings.ufoc"))
				{
					match = Regex.Match(line, pattern);
					if (match.Success)
						if (match.Groups[1].Value == "BATTLEFIELD_DIMENSION")
						{
							match = Regex.Match(match.Groups[2].Value, @"^(\d+), *(\d+)$");
							if (match.Success)
								BATTLEFIELD_DIMENSION.Set(new Point(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value)));
						}
						else if (match.Groups[1].Value == "UFO_LIFE")
						{
							float value;
							if (float.TryParse(match.Groups[2].Value, out value))
								UFO_LIFE.Set(value);
						}
				}
			}
			catch (FileNotFoundException) {
				// Values do not need to be set to default since it's already the behavior of the class Setting.
			}
		}
	}
}
