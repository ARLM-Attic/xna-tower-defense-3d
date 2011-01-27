using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GlobalsComponent
{
    public static class GlobalsGameRessources
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
    }
}