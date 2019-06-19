/// UfoCode - Copyright (C) Shallow
/// <summary>
/// Represents a game character.
/// </summary>

using Microsoft.Xna.Framework;

namespace ufocode
{
	// Character
	internal class Ufo : Entity
	{
		public float Life { get; private set; }

		private Vector2 ScreenLimit;

		public Ufo()
		{
			// Esthetic
			Sprite = ImageContent.Ufo;

			// Screen limit to stop acceleration
			ScreenLimit = new Vector2(UfoCode.GameBoundary.Width, UfoCode.GameBoundary.Height) - HalfSize;
		}

		public override void Update()
		{
			Position = Vector2.Clamp(Position + Velocity, HalfSize, ScreenLimit);
		}
	}
}