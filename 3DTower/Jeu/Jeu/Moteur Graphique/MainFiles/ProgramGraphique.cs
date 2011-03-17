namespace MoteurGraphique
{
    //#if WINDOWS || XBOX

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            bool console = true;
            if (console)
            {
                new MainMoteur();
            }
            else
            {
                using (GameMain game = new GameMain())
                {
                    game.Run();
                }
            }
        }
    }

    //#endif
}