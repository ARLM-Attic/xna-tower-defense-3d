using System;
using System.Collections.Generic;
using System.Linq;
using GlobalComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Jeu.Moteur_Graphique.Camera
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Camera : Microsoft.Xna.Framework.GameComponent
    {
        public Vector3 CameraInitPosition;
        public Vector3 CameraPosition;

        public Vector3 CameraInitLookAt;
        public Vector3 CameraLookAt;

        public Matrix ViewMatrix;

        public Matrix ProjectionMatrix;

        Quaternion CameraRotation;

        public float OffSetZ;

        public float OffSetY;

        public float OffSetX;

        private Vector3 CameraUpVector;
        private float Near;
        private int Far;
        private int AspectRatio;

        public Vector3 Dimension;

        public Camera(Game game)
            : base(game)
        {
            CameraInitPosition = CameraPosition = new Vector3(0, 200, 0.0001f);
            CameraInitLookAt = CameraLookAt = new Vector3(0, -10, 0);
            ViewMatrix = Matrix.Identity;
            ProjectionMatrix = Matrix.Identity;
            CameraRotation = Quaternion.Identity;

            OffSetX = 0;
            OffSetY = 0;
            OffSetZ = 0;

            CameraUpVector = Vector3.Up;

            Near = 1.0F;
            Far = 2000;

            Dimension = Vector3.Zero;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            AspectRatio =
                GLOBALS_GAME_RESSOURCES.VP_viewGame.Width /
                GLOBALS_GAME_RESSOURCES.VP_viewGame.Height;
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            //Recuperation du clavier
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Left))
            {
                OffSetX -= 10;
                if (OffSetX < 0)
                    OffSetX = 0;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                OffSetX += 10;
                if (OffSetX > Dimension.X)
                    OffSetX = Dimension.X;
            }

            if (kstate.IsKeyDown(Keys.Down) && !kstate.IsKeyDown(Keys.LeftControl))
            {
                OffSetZ -= 10;
                if (OffSetZ < 0)
                    OffSetZ = 0;
            }

            if (kstate.IsKeyDown(Keys.Up) && !kstate.IsKeyDown(Keys.LeftControl))
            {
                OffSetZ += 10;
                if (OffSetZ > Dimension.Y)
                    OffSetZ = Dimension.Y;
            }

            if (kstate.IsKeyDown(Keys.Up) && kstate.IsKeyDown(Keys.LeftControl))
            {
                OffSetY += 10;
                if (OffSetY > 1800)
                    OffSetY = 1800;
            }

            if (kstate.IsKeyDown(Keys.Down) && kstate.IsKeyDown(Keys.LeftControl))
            {
                OffSetY -= 10;
                if (OffSetY < Dimension.Z)
                    OffSetY = Dimension.Z;
            }
            /*if (kstate.IsKeyDown(Keys.Down) && kstate.IsKeyDown(Keys.LeftAlt))
                RotationX += 2;

            if (kstate.IsKeyDown(Keys.Up) && kstate.IsKeyDown(Keys.LeftAlt))
                RotationX -= 2;*/

            ///////////////////////////////////////////////////////////////////

            //Calcule des matrices

            CameraPosition = Vector3.Transform(CameraInitPosition, Matrix.CreateFromQuaternion(CameraRotation));

            CameraPosition += new Vector3(OffSetX, OffSetY, OffSetZ);

            CameraLookAt = Vector3.Transform(CameraInitLookAt, Matrix.CreateFromQuaternion(CameraRotation));

            CameraLookAt += new Vector3(OffSetX, 0, OffSetZ);

            CameraUpVector = Vector3.Transform(CameraUpVector, Matrix.CreateFromQuaternion(CameraRotation));

            ViewMatrix = Matrix.CreateLookAt(CameraPosition, CameraLookAt, CameraUpVector);

            ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, AspectRatio, Near, Far);
            base.Update(gameTime);
        }
    }
}