/// UfoCode - Copyright (C) Shallow
/// <summary>
/// The main class of the game, where the game starts.
/// </summary>

namespace ufocode
{
#if WINDOWS
	static class Program
	{
		static void Main(string[] args)
		{
			using (UfoCode game = new UfoCode())
			{
				game.Run();
			}
		}
	}
#endif
}