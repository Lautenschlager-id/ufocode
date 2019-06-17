/// UfoCode - Copyright (C) Shallow
/// <summary>
/// The image content loader, where the images are loaded and managed.
/// </summary>

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ufocode
{
	static class ImageContent
	{
		// Objects
		public static Texture2D Ufo { get; private set; }
		public static Texture2D EnergyOrb { get; private set; }

		public static void LoadContent(ContentManager content)
		{
			Ufo = content.Load<Texture2D>("objects/Ufo");
			EnergyOrb = content.Load<Texture2D>("objects/EnergyOrb");
		}
	}
}
