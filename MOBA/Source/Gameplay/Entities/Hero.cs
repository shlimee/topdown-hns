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
        public Hero(Vector2 pos, string model, World w) : base(pos, model, w)
        {
            this.World = w;
            this.Position = pos;
            this.Model = new Model2D(model, Position, new Vector2(100, 100), Model2D.Layer.FRONT, 0);
            this.Health = 100;
            this.SpeedX = 5;
            this.SpeedY = 5;

             prevMouseState = Mouse.GetState();
        }

        MouseState prevMouseState;

        public override void Update()
        {
            KeyboardState state = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            Tools.RotateTowards(Position, mouseState.Position.ToVector2(), ref Rotation);
            Model.Rotation = Rotation;

            if(/*prevMouseState.LeftButton == ButtonState.Released && */mouseState.LeftButton == ButtonState.Pressed)
            {
                Vector2 direction = Vector2.Normalize(new Vector2(mouseState.X, mouseState.Y) - Position);
                GameGlobals.PassProjectile(new Fireball("textures/fireball", Position, direction, this));
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
