using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlobalComponents;
using Microsoft.Xna.Framework;

namespace MoteurGraphique
{
    class OpeningScreen : Screen
    {
        int numScreen = -1;
        TimeSpan time;
        private GameMain gameMain;
        int aVoir = 0;

        public OpeningScreen(Game game)
            : base(game)
        {
            Name = "OpeningScreen";
        }

        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            if (numScreen == -1)
            {
                time = gameTime.ElapsedGameTime;
                ++numScreen;
            }
            else if ((time - gameTime.ElapsedGameTime) > new TimeSpan(30000000))
            {
                ++numScreen;
                time = TimeSpan.Zero;
            }
            else
                time += gameTime.ElapsedGameTime;
            if (numScreen >= aVoir)
            {
                GlobalComponents.ScreenManager.disableScreen(Name);
                GlobalComponents.ScreenManager.activateScreen("game");
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //GLOBALS_GAME_RESSOURCES.SPRITEBATCH.Begin();
            //{
            //    GLOBALS_GAME_RESSOURCES.SPRITEBATCH.Draw(GLOBALS_GAME_RESSOURCES.Images[numScreen], Vector2.Zero, Color.White);
            //}
            //GLOBALS_GAME_RESSOURCES.SPRITEBATCH.End();

            base.Draw(gameTime);
        }
    }
}