using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PixelDefenseForce
{
	internal class CameraInputMover
	{
		// TODO: Replace this entire class with a rebindable key system

		private const float Speed = 10.0f;
		private const float ZoomScrollIncrement = 120;
		private int _previousScrollPosition;

		public CameraInputMover()
		{
			_previousScrollPosition = Mouse.GetState().ScrollWheelValue;
		}

		public void Update(GameTime time, Camera camera)
		{
			var scrollPosition = (int)(Mouse.GetState().ScrollWheelValue / ZoomScrollIncrement);
			if (scrollPosition != _previousScrollPosition)
			{
				var zoom = camera.Zoom;
				var scrollDifference = scrollPosition - _previousScrollPosition;

				// Move zoom to next power of 2
				if (scrollDifference > 0)
					zoom = zoom << scrollDifference;
				else
					zoom = zoom >> -scrollDifference;

				// Make sure zoom doesn't exceed maximum or minimum
				zoom = Math.Min(zoom, 4);
				zoom = Math.Max(zoom, 1);

				camera.Zoom = zoom;
				_previousScrollPosition = scrollPosition;
			}

			var camPos = camera.Position;

			var changeValue = (float)((Speed/camera.Zoom) * time.ElapsedGameTime.TotalSeconds);
			if (Keyboard.GetState().IsKeyDown(Keys.D))
				camPos.X += changeValue;
			if (Keyboard.GetState().IsKeyDown(Keys.A))
				camPos.X -= changeValue;
			if (Keyboard.GetState().IsKeyDown(Keys.S))
				camPos.Y += changeValue;
			if (Keyboard.GetState().IsKeyDown(Keys.W))
				camPos.Y -= changeValue;

			camera.Position = camPos;
		}
	}
}