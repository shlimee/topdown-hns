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
    public delegate void PassObject(object INFO);
    public delegate object PassObjectReturn(object INFO);

    public static class Globals
    {

        //  TODO: put these into a separate class, so it's easier to create settings templates
        //  something like an Options abstract class, then create custom def. settings for different
        //  resolutions/hardvers.
        public static uint      WINDOW_WIDTH  = 1280;
        public static uint      WINDOW_HEIGHT = 1024;
        public static string    WINDOW_TITLE  = "Burrow Deeper";
        public static bool      WINDOW_VSYNC  = false;

        public static SpriteBatch SpriteBatch;
        public static ContentManager Content;
        public static GraphicsDeviceManager Graphics;
        public static UI UserInterface;

        
    }
}
