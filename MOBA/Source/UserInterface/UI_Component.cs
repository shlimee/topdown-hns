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
    public abstract class UI_Component
    {

        public UI_Component()
        {

        }

        public Vector2 position;


        public virtual void Update()
        {

        }

        public virtual void Draw()
        {

        }
    }
}
