namespace PixelDefenseForce.Windows
{
	internal static class Program
	{
		private static void Main()
		{
			using(var game = new PixelDefense())
				game.Run();
		}
	}
}