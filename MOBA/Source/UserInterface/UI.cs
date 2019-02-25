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
    public class UI
    {
        public UI()
        {
            components = new List<UI_Component>();
            fps = new Text2D("0fps");
            components.Add(fps);
        }

        public List<UI_Component> components;
        public Text2D fps;

        public void Update()
        {
            foreach(var c in components)
            {
                c.Update();
            }
        }

        public void Draw()
        {
            foreach (var c in components)
            {
                c.Draw();
            }
        }

    }
}
