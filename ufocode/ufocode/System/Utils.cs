/// UfoCode - Copyright (C) Shallow
/// <summary>
/// Misc utilities.
/// </summary>

using Microsoft.Xna.Framework;
using System;

namespace ufocode
{
	static class Utils
	{
		public static Point ToPoint(this Vector2 v)
		{
			return new Point((int)v.X, (int)v.Y);
		}

		public static Point Clamp(this Point p, Point min, Point max)
		{
			p.X = ((p.X < min.X) ? min.X : ((p.X > max.X) ? max.X : p.X));
			p.Y = ((p.Y < min.Y) ? min.Y : ((p.Y > max.Y) ? max.Y : p.Y));
			return p;
		}

		public static Point Clamp(this Point p, Point max)
		{
			p.X = ((p.X > max.X) ? max.X : p.X);
			p.Y = ((p.Y > max.Y) ? max.Y : p.Y);
			return p;
		}
	}
}
