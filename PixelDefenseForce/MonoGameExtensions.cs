using Microsoft.Xna.Framework;

namespace PixelDefenseForce
{
	internal static class MonoGameExtensions
	{
		public static Point ToPoint(this Vector2 vector)
		{
			return new Point((int) vector.X, (int) vector.Y);
		}
	}

	internal struct WorldPosition
	{
		public Vector2 Vector;

		public WorldPosition(float x, float y)
		{
			Vector.X = x;
			Vector.Y = y;
		}

		public WorldPosition(Vector2 vector)
		{
			Vector = vector;
		}

		public float X
		{
			get { return Vector.X; }
			set { Vector.X = value; }
		}

		public float Y
		{
			get { return Vector.Y; }
			set { Vector.Y = value; }
		}
	}

	internal struct WindowPosition
	{
		public Point Point;

		public WindowPosition(int x, int y)
		{
			Point.X = x;
			Point.Y = y;
		}

		public WindowPosition(Point point)
		{
			Point = point;
		}

		public int X
		{
			get { return Point.X; }
			set { Point.X = value; }
		}

		public int Y
		{
			get { return Point.Y; }
			set { Point.Y = value; }
		}
	}
}