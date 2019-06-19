/// UfoCode - Copyright (C) Shallow
/// <summary>
/// Manages all the entities of the game (characters, bullets, ...) and its collisions.
/// </summary>

using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace ufocode
{
	internal static class EntityManager
	{
		private static bool isUpdating;

		private static List<Entity> entities = new List<Entity>();
		// To be added after the last update
		private static List<Entity> newEntities = new List<Entity>();

		// Separated for collision purposes
		public static List<Ufo> ufos = new List<Ufo>();
		private static List<EnergyOrb> energyOrbs = new List<EnergyOrb>();
		private static List<API> players = new List<API>();

		private static void Insert(Entity e)
		{
			entities.Add(e);
			if (e is Ufo)
				ufos.Add(e as Ufo);
			else if (e is EnergyOrb)
				energyOrbs.Add(e as EnergyOrb);
		}

		public static void New(Entity e)
		{
			if (isUpdating)
				newEntities.Add(e);
			else
				Insert(e);
		}

		public static void New(API p)
		{
			players.Add(p as API);
		}

		// All hitboxes are circles
		private static bool OnCollision(Entity e1, Entity e2)
		{
			if (e1.Remove || e2.Remove) return false;
			return Mathematics.Pythagoras(e1.Position, e2.Position, (e1.Radius + e2.Radius));
		}

		public static void Update()
		{
			isUpdating = true;

			foreach (API p in players)
				p.Update();
			foreach (Entity e in entities)
				e.Update();

			isUpdating = false;

			foreach (Entity e in newEntities)
				Insert(e);
			newEntities.Clear();

			entities = entities.Where(e => !e.Remove).ToList();
			ufos = ufos.Where(e => !e.Remove).ToList();
			energyOrbs = energyOrbs.Where(e => !e.Remove).ToList();
		}

		public static void Draw(SpriteBatch spriteBatch)
		{
			foreach (Entity e in entities)
				e.Draw(spriteBatch);
		}
	}
}
