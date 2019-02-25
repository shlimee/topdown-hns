#region Including necessary namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace MOBA
{
    public class World
    {
        public World()
        {

            Initialize();
            hero = new Hero(new Vector2(100, 100), "textures/karakter", this);
            enemy = new Enemy(new Vector2(100, 100), "textures/enemy", this);
            
            units.Add(hero);
            units.Add(enemy);
        }

        public List<Unit> units;
        public List<Projectile> projectiles;

        Unit hero;
        Unit enemy;

        public void Initialize()
        {
            units = new List<Unit>();
            projectiles = new List<Projectile>();
            GameGlobals.PassProjectile = AddProjectile;
        }

        public void Update()
        {
            if (units != null)
            { 
                if (units.Count > 0)
                {
                    foreach (var u in units)
                    {
                        u.Update();
                    }
                }
            }

            if (projectiles != null)
            {
                if (projectiles.Count > 0)
                {
                    foreach (var p in projectiles)
                    {
                        p.Update();
                    }
                }
            }

        }

        public void Draw()
        {
            if (units != null)
            {
                if (units.Count > 0)
                {
                    foreach (var u in units)
                    {
                        u.Draw();
                    }
                }
            }

            if (projectiles != null)
            {
                if (projectiles.Count > 0)
                {
                    foreach (var p in projectiles)
                    {
                        p.Draw();
                    }
                }
            }

        }

        public void AddProjectile(object INFO)
        {
            projectiles.Add((Projectile)INFO);
        }
    }
}
