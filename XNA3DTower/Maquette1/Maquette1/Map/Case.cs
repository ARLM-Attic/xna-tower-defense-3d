using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoteurGraphique.Map
{
    partial class Case : Microsoft.Xna.Framework.IDrawable
    {
        public void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
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