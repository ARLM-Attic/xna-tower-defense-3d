using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GUILibrary
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Bouton : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Viewport vp;

        public Viewport Vp
        {
            get { return vp; }
            set { vp = value; }
        }

        SpriteBatch spriteBatch;

        public SpriteBatch SpriteBatch
        {
            get { return spriteBatch; }
            set { spriteBatch = value; }
        }

        Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        string texte;

        public string Texte
        {
            get { return texte; }
            set { texte = value; }
        }

        Texture2D texture;

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        bool isTexte;

        public bool IsTexte
        {
            get { return isTexte; }
            set { isTexte = value; }
        }

        public Bouton(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        public void Use(SpriteBatch spriteBatch, Texture2D texture, String textOver, Viewport vp, int x, int y)
        {
            SpriteBatch = spriteBatch;
            Texture = texture;
            Vp = vp;
            Position = new Vector2(x, y);
            TextOver = textOver;
        }

        public void Use(Texture2D texture)
        {
            Texture = texture;
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
            GraphicsDevice.Viewport = Vp;
            SpriteBatch.Begin();

            if (IsDown)
                SpriteBatch.Draw(tx_clic, new Rectangle((int)Position.X - 2, (int)Position.Y - 2,
                    Texture.Width + 4, Texture.Height + 4), Color.Red);
            SpriteBatch.Draw(Texture, Position, Color.White);
            if (IsOver)
                SpriteBatch.DrawString(Font, TextOver, Position, Color.Black);
            SpriteBatch.End();
            base.Draw(gameTime);
        }

        internal bool isIn(Microsoft.Xna.Framework.Input.MouseState mouse)
        {
            return (mouse.X > Position.X + Vp.X && mouse.Y > Position.Y + Vp.Y &&
                mouse.X < Position.X + Texture.Width + Vp.X && mouse.Y < Position.Y + Texture.Height + Vp.Y);
        }

        public string TextOver { get; set; }

        public bool IsOver { get; set; }

        public void Use(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Texture2D texture, string textOver, SpriteFont font, Viewport vp, int x, int y)
        {
            SpriteBatch = spriteBatch;
            Texture = texture;
            Vp = vp;
            Position = new Vector2(x, y);
            TextOver = textOver;
            Font = font;
        }

        public SpriteFont Font { get; set; }

        public bool IsDown { get; set; }

        public Texture2D tx_clic { get; set; }

        public bool TmpDown { get; set; }

        public bool FromOut { get; set; }
    }
}