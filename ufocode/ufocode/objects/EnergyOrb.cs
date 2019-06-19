/// UfoCode - Copyright (C) Shallow
/// <summary>
/// Represents a game bullet.
/// </summary>

namespace ufocode
{
	// UFO Bullet
	internal class EnergyOrb : Entity
	{
		public EnergyOrb()
		{
			Sprite = ImageContent.EnergyOrb;
		}

		public override void Update()
		{
			// Destroys the entity when it's out of the screen
			if (!UfoCode.GameBoundary.Contains(Position.ToPoint()))
				Remove = true;
		}
	}
}
