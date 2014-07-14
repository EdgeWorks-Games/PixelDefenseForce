using Microsoft.Xna.Framework;

namespace PixelDefenseForce
{
	internal sealed class Camera
	{
		private Point _halfResolution;
		private Point _multipliedTileSize;
		private Point _tileSize;
		private int _zoom;

		public Vector2 Position { get; set; }

		public Point Resolution
		{
			set { _halfResolution = new Point(value.X/2, value.Y/2); }
		}

		public int Zoom
		{
			get { return _zoom; }
			set
			{
				_zoom = value;
				_multipliedTileSize = new Point(_tileSize.X*_zoom, _tileSize.Y*_zoom);
			}
		}

		public Point TileSize
		{
			get { return _tileSize; }
			set
			{
				_tileSize = value;
				_multipliedTileSize = new Point(_tileSize.X*_zoom, _tileSize.Y*_zoom);
			}
		}

		public Vector2 ToAbsolute(Vector2 position)
		{
			return new Vector2(
				(position.X - Position.X)*_multipliedTileSize.X + _halfResolution.X,
				(position.Y - Position.Y)*_multipliedTileSize.Y + _halfResolution.Y);
		}
	}
}