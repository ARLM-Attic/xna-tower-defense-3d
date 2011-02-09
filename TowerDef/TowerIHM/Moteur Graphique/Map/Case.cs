using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlobalsComponent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDef
{
    partial class Case : IDrawable
    {
        Texture2D texture;

        Vector2 Position
        {
            get;
            private set;
        }

        public void Initialize(ref Texture2D tex)
        {
            texture = tex;
            Position = new Vector2(X, Y);
        }

        public void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            GLOBALS_GAME_RESSOURCES.GRAPHICS.GraphicsDevice.Viewport = GLOBALS_GAME_RESSOURCES.VP_viewGame;
            GLOBALS_GAME_RESSOURCES.SPRITEBATCH.Draw(texture, Position, Color.White);
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