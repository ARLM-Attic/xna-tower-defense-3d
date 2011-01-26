using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GUILibrary
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// Composant définissant un menu vertical.
    /// </summary>
    public class Menu : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Texture2D White;
        string texte;
        List<Bouton> boutons;

        Viewport Vp;

        //public Viewport Vp
        //{
        //    get { return vp; }
        //    set { vp = value; }
        //}

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

        Vector2 max;
        MouseState mouse;

        public Vector2 Max
        {
            get { return max; }
            set { max = value; }
        }

        public Menu(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        unsafe public void Use(SpriteBatch sb, Viewport vp, int x, int y)
        {
            SpriteBatch = sb;
            Vp = vp;
            Position = new Vector2(x, y);
            Max = new Vector2(x, y);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            boutons = new List<Bouton>();
            LeftDown = false;

            base.Initialize();
        }

        public void pseudoLoad()
        {
            White = new Texture2D(GraphicsDevice, 1, 1);
            //White = Game.Content.Load<Texture2D>("Textures/white");
            White.SetData(new Color[] { Color.White });
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            mouse = Mouse.GetState();
            texte = mouse.X + "x, " + mouse.Y + "y\n";
            bool OnButton = false;
            if (isIn(mouse))
            {
                texte += "Est dans le menu \n";
                foreach (Bouton b in boutons)
                {
                    b.Update(gameTime);
                    texte += "Bouton : " + b.Position.X + "x, " + b.Position.Y + "y\n";
                    texte += "Texture : " + b.Texture.Width + " : " + b.Texture.Height + "\n";
                    if (b.isIn(mouse))
                    {
                        OnButton = true;
                        b.IsOver = true;
                        texte += "Est dedans\n";
                        b.FromOut = Out || b.FromOut;
                        if (mouse.LeftButton == ButtonState.Released)
                        {
                            b.FromOut = false;
                            if (b.TmpDown)
                                b.IsDown = !b.IsDown;
                        }

                        b.TmpDown = (mouse.LeftButton == ButtonState.Pressed && !b.FromOut);
                    }
                    else
                    {
                        b.IsOver = false;
                        b.TmpDown = false;
                        b.FromOut = false;
                    }
                }
            }
            else
                foreach (Bouton b in boutons)
                {
                    b.Update(gameTime);
                    b.IsOver = false;
                }
            Out = (!OnButton && (mouse.LeftButton == ButtonState.Pressed));
            base.Update(gameTime);
        }

        private bool isIn(MouseState mouse)
        {
            return (mouse.X > Position.X + Vp.X && mouse.Y > Position.Y + Vp.Y &&
                mouse.X < Vp.X + Position.X + max.X && mouse.Y < Vp.Y + Position.Y + max.Y);
        }

        public void add(Bouton newBouton)
        {
            boutons.Add(newBouton);

            newBouton.Vp = Vp;
            newBouton.SpriteBatch = SpriteBatch;
            newBouton.Position = new Vector2(Position.X, Max.Y);
            newBouton.tx_clic = White;
            newBouton.TmpDown = false;
            newBouton.IsDown = false;
            Max = new Vector2(MathHelper.Max(Max.X, newBouton.Texture.Width),
                Max.Y + 2 + newBouton.Texture.Height);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (Bouton b in boutons)
            {
                b.Draw(gameTime);
                SpriteBatch.Begin();
                //SpriteBatch.Draw(White, new Rectangle(0, 0, 100, 100), Color.Black);//Position dans le VP
                SpriteBatch.End();
            }
            SpriteBatch.Begin();
            SpriteBatch.DrawString(boutons[0].Font, texte, new Vector2(100, 100), Color.OrangeRed);
            SpriteBatch.End();
            base.Draw(gameTime);
        }

        public bool LeftDown { get; set; }

        public bool Out { get; set; }
    }
}