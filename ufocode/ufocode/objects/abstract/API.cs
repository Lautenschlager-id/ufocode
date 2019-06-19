/// UfoCode - Copyright (C) Shallow
/// <summary>
/// The API functions to control a single bot.
/// </summary>

using Microsoft.Xna.Framework;

namespace ufocode
{
	internal abstract class API
	{
		private Ufo ufo;

		// Gets the spawn point of the UFO in a position that is not near any other UFO.
		private static Vector2 SpawnPoint()
		{
			Point BATTLEFIELD = (Point)Settings.BATTLEFIELD_DIMENSION.VALUE;

			Vector2 position;

			bool distant;
			do
			{
				distant = true;

				position = new Vector2(Mathematics.Random.Next(50, BATTLEFIELD.X - 50 + 1), Mathematics.Random.Next(50, BATTLEFIELD.Y - 50 + 1));

				foreach (Ufo u in EntityManager.ufos)
					if (Mathematics.Pythagoras(position, u.Position, Enums.ENEMY_DISTANCE))
					{
						distant = false;
						break;
					}
			} while (!distant);

			return position;
		}

		public API()
		{
			ufo = new Ufo()
			{
				Position = SpawnPoint()
			};

			EntityManager.New(this);
		}

		// Checks whether the UFO is alive or not
		public bool IsAlive()
		{
			return !ufo.Remove;
		}

		// Returns the UFO position
		public Vector2 GetPosition()
		{
			return ufo.Position;
		}

		public virtual void Update()
		{
			ufo.Velocity = Vector2.Zero;
			if (Mathematics.Random.Next(0, 5) == 0)
				ufo.Velocity = new Vector2(5, 0);
			else if (Mathematics.Random.Next(0, 5) == 0)
				ufo.Velocity = new Vector2(0, 10);
			else if (Mathematics.Random.Next(0, 5) == 0)
				ufo.Velocity = new Vector2(0, -5);
			else if (Mathematics.Random.Next(0, 5) == 0)
				ufo.Velocity = new Vector2(-10, 0);
		}
	}
}