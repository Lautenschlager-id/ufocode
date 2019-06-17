/// UfoCode - Copyright (C) Shallow
/// <summary>
/// Represents a game bullet.
/// </summary>

namespace ufocode
{
	// UFO Bullet
	class EnergyOrb : Entity
	{
		public EnergyOrb()
		{
			Sprite = ImageContent.EnergyOrb;

			EntityManager.New(this);
		}

		public override void Update()
		{
			// Destroys the entity when it's out of the screen
			if (!UfoCode.ScreenBound.Contains(Position.ToPoint()))
				Remove = true;
		}
	}
}
