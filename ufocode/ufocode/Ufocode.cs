/// UfoCode - Copyright (C) Shallow
/// <summary>
/// The game manager, with the original Update and Draw methods.
/// All the important system goes here.
/// </summary>

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ufocode
{
	internal class UfoCode : Game
	{
		private static GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;

		// To be used in static methods, getters and setters.
		public static UfoCode Instance { get; private set; }

		private static Viewport viewPort
		{
			get => Instance.GraphicsDevice.Viewport;
		}

		// Total area of the window.
		public static Vector2 WindowBoundary
		{
			get => new Vector2(viewPort.Width, viewPort.Height);
		}

		// Total area of the screen.
		public static Vector2 ScreenDimension
		{
			get => new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 10, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 70);
		}

		// Area of the window where the action is limited.
		public static Rectangle GameBoundary { get; set; }

		// Resizes the window
		public static void Resize(int Width, int Height)
		{
			graphics.PreferredBackBufferWidth = (int)MathHelper.Clamp(Width, 50, ScreenDimension.X);
			graphics.PreferredBackBufferHeight = (int)MathHelper.Clamp(Height, 50, ScreenDimension.Y);
			graphics.ApplyChanges();
		}

		public UfoCode()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			IsMouseVisible = true;
			Window.Title = "UFOCODE ALPHA";
			Instance = this;
		}

		protected override void Initialize()
		{
			Settings.LoadSettings();
			base.Initialize();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			ImageContent.LoadContent(Content);
			FontContent.LoadContent(Content);
			SoundContent.LoadContent(Content);
		}

		protected override void UnloadContent() { }

		protected override void Update(GameTime gameTime)
		{
			if (!IsActive) return;
			Input.Update();

			EntityManager.Update(); // Temporary, only works in game

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);
			if (!IsActive) return;

			spriteBatch.Begin();
			EntityManager.Draw(spriteBatch); // Temporary, only works in game
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
