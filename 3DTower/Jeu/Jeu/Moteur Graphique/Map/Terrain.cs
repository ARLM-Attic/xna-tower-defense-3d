using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jeu
{
    partial class Terrain : IDrawable
    {
        //Texture2D textureChemin;
        //Texture2D textureConstructible;

        public void Draw(GameTime gameTime)
        {
            foreach (Case c in Carte)
            {
                c.Draw(gameTime);
            }

            //throw new NotImplementedException();
        }

        public int DrawOrder
        {
            get { throw new NotImplementedException(); }
        }

        public event EventHandler<EventArgs> DrawOrderChanged;

        public bool Visible
        {
            get { throw new NotImplementedException(); }
        }

        public event EventHandler<EventArgs> VisibleChanged;
    }
}