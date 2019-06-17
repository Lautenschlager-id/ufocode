/// UfoCode - Copyright (C) Shallow
/// <summary>
/// Mathematical utilities.
/// </summary>

using Microsoft.Xna.Framework;

namespace ufocode
{
	static class Mathematics
	{
		public static int Clamp(int value, int min, int max)
		{
			return ((value < min) ? min : ((value > max) ? max : value));
		}

		public static bool Pythagoras(Vector2 p1, Vector2 p2, float range)
		{
			return Vector2.DistanceSquared(p1, p2) < (range * range);
		}
	}
}
