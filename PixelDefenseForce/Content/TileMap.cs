using System;
using Microsoft.Xna.Framework.Graphics;

namespace PixelDefenseForce.Content
{
	[Flags]
	internal enum Paths
	{
		NorthWest = 0,
		NorthEast = 1 << 0,
		SouthWest = 1 << 1,
		SouthEast = 1 << 2,
	}

	internal struct Tile
	{
		public readonly TileType TileType;
		public readonly Paths Paths;

		public Tile(TileType tileType, Paths paths)
		{
			TileType = tileType;
			Paths = paths;
		}
	}

	internal sealed class TileMap
	{
		public Tile[][] Tiles { get; set; }
		public Texture2D Tileset { get; set; }
	}
}