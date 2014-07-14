using Microsoft.Xna.Framework;

namespace PixelDefenseForce
{
	internal sealed class Camera
	{
		private Point _tileSize;
		private Point _multipliedTileSize;
		private int _zoom;

		public Point Resolution { get; set; }
		public Vector2 Position { get; set; }

		public int Zoom
		{
			get { return _zoom; }
			set
			{
				_zoom = value;
				_multipliedTileSize = new Point(_tileSize.X * _zoom, _tileSize.Y * _zoom);
			}
		}

		public Point TileSize
		{
			get { return _tileSize; }
			set
			{
				_tileSize = value;
				_multipliedTileSize = new Point(_tileSize.X * _zoom, _tileSize.Y * _zoom);
			}
		}

		public Vector2 ToAbsolute(Vector2 position)
		{
			return new Vector2(
				(position.X * _multipliedTileSize.X) - Position.X,
				(position.Y * _multipliedTileSize.Y) - Position.Y);
		}
	}
}