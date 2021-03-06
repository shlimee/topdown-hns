﻿/*
	Created by zsolc
	on 2/25/2019 9:36:09 PM.
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
    public class Fireball : Projectile
    {
        public Fireball(string path, Vector2 pos,Vector2 dim, Vector2 dir, Unit owner) : base(path, pos, dim, dir, owner)
        {
            //model = new Model2D(path, pos, new Vector2(32, 32));
            speed = 2f;
            lifeTime = 3f;
        }

        public override void Update(Vector2 offset)
        {
            base.Update(offset);
        }

        public override void Draw()
        {
            base.Draw();
        }

    }
}
