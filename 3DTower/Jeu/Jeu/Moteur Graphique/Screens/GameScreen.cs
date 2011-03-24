using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlobalComponents;
using GUILibrary;
using Jeu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MoteurGraphique.MainFiles
{
    class GameScreen : Screen
    {
        public Jeu.Moteur_Graphique.Camera.Camera cam;

        public Jeu.Moteur_Graphique.Camera.Camera Cam
        {
            get
            {
                return cam;
            }
            set
            {
                cam = value;
                cam.Dimension = new Vector3(Map.x * Map.Horizontal,
                                        Map.y * Map.Vertical,
                                        Map.z * Map.Profondeur);
            }
        }

        Menu Menu { get; set; }

        Terrain Map { get; set; }

        public GameScreen(Game game)

            : base(game)
        {
            Name = "game";
            // TODO: Complete member initialization
            Map = new Terrain("Test", 5, 5, 3);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            if (Cam.CameraPosition.X < 0)
            {
                Cam.OffSetX = 0;
                Cam.CameraPosition = new Vector3(
                    Cam.OffSetX,
                    Cam.OffSetY,
                    Cam.OffSetZ);
                Cam.CameraLookAt = new Vector3(
                    Cam.OffSetX,
                    -10,
                    Cam.OffSetZ);
            }

            if (Cam.CameraPosition.Y < 64)
            {
                Cam.OffSetY = 64;
                Cam.CameraPosition = new Vector3(
                    Cam.OffSetX,
                    Cam.OffSetY,
                    Cam.OffSetZ);
            }

            if (Cam.CameraPosition.Z < 0)
            {
                Cam.OffSetZ = 0;
                Cam.CameraPosition = new Vector3(
                    Cam.OffSetX,
                    Cam.OffSetY,
                    Cam.OffSetZ);
                Cam.CameraLookAt = new Vector3(
                    Cam.OffSetX,
                    -10,
                    Cam.OffSetZ);
            }

            if (Cam.CameraPosition.X > Map.x)
            {
                Cam.OffSetX = Map.x;
                Cam.CameraPosition = new Vector3(
                    Cam.OffSetX,
                    Cam.OffSetY,
                    Cam.OffSetZ);
                Cam.CameraLookAt = new Vector3(
                    Cam.OffSetX,
                    -10,
                    Cam.OffSetZ);
            }

            if (Cam.CameraPosition.Y > 1800)
            {
                Cam.OffSetY = 1800;
                Cam.CameraPosition = new Vector3(
                    Cam.OffSetX,
                    Cam.OffSetY,
                    Cam.OffSetZ);
            }

            if (Cam.CameraPosition.Z > Map.y)
            {
                Cam.OffSetZ = Map.y;
                Cam.CameraPosition = new Vector3(
                    Cam.OffSetX,
                    Cam.OffSetY,
                    Cam.OffSetZ);
                Cam.CameraLookAt = new Vector3(
                    Cam.OffSetX,
                    -10,
                    Cam.OffSetZ);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //Changement de vp
            GraphicsDevice.Viewport = GLOBALS_GAME_RESSOURCES.VP_panneauStatut;

            GLOBALS_GAME_RESSOURCES.SPRITEBATCH.Begin();
            GLOBALS_GAME_RESSOURCES.SPRITEBATCH.Draw(GLOBALS_GAME_RESSOURCES.TX_panneauStatut,
                new Rectangle(0, 0,
                    GLOBALS_GAME_RESSOURCES.VP_panneauStatut.Width, GLOBALS_GAME_RESSOURCES.VP_panneauStatut.Height),
                Color.White);
            GLOBALS_GAME_RESSOURCES.SPRITEBATCH.End();

            GraphicsDevice.Viewport = GLOBALS_GAME_RESSOURCES.VP_panneauTour;

            GLOBALS_GAME_RESSOURCES.SPRITEBATCH.Begin();
            GLOBALS_GAME_RESSOURCES.SPRITEBATCH.Draw(GLOBALS_GAME_RESSOURCES.TX_panneauTour,
                new Rectangle(0, 0,
                    GLOBALS_GAME_RESSOURCES.VP_panneauTour.Width, GLOBALS_GAME_RESSOURCES.VP_panneauTour.Height),
                    Color.White);
            GLOBALS_GAME_RESSOURCES.SPRITEBATCH.End();

            GraphicsDevice.Viewport = GLOBALS_GAME_RESSOURCES.VP_minimap;

            GLOBALS_GAME_RESSOURCES.SPRITEBATCH.Begin();
            GLOBALS_GAME_RESSOURCES.SPRITEBATCH.Draw(GLOBALS_GAME_RESSOURCES.TX_minimap,
                new Rectangle(0, 0,
                    GLOBALS_GAME_RESSOURCES.VP_minimap.Width, GLOBALS_GAME_RESSOURCES.VP_minimap.Height),
                    Color.White);
            GLOBALS_GAME_RESSOURCES.SPRITEBATCH.End();

            GraphicsDevice.Viewport = GLOBALS_GAME_RESSOURCES.VP_viewGame;
            // Copy any parent transforms.
            foreach (Case c in Map.Carte)
            {
                drawCube(c.X, c.Y, c.Z);
            }

            base.Draw(gameTime);
        }

        void drawCube(int abs, int ord, int hauteur)
        {
            //// Copy any parent transforms.
            Matrix[] transforms = new Matrix[GLOBALS_GAME_RESSOURCES.Models[0].Bones.Count];
            GLOBALS_GAME_RESSOURCES.Models[0].CopyBoneTransformsTo(transforms);
            //mo_sship.CopyAbsoluteBoneTransformsTo(transforms);

            //// Draw the model. A model can have multiple meshes, so loop.
            foreach (ModelMesh mesh in GLOBALS_GAME_RESSOURCES.Models[0].Meshes)
            {
                // This is where the mesh orientation is set, as well
                // as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                {
                    //effect.EnableDefaultLighting();

                    effect.TextureEnabled = true;
                    effect.World = transforms[mesh.ParentBone.Index]
                        * Matrix.CreateTranslation(new Vector3(32 * abs, 32 * hauteur, 32 * ord));
                    effect.View = Cam.ViewMatrix;
                    effect.Projection = Cam.ProjectionMatrix;
                }

                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
        }
    }
}