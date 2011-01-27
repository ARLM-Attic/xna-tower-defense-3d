namespace Maquette1
{
#if WINDOWS || XBOX

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (GameWindow game = new GameWindow())
            {
                game.Run();
            }
        }
    }

#endif
}