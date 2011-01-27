using GlobalsComponent;
using GUILibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Maquette1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameWindow : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        //ViewPort
        Viewport vp_defaultViewPort;
        Viewport vp_viewGame;
        Viewport vp_panneauTour;
        Viewport vp_minimap;
        Viewport vp_panneauStatut;

        //Texture
        Texture2D tx_panneauStatut;
        Texture2D tx_panneauTour;
        Texture2D tx_minimap;

        //Model
        Model mo_sship;

        Vector3 modelPosition = Vector3.Zero;
        float modelRotation = 0.0f;

        // Set the position of the camera in world space, for our view matrix.
        Vector3 cameraPosition = new Vector3(0.0f, 50.0f, 5000.0f);

        //Matrix
        Matrix pm_projectionMatrix;
        Matrix pm_game;

        Bouton bb;
        Menu menu;

        public Menu Menu
        {
            get { return menu; }
            set { menu = value; }
        }

        public Bouton Bb
        {
            get { return bb; }
            set { bb = value; }
        }

        public GameWindow()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Ouverture des gameComponent
            FPS_GC fps = new FPS_GC(this);
            this.Components.Add(fps);

            Bb = new Bouton(this);
            this.Components.Add(Bb);

            Menu = new Menu(this);
            this.Components.Add(Menu);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //

            this.IsMouseVisible = true;

            //Initialisation des parametre de la fenetre
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferFormat = SurfaceFormat.Rg32;
            //graphics.ToggleFullScreen();
            graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new GlobalsGameRessources.SPRITEBATCH, which can be used to draw textures.
            GlobalsGameRessources.SPRITEBATCH = new SpriteBatch(GraphicsDevice);

            //Viewports
            vp_defaultViewPort = GraphicsDevice.Viewport;
            vp_defaultViewPort.Width = 800;
            vp_defaultViewPort.Height = 600;

            vp_viewGame = vp_defaultViewPort;
            vp_panneauStatut = vp_defaultViewPort;
            vp_panneauTour = vp_defaultViewPort;
            vp_minimap = vp_defaultViewPort;

            //Longueur des vp
            vp_viewGame.Width = 3 * vp_viewGame.Width / 2 / 2; // 3:4
            vp_panneauTour.Width = vp_panneauTour.Width / 2 / 2; // 1:4

            //Hauteur des vp
            vp_viewGame.Height = 3 * vp_viewGame.Height / 2 / 2; // 3:4
            vp_panneauStatut.Height = vp_panneauStatut.Height / 2 / 2; // 1:4
            vp_panneauTour.Height = vp_viewGame.Height; // 3:4
            vp_minimap.Height = vp_panneauStatut.Height; // 1:4

            //Voir a augmenter la taille de la minimap
            vp_minimap.Width = vp_minimap.Height; // 1:4
            vp_panneauStatut.Width = vp_defaultViewPort.Width - vp_minimap.Width; // 3:4

            //Coordiné des vp
            //vp_game est en 0,0 (coo du defaultVP)
            vp_minimap.Y = vp_viewGame.Height;
            vp_panneauStatut.X = vp_minimap.Width;
            vp_panneauStatut.Y = vp_viewGame.Height;
            vp_panneauTour.X = vp_viewGame.Width;

            // TODO: use this.Content to load your game content here

            //Texture
            tx_panneauStatut = Content.Load<Texture2D>("Textures/planet-001");
            tx_panneauTour = Content.Load<Texture2D>("Textures/paves_32x32");
            tx_minimap = Content.Load<Texture2D>("Textures/vert_32x32");

            //Model
            mo_sship = Content.Load<Model>("Modeles/p1_wedge");

            //Definir les matrix
            pm_projectionMatrix = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4, 4.0f / 3.0f, 1.0f, 10000f);
            pm_game = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4, 1.0F, 1.0f, 10000f);

            SpriteFont font = Content.Load<SpriteFont>("myfont");
            Bb.Use(GlobalsGameRessources.SPRITEBATCH, tx_minimap, "Over", font, vp_panneauTour, 10, 10);
            Menu.Use(GlobalsGameRessources.SPRITEBATCH, vp_panneauTour, 50, 50);
            Menu.pseudoLoad();
            Menu.add(Bb);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            modelRotation += (float)gameTime.ElapsedGameTime.TotalMilliseconds *
        MathHelper.ToRadians(0.1f);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //Changement de vp
            GraphicsDevice.Viewport = vp_panneauStatut;

            GlobalsGameRessources.SPRITEBATCH.Begin();
            GlobalsGameRessources.SPRITEBATCH.Draw(tx_panneauStatut, new Rectangle(0, 0, vp_panneauStatut.Width, vp_panneauStatut.Height), Color.White);
            GlobalsGameRessources.SPRITEBATCH.End();

            GraphicsDevice.Viewport = vp_panneauTour;
            GlobalsGameRessources.SPRITEBATCH.Begin();
            GlobalsGameRessources.SPRITEBATCH.Draw(tx_panneauTour, new Rectangle(0, 0, vp_panneauTour.Width, vp_panneauTour.Height), Color.White);
            GlobalsGameRessources.SPRITEBATCH.End();

            GraphicsDevice.Viewport = vp_minimap;
            GlobalsGameRessources.SPRITEBATCH.Begin();
            GlobalsGameRessources.SPRITEBATCH.Draw(tx_minimap, new Rectangle(0, 0, vp_minimap.Width, vp_minimap.Height), Color.White);
            GlobalsGameRessources.SPRITEBATCH.End();

            GraphicsDevice.Viewport = vp_viewGame;
            // Copy any parent transforms.
            Matrix[] transforms = new Matrix[mo_sship.Bones.Count];
            mo_sship.CopyAbsoluteBoneTransformsTo(transforms);

            // Draw the model. A model can have multiple meshes, so loop.
            foreach (ModelMesh mesh in mo_sship.Meshes)
            {
                // This is where the mesh orientation is set, as well
                // as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = transforms[mesh.ParentBone.Index] *
                        Matrix.CreateRotationY(modelRotation)
                        * Matrix.CreateTranslation(modelPosition);
                    effect.View = Matrix.CreateLookAt(cameraPosition,
                        Vector3.Zero, Vector3.Up);
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                        MathHelper.ToRadians(45.0f), graphics.GraphicsDevice.Viewport.AspectRatio,
                        1.0f, 10000.0f);
                }

                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }

            base.Draw(gameTime);
        }
    }
}