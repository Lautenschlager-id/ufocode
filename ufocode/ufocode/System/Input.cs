/// UfoCode - Copyright (C) Shallow
/// <summary>
/// The input manager, handles the mouse, keyboard, joysticks and others.
/// </summary>

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ufocode
{
	static class Input
	{
		private static MouseState lastMouseState, currentMouseState;

		public static Vector2 MouseCoordinates
		{
			get => new Vector2(currentMouseState.X, currentMouseState.Y);
		}

		public static bool OnLeftClick
		{
			get => (lastMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed);
		}

		public static bool OnLeftClickRelease
		{
			get => (lastMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Released);
		}

		public static bool OnLeftClickHold
		{
			get => (lastMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Pressed);
		}

		public static void Update()
		{
			lastMouseState = currentMouseState;
			currentMouseState = Mouse.GetState();
		}
	}
}
