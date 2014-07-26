using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PixelDefenseForce.Content;

namespace PixelDefenseForce
{
	public sealed class PixelDefense : Game
	{
		private readonly IDrawer _drawer;
		private readonly GraphicsDeviceManager _graphics;
		private Camera _camera;
		private SelectionController _selectionController;
		private SpriteBatch _spriteBatch;
		private TileMap _tileMap;

		public PixelDefense()
		{
			_graphics = new GraphicsDeviceManager(this);
			_drawer = new GameDrawer();
		}

		protected override void Initialize()
		{
			// Set default settings
			IsMouseVisible = true;
			Content.RootDirectory = "Content";
			Window.Title = "Pixel Defense Force";

			// Perhaps retrieve/create a settings file here?

			// Set graphics settings
			_graphics.PreferMultiSampling = false;
			_graphics.PreferredBackBufferWidth = 1280;
			_graphics.PreferredBackBufferHeight = 720;
			_graphics.ApplyChanges();

			// Create the camera
			_camera = new Camera
			{
				Resolution = new Point(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight),
				Position = new Vector2(8, 8),
				Zoom = 2,
				TileSize = new Point(32, 32)
			};
			Components.Add(new CameraController(this, _camera));

			// Generate a test map for now
			_tileMap = new TileMap {Tiles = new Tile[16][]};
			for (var x = 0; x < _tileMap.Tiles.Length; x++)
				_tileMap.Tiles[x] = new Tile[16];

			// Add a row of blocked tiles to test
			for (var y = 0; y < _tileMap.Tiles[0].Length; y++)
			{
				var oldTile = _tileMap.Tiles[0][y];
				_tileMap.Tiles[0][y] = new Tile(oldTile.TileType, oldTile.Paths, true);
			}

			// Allow the player to select stuff
			_selectionController = new SelectionController(this, _camera);
			Components.Add(_selectionController);

			base.Initialize();
		}

		protected override void LoadContent()
		{
			// Set up the sprite batcher
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			var tileset = Content.Load<Texture2D>("Graphics/Tiles");
			_tileMap.Tileset = tileset;
			_selectionController.Model.Tileset = tileset;
		}

		protected override void UnloadContent()
		{
			// Clean up the sprite batcher
			_spriteBatch.Dispose();

			Content.Unload();
		}

		protected override void Update(GameTime time)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
			    Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			base.Update(time);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			_spriteBatch.Begin(
				SpriteSortMode.Deferred, BlendState.AlphaBlend,
				SamplerState.PointClamp, DepthStencilState.None,
				RasterizerState.CullCounterClockwise);

			_drawer.Draw(_spriteBatch, _camera, _tileMap);
			_drawer.Draw(_spriteBatch, _camera, _selectionController.Model);

			_spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}