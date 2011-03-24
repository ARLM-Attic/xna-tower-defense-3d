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
        private Vector3 position;
        private Quaternion rotation;
        private Vector3 regarde;
        private Matrix view;
        private Matrix projection;
        private float aspectRatio;
        private float near;
        private float far;

        public float OffsetX { get; set; }

        public float OffsetY { get; set; }

        public float OffsetZ { get; set; }

        public float RotationX { get; set; }

        public float RotationY { get; set; }

        public float RotationZ { get; set; }

        public Camera(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        public Vector3 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector3 LookAt
        {
            get { return regarde; }
            set { regarde = value; }
        }

        public Matrix View
        {
            get { return view; }
        }

        public Matrix ProjectionMatrix
        {
            get { return projection; }
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            near = 1.0F;
            far = 2000;
            aspectRatio =
                GLOBALS_GAME_RESSOURCES.VP_viewGame.Width /
                GLOBALS_GAME_RESSOURCES.VP_viewGame.Height;
            projection = Matrix.CreatePerspectiveFieldOfView(
                                        MathHelper.ToRadians(45.0f),
                                        aspectRatio,
                                        near,
                                        far);
            view = Matrix.Identity;// *Matrix.CreateRotationY(MathHelper.ToRadians(90));
            Position = new Vector3(0, 200, 0.001f);
            rotation = Quaternion.Identity;
            LookAt = new Vector3(0, -10, 0);
            OffsetY = 500;
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
                OffsetX -= 10;

            if (kstate.IsKeyDown(Keys.Right))
                OffsetX += 10;

            if (kstate.IsKeyDown(Keys.Down) && !kstate.IsKeyDown(Keys.LeftControl))
                OffsetZ -= 10;

            if (kstate.IsKeyDown(Keys.Up) && !kstate.IsKeyDown(Keys.LeftControl))
                OffsetZ += 10;

            if (kstate.IsKeyDown(Keys.Up) && kstate.IsKeyDown(Keys.LeftControl))
                OffsetY += 10;

            if (kstate.IsKeyDown(Keys.Down) && kstate.IsKeyDown(Keys.LeftControl))
                OffsetY -= 10;

            if (kstate.IsKeyDown(Keys.Down) && kstate.IsKeyDown(Keys.LeftAlt))
                RotationX += 2;

            if (kstate.IsKeyDown(Keys.Up) && kstate.IsKeyDown(Keys.LeftAlt))
                RotationX -= 2;

            ///////////////////////////////////////////////////////////////////

            //Calcule des matrices

            Position = new Vector3(OffsetX, OffsetY, OffsetZ + 0.001f);
            LookAt = new Vector3(OffsetX, -10, OffsetZ);
            Matrix rotation = Matrix.CreateRotationX(MathHelper.ToRadians(RotationX)) *
                                Matrix.CreateRotationY(MathHelper.ToRadians(RotationY)) *
                                Matrix.CreateRotationZ(MathHelper.ToRadians(RotationZ));
            Position = Vector3.Transform(Position, rotation);
            /*Matrix rotationCameraPosition = Matrix.CreateRotationX(MathHelper.ToRadians(-RotationX)) *
                                            Matrix.CreateRotationY(MathHelper.ToRadians(-RotationY)) *
                                            Matrix.CreateRotationZ(MathHelper.ToRadians(-RotationZ));*/
            // Vector3 PositionTransformed = Vector3.Transform(Position, rotationCameraPosition);
            Vector3 LookAtTransformed = Vector3.Transform(LookAt, rotation);
            //view =
            //    Matrix.CreateLookAt(position, LookAt, Vector3.Up);
            //Matrix.CreateLookAt(PositionTransformed, LookAtTransformed, Vector3.Up);
            base.Update(gameTime);
        }
    }
}