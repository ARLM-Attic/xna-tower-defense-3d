using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Maquette1
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class FPS_GC : Microsoft.Xna.Framework.DrawableGameComponent
    {
        //Composant de dessin
        public SpriteBatch spriteBatch;
        //Police de caractêres
        public SpriteFont spriteFont;
        //Nombre d'images par secondes
        public double fps = 0.0f;

        public FPS_GC(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            Game g = Game;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            this.spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);

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

        protected override void LoadContent()
        {
            this.spriteFont = this.Game.Content.Load<SpriteFont>("myfont");
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            this.fps = 1000.0d / gameTime.ElapsedGameTime.TotalMilliseconds;
            //Formatage de la chaine
            string texte = string.Format("{0:00.00} images / sec", this.fps);
            //Calcul de la taille de la chaine pour la police de caractère choisie
            Vector2 taille = this.spriteFont.MeasureString(texte);
            //Affichage de la chaine
            this.spriteBatch.Begin();
            this.spriteBatch.DrawString(this.spriteFont, texte, new Vector2(this.GraphicsDevice.Viewport.Width - taille.X, 5), Color.Green);
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}