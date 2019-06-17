/// UfoCode - Copyright (C) Shallow
/// <summary>
/// Represents a game character.
/// </summary>

namespace ufocode
{
	// Character
	class Ufo : Entity
	{
		public float Life { get; private set; }
		private float roundLife; // Life initial value may be changed once per battle, not per round.

		public Ufo()
		{
			// System
			roundLife = (float)Settings.UFO_LIFE.VALUE;

			// Esthetic
			Sprite = ImageContent.Ufo;

			EntityManager.New(this);
		}

		public void NewRound()
		{
			Life = roundLife;
		}

		public override void Update()
		{

		}
	}
}