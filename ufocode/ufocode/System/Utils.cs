/// UfoCode - Copyright (C) Shallow
/// <summary>
/// Misc utilities.
/// </summary>

using Microsoft.Xna.Framework;

namespace ufocode
{
	static class Utils
	{
		public static Point ToPoint(this Vector2 v)
		{
			return new Point((int)v.X, (int)v.Y);
		}
	}
}
