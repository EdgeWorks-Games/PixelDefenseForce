using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PixelDefenseForce
{
	internal sealed class SelectionModel
	{
		public WorldPosition MouseHoverTile { get; set; }
		public Texture2D Tileset { get; set; }
	}

	internal sealed class SelectionController : GameComponent
	{
		public SelectionController(Game game, Camera camera)
			: base(game)
		{
			Camera = camera;
			Model = new SelectionModel();
		}

		public Camera Camera { get; set; }
		public SelectionModel Model { get; set; }

		public override void Update(GameTime gameTime)
		{
			var hoverPos = Camera.ToWorld(new WindowPosition(Mouse.GetState().Position));

			if (hoverPos.X < 0)
				hoverPos.X = 0;
			if (hoverPos.X > 15)
				hoverPos.X = 15;
			if (hoverPos.Y < 0)
				hoverPos.Y = 0;
			if (hoverPos.Y > 15)
				hoverPos.Y = 15;

			Model.MouseHoverTile = hoverPos;
		}
	}
}