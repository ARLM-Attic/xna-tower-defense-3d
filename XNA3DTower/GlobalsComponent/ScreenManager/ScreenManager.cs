using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GlobalsComponent
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public static class ScreenManager
    {
        public static Game game;
        private static List<Screen> screenList;

        //public ScreenManager()
        //{
        //    game = null;
        //    screenList = new List<Screen>();
        //}

        //public ScreenManager(ref Game game)
        //{
        //    this.game = game;
        //    screenList = new List<Screen>();
        //    // TODO: Construct any child components here
        //}

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public static void Initialize()
        {
            // TODO: Add your initialization code here
            screenList = new List<Screen>();
        }

        public static void add(Screen screen)
        {
            screenList.Add(screen);
        }

        public static void activateScreen(String cible)
        {
            foreach (Screen screen in screenList)
            {
                if (screen.Name == cible)
                {
                    game.Components.Add(screen);
                    return;
                }
            }
        }

        public static void disableScreen(String cible)
        {
            foreach (Screen screen in screenList)
            {
                if (screen.Name == cible)
                {
                    game.Components.Remove(screen);
                    return;
                }
            }
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public static void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
        }
    }
}