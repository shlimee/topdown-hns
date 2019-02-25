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
    public class Unit
    {
        public Unit() { this.World = null; }

        public Unit(Vector2 pos, string model, World w)
        {
            this.World = w;
            this.Position = pos;
            this.Model = new Model2D(model, Position, new Vector2(100,100), Model2D.Layer.MIDDLE, 0);
            this.Health = 100;
            this.SpeedX = 5;
            this.SpeedY = 5;
        }


        public World World;
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                if(Model != null)
                    Model.Position = value;
            }
        }
        public Model2D Model;
        public float Health;
        public float SpeedX;
        public float SpeedY;
        public float Rotation;

        private Vector2 position;


        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            Model.Draw();
        }


        public void SetPosition(Vector2 newPosition)
        {
            Position = newPosition;
        }



    }
}
