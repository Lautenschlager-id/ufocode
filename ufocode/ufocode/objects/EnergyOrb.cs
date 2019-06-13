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
			if (!UfoCode.ScreenBound.Contains(Position.ToPoint()))
				Destroy = true;
		}
	}
}
