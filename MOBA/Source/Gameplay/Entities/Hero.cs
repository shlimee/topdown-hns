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
    //  TODO: refactor!!
    public class Hero : Unit
    {
        public Hero(string path, Vector2 pos, Vector2 dims, World w) : base(path, pos, dims, w)
        {
            this.World = w;
            //this.Position = pos;

             prevMouseState = Mouse.GetState();
        }

        MouseState prevMouseState;

        public override void Update(Vector2 offset)
        {
            KeyboardState state = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            //  ROTATION TOWARDS MOUSE POSITION
            //Tools.RotateTowards(Position, mouseState.Position.ToVector2(), ref rot);
            //Rotation = rot;

            if(/*prevMouseState.LeftButton == ButtonState.Released && */mouseState.LeftButton == ButtonState.Pressed)
            {
                Vector2 direction = Vector2.Normalize(GameGlobals.MainCamera.ScreenToWorld(new Vector2(mouseState.X, mouseState.Y)) - Position);
                GameGlobals.PassProjectile(new Fireball("textures/fireball", Position, new Vector2(8,8), direction, this));
                Console.WriteLine("Projecitle has been fired!");
            }

            if (state.IsKeyDown(Keys.A))
            {
                SetPosition(new Vector2(Position.X - 0.5f, Position.Y));
            }
            if (state.IsKeyDown(Keys.D))
            {
                SetPosition(new Vector2(Position.X + 0.5f, Position.Y));
            }
            if (state.IsKeyDown(Keys.W))
            {
                SetPosition(new Vector2(Position.X, Position.Y - 0.5f));
            }
            if (state.IsKeyDown(Keys.S))
            {
                SetPosition(new Vector2(Position.X, Position.Y + 0.5f));
            }

            prevMouseState = Mouse.GetState();
        }

        

    }
}
