using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelDefenseForce.Content;

namespace PixelDefenseForce
{
	internal sealed class Drawer
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
						camera.ToAbsolute(new Vector2(x, y)),
						new Rectangle(
							32, 0, //tile.TileType.TextureLocation.X, tile.TileType.TextureLocation.Y,
							32, 32),
						Color.White,
						0f, Vector2.Zero, camera.Zoom,
						SpriteEffects.None, 0f);
				}
			}
		}
	}
}