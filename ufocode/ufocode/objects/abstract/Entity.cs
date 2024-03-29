﻿/// UfoCode - Copyright (C) Shallow
/// <summary>
/// Abstract class for all entities of the game (characters, bullets, ...).
/// </summary>

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ufocode
{
	internal abstract class Entity
	{
		public bool Remove = false;

		public float Angle, Radius, Scale = 1;

		public Vector2 Position, Velocity;
		public Vector2 Size { get; private set; }
		public Vector2 HalfSize { get; private set; }

		protected float Depth = Enums.MIDDLEGROUND_DEPTH;
		protected Color Color = Color.White;

		private Texture2D sprite;
		protected Texture2D Sprite {
			get => sprite;
			set
			{
				Size = new Vector2(value.Width, value.Height);

				HalfSize = Size / 2f;
				Radius = value.Width / 2f;

				sprite = value;
			}
		}

		public Entity()
		{
			EntityManager.New(this);
		}

		public abstract void Update();

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Sprite, Position, null, Color, Angle, HalfSize, Scale, 0, Depth);
		}
	}
}
