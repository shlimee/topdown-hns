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

        public Enemy(string path, Vector2 pos, Vector2 dims, World w) : base(path, pos, dims, w)
        {
            
        }

    }
}
