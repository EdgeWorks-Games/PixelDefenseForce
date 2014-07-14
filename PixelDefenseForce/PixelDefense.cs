﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PixelDefenseForce.Content;

namespace PixelDefenseForce
{
	public sealed class PixelDefense : Game
	{
		private readonly GraphicsDeviceManager _graphics;
		private Camera _camera;
		private readonly Drawer _drawer;
		private SpriteBatch _spriteBatch;
		private TileMap _tileMap;

		public PixelDefense()
		{
			_graphics = new GraphicsDeviceManager(this);

			_drawer = new Drawer();
		}

		protected override void Initialize()
		{
			// Set default settings
			IsMouseVisible = true;
			Content.RootDirectory = "Content";
			Window.Title = "Pixel Defense Force";

			// Perhaps retrieve/create a settings file here?

			_graphics.PreferMultiSampling = false;
			_graphics.PreferredBackBufferWidth = 1280;
			_graphics.PreferredBackBufferHeight = 720;
			_graphics.ApplyChanges();

			// Create the camera
			_camera = new Camera
			{
				Resolution = new Point(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight),
				Position = new Vector2(0, 0),
				Zoom = 2,
				TileSize = new Point(32, 32)
			};

			// Generate a test map for now
			_tileMap = new TileMap {Tiles = new Tile[16][]};
			for (var x = 0; x < _tileMap.Tiles.Length; x++)
				_tileMap.Tiles[x] = new Tile[16];

			base.Initialize();
		}

		protected override void LoadContent()
		{
			// Set up the sprite batcher
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			var tileset = Content.Load<Texture2D>("Graphics/Tiles");
			_tileMap.Tileset = tileset;
		}

		protected override void UnloadContent()
		{
			// Clean up the sprite batcher
			_spriteBatch.Dispose();

			Content.Unload();
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			    Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin(
				SpriteSortMode.Deferred, BlendState.AlphaBlend,
				SamplerState.PointClamp, DepthStencilState.None,
				RasterizerState.CullCounterClockwise);

			_drawer.Draw(_spriteBatch, _camera, _tileMap);

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}