/// UfoCode - Copyright (C) Shallow
/// <summary>
/// Represents a game bullet.
/// </summary>

namespace ufocode
{
	class EnergyOrb : Entity
	{
		// UFO Bullet
		public EnergyOrb()
		{

		}

		public override void Update()
		{
			// Destroys the entity when it's out of the screen
			if (!UfoCode.ScreenBound.Contains(Position.ToPoint()))
				Destroy = true;
		}
	}
}
