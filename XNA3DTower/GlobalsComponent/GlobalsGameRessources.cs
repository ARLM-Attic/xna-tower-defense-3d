using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GlobalsComponent
{
    public static class GLOBALS_GAME_RESSOURCES
    {
        //Devices
        public static GraphicsDeviceManager GRAPHICS;
        public static SpriteBatch SPRITEBATCH;

        //ViewPort
        public static Viewport VP_defaultViewPort,
            VP_viewGame,
            VP_panneauTour,
            VP_minimap,
            VP_panneauStatut;

        //Texture
        public static Texture2D TX_panneauStatut,
            TX_panneauTour,
            TX_minimap;

        //Model

        public static void Initialize()
        {
            // Create a new GlobalsGameRessources.SPRITEBATCH, which can be used to draw textures.
            SPRITEBATCH = new SpriteBatch(GRAPHICS.GraphicsDevice);

            //Viewports
            VP_defaultViewPort = GRAPHICS.GraphicsDevice.Viewport;
            VP_defaultViewPort.Width = 1280;
            VP_defaultViewPort.Height = 1024;

            VP_viewGame = VP_defaultViewPort;
            VP_panneauStatut = VP_defaultViewPort;
            VP_panneauTour = VP_defaultViewPort;
            VP_minimap = VP_defaultViewPort;

            //Longueur des vp
            VP_viewGame.Width = 3 * VP_viewGame.Width / 2 / 2; // 3:4
            VP_panneauTour.Width = VP_panneauTour.Width / 2 / 2; // 1:4

            //Hauteur des vp
            VP_viewGame.Height = 3 * VP_viewGame.Height / 2 / 2; // 3:4
            VP_panneauStatut.Height = VP_panneauStatut.Height / 2 / 2; // 1:4
            VP_panneauTour.Height = VP_viewGame.Height; // 3:4
            VP_minimap.Height = VP_panneauStatut.Height; // 1:4

            //Voir a augmenter la taille de la minimap
            VP_minimap.Width = VP_minimap.Height; // 1:4
            VP_panneauStatut.Width = VP_defaultViewPort.Width - VP_minimap.Width; // 3:4

            //Coordiné des vp
            //vp_game est en 0,0 (coo du defaultVP)
            VP_minimap.Y = VP_viewGame.Height;
            VP_panneauStatut.X = VP_minimap.Width;
            VP_panneauStatut.Y = VP_viewGame.Height;
            VP_panneauTour.X = VP_viewGame.Width;

            Images = new Texture2D[3];
        }

        public static Texture2D[] Images { get; set; }
    }
}