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
    public class Text2D : UI_Component
    {
        public Text2D(string text) : base()
        {
            font = Globals.Content.Load<SpriteFont>(@"fonts/arial");
            this.text = text;
            
        }

        public SpriteFont font;
        public string text;

        public override void Update()
        {
            //base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            Globals.SpriteBatch.DrawString(font, text, new Vector2(0, 0), Color.Black);
        }
    }
}
