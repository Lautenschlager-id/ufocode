using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ufocode
{
	public class UfoCode : Game
	{
		// Multiple layer depths
		private SpriteBatch Background, Middleground, Foreground;

		GraphicsDeviceManager graphics;
		public static UfoCode Instance { get; private set; }

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
			base.Initialize();
		}

		protected override void LoadContent()
		{
			Background = new SpriteBatch(GraphicsDevice);
			Middleground = new SpriteBatch(GraphicsDevice);
			Foreground = new SpriteBatch(GraphicsDevice);

			SpriteContent.LoadContent(Content);
			FontContent.LoadContent(Content);
			SoundContent.LoadContent(Content);
		}

		protected override void UnloadContent() { }

		protected override void Update(GameTime gameTime)
		{
			if (!IsActive) return;
			Input.Update();

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			if (!IsActive) return;
			GraphicsDevice.Clear(Color.Black);

			Background.Begin();
			Background.End();
			Middleground.Begin();
			Middleground.End();
			Foreground.Begin();
			Foreground.End();

			base.Draw(gameTime);
		}
	}
}
