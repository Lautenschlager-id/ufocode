/// UfoCode - Copyright (C) Shallow
/// <summary>
/// Mathematical utilities.
/// </summary>

using Microsoft.Xna.Framework;
using System;

namespace ufocode
{
	internal static class Mathematics
	{
		public static Random Random = new Random();

		public static int Clamp(int value, int min, int max)
		{
			return ((value < min) ? min : ((value > max) ? max : value));
		}

		public static bool Pythagoras(Vector2 p1, Vector2 p2, float range)
		{
			return Vector2.DistanceSquared(p1, p2) < (range * range);
		}

		public static float Percent(float p, float of)
		{
			return (p / 100 * of);
		}

		public static Vector2 Percent(float p, Vector2 of)
		{
			return new Vector2(Percent(p, of.X), Percent(p, of.Y));
		}
	}
}
