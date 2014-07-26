using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PixelDefenseForce
{
	internal sealed class SelectionModel
	{
		public WorldPosition HoveredTile { get; set; }
		public WorldPosition? SelectedTile { get; set; }
		public Texture2D Tileset { get; set; }
	}

	internal sealed class SelectionController : GameComponent
	{
		private ButtonState _prevState;

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
			else if (hoverPos.X > 15)
				hoverPos.X = 15;
			if (hoverPos.Y < 0)
				hoverPos.Y = 0;
			else if (hoverPos.Y > 15)
				hoverPos.Y = 15;

			Model.HoveredTile = hoverPos;


			var curState = Mouse.GetState().LeftButton;

			if (curState == ButtonState.Released && _prevState == ButtonState.Pressed)
			{
				// TODO: Make reacting to something being selected an entirely different class, separated from the actual selection logic
				if (Model.SelectedTile == null)
					Model.SelectedTile = Model.HoveredTile;
				else
					Model.SelectedTile = null;
			}

			_prevState = curState;
		}
	}
}