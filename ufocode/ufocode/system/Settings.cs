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
	internal static class Settings
	{
		// Types
		static Type T_point = typeof(Point);
		static Type T_float = typeof(float);
		static Type T_bool = typeof(bool);

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
		public static Setting BATTLEFIELD_DIMENSION = new Setting(T_point, new Point(1024, 720), new Point(800, 600), (UfoCode.ScreenDimension - new Vector2(Enums.INTERFACE_WIDTH, Enums.INTERFACE_HEIGHT)).ToPoint());

		// Ufo
		public static Setting UFO_LIFE = new Setting(T_float, 100f, 1f, 100f);

		// Debug
		public static Setting DEBUG_MODE = new Setting(T_bool, false, null, null);

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
								// TryParse is not needed because the match checks if it is an int already.
								BATTLEFIELD_DIMENSION.Set(new Point(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value)));
						}
						else if (match.Groups[1].Value == "UFO_LIFE")
						{
							float value;
							if (float.TryParse(match.Groups[2].Value, out value))
								UFO_LIFE.Set(value);
						}
						else if (match.Groups[1].Value == "DEBUG_MODE")
						{
							int value = (match.Groups[2].Value == "TRUE" || match.Groups[2].Value == "true" || match.Groups[2].Value == "1") ? 1 : ((match.Groups[2].Value == "FALSE" || match.Groups[2].Value == "false" || match.Groups[2].Value == "0") ? 0 : 2);
							if (value < 2)
								DEBUG_MODE.Set(value == 1);
						}
				}
			}
			catch (FileNotFoundException) {
				// Values do not need to be set to default since it's already the behavior of the class Setting.
			}

			// Set game boundaries
			Point battlefield = (Point)BATTLEFIELD_DIMENSION.VALUE;
			UfoCode.GameBoundary = new Rectangle(0, 0, battlefield.X, battlefield.Y);

			UfoCode.Resize(battlefield.X, battlefield.Y);// + Enums.INTERFACE_WIDTH_SIZE, battlefield.Y + Enums.INTERFACE_HEIGHT_SIZE);
		}
	}
}
