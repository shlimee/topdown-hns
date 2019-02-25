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
    public class Projectile
    {
        public Projectile(string path, Vector2 pos, Vector2 dir, Unit owner)
        {
            this.model = new Model2D(path, pos, new Vector2(16,16));
            this.position = pos;
            this.direction = dir;
            this.owner = owner;

            Tools.RotateTowards(Position, direction, ref model.Rotation);

            speed = 1f;
            lifeTime = 3f;
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                if(model != null)
                    model.Position = value;
            }
        }

        protected Model2D model;
        protected Vector2 position;
        protected Vector2 direction;
        protected float speed;
        protected float lifeTime;         // in seconds
        protected Unit owner;
        protected bool isDone;

        

        public virtual void Update()
        {
            if(!isDone)
            {
                Position += direction * speed;
            }
            
        }

        public virtual void Draw()
        {
            model.Draw();
        }
    }
}
