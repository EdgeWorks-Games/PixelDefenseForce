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

					spriteBatch.Draw(
						tileMap.Tileset,
						camera.ToWindow(new Rectangle(x, y, 1, 1)),
						new Rectangle(
							32, 0, //tile.TileType.TextureLocation.X, tile.TileType.TextureLocation.Y,
							32, 32),
						Color.White,
						0f, Vector2.Zero,
						SpriteEffects.None, 0f);
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch, Camera camera, SelectionModel model)
		{
			var tileLocation =
				model.SelectedTile == null
					? model.HoveredTile
					: model.SelectedTile.Value;

			spriteBatch.Draw(
				model.Tileset,
				camera.ToWindow(new Rectangle(
					(int) tileLocation.X, (int) tileLocation.Y,
					1, 1)),
				new Rectangle(0, 32, 32, 32),
				Color.White,
				0f, Vector2.Zero,
				SpriteEffects.None, 0f);
		}
	}
}