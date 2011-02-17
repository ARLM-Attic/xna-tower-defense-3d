using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlobalComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MoteurGraphique.MainFiles
{
    class GameScreen : Screen
    {
        public GameScreen(Game game)
            : base(game)
        {
            Name = "game";
            // TODO: Complete member initialization
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            modelRotation += (float)gameTime.ElapsedGameTime.TotalMilliseconds *
        MathHelper.ToRadians(0.1f);

            base.Update(gameTime);
        }

        float modelRotation = 0;

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
                    effect.EnableDefaultLighting();
                    effect.World = transforms[mesh.ParentBone.Index] *
                        Matrix.CreateRotationY(modelRotation)
                        * Matrix.CreateTranslation(Vector3.Zero);
                    effect.View = Matrix.CreateLookAt(new Vector3(0.0f, 50.0f, 5000.0f),
                        Vector3.Zero, Vector3.Up);
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                        MathHelper.ToRadians(45.0f),
                        GLOBALS_GAME_RESSOURCES.GRAPHICS.GraphicsDevice.Viewport.AspectRatio,
                        1.0f, 10000.0f);
                }

                //    // Draw the mesh, using the effects set above.
                mesh.Draw();
            }

            base.Draw(gameTime);
        }
    }
}