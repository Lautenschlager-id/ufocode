using Microsoft.Xna.Framework;

namespace ufocode
{
	static class Mathematics
	{
		public static bool Pythagoras(Vector2 p1, Vector2 p2, float range)
		{
			return Vector2.DistanceSquared(p1, p2) < (range * range);
		}
	}
}
