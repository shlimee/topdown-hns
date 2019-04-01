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
            hero = new Hero("textures/templar_png", Vector2.Zero, new Vector2(16, 16), this);
            enemy = new Enemy("textures/templar_png", Vector2.Zero, new Vector2(16, 16),  this);
            
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
                        u.Update(GameGlobals.MainCamera.Position);
                    }
                }
            }

            if (projectiles != null)
            {
                if (projectiles.Count > 0)
                {
                    foreach (var p in projectiles)
                    {
                        p.Update(GameGlobals.MainCamera.Position);
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
