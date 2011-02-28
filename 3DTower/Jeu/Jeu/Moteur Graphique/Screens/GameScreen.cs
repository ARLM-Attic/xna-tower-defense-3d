﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlobalComponents;
using Jeu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MoteurGraphique.MainFiles
{
    class GameScreen : Screen
    {
        Terrain Map { get; set; }

        public GameScreen(Game game)
            : base(game)
        {
            Name = "game";
            // TODO: Complete member initialization
            Map = new Terrain("Test", 5, 5, 2);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

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
                    effect.View = Matrix.CreateLookAt(new Vector3(0.0f, 500.0f, 0.01f),
                        Vector3.Zero, Vector3.Up);
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                        MathHelper.ToRadians(120.0f),
                        GLOBALS_GAME_RESSOURCES.GRAPHICS.GraphicsDevice.Viewport.AspectRatio,
                        1.0f, 7000.0f);
                }

                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
        }

        public Jeu.Moteur_Graphique.Camera.Camera Cam { get; set; }
    }
}