/*
	Created by zsolc
	on 2/25/2019 8:58:06 PM.
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
    public abstract class Projectile : Model2D
    {
        public Projectile(string path, Vector2 pos, Vector2 dims, Vector2 dir, Unit owner) : base(path, pos, dims, Layer.PROJECTILE)
        {
            //this.model = new Model2D(path, pos, new Vector2(16,16));
            this.owner = owner;
            this.direction = dir;
            Tools.RotateTowards(Position, direction, ref Rotation);

            speed = 1f;
            lifeTime = 3f;
        }

        protected Vector2 direction;
        protected float speed;
        protected float lifeTime;         // in seconds
        protected Unit owner;
        protected bool isDone;

        

        public override void Update(Vector2 offset)
        {
            if(!isDone)
            {
                Position += direction * speed;
            }
            
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
