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

namespace ScreenManager
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Screen : Microsoft.Xna.Framework.DrawableGameComponent
    {
        //Nom de l'écran, de manière générale, ce doit d'être unique.
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private Boolean isActive;

        public Boolean IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public Screen(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            name = "unknown";
            isActive = false;
        }

        public Screen(Game game, String nom)
            : base(game)
        {
            name = nom;
            isActive = false;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
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

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}