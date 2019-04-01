/*
	Created by zsolc
	on 2/25/2019 8:24:43 PM.
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
    public class Tools
    {
        public static void RotateTowards(Vector2 pos, Vector2 towards, ref float rot)
        {
            Vector2 dirToRotate = Vector2.Normalize(pos - towards);
            float angle = (float)Math.Atan2(dirToRotate.X, dirToRotate.Y * -1f);
            rot = (float)(angle + (Math.PI * 1f));

        }

    }
}
