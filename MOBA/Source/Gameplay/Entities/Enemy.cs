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
    public class Enemy : Unit
    {

        public Enemy() { }
        public Enemy(Vector2 pos, string model, World w) : base(pos, model, w)
        {
            this.World = w;
            this.Position = pos;
            this.Model = new Model2D(model, Position, new Vector2(50, 50), Model2D.Layer.FRONT, 0);
            this.Health = 100;
            this.SpeedX = 5;
            this.SpeedY = 5;
        }

    }
}
