using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelDefenseForce.Content;

namespace PixelDefenseForce
{
	internal sealed class GameDrawer : IDrawer
	{
		public void Draw(SpriteBatch spriteBatch, Camera camera, TileMap tileMap)
		{
			for (var x = 0; x < tileMap.Tiles.Length; x++)
			{
				for (var y = 0; y < tileMap.Tiles[x].Length; y++)
				{
					var tile = tileMap.Tiles[x][y];

					DrawTile(
						spriteBatch, tileMap.Tileset,
						camera.ToWindow(new Rectangle(x, y, 1, 1)),
						new Point(1, 0));

					if (tile.IsDisabled)
					{
						DrawTile(
							spriteBatch, tileMap.Tileset,
							camera.ToWindow(new Rectangle(x, y, 1, 1)),
							new Point(2, 1));
					}
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch, Camera camera, SelectionModel model)
		{
			var tileLocation =
				model.SelectedTile == null
					? model.HoveredTile
					: model.SelectedTile.Value;

			DrawTile(
				spriteBatch, model.Tileset,
				camera.ToWindow(new Rectangle((int) tileLocation.X, (int) tileLocation.Y, 1, 1)),
				new Point(0, 1));
		}

		private static void DrawTile(
			SpriteBatch spriteBatch, Texture2D tileset,
			Rectangle targetPosition, Point sourcePosition)
		{
			// TODO: Perhaps replace this with a better SpriteBatch extension method specifically for tiles.

			spriteBatch.Draw(
				tileset,
				targetPosition,
				new Rectangle(
					sourcePosition.X*32, sourcePosition.Y*32,
					32, 32),
				Color.White,
				0f, Vector2.Zero,
				SpriteEffects.None, 0f);
		}
	}
}