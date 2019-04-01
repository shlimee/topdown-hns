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
    public class Model2D
    {

        public enum Layer
        {
            BACKGROUND,
            MIDDLE,
            FRONT,
            PROJECTILE
        }
        
        public Model2D(string path, Vector2 pos, Vector2 dims, Layer layer = Layer.MIDDLE, float layerDepth = 0)
        {
            Position = pos;
            Rotation = 0;
            Dimensions = dims;
            this.Texture = Globals.Content.Load<Texture2D>(path);
            Layering = layer;
            LayerDepth = layerDepth;
        }

        public Vector2 Position;
        public float Rotation;
        public Vector2 Dimensions;
        public Texture2D Texture;
        public Layer Layering;
        public float LayerDepth;

        public virtual void Update(Vector2 offset)
        {

        }

        public virtual void Draw()
        {
            if(Texture != null)
            {
                Globals.SpriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, (int)Dimensions.X, (int)Dimensions.Y), null, Color.White, Rotation, new Vector2(Texture.Bounds.Width / 2, Texture.Bounds.Height / 2), SpriteEffects.None, 0);
            }
        }
    }
}
