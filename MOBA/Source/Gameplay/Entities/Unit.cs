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
    public class Unit : Model2D
    {

        public Unit(string path, Vector2 pos, Vector2 dims, World w) : base(path, pos, dims)
        {
            this.World = w;
            this.Health = 100;
            this.SpeedX = 5;
            this.SpeedY = 5;
        }


        public World World;
        public float Health;
        public float SpeedX;
        public float SpeedY;

        protected float rot;


        public override void Update(Vector2 offset)
        {
            base.Update(offset);
        }

        public override void Draw()
        {
            base.Draw();
        }


        public void SetPosition(Vector2 newPosition)
        {
            Position = newPosition;
        }



    }
}
