using GlobalComponents;
using GUILibrary;
using Jeu.Moteur_Graphique.Camera;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MoteurGraphique.MainFiles;

namespace MoteurGraphique
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameMain : Microsoft.Xna.Framework.Game
    {
        public GameMain()
        {
            GLOBALS_GAME_RESSOURCES.GRAPHICS = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            ScreenManager.game = this;
            ScreenManager.Initialize();

            //Component
            OpeningScreen os = new OpeningScreen(this);
            FPS_GC fps = new FPS_GC(this);
            GameScreen gs = new GameScreen(this);
            Camera camera = new Camera(this);

            gs.Cam = camera;

            ScreenManager.add(os);
            ScreenManager.add(gs);

            Components.Add(os);
            Components.Add(camera);
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

            IsMouseVisible = true;

            //Initialisation des parametre de la fenetre
            GLOBALS_GAME_RESSOURCES.GRAPHICS.PreferredBackBufferHeight = 1024;
            GLOBALS_GAME_RESSOURCES.GRAPHICS.PreferredBackBufferWidth = 1280;
            GLOBALS_GAME_RESSOURCES.GRAPHICS.PreferredBackBufferFormat = SurfaceFormat.Rg32;
            GLOBALS_GAME_RESSOURCES.Initialize();
            //GLOBALS_GAME_RESSOURCES.GRAPHICS.ToggleFullScreen();
            Window.Title = "3D Tower";
            Window.AllowUserResizing = true;
            GLOBALS_GAME_RESSOURCES.GRAPHICS.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //GLOBALS_GAME_RESSOURCES.Images[0] = Content.Load<Texture2D>("Images/Shiki1");
            //GLOBALS_GAME_RESSOURCES.Images[1] = Content.Load<Texture2D>("Images/Shiki2");
            //GLOBALS_GAME_RESSOURCES.Images[2] = Content.Load<Texture2D>("Images/Shiki3");

            //Texture
            GLOBALS_GAME_RESSOURCES.TX_panneauStatut = Content.Load<Texture2D>("Textures/planet-001");
            GLOBALS_GAME_RESSOURCES.TX_panneauTour = Content.Load<Texture2D>("Textures/paves_32x32");
            GLOBALS_GAME_RESSOURCES.TX_minimap = Content.Load<Texture2D>("Textures/vert_32x32");

            //Models
            GLOBALS_GAME_RESSOURCES.Models[0] = Content.Load<Model>("Modeles/CubeVert");
            GLOBALS_GAME_RESSOURCES.Models[1] = Content.Load<Model>("Modeles/Tour");

            //Font
            //GLOBALS_GAME_RESSOURCES.Font = Content.Load<SpriteFont>("Font/myfont");
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

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GLOBALS_GAME_RESSOURCES.GRAPHICS.GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}