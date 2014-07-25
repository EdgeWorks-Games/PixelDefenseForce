using Microsoft.Xna.Framework.Graphics;
using PixelDefenseForce.Content;

namespace PixelDefenseForce
{
	internal interface IDrawer
	{
		void Draw(SpriteBatch spriteBatch, Camera camera, TileMap tileMap);
		void Draw(SpriteBatch spriteBatch, Camera camera, SelectionModel model);
	}
}