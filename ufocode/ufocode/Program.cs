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
