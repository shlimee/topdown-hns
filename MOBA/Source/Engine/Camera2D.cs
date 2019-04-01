/*
	Created by zsolc
	on 3/27/2019 10:55:36 PM.
	Credits: shlime

*/

#region Including necessary namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace MOBA
{
    public class Camera2D
    {
        public Camera2D(int viewportWidth, int viewportHeight, Vector2 cameraPosition)
        {
            ViewportWidth = viewportWidth;
            ViewportHeight = viewportHeight;
            Position = cameraPosition;
            Zoom = 1.0f;
        }

        public Vector2 Position { get; private set; }
        public float Zoom { get; private set; }
        public float Rotation { get; private set; }

        public int ViewportWidth { get; set; }
        public int ViewportHeight { get; set; }

        private float currentMouseWheelValue, previousMouseWheelValue, zoom, previousZoom;

        public Vector2 ViewportCenter
        {
            get
            {
                return new Vector2(ViewportWidth * 0.5f, ViewportHeight * 0.5f);
            }
        }
        
        public Matrix TranslationMatrix
        {
            get
            {
                return Matrix.CreateTranslation(-(int)Position.X, -(int)Position.Y, 0) *
                   Matrix.CreateRotationZ(Rotation) *
                   Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                   Matrix.CreateTranslation(new Vector3(ViewportCenter, 0));
            }
        }

        public void AdjustZoom(float amount)
        {
            Zoom += amount;
            if (Zoom < .15f)
            {
                Zoom = .15f;
            }
            if (Zoom > 4f)
            {
                Zoom = 4f;
            }
        }

        public void MoveCamera(Vector2 cameraMovement, bool clampToMap = false)
        {
            Position += cameraMovement;

            if (clampToMap)
            {
                
                var cameraMax = new Vector2(2000 * GameGlobals.TILE_SIZE - ViewportWidth,
                                             2000 * GameGlobals.TILE_SIZE - ViewportHeight);

                Position = Vector2.Clamp(Position, Vector2.Zero, cameraMax);
            }
        }

        public Rectangle ViewportWorldBoundry()
        {
            Vector2 viewPortCorner = ScreenToWorld(new Vector2(0, 0));
            Vector2 viewPortBottomCorner = ScreenToWorld(new Vector2(ViewportWidth, ViewportHeight));

            return new Rectangle((int)viewPortCorner.X, (int)viewPortCorner.Y, (int)(viewPortBottomCorner.X - viewPortCorner.X),
                                                   (int)(viewPortBottomCorner.Y - viewPortCorner.Y));
        }

        public void CenterOn(Vector2 position)
        {
            Position = position;
        }

        public void CenterOn(Point location)
        {
            Position = CenteredPosition(location);
        }

        private Vector2 CenteredPosition(Point location, bool clampToMap = false)
        {
            var cameraPosition = new Vector2(location.X * GameGlobals.TILE_SIZE, location.Y * GameGlobals.TILE_SIZE);
            var cameraCenteredOnTilePosition = new Vector2(cameraPosition.X + GameGlobals.TILE_SIZE/2,
                                                            cameraPosition.Y + GameGlobals.TILE_SIZE/2);
            if (clampToMap)
            {
                // clamp the camera so it never leaves the visible area of the map.
                var cameraMax = new Vector2(2000 * GameGlobals.TILE_SIZE - ViewportWidth,
                                             2000 * GameGlobals.TILE_SIZE - ViewportHeight);

                return Vector2.Clamp(cameraCenteredOnTilePosition, Vector2.Zero, cameraMax);
            }

            return cameraCenteredOnTilePosition;
        }

        public Vector2 WorldToScreen(Vector2 worldPosition)
        {
            return Vector2.Transform(worldPosition, TranslationMatrix);
        }

        public Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            return Vector2.Transform(screenPosition, Matrix.Invert(TranslationMatrix));
        }

        public void HandleInput(PlayerIndex? controllingPlayer)
        {

        }

        public void UpdateCamera()
        {

            Vector2 cameraMovement = Vector2.Zero;
            int moveSpeed;

            if (Zoom > .8f)
            {
                moveSpeed = 15;
            }
            else if (Zoom < .8f && Zoom >= .6f)
            {
                moveSpeed = 20;
            }
            else if (Zoom < .6f && Zoom > .35f)
            {
                moveSpeed = 25;
            }
            else if (Zoom <= .35f)
            {
                moveSpeed = 30;
            }
            else
            {
                moveSpeed = 10;
            }

            previousMouseWheelValue = currentMouseWheelValue;
            currentMouseWheelValue = Mouse.GetState().ScrollWheelValue;

            if (currentMouseWheelValue > previousMouseWheelValue)
            {
                AdjustZoom(10.05f);
                Console.WriteLine(moveSpeed);
            }

            if (currentMouseWheelValue < previousMouseWheelValue)
            {
                AdjustZoom(-10.05f);
                Console.WriteLine(moveSpeed);
            }

            previousZoom = zoom;
            zoom = Zoom;
            if (previousZoom != zoom)
            {
                Console.WriteLine(zoom);

            }

            MoveCamera(cameraMovement);
        }
    }
}
