using System;
using Microsoft.Xna.Framework;

namespace PixelDefenseForce
{
	internal sealed class Camera
	{
		private Point _halfResolution;
		private Point _tileSize;
		private int _zoom;
		private Point _zoomedTileSize;

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
				_zoomedTileSize = new Point(_tileSize.X*_zoom, _tileSize.Y*_zoom);
			}
		}

		public Point TileSize
		{
			get { return _tileSize; }
			set
			{
				_tileSize = value;
				_zoomedTileSize = new Point(_tileSize.X*_zoom, _tileSize.Y*_zoom);
			}
		}

		public WindowPosition ToWindow(WorldPosition position)
		{
			return new WindowPosition(
				(int) Math.Round((position.X - Position.X)*_zoomedTileSize.X + _halfResolution.X),
				(int) Math.Round((position.Y - Position.Y)*_zoomedTileSize.Y + _halfResolution.Y));
		}

		public Rectangle ToWindow(Rectangle rectangle)
		{
			var position = ToWindow(new WorldPosition(rectangle.X, rectangle.Y));
			return new Rectangle(
				position.X, position.Y,
				_zoomedTileSize.X, _zoomedTileSize.Y);
		}

		public WorldPosition ToWorld(WindowPosition position)
		{
			return new WorldPosition(
				((float) position.X - _halfResolution.X)/_zoomedTileSize.X + Position.X,
				((float) position.Y - _halfResolution.Y)/_zoomedTileSize.Y + Position.Y);
		}
	}
}